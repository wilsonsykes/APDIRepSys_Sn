using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace APDIRepSys.Admin
{
    public sealed class ImagePathValidatorForm : Form
    {
        private const string ConnectionString = "Host=192.168.2.166;Database=apdireports;Username=postgres;Password=postgres";

        private readonly BindingSource issuesSource = new BindingSource();
        private readonly DataGridView issuesGrid = new DataGridView();
        private readonly Button scanButton = new Button();
        private readonly Button fixButton = new Button();
        private readonly Button closeButton = new Button();
        private readonly Label statusLabel = new Label();

        public ImagePathValidatorForm()
        {
            Text = "Image Path Validator (Admin)";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1180, 640);
            MinimumSize = new Size(1000, 520);

            BuildLayout();
            Shown += async (_, __) => await ScanAsync();
        }

        private void BuildLayout()
        {
            var headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 56
            };

            scanButton.Text = "Scan";
            scanButton.Width = 110;
            scanButton.Height = 34;
            scanButton.Left = 12;
            scanButton.Top = 11;
            scanButton.Click += async (_, __) => await ScanAsync();

            fixButton.Text = "Auto-Fix";
            fixButton.Width = 110;
            fixButton.Height = 34;
            fixButton.Left = 132;
            fixButton.Top = 11;
            fixButton.Click += async (_, __) => await FixAsync();

            closeButton.Text = "Close";
            closeButton.Width = 110;
            closeButton.Height = 34;
            closeButton.Left = 252;
            closeButton.Top = 11;
            closeButton.Click += (_, __) => Close();

            statusLabel.AutoSize = false;
            statusLabel.Left = 374;
            statusLabel.Top = 16;
            statusLabel.Width = 780;
            statusLabel.Height = 24;
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            statusLabel.Text = "Ready";

            headerPanel.Controls.Add(scanButton);
            headerPanel.Controls.Add(fixButton);
            headerPanel.Controls.Add(closeButton);
            headerPanel.Controls.Add(statusLabel);

            issuesGrid.Dock = DockStyle.Fill;
            issuesGrid.ReadOnly = true;
            issuesGrid.AutoGenerateColumns = true;
            issuesGrid.AllowUserToAddRows = false;
            issuesGrid.AllowUserToDeleteRows = false;
            issuesGrid.AllowUserToResizeRows = false;
            issuesGrid.RowHeadersVisible = false;
            issuesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            issuesGrid.DataSource = issuesSource;

            Controls.Add(issuesGrid);
            Controls.Add(headerPanel);
        }

        private async Task ScanAsync()
        {
            SetBusy(true, "Scanning image paths...");

            try
            {
                List<ImagePathIssue> issues = await Task.Run(LoadIssues);
                issuesSource.DataSource = issues;
                statusLabel.Text = $"Invalid image paths found: {issues.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image path scan failed: " + ex.Message, "Validator Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Scan failed.";
            }
            finally
            {
                SetBusy(false);
            }
        }

        private async Task FixAsync()
        {
            if (!(issuesSource.DataSource is List<ImagePathIssue> issues) || issues.Count == 0)
            {
                MessageBox.Show("No invalid paths to fix.", "Validator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ImagePathIssue> fixable = issues
                .Where(i => i.HasSuggestion)
                .ToList();

            if (fixable.Count == 0)
            {
                MessageBox.Show("No auto-fix suggestions are available for the current list.", "Validator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                $"Apply auto-fix for {fixable.Count} item(s)?",
                "Confirm Auto-Fix",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            SetBusy(true, "Applying path fixes...");

            try
            {
                int updatedRows = await Task.Run(() => ApplyFixes(fixable));
                statusLabel.Text = $"Updated rows: {updatedRows}. Rescanning...";
                await ScanAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to apply fixes: " + ex.Message, "Validator Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Auto-fix failed.";
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void SetBusy(bool busy, string? message = null)
        {
            UseWaitCursor = busy;
            scanButton.Enabled = !busy;
            fixButton.Enabled = !busy;
            closeButton.Enabled = !busy;

            if (!string.IsNullOrWhiteSpace(message))
            {
                statusLabel.Text = message;
            }
        }

        private static List<ImagePathIssue> LoadIssues()
        {
            var issues = new List<ImagePathIssue>();
            var fileLookup = BuildFileLookup();

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                const string systemQuery = @"
SELECT id, sellthru_no, product, image
FROM system_sellthru_summary
WHERE image IS NOT NULL AND btrim(image) <> '';";

                using (var cmd = new NpgsqlCommand(systemQuery, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string originalPath = reader["image"]?.ToString() ?? string.Empty;
                        string suggestedPath = SuggestPath(originalPath, fileLookup);

                        if (!PathExists(originalPath) && !string.IsNullOrWhiteSpace(originalPath))
                        {
                            issues.Add(new ImagePathIssue
                            {
                                SourceTable = "system_sellthru_summary",
                                SourceId = reader["id"]?.ToString() ?? string.Empty,
                                StockOrName = reader["product"]?.ToString() ?? string.Empty,
                                GroupRef = reader["sellthru_no"]?.ToString() ?? string.Empty,
                                OriginalPath = originalPath,
                                SuggestedPath = suggestedPath,
                                Exists = false
                            });
                        }
                    }
                }

                const string productQuery = @"
SELECT name, path
FROM product_images
WHERE path IS NOT NULL AND btrim(path) <> '';";

                using (var cmd = new NpgsqlCommand(productQuery, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string originalPath = reader["path"]?.ToString() ?? string.Empty;
                        string suggestedPath = SuggestPath(originalPath, fileLookup);

                        if (!PathExists(originalPath) && !string.IsNullOrWhiteSpace(originalPath))
                        {
                            issues.Add(new ImagePathIssue
                            {
                                SourceTable = "product_images",
                                SourceId = string.Empty,
                                StockOrName = reader["name"]?.ToString() ?? string.Empty,
                                GroupRef = string.Empty,
                                OriginalPath = originalPath,
                                SuggestedPath = suggestedPath,
                                Exists = false
                            });
                        }
                    }
                }
            }

            return issues
                .OrderBy(i => i.SourceTable)
                .ThenBy(i => i.StockOrName)
                .ToList();
        }

        private static int ApplyFixes(List<ImagePathIssue> fixableIssues)
        {
            int updated = 0;

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    foreach (ImagePathIssue issue in fixableIssues)
                    {
                        if (!issue.HasSuggestion)
                        {
                            continue;
                        }

                        if (issue.SourceTable == "system_sellthru_summary" && int.TryParse(issue.SourceId, out int id))
                        {
                            const string updateSystem = @"
UPDATE system_sellthru_summary
SET image = @newPath
WHERE id = @id AND image = @oldPath;";

                            using (var cmd = new NpgsqlCommand(updateSystem, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@newPath", issue.SuggestedPath);
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.Parameters.AddWithValue("@oldPath", issue.OriginalPath);
                                updated += cmd.ExecuteNonQuery();
                            }
                        }
                        else if (issue.SourceTable == "product_images")
                        {
                            const string updateProduct = @"
UPDATE product_images
SET path = @newPath
WHERE name = @name AND path = @oldPath;";

                            using (var cmd = new NpgsqlCommand(updateProduct, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@newPath", issue.SuggestedPath);
                                cmd.Parameters.AddWithValue("@name", issue.StockOrName);
                                cmd.Parameters.AddWithValue("@oldPath", issue.OriginalPath);
                                updated += cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    tx.Commit();
                }
            }

            return updated;
        }

        private static bool PathExists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            try
            {
                return File.Exists(path.Trim());
            }
            catch
            {
                return false;
            }
        }

        private static string SuggestPath(string originalPath, Dictionary<string, string> fileLookup)
        {
            if (string.IsNullOrWhiteSpace(originalPath))
            {
                return string.Empty;
            }

            string normalized = NormalizePath(originalPath);
            foreach (string candidate in BuildCandidates(normalized, fileLookup))
            {
                if (PathExists(candidate))
                {
                    return candidate;
                }
            }

            return string.Empty;
        }

        private static string NormalizePath(string path)
        {
            string normalized = path.Trim().Trim('"', '\'');
            normalized = Environment.ExpandEnvironmentVariables(normalized);
            normalized = normalized.Replace('/', '\\');

            while (normalized.Contains("\\\\"))
            {
                normalized = normalized.Replace("\\\\", "\\");
            }

            if (normalized.StartsWith("\\") && !normalized.StartsWith("\\\\"))
            {
                normalized = "\\" + normalized;
            }

            return normalized;
        }

        private static IEnumerable<string> BuildCandidates(string normalizedPath, Dictionary<string, string> fileLookup)
        {
            var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            if (!string.IsNullOrWhiteSpace(normalizedPath) && visited.Add(normalizedPath))
            {
                yield return normalizedPath;
            }

            string folderFixed = Regex.Replace(
                normalizedPath,
                @"(?<=\\)([A-Za-z])\(([^\\]+)\)",
                "$1 ($2)");
            if (!string.IsNullOrWhiteSpace(folderFixed) && visited.Add(folderFixed))
            {
                yield return folderFixed;
            }

            string fileName = Path.GetFileName(normalizedPath);
            if (!string.IsNullOrWhiteSpace(fileName) && fileLookup.TryGetValue(fileName, out string? mappedPath) && !string.IsNullOrWhiteSpace(mappedPath))
            {
                if (visited.Add(mappedPath))
                {
                    yield return mappedPath;
                }
            }
        }

        private static Dictionary<string, string> BuildFileLookup()
        {
            var roots = new[]
            {
                @"\\mpc2\Users\Public\Merchandise Pictures\NEW",
                @"\\mpc2\Users\Public\Merchandise Pictures"
            };

            var lookup = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (string root in roots)
            {
                if (!Directory.Exists(root))
                {
                    continue;
                }

                IEnumerable<string> files;
                try
                {
                    files = Directory.EnumerateFiles(root, "*.*", SearchOption.AllDirectories);
                }
                catch
                {
                    continue;
                }

                foreach (string filePath in files)
                {
                    string fileName = Path.GetFileName(filePath);
                    if (!lookup.ContainsKey(fileName))
                    {
                        lookup[fileName] = filePath;
                    }
                }
            }

            return lookup;
        }

        private sealed class ImagePathIssue
        {
            public string SourceTable { get; set; } = string.Empty;
            public string SourceId { get; set; } = string.Empty;
            public string GroupRef { get; set; } = string.Empty;
            public string StockOrName { get; set; } = string.Empty;
            public string OriginalPath { get; set; } = string.Empty;
            public string SuggestedPath { get; set; } = string.Empty;
            public bool Exists { get; set; }

            public bool HasSuggestion => !string.IsNullOrWhiteSpace(SuggestedPath);
        }
    }
}
