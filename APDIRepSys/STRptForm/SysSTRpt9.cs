using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics; // ✅ Required for Process.Start (executing MyRep.exe)
using MyRep;
using System.Xml;
using Npgsql;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace APDIRepSys.STRptForm
{
    public partial class SysSTRpt9 : Form
    {
        private bool isFormLoaded = false;
        private int selectedSTNo = 0;
        private bool isComboBox2FirstSelection = true; // ✅ Prevents unwanted event triggers during form initialization
        private Dictionary<ComboBox, List<string>> comboBoxSourceMap = new();
        private ComboBox activeComboBox = null;
        private System.Windows.Forms.Timer fuzzyFilterTimer;
        private string lastSearchText = "";
        private DataTable originalComboSourceTable;
        public SysSTRpt9()
        {
            InitializeComponent();
            toolStripComboBox1.ComboBox.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;

        }

        private void SysSTRpt9_Load(object sender, EventArgs e)
        {
            // ✅ Make DataGridView fill the entire form
            dataGridView1.Dock = DockStyle.Fill;

            try
            {
                // ✅ Load all data from the database into the dataset
                this.syssThruReport9TableAdapter1.Fill(this.dataSet11.SysSThruReport9);

                //Apply Format for DataGrid View
                dataGridView1.Columns["currentinvtyamountDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["currentinvtyamountDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["currentpriceDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["currentpriceDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["nextscheddateDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "MM/dd/yyyy";
                dataGridView1.Columns["nextscheddateDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["mos3salerateDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "P0";
                dataGridView1.Columns["mos3salerateDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["mos6salerateDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "P0";
                dataGridView1.Columns["mos6salerateDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["mos9salerateDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "P0";
                dataGridView1.Columns["mos9salerateDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["mos9revenueDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["mos9revenueDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["mos9invtyamountDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["mos9invtyamountDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["orderamountDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["orderamountDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                // ✅ Extract distinct years from the dataset for ComboBox filtering
                FillBlankDecimalCellsWithZero(dataGridView1); // 👈 Use your actual DataGridView name


                DataView dv = new DataView(this.dataSet11.SysSThruReport9);
                DataTable distinctSTNo = dv.ToTable(true, "sellthru_no");

                originalComboSourceTable = distinctSTNo.Copy();

                // ✅ Bind sellthru_no list to the ComboBox
                toolStripComboBox1.ComboBox.DataSource = distinctSTNo;
                toolStripComboBox1.ComboBox.DisplayMember = "sellthru_no";
                toolStripComboBox1.ComboBox.ValueMember = "sellthru_no";
                toolStripComboBox1.ComboBox.SelectedIndex = -1;
                toolStripComboBox1.Enabled = true;

                // ✅ Backup original ComboBox values for fuzzy search
                comboBoxSourceMap[toolStripComboBox1.ComboBox] =
                    distinctSTNo.AsEnumerable()
                        .Select(row => row["sellthru_no"].ToString())
                        .Distinct()
                        .ToList();

                isFormLoaded = true; // ✅ Now safe to allow events
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data! " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // ✅ Setup fuzzy search behavior
            toolStripComboBox1.ComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            toolStripComboBox1.ComboBox.AutoCompleteMode = AutoCompleteMode.None;
            toolStripComboBox1.ComboBox.TextChanged += ComboBox_TextChanged;


        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data to update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection("Host=192.168.2.166;Database=apdireports;Username=postgres;Password=postgres"))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlTransaction transaction = conn.BeginTransaction())
                    {

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;

                            // 🔹 Fetch current values from the DataGridView
                            string sellthruNo = row.Cells["sellthrunoDataGridViewTextBoxColumn"].Value?.ToString();
                            string product = row.Cells["productDataGridViewTextBoxColumn"].Value?.ToString(); // ✅ Corrected to use the right column name

                            if (string.IsNullOrEmpty(sellthruNo) || string.IsNullOrEmpty(product))
                                continue;

                            string StoreGroupName = Convert.ToString(row.Cells["storegroupDataGridViewTextBoxColumn"].Value);
                            string updateQuery = @"
                        UPDATE system_sellthru_summary SET
                            store_group = @store_group
                        WHERE sellthru_no = @sellthru_no AND product = @product;
                    ";

                            using (NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@sellthru_no", sellthruNo);
                                cmd.Parameters.AddWithValue("@product", product); // ✅ Ensure the correct column is used
                                cmd.Parameters.AddWithValue("@store_group", StoreGroupName);
                                cmd.ExecuteNonQuery();
                            }

                            // 🔁 Update UI immediately
                            row.Cells["storegroupDataGridViewTextBoxColumn"].Value = StoreGroupName; // ✅ Ensure the correct column is updated

                            // 🔶 Highlight updated cells in current row ONLY
                            row.Cells["storegroupdataGridViewTextBoxColumn"].Style.BackColor = Color.Yellow; // ✅ Highlight the original column as well
                        }

                        transaction.Commit();
                        MessageBox.Show("Store Group Name updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving updates: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            try
            {
                string reportFileName = "SysSellThruRpt9.rpt"; // ✅ Name of the Crystal Report file

                // ✅ Define the directory where the XML file will be saved
                string saveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "APDIRepSys", "Reports");
                Directory.CreateDirectory(saveDirectory); // ✅ Ensures directory exists

                string xmlFilePath = Path.Combine(saveDirectory, "syssthrulist.xml"); // ✅ Path for XML output
                string reportFilePath = Path.Combine(saveDirectory, reportFileName); // ✅ Path for RPT file

                // ✅ Ensure an sellthru_no is selected before proceeding
                if (toolStripComboBox1.ComboBox.SelectedItem == null)
                {
                    MessageBox.Show("No ST No selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Retrieve selected sellthru_no as a string (no conversion needed)
                string selectedSTNo = toolStripComboBox1.ComboBox.Text.Trim();

                // ✅ Filter dataset based on selected rr_no
                System.Data.DataView dv = new System.Data.DataView(this.dataSet11.SysSThruReport9);
                dv.RowFilter = $"sellthru_no = '{selectedSTNo}'"; // 🔹 Ensure string values are enclosed in single quotes

                // ✅ Check if the filter returned results
                if (dv.Count == 0)
                {
                    MessageBox.Show("No data found for the selected sellthru no!", "Filter Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Create a new dataset to store only the filtered data
                System.Data.DataSet filteredDataSet = new System.Data.DataSet("NewDataSet");
                System.Data.DataTable filteredTable = dv.ToTable();

                // ✅ Ensure order_amount is present in the XML (even when blank)
                if (filteredTable.Columns.Contains("order_amount"))
                {
                    foreach (DataRow row in filteredTable.Rows)
                    {
                        if (row["order_amount"] == DBNull.Value || string.IsNullOrWhiteSpace(row["order_amount"].ToString()))
                        {
                            row["order_amount"] = DBNull.Value; // ✅ Keeps column type correct for decimal fields

                        }
                    }
                }



                filteredTable.TableName = "SysSThruReport9"; // ✅ Ensure MyRep.exe expects this exact table name
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
                        // ✅ Retrieve selected sellthru_no as a string
                        string selectedSTNo = toolStripComboBox1.ComboBox.SelectedValue.ToString();

                        // ✅ Filter dataset based on selected sellthru_no
                        System.Data.DataView dv = new System.Data.DataView(this.dataSet11.SysSThruReport9);
                        dv.RowFilter = $"sellthru_no = '{selectedSTNo}'"; // 🔹 Ensure string values are enclosed in single quotes

                        // ✅ Convert 'order_qty' and 'order_amount' to numeric types before loading
                        foreach (DataRowView rowView in dv)
                        {
                            DataRow row = rowView.Row;

                            if (row["order_qty"] != DBNull.Value)
                            {
                                row["order_qty"] = Convert.ToInt32(row["order_qty"]); // ✅ Convert to integer
                            }

                            if (row["order_amount"] != DBNull.Value)
                            {
                                row["order_amount"] = Convert.ToDecimal(row["order_amount"]); // ✅ Convert to decimal
                            }
                        }

                        // ✅ Update DataGridView to show only filtered data
                        dataGridView1.DataSource = dv.ToTable(); // Convert DataView back to DataTable

                        // ✅ Debugging messages to confirm filtering works
                        // MessageBox.Show("Filtered by Sell-Thru No: " + selectedSTNo);
                        // MessageBox.Show("Rows after filtering: " + dv.Count);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error filtering and converting data! " + ex.Message, "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No ST No selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void sys_sell_thru_bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            //Placeholder
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data to update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection("Host=192.168.2.166;Database=apdireports;Username=postgres;Password=postgres"))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlTransaction transaction = conn.BeginTransaction())
                    {
                        // 🔄 Reset background color for all cells before highlighting updated ones
                        foreach (DataGridViewRow r in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell c in r.Cells)
                            {
                                c.Style.BackColor = Color.White;
                            }
                        }

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;

                            // 🔹 Fetch current values from the DataGridView
                            string sellthruNo = row.Cells["sellthrunoDataGridViewTextBoxColumn"].Value?.ToString();
                            string product = row.Cells["productDataGridViewTextBoxColumn"].Value?.ToString();

                            if (string.IsNullOrEmpty(sellthruNo) || string.IsNullOrEmpty(product))
                                continue;

                            int currentInvty = row.Cells["currentinvtyDataGridViewTextBoxColumn"].Value == DBNull.Value
                                ? 0
                                : Convert.ToInt32(row.Cells["currentinvtyDataGridViewTextBoxColumn"].Value);

                            int orderQty = row.Cells["orderqtyDataGridViewTextBoxColumn"].Value == DBNull.Value
                                ? 0
                                : Convert.ToInt32(row.Cells["orderqtyDataGridViewTextBoxColumn"].Value);

                            decimal currentPrice = row.Cells["currentpriceDataGridViewTextBoxColumn"].Value == DBNull.Value
                                ? 0
                                : Convert.ToDecimal(row.Cells["currentpriceDataGridViewTextBoxColumn"].Value);
                            int mos3ItemSold = row.Cells["mos3itemsoldDataGridViewTextBoxColumn"].Value == DBNull.Value
                                ? 0
                                : Convert.ToInt32(row.Cells["mos3itemsoldDataGridViewTextBoxColumn"].Value);
                            int mos6ItemSold = row.Cells["mos6itemsoldDataGridViewTextBoxColumn"].Value == DBNull.Value
                                ? 0
                                : Convert.ToInt32(row.Cells["mos6itemsoldDataGridViewTextBoxColumn"].Value);

                            int mos9ItemSold = row.Cells["mos9itemsoldDataGridViewTextBoxColumn"].Value == DBNull.Value
                                ? 0
                                : Convert.ToInt32(row.Cells["mos9itemsoldDataGridViewTextBoxColumn"].Value);

                            // 🔢 Computed fields
                            decimal currentInvtyAmt = currentInvty * currentPrice;
                            decimal mos3SaleRate = currentInvty == 0 ? 0 : (decimal)mos3ItemSold / currentInvty;
                            decimal mos6SaleRate = currentInvty == 0 ? 0 : (decimal)mos6ItemSold / currentInvty;
                            decimal mos9SaleRate = currentInvty == 0 ? 0 : (decimal)mos9ItemSold / currentInvty;
                            int mos9ClosingInvty = currentInvty - mos9ItemSold;
                            decimal mos9InvtyAmt = mos9ClosingInvty * currentPrice;

                            string updateQuery = @"
                            UPDATE system_sellthru_summary SET
                                current_invty = @current_invty,
                                current_invty_amount = @current_invty_amount,
                                mos3_sale_rate = @mos3_sale_rate,
                                mos6_sale_rate = @mos6_sale_rate,
                                mos9_sale_rate = @mos9_sale_rate,
                                mos9_closing_invty = @mos9_closing_invty,
                                mos9_invty_amount = @mos9_invty_amount,
                                order_qty = @order_qty
                            WHERE sellthru_no = @sellthru_no AND product = @product;
                        ";

                            using (NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@current_invty", currentInvty);
                                cmd.Parameters.AddWithValue("@current_invty_amount", currentInvtyAmt);
                                cmd.Parameters.AddWithValue("@mos3_sale_rate", mos3SaleRate);
                                cmd.Parameters.AddWithValue("@mos6_sale_rate", mos6SaleRate);
                                cmd.Parameters.AddWithValue("@mos9_sale_rate", mos9SaleRate);
                                cmd.Parameters.AddWithValue("@mos9_closing_invty", mos9ClosingInvty);
                                cmd.Parameters.AddWithValue("@mos9_invty_amount", mos9InvtyAmt);
                                cmd.Parameters.AddWithValue("@order_qty", orderQty);
                                cmd.Parameters.AddWithValue("@sellthru_no", sellthruNo);
                                cmd.Parameters.AddWithValue("@product", product);

                                cmd.ExecuteNonQuery();
                            }

                            // 🔁 Update UI immediately
                            row.Cells["currentinvtyamountDataGridViewTextBoxColumn"].Value = currentInvtyAmt;
                            row.Cells["mos3SaleRateDataGridViewTextBoxColumn"].Value = mos3SaleRate;
                            row.Cells["mos6salerateDataGridViewTextBoxColumn"].Value = mos6SaleRate;
                            row.Cells["mos9salerateDataGridViewTextBoxColumn"].Value = mos9SaleRate;
                            row.Cells["mos9closinginvtyDataGridViewTextBoxColumn"].Value = mos9ClosingInvty;
                            row.Cells["mos9invtyamountDataGridViewTextBoxColumn"].Value = mos9InvtyAmt;

                            // 🔶 Highlight updated cells in current row ONLY
                            row.Cells["currentinvtyamountDataGridViewTextBoxColumn"].Style.BackColor = Color.Yellow;
                            row.Cells["mos3salerateDataGridViewTextBoxColumn"].Style.BackColor = Color.Yellow;
                            row.Cells["mos6salerateDataGridViewTextBoxColumn"].Style.BackColor = Color.Yellow;
                            row.Cells["mos9salerateDataGridViewTextBoxColumn"].Style.BackColor = Color.Yellow;
                            row.Cells["mos9invtyamountDataGridViewTextBoxColumn"].Style.BackColor = Color.Yellow;
                            row.Cells["mos9invtyamountDataGridViewTextBoxColumn"].Style.BackColor = Color.Yellow;
                        }

                        transaction.Commit();
                        MessageBox.Show("Updates successfully saved to database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving updates: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            // 🎯 Cast the sender to a ComboBox; ignore if it's not valid
            ComboBox combo = sender as ComboBox;
            if (combo == null) return;

            // 💾 Store which ComboBox triggered the event (used in timer logic)
            activeComboBox = combo;

            // 🔍 Store the current input text in lowercase for case-insensitive matching
            lastSearchText = combo.Text.ToLower();

            // 🚫 No need to fetch the item list here — it will be handled inside the timer tick

            // ⏲️ Initialize the timer only once
            if (fuzzyFilterTimer == null)
            {
                fuzzyFilterTimer = new System.Windows.Forms.Timer();
                fuzzyFilterTimer.Interval = 200; // milliseconds to wait before filtering
                fuzzyFilterTimer.Tick += FuzzyFilterTimer_Tick;
            }

            // 🛑 Stop any ongoing timer to debounce rapid keystrokes
            fuzzyFilterTimer.Stop();

            // ▶️ Start the timer — filtering will occur only after user pauses typing
            fuzzyFilterTimer.Start();
        }


        private void FuzzyFilterTimer_Tick(object sender, EventArgs e)
        {
            fuzzyFilterTimer.Stop();

            if (activeComboBox == null || !comboBoxSourceMap.ContainsKey(activeComboBox)) return;

            // 🔍 Filter the original list based on input text
            var filteredList = comboBoxSourceMap[activeComboBox]
                .Where(item => item.ToLower().Contains(lastSearchText))
                .ToList();

            int selectionStart = activeComboBox.SelectionStart;
            string currentText = activeComboBox.Text;

            activeComboBox.TextChanged -= ComboBox_TextChanged;

            // ✅ If input is empty, restore original DataTable
            if (string.IsNullOrWhiteSpace(currentText))
            {
                activeComboBox.DataSource = originalComboSourceTable;
                activeComboBox.DisplayMember = "sellthru_no";
                activeComboBox.ValueMember = "sellthru_no";
            }
            else
            {
                // 🧹 Unbind to allow manual item manipulation
                activeComboBox.DataSource = null;
                activeComboBox.Items.Clear();

                foreach (string item in filteredList)
                    activeComboBox.Items.Add(item);
            }

            activeComboBox.DroppedDown = true;
            Cursor.Current = Cursors.Default;
            activeComboBox.SelectionStart = selectionStart;
            activeComboBox.SelectionLength = 0;
            activeComboBox.Text = currentText;

            activeComboBox.TextChanged += ComboBox_TextChanged;

            // ✅ Always filter the DataGridView based on current text
            FilterDataGridViewBySellThru(currentText);
        }


        private void FilterDataGridViewBySellThru(string sellThruNo)
        {
            if (string.IsNullOrWhiteSpace(sellThruNo))
            {
                dataGridView1.DataSource = dataSet11.SysSThruReport9;
                return;
            }

            DataView dv = new DataView(dataSet11.SysSThruReport9);
            dv.RowFilter = $"sellthru_no LIKE '%{sellThruNo.Replace("'", "''")}%'";

            dataGridView1.DataSource = dv.ToTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
