using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics; // ✅ Required for Process.Start (executing MyRep.exe)
using MyRep;
using System.Xml;
using Npgsql;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace APDIRepSys.RFMDForm
{
    public partial class RfmdRecSummary : Form
    {

        private bool isFormLoaded = false;
        private int selectedSTNo = 0;
        public RfmdRecSummary()
        {
            InitializeComponent();
            toolStripComboBox1.ComboBox.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
        }

        private void RfmdRecSummary_Load(object sender, EventArgs e)
        {
            try
            {
                // ✅ Load all data from the database into the dataset
                this.rfmdRecSummaryTableAdapter1.Fill(this.DataSet15.RfmdRecSummary);

                // ✅ Extract distinct RFMD numbers for filtering before modifying the grid
                System.Data.DataView dv = new System.Data.DataView(this.DataSet15.RfmdRecSummary);
                System.Data.DataTable distinctRFMDNo = dv.ToTable(true, "rfmd_no"); // ✅ Ensures uniqueness

                // ✅ Bind extracted RFMD numbers to the ToolStripComboBox
                toolStripComboBox1.ComboBox.DataSource = distinctRFMDNo;
                toolStripComboBox1.ComboBox.DisplayMember = "rfmd_no";  // ✅ What the user sees
                toolStripComboBox1.ComboBox.ValueMember = "rfmd_no";    // ✅ What is stored internally

                // ✅ Optional: Apply formatting to numeric columns
                // dataGridView1.Columns["currentinvtyamountDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "N2";
                // dataGridView1.Columns["currentinvtyamountDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // ✅ Replace blank decimal cells with 0 before XML export or use
                FillBlankDecimalCellsWithZero(dataGridView1);

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
                // ✅ Name of the Crystal Report file
                string reportFileName = "RfmdPrint.rpt";

                // ✅ Define the directory where the XML file will be saved
                string saveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "APDIRepSys", "Reports");
                Directory.CreateDirectory(saveDirectory); // ✅ Ensure directory exists

                string xmlFilePath = Path.Combine(saveDirectory, "rfmd.xml");      // ✅ Path for XML output
                string reportFilePath = Path.Combine(saveDirectory, reportFileName); // ✅ Path for RPT file

                // ✅ Ensure a selection was made before proceeding
                if (toolStripComboBox1.ComboBox.SelectedItem == null)
                {
                    MessageBox.Show("No RFMD No selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Retrieve selected RFMD No
                string selectedRFMDNo = toolStripComboBox1.ComboBox.SelectedValue.ToString();

                // ✅ Filter dataset based on selected rfmd_no
                System.Data.DataView dv = new System.Data.DataView(this.DataSet15.RfmdRecSummary);
                dv.RowFilter = $"rfmd_no = '{selectedRFMDNo}'"; // 🔹 Use single quotes for string filters

                // ✅ Check if the filter returned results
                if (dv.Count == 0)
                {
                    MessageBox.Show("No data found for the selected sellthru no!", "Filter Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Create a new dataset to store only the filtered data
                System.Data.DataSet filteredDataSet = new System.Data.DataSet("NewDataSet");

                // ✅ Clone schema from original table to retain column structure
                System.Data.DataTable filteredTable = this.DataSet15.RfmdRecSummary.Clone();

                // ✅ Import filtered rows
                foreach (DataRow row in dv.ToTable().Rows)
                {
                    filteredTable.ImportRow(row);
                }

                // ✅ Set proper table name expected by Crystal Report
                filteredTable.TableName = "RfmdRecSummary";
                filteredDataSet.Tables.Add(filteredTable);

                // ✅ Save the filtered data to XML with schema
                XmlWriterSettings settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = false };
                using (XmlWriter writer = XmlWriter.Create(xmlFilePath, settings))
                {
                    filteredDataSet.WriteXml(writer, XmlWriteMode.WriteSchema);
                }

                reportFilePath = ReportLaunchHelper.ResolveReportArgument(reportFilePath, reportFileName);

                // ✅ Launch MyRep.exe and pass XML and RPT paths
                string myRepPath = Path.Combine(Application.StartupPath, "MyRep.exe");

                if (File.Exists(myRepPath))
                {
                    Process.Start(myRepPath, $"\"{reportFilePath}\" \"{xmlFilePath}\"");
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

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                // ✅ Name of the Crystal Report file
                string reportFileName = "RfmdMemo.rpt";

                // ✅ Define the directory where the XML file will be saved
                string saveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "APDIRepSys", "Reports");
                Directory.CreateDirectory(saveDirectory); // ✅ Ensure directory exists

                string xmlFilePath = Path.Combine(saveDirectory, "rfmd.xml");      // ✅ Path for XML output
                string reportFilePath = Path.Combine(saveDirectory, reportFileName); // ✅ Path for RPT file

                // ✅ Ensure a selection was made before proceeding
                if (toolStripComboBox1.ComboBox.SelectedItem == null)
                {
                    MessageBox.Show("No RFMD No selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Retrieve selected RFMD No
                string selectedRFMDNo = toolStripComboBox1.ComboBox.SelectedValue.ToString();

                // ✅ Filter dataset based on selected rfmd_no
                System.Data.DataView dv = new System.Data.DataView(this.DataSet15.RfmdRecSummary);
                dv.RowFilter = $"rfmd_no = '{selectedRFMDNo}'"; // 🔹 Use single quotes for string filters

                // ✅ Check if the filter returned results
                if (dv.Count == 0)
                {
                    MessageBox.Show("No data found for the selected sellthru no!", "Filter Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Create a new dataset to store only the filtered data
                System.Data.DataSet filteredDataSet = new System.Data.DataSet("NewDataSet");

                // ✅ Clone schema from original table to retain column structure
                System.Data.DataTable filteredTable = this.DataSet15.RfmdRecSummary.Clone();

                // ✅ Import filtered rows
                foreach (DataRow row in dv.ToTable().Rows)
                {
                    filteredTable.ImportRow(row);
                }


                // ✅ Set proper table name expected by Crystal Report
                filteredTable.TableName = "RfmdRecSummary";
                filteredDataSet.Tables.Add(filteredTable);


                // ✅ Create new DataTable for memo field values
                DataTable memoTable = new DataTable("RfmdMemo");

                // ✅ Add columns for each form field
                memoTable.Columns.Add("memo_no", typeof(string));
                memoTable.Columns.Add("memo_to", typeof(string));
                memoTable.Columns.Add("memo_cc", typeof(string));
                memoTable.Columns.Add("memo_re", typeof(string));
                memoTable.Columns.Add("memo_prepared_by", typeof(string));
                memoTable.Columns.Add("memo_date", typeof(DateTime));
                memoTable.Columns.Add("memo_effective_date", typeof(DateTime));
                memoTable.Columns.Add("memo_body", typeof(string));

                // ✅ Add a single row using current form field values
                memoTable.Rows.Add(
                    textBoxMemoNo.Text,
                    textBoxTo.Text,
                    textBoxCc.Text,
                    textBoxRe.Text,
                    textBoxPreparedBy.Text,
                    dateTimePickerDate.Value,
                    dateTimePickerEffectiveDate.Value,
                    textBoxContent.Text
                );

                // ✅ Add to dataset
                filteredDataSet.Tables.Add(memoTable);

                // ✅ Save the filtered data to XML with schema
                XmlWriterSettings settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = false };
                using (XmlWriter writer = XmlWriter.Create(xmlFilePath, settings))
                {
                    filteredDataSet.WriteXml(writer, XmlWriteMode.WriteSchema);
                }

                reportFilePath = ReportLaunchHelper.ResolveReportArgument(reportFilePath, reportFileName);

                // ✅ Launch MyRep.exe and pass XML and RPT paths
                string myRepPath = Path.Combine(Application.StartupPath, "MyRep.exe");

                if (File.Exists(myRepPath))
                {
                    Process.Start(myRepPath, $"\"{reportFilePath}\" \"{xmlFilePath}\"");
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
                        // ✅ Retrieve selected sellthru_no as a string
                        string selectedRfmdNo = toolStripComboBox1.ComboBox.SelectedValue.ToString();

                        // ✅ Filter dataset based on selected sellthru_no
                        System.Data.DataView dv = new System.Data.DataView(this.DataSet15.RfmdRecSummary);
                        dv.RowFilter = $"rfmd_no = '{selectedRfmdNo}'"; // 🔹 Ensure string values are enclosed in single quotes



                        // ✅ Update DataGridView to show only filtered data
                        dataGridView1.DataSource = dv.ToTable(); // Convert DataView back to DataTable

                        // ✅ Debugging messages to confirm filtering works
                        // MessageBox.Show("Filtered by Sell-Thru No: " + selectedSTNo);
                        // MessageBox.Show("Rows after filtering: " + dv.Count);

                        // 🔄 Load memo fields if available for the selected RFMD
                        try
                        {
                            using (var conn = new NpgsqlConnection("Host=192.168.2.152;Port=5432;Username=postgres;Password=d4s31n@;Database=apdireports"))
                            {
                                conn.Open();

                                string memoQuery = @"
                                SELECT memo_no, memo_to, memo_cc, memo_re, memo_prepared_by, 
                                       memo_date, memo_effective_date, memo_body
                                FROM rfmd_list_summary
                                WHERE rfmd_no = @rfmd_no
                                LIMIT 1;
                            ";

                                using (var cmd = new NpgsqlCommand(memoQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@rfmd_no", selectedRfmdNo);

                                    using (var reader = cmd.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            textBoxMemoNo.Text = reader["memo_no"]?.ToString();
                                            textBoxTo.Text = reader["memo_to"]?.ToString();
                                            textBoxCc.Text = reader["memo_cc"]?.ToString();
                                            textBoxRe.Text = reader["memo_re"]?.ToString();
                                            textBoxPreparedBy.Text = reader["memo_prepared_by"]?.ToString();
                                            dateTimePickerDate.Value = reader["memo_date"] != DBNull.Value
                                                ? Convert.ToDateTime(reader["memo_date"])
                                                : DateTime.Now;
                                            dateTimePickerEffectiveDate.Value = reader["memo_effective_date"] != DBNull.Value
                                                ? Convert.ToDateTime(reader["memo_effective_date"])
                                                : DateTime.Now;
                                            textBoxContent.Text = reader["memo_body"]?.ToString();
                                        }
                                        else
                                        {
                                            ClearMemoFields(); // Optional: reset fields
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to load memo data: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error filtering and converting data! " + ex.Message, "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No RFMD No selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearMemoFields()
        {
            textBoxMemoNo.Clear();
            textBoxTo.Clear();
            textBoxCc.Clear();
            textBoxRe.Clear();
            textBoxPreparedBy.Clear();
            dateTimePickerDate.Value = DateTime.Now;
            dateTimePickerEffectiveDate.Value = DateTime.Now;
            textBoxContent.Clear();
        }

        private void buttonClearMemo_Click(object sender, EventArgs e)
        {
            ClearMemoFields();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void mainLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FillBlankDecimalCellsWithZero(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        // Optional: add column check to only apply to specific decimal columns
                        if (cell.OwningColumn.ValueType == typeof(decimal))
                        {
                            cell.Value = 0m;
                        }
                    }
                }
            }
        }

        

        private void buttonSaveMemo_Click(object sender, EventArgs e)
        {
           //placeholder
        }



        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            //placeholder
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            //placeholder
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //placeholder
        }

        private void SaveMemoToDatabase()
        {
            try
            {
                string connString = "Host=192.168.2.152;Port=5432;Username=postgres;Password=d4s31n@;Database=apdireports"; // Use your actual connection string

                string rfmdNo = toolStripComboBox1.Text.Trim();
                string memoNo = textBoxMemoNo.Text.Trim();
                string memoTo = textBoxTo.Text.Trim();
                string memoCc = textBoxCc.Text.Trim();
                string memoFrom = textBoxFrom.Text.Trim();
                string memoRe = textBoxRe.Text.Trim();
                string preparedBy = textBoxPreparedBy.Text.Trim();
                DateTime memoDate = dateTimePickerDate.Value;
                DateTime effectiveDate = dateTimePickerEffectiveDate.Value;
                string memoBody = textBoxContent.Text.Trim();

                string updateQuery = @"
            UPDATE public.rfmd_list_summary
            SET 
                memo_no = @memo_no,
                memo_to = @memo_to,
                memo_cc = @memo_cc,
                memo_re = @memo_re,
                memo_prepared_by = @prepared_by,
                memo_date = @memo_date,
                memo_effective_date = @effective_date,
                memo_body = @memo_body
            WHERE rfmd_no = @rfmd_no;
        ";

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@memo_no", memoNo);
                        cmd.Parameters.AddWithValue("@memo_to", memoTo);
                        cmd.Parameters.AddWithValue("@memo_cc", memoCc);
                        cmd.Parameters.AddWithValue("@memo_re", memoRe);
                        cmd.Parameters.AddWithValue("@prepared_by", preparedBy);
                        cmd.Parameters.AddWithValue("@memo_date", memoDate);
                        cmd.Parameters.AddWithValue("@effective_date", effectiveDate);
                        cmd.Parameters.AddWithValue("@memo_body", memoBody);
                        cmd.Parameters.AddWithValue("@rfmd_no", rfmdNo);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        MessageBox.Show($"{rowsAffected} record(s) updated successfully.", "Memo Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving memo data: " + ex.Message, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadFilteredRfmdData(string rfmdNo)
        {
            try
            {
                string connString = "Host=192.168.2.152;Port=5432;Username=postgres;Password=d4s31n@;Database=apdireports"; // Replace with actual

                string query = @"SELECT * FROM public.rfmd_list_summary WHERE rfmd_no = @rfmd_no ORDER BY id;";

                using (var conn = new NpgsqlConnection(connString))
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@rfmd_no", rfmdNo);
                    var adapter = new NpgsqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load updated data: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ButtonSaveMemo_Click(object sender, EventArgs e)
        {
            SaveMemoToDatabase();
            LoadFilteredRfmdData(toolStripComboBox1.Text.Trim()); // Refresh after save
        }


    }



}
