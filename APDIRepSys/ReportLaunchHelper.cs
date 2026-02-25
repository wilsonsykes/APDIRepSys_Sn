using System.IO;
using System.Windows.Forms;

namespace APDIRepSys
{
    internal static class ReportLaunchHelper
    {
        internal static string ResolveReportArgument(string reportPathCandidate, string reportFileName)
        {
            if (!string.IsNullOrWhiteSpace(reportPathCandidate) && File.Exists(reportPathCandidate))
            {
                return reportPathCandidate;
            }

            if (!string.IsNullOrWhiteSpace(reportFileName) && Path.IsPathRooted(reportFileName) && File.Exists(reportFileName))
            {
                return reportFileName;
            }

            string fileName = Path.GetFileName(reportFileName);
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] candidates =
            {
                Path.Combine(Application.StartupPath, "DataFolder", "Reports", fileName),
                Path.Combine(Application.StartupPath, fileName)
            };

            foreach (string candidate in candidates)
            {
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }

            // Fall back to report file name. MyRep can still open embedded report resources.
            return fileName;
        }
    }
}
