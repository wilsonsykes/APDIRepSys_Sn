using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRep
{
    public partial class GmroiPrev1 : Form
    {
        private string rptFileName; // ✅ Stores the report filename dynamically
        public GmroiPrev1(string reportFileName)
        {
            InitializeComponent();
            this.rptFileName = reportFileName;

        }

        private void GmroiPrev1_Load(object sender, EventArgs e)
        {
            try
            {
                // ✅ Define the correct path for report and XML files
                string appDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "APDIRepSys", "Reports");

                // ✅ Full paths for report and XML files
                string reportPath = Path.Combine(appDataDirectory, rptFileName);
                string xmlPath = Path.Combine(appDataDirectory, "gmroisum1.xml");

                // ✅ Ensure the report file exists before loading
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show($"Error: Report file not found at:\n{reportPath}", "Missing Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
                string detectedTables = string.Join(", ", reportDataset.Tables.Cast<DataTable>().Select(t => t.TableName));
                //MessageBox.Show($"Tables Found in Dataset: {detectedTables}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Ensure that the expected `GmroiReport1` table exists in the dataset
                if (!reportDataset.Tables.Contains("GmroiRpt1"))
                {
                    MessageBox.Show("Error: `GmroiReport1` table not found in XML!", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ Extract the `GmroiReport1` table from the dataset
                DataTable reportTable = reportDataset.Tables["GmroiRpt1"];

                // ✅ Debugging: Display the number of rows loaded from XML
                //MessageBox.Show($"Rows Loaded from XML: {reportTable.Rows.Count}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ If no data exists in the XML, show an error message
                if (reportTable.Rows.Count == 0)
                {
                    MessageBox.Show("Error: No data available in `GmroiReport1` table!", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ Load the Crystal Report file
                this.reportDocument3.Load(reportPath);

                // ✅ Set the dataset as the data source for the report
                this.reportDocument3.SetDataSource(reportDataset);

                // ✅ Assign the report to the Crystal Report Viewer and refresh it
                this.crystalReportViewer1.ReportSource = this.reportDocument3;
                this.crystalReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                // ✅ Catch any unexpected errors and display them in a message box
                MessageBox.Show($"Error loading report:\n{ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportDocument3_InitReport(object sender, EventArgs e)
        {

        }
    }
}
