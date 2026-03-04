using System;
using Npgsql;

namespace APDIRepSys
{
    internal static class DatabaseConnectionHelper
    {
        private sealed class DbEndpoint
        {
            public DbEndpoint(string host, string username, string password)
            {
                Host = host;
                Username = username;
                Password = password;
            }

            public string Host { get; }
            public string Username { get; }
            public string Password { get; }
        }

        private static readonly DbEndpoint[] Endpoints =
        {
            // Primary endpoint (new host)
            new DbEndpoint("192.168.2.166", "postgres", "postgres"),
            // Legacy endpoint fallback while migration is in-progress
            new DbEndpoint("192.168.2.152", "postgres", "d4s31n@")
        };

        private static readonly object Sync = new object();
        private static readonly TimeSpan CacheWindow = TimeSpan.FromMinutes(5);

        private static DbEndpoint cachedEndpoint = Endpoints[0];
        private static DateTime lastProbeUtc = DateTime.MinValue;

        private const string DatabaseName = "apdireports";
        private const int Port = 5432;

        public static string GetNpgsqlConnectionString()
        {
            DbEndpoint endpoint = ResolveEndpoint();
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = endpoint.Host,
                Port = Port,
                Database = DatabaseName,
                Username = endpoint.Username,
                Password = endpoint.Password,
                SslMode = SslMode.Disable,
                Timeout = 5,
                CommandTimeout = 120
            };

            return builder.ConnectionString;
        }

        public static string GetOdbcConnectionString()
        {
            DbEndpoint endpoint = ResolveEndpoint();

            return
                $"Dsn=PostgreSQL35Wnew;database={DatabaseName};server={endpoint.Host};port={Port};uid={endpoint.Username};pwd={endpoint.Password};" +
                "sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;" +
                "fetch=100;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;usedeclarefetch=0;" +
                "textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;lfconversion=1;updatablecursors=1;" +
                "trueisminus1=0;bi=0;byteaaslongvarbinary=1;useserversideprepare=1;lowercaseidentifier=0;d6=-101;" +
                "optionalerrors=0;fetchrefcursors=0;xaopt=1";
        }

        private static DbEndpoint ResolveEndpoint()
        {
            lock (Sync)
            {
                if (DateTime.UtcNow - lastProbeUtc < CacheWindow)
                {
                    return cachedEndpoint;
                }
            }

            foreach (DbEndpoint endpoint in Endpoints)
            {
                if (CanConnect(endpoint))
                {
                    lock (Sync)
                    {
                        cachedEndpoint = endpoint;
                        lastProbeUtc = DateTime.UtcNow;
                    }

                    return endpoint;
                }
            }

            lock (Sync)
            {
                // Keep default primary endpoint when all probes fail.
                cachedEndpoint = Endpoints[0];
                lastProbeUtc = DateTime.UtcNow;
                return cachedEndpoint;
            }
        }

        private static bool CanConnect(DbEndpoint endpoint)
        {
            try
            {
                var builder = new NpgsqlConnectionStringBuilder
                {
                    Host = endpoint.Host,
                    Port = Port,
                    Database = DatabaseName,
                    Username = endpoint.Username,
                    Password = endpoint.Password,
                    SslMode = SslMode.Disable,
                    Timeout = 3,
                    CommandTimeout = 5,
                    Pooling = false
                };

                using (var conn = new NpgsqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT 1", conn))
                    {
                        cmd.CommandTimeout = 5;
                        cmd.ExecuteScalar();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
