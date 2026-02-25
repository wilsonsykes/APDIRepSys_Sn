using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MyRep
{
    public partial class STRptPrev : Form
    {
        private string rptFileName; // ✅ Stores the report filename dynamically

        // ✅ Constructor receives the report filename as a parameter
        public STRptPrev(string reportFileName)
        {
            InitializeComponent();
            this.rptFileName = reportFileName;
        }

        private void STRptPrev_Load(object sender, EventArgs e)
        {
            try
            {
                // ✅ Define the correct path for report and XML files
                string appDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "APDIRepSys", "Reports");

                // ✅ Full paths for report and XML files
                string reportPath = Path.Combine(appDataDirectory, rptFileName);
                string xmlPath = Path.Combine(appDataDirectory, "sthrulist.xml");

                // ✅ Ensure the XML data file exists before loading
                if (!File.Exists(xmlPath))
                {
                    MessageBox.Show($"Error: Data file not found at:\n{xmlPath}", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ Load dataset from XML
                System.Data.DataSet reportDataset = new System.Data.DataSet();
                reportDataset.ReadXml(xmlPath, XmlReadMode.InferSchema); // Loads XML while inferring schema

                // ✅ Debugging: Check detected tables inside dataset
                //string detectedTables = string.Join(", ", reportDataset.Tables.Cast<DataTable>().Select(t => t.TableName));
                //MessageBox.Show($"Tables Found in Dataset: {detectedTables}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Ensure that the expected `SThruReport` table exists in the dataset
                if (!reportDataset.Tables.Contains("SThruReport2"))
                {
                    MessageBox.Show("Error: `SThruReport2` table not found in XML!", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ Extract the `SThruReport` table from the dataset
                DataTable reportTable = reportDataset.Tables["SThruReport2"];

                // ✅ Debugging: Display the number of rows loaded from XML
                //MessageBox.Show($"Rows Loaded from XML: {reportTable.Rows.Count}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ If no data exists in the XML, show an error message
                if (reportTable.Rows.Count == 0)
                {
                    MessageBox.Show("Error: No data available in `SThruReport2` table!", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Try to load an external report file when present.
                // If none is found, Crystal uses the embedded report resource.
                ReportRuntimeHelper.TryLoadReport(this.reportDocument2, reportPath);

                // ✅ Resolve image paths before binding data to Crystal Report.
                ReportRuntimeHelper.NormalizeImagePaths(reportDataset);

                // ✅ Set the dataset as the data source for the report
                this.reportDocument2.SetDataSource(reportDataset);

                // ✅ Assign the report to the Crystal Report Viewer and refresh it
                this.crystalReportViewer1.ReportSource = this.reportDocument2;
                this.crystalReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                // ✅ Catch any unexpected errors and display them in a message box
                MessageBox.Show($"Error loading report:\n{ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Event triggered when the Crystal Report Viewer loads
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            // 🔹 Placeholder event: No additional logic is needed at this moment
        }

        // ✅ Event triggered when the report document initializes
        private void reportDocument1_InitReport(object sender, EventArgs e)
        {
            // 🔹 Placeholder event: No additional logic is needed at this moment
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
    
}
