using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CrystalDecisions.CrystalReports.Engine;

namespace MyRep
{
    internal static class ReportRuntimeHelper
    {
        private static readonly string[] KnownImageFolderNames =
        {
            "MPC2 Merchandise Pictures",
            "Merchandise Pictures"
        };

        private static readonly Lazy<string[]> ImageSearchRoots = new Lazy<string[]>(BuildImageSearchRoots);

        private static string GetReportsDirectory()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "APDIRepSys",
                "Reports");
        }

        internal static string ResolveReportPath(string reportInput)
        {
            if (string.IsNullOrWhiteSpace(reportInput))
            {
                return null;
            }

            string fileName = Path.GetFileName(reportInput);
            string appDataReports = GetReportsDirectory();

            string[] candidates =
            {
                reportInput,
                Path.Combine(appDataReports, reportInput),
                Path.Combine(appDataReports, fileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFolder", "Reports", fileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)
            };

            foreach (string candidate in candidates)
            {
                if (!string.IsNullOrWhiteSpace(candidate) && File.Exists(candidate))
                {
                    return candidate;
                }
            }

            return null;
        }

        private static string[] BuildImageSearchRoots()
        {
            var roots = new List<string>();

            AddDirectoryIfExists(roots, GetReportsDirectory());
            AddDirectoryIfExists(roots, AppDomain.CurrentDomain.BaseDirectory);
            AddDirectoryIfExists(roots, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFolder", "Reports"));

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                bool isReady;
                try
                {
                    isReady = drive.IsReady;
                }
                catch
                {
                    continue;
                }

                if (!isReady)
                {
                    continue;
                }

                foreach (string folderName in KnownImageFolderNames)
                {
                    AddDirectoryIfExists(roots, Path.Combine(drive.RootDirectory.FullName, folderName));
                }
            }

            return roots
                .Where(path => !string.IsNullOrWhiteSpace(path))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();
        }

        private static void AddDirectoryIfExists(List<string> roots, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }

            if (Directory.Exists(path))
            {
                roots.Add(path);
            }
        }

        private static bool IsImageColumn(string columnName)
        {
            return !string.IsNullOrWhiteSpace(columnName) &&
                   columnName.IndexOf("image", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static string NormalizeStoredPath(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            string normalized = input.Trim().Trim('"', '\'');
            normalized = Environment.ExpandEnvironmentVariables(normalized);

            Uri uri;
            if (Uri.TryCreate(normalized, UriKind.Absolute, out uri))
            {
                if (uri.IsFile)
                {
                    normalized = uri.LocalPath;
                }
                else
                {
                    return normalized;
                }
            }

            normalized = normalized.Replace('/', Path.DirectorySeparatorChar);

            while (normalized.Contains("\\\\"))
            {
                normalized = normalized.Replace("\\\\", "\\");
            }

            if (normalized.Length > 2 && normalized.StartsWith("\\") && normalized[1] != '\\')
            {
                normalized = "\\" + normalized;
            }

            return normalized;
        }

        private static string ResolveImagePath(string imageValue)
        {
            string normalized = NormalizeStoredPath(imageValue);
            if (string.IsNullOrWhiteSpace(normalized))
            {
                return imageValue;
            }

            string[] pathVariants = BuildPathVariants(normalized);

            foreach (string variant in pathVariants)
            {
                if (Path.IsPathRooted(variant) && File.Exists(variant))
                {
                    return Path.GetFullPath(variant);
                }
            }

            string fileName = Path.GetFileName(normalized);

            foreach (string root in ImageSearchRoots.Value)
            {
                foreach (string variant in pathVariants)
                {
                    string candidateFromRelative = Path.Combine(root, variant.TrimStart('\\'));
                    if (File.Exists(candidateFromRelative))
                    {
                        return candidateFromRelative;
                    }
                }

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    string candidateFromFile = Path.Combine(root, fileName);
                    if (File.Exists(candidateFromFile))
                    {
                        return candidateFromFile;
                    }
                }
            }

            return normalized;
        }

        private static string[] BuildPathVariants(string normalizedPath)
        {
            var variants = new List<string>();

            void add(string candidate)
            {
                if (!string.IsNullOrWhiteSpace(candidate) &&
                    !variants.Contains(candidate, StringComparer.OrdinalIgnoreCase))
                {
                    variants.Add(candidate);
                }
            }

            add(normalizedPath);

            // Fix common bad category folder naming, e.g. "M(Mirror)" -> "M (Mirror)".
            string withSpacedCategory = Regex.Replace(
                normalizedPath,
                @"(?<=\\)([A-Za-z])\(([^\\]+)\)",
                "$1 ($2)");
            add(withSpacedCategory);

            return variants.ToArray();
        }

        internal static void NormalizeImagePaths(System.Data.DataSet reportDataset)
        {
            if (reportDataset == null || reportDataset.Tables.Count == 0)
            {
                return;
            }

            var cache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (DataTable table in reportDataset.Tables)
            {
                foreach (DataColumn column in table.Columns)
                {
                    if (column.DataType != typeof(string) || !IsImageColumn(column.ColumnName))
                    {
                        continue;
                    }

                    foreach (DataRow row in table.Rows)
                    {
                        if (row[column] == DBNull.Value)
                        {
                            continue;
                        }

                        string rawPath = Convert.ToString(row[column]);
                        if (string.IsNullOrWhiteSpace(rawPath))
                        {
                            continue;
                        }

                        string resolvedPath;
                        if (!cache.TryGetValue(rawPath, out resolvedPath))
                        {
                            resolvedPath = ResolveImagePath(rawPath);
                            cache[rawPath] = resolvedPath;
                        }

                        row[column] = resolvedPath;
                    }
                }
            }
        }

        internal static void TryLoadReport(ReportDocument report, string reportInput)
        {
            string resolvedPath = ResolveReportPath(reportInput);
            if (!string.IsNullOrWhiteSpace(resolvedPath))
            {
                report.Load(resolvedPath);
            }
        }
    }
}
