using System;
using System.Linq;
using System.Windows.Forms;
using MyRep.DataFolder.Reports;

namespace MyRep
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ✅ Check if arguments were passed
            if (args.Length > 0)
            {
                string reportFile = args[0];  // 🔹 Get the report file from arguments

                // ✅ Debugging: Show the received argument
                //MessageBox.Show($"Received argument: {reportFile}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form reportForm = null;

                // ✅ Check if the correct form is selected
                if (reportFile.Contains("SellThroughRpt"))
                {
                    reportForm = new ReportPreview(reportFile);
                }
                else if (reportFile.Contains("SysSellThruRpt2"))
                {
                    reportForm = new SysSTRptPrev(reportFile);
                }
                else if (reportFile.Contains("SysSellThruRpt3"))
                {
                    reportForm = new SysSTRptPrev3(reportFile);
                }
                else if (reportFile.Contains("SysSellThruRpt6"))
                {
                    reportForm = new SysSTRptPrev6(reportFile);
                }
                else if (reportFile.Contains("SysSellThruRpt9"))
                {
                    reportForm = new SysSTRptPrev9(reportFile);
                }
                else if (reportFile.Contains("SellThruRpt2"))
                {
                    reportForm = new STRptPrev(reportFile);
                }
                else if (reportFile.Contains("SellThruRpt9"))
                {
                    reportForm = new SysSTRptPrev9(reportFile);
                }
                else if (reportFile.Contains("GmroiRpt1"))
                {
                    reportForm = new GmroiPrev1(reportFile);
                }
                else if (reportFile.Contains("RfmdPrint"))
                {
                    reportForm = new RfmdFormPrev(reportFile);
                }
                else if (reportFile.Contains("RfmdMemo"))
                {
                    reportForm = new RfmdMemoPrev(reportFile);
                }
                else
                {
                    MessageBox.Show($"Error: Unknown report file!\nReceived: {reportFile}", "Startup Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                // ✅ Debugging: Show which form is selected
                //MessageBox.Show($"Opening Form: {reportForm.GetType().Name}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.Run(reportForm);
            }
            else
            {
                MessageBox.Show("Error: No report file specified!", "Startup Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

    }
}
