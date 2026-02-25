using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics; // ✅ Required for Process.Start (executing MyRep.exe)
using MyRep;
using System.Xml;

namespace APDIRepSys.STRptForm
{
    public partial class Sellthrough : Form
    {
        private bool isFormLoaded = false;  // ✅ Prevents unwanted event triggers during form initialization
        private int selectedYear = 0; // ✅ Stores the selected year globally

        public Sellthrough()
        {
            InitializeComponent();

            // ✅ Attach event to handle selection changes in ComboBox
            toolStripComboBox1.ComboBox.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
        }

        private void Sellthrough_Load(object sender, EventArgs e)
        {
            // ✅ Make DataGridView fill the entire form
            dataGridView1.Dock = DockStyle.Fill;

            try
            {
                // ✅ Load all data from the database into the dataset
                this.sThruReportTableAdapter1.Fill(this.dataSet1.SThruReport);

                // ✅ Extract distinct years from the dataset for ComboBox filtering
                System.Data.DataView dv = new System.Data.DataView(this.dataSet1.SThruReport);
                System.Data.DataTable distinctYears = dv.ToTable(true, "year"); // ✅ Ensures uniqueness

                // ✅ Bind extracted years to the ToolStripComboBox
                toolStripComboBox1.ComboBox.DataSource = distinctYears;
                toolStripComboBox1.ComboBox.DisplayMember = "year";  // ✅ What the user sees
                toolStripComboBox1.ComboBox.ValueMember = "year";    // ✅ What is stored internally

                // ✅ Mark that the form has loaded to avoid unnecessary event triggers
                isFormLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data! " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string reportFileName = "SellThroughRpt.rpt"; // ✅ Name of the Crystal Report file

                // ✅ Define the directory where the XML file will be saved
                string saveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "APDIRepSys", "Reports");
                Directory.CreateDirectory(saveDirectory); // ✅ Ensures directory exists

                string xmlFilePath = Path.Combine(saveDirectory, "help.xml"); // ✅ Path for XML output
                string reportFilePath = Path.Combine(saveDirectory, reportFileName); // ✅ Path for RPT file

                // ✅ Ensure a year is selected before proceeding
                if (toolStripComboBox1.ComboBox.SelectedItem == null)
                {
                    MessageBox.Show("No year selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Convert selected year from ComboBox to integer
                int selectedYear = Convert.ToInt32(toolStripComboBox1.ComboBox.SelectedValue);

                // ✅ Filter dataset based on selected year
                System.Data.DataView dv = new System.Data.DataView(this.dataSet1.SThruReport);
                dv.RowFilter = $"year = {selectedYear}";

                // ✅ Check if the filter returned results
                if (dv.Count == 0)
                {
                    MessageBox.Show("No data found for the selected year!", "Filter Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Create a new dataset to store only the filtered data
                System.Data.DataSet filteredDataSet = new System.Data.DataSet("NewDataSet");
                System.Data.DataTable filteredTable = dv.ToTable();
                filteredTable.TableName = "SThruReport"; // ✅ Ensure MyRep.exe expects this exact table name
                filteredDataSet.Tables.Add(filteredTable);

                // ✅ Save the filtered data to an XML file
                XmlWriterSettings settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = false };
                using (XmlWriter writer = XmlWriter.Create(xmlFilePath, settings))
                {
                    filteredDataSet.WriteXml(writer, XmlWriteMode.WriteSchema);
                }

                //MessageBox.Show("Filtered XML saved successfully.", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Debugging: Ensure XML contains expected data
                //MessageBox.Show($"XML Rows Saved: {filteredTable.Rows.Count}");

                reportFilePath = ReportLaunchHelper.ResolveReportArgument(reportFilePath, reportFileName);

                // ✅ Execute MyRep.exe with the correct XML and report file
                string myRepPath = Path.Combine(Application.StartupPath, "MyRep.exe");

                if (File.Exists(myRepPath))
                {
                    Process.Start(myRepPath, $"\"{reportFilePath}\" \"{xmlFilePath}\""); // ✅ Pass both file paths as arguments
                }
                else
                {
                    MessageBox.Show("Error! MyRep.exe not found.", "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving file or executing MyRep.exe: " + ex.Message, "File/Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ✅ Prevent execution during form initialization
            if (!isFormLoaded) return;

            if (toolStripComboBox1.ComboBox.SelectedItem != null)
            {
                try
                {
                    // ✅ Get the selected row from ComboBox
                    DataRowView selectedRow = toolStripComboBox1.ComboBox.SelectedItem as DataRowView;

                    if (selectedRow != null)
                    {
                        selectedYear = Convert.ToInt32(selectedRow["year"]); // ✅ Assign to class-level variable

                        // ✅ Filter the dataset based on selected year
                        System.Data.DataView dv = new System.Data.DataView(this.dataSet1.SThruReport);
                        dv.RowFilter = $"year = {selectedYear}";

                        // ✅ Update DataGridView to show only filtered data
                        dataGridView1.DataSource = dv;

                        // ✅ Debugging messages to confirm filtering works
                        //MessageBox.Show("Filtered by Year: " + selectedYear);
                        //MessageBox.Show("Rows after filtering: " + dv.Count);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error filtering data! " + ex.Message, "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No year selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ✅ Placeholder for DataGridView events if needed in future
        }
    }
}
