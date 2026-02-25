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
    public partial class RfmdMemoPrev : Form
    {
        private string rptFileName; // ✅ Stores the report filename dynamically
        public RfmdMemoPrev(string reportFileName)
        {
            InitializeComponent();
            this.rptFileName = reportFileName;
        }

        private void RfmdMemoPrev_Load(object sender, EventArgs e)
        {
            try
            {
                string appDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "APDIRepSys", "Reports");

                string reportPath = Path.Combine(appDataDirectory, rptFileName);
                string xmlPath = Path.Combine(appDataDirectory, "rfmd.xml");
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
                // ✅ Ensure that the expected `RfmdRecSummary` table exists in the dataset
                if (!reportDataset.Tables.Contains("RfmdMemo"))
                {
                    MessageBox.Show("Error: `RfmdMemo` table not found in XML!", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // ✅ Extract the `RfmdMemo` table from the dataset
                DataTable reportTable = reportDataset.Tables["RfmdMemo"];

                // ✅ Debugging: Display the number of rows loaded from XML
                //MessageBox.Show($"Rows Loaded from XML: {reportTable.Rows.Count}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ If no data exists in the XML, show an error message
                if (reportTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found in the XML file.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                // Load external report when available; otherwise use embedded report
                ReportRuntimeHelper.TryLoadReport(this.rfmdMemo1, reportPath);




                // ✅ Resolve image paths before binding data to Crystal Report.
                ReportRuntimeHelper.NormalizeImagePaths(reportDataset);

                // ✅ Set the dataset as the data source for the report
                this.rfmdMemo1.SetDataSource(reportDataset);



                // ✅ Assign the report to the Crystal Report Viewer and refresh it
                this.crystalReportViewer1.ReportSource = this.rfmdMemo1;
                this.crystalReportViewer1.RefreshReport();


            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report:\n{ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}
