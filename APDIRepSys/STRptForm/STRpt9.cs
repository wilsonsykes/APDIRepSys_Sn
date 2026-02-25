using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics; // ✅ Required for Process.Start (executing MyRep.exe)
using MyRep;
using System.Xml;
using Npgsql;

namespace APDIRepSys.STRptForm
{
    public partial class STRpt9 : Form
    {
        private bool isFormLoaded = false;  // ✅ Prevents unwanted event triggers during form initialization
        private int selectedPONo = 0; // ✅ Stores the selected year globally
        private int selectedSupplier = 0; // ✅ Stores the selected supplier code globally
        private bool isComboBox2FirstSelection = true; // ✅ Prevents unwanted event triggers during form initialization
        // 📦 Holds the original (unfiltered) item lists for each ComboBox involved in fuzzy search.
        // Key   = the ComboBox control itself
        // Value = the list of original strings (e.g., PO numbers, supplier codes, etc.)
        private Dictionary<ComboBox, List<string>> comboBoxSourceMap = new();
        // 🎯 Stores the ComboBox currently being typed into (used by the filtering logic)
        private ComboBox activeComboBox = null;

        // ⏲️ Timer to debounce filtering — waits a short delay before applying fuzzy search after typing
        private System.Windows.Forms.Timer fuzzyFilterTimer;

        // 📝 The latest typed text (converted to lowercase) used for filtering
        private string lastSearchText = "";
        public STRpt9()
        {
            InitializeComponent();
            // ✅ Attach event to handle selection changes in ComboBox
            toolStripComboBox1.ComboBox.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
        }

        private void STRpt9_Load(object sender, EventArgs e)
        {
            dataGridView1.Dock = DockStyle.Fill;

            try
            {
                // ✅ Load all data into the dataset
                this.sThruReport9TableAdapter1.Fill(this.dataSet9.SThruReport9);
                dataGridView1.DataSource = this.dataSet9.SThruReport9; // ✅ Start with full dataset


                //Apply Number Format with Commas for Readability
                dataGridView1.Columns["current_invty_amt9mos"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["current_invty_amt9mos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["unit_price"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["unit_price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["mosrevenueDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["mosrevenueDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["mosinvtyamountDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["mosinvtyamountDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["mossalerateDataGridViewTextBoxColumn1"].DefaultCellStyle.Format = "P0";
                dataGridView1.Columns["mossalerateDataGridViewTextBoxColumn1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["mossalerateDataGridViewTextBoxColumn2"].DefaultCellStyle.Format = "P0";
                dataGridView1.Columns["mossalerateDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["mossalerateDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "P0";

                System.Data.DataView dv = new System.Data.DataView(this.dataSet9.SThruReport9);

                // ✅ Extract distinct values & manually add them to the ComboBox
                System.Data.DataTable distinctPONo = dv.ToTable(true, "po_date");
                System.Data.DataTable distinctSupplier = dv.ToTable(true, "supplier_code");
                System.Data.DataTable distinctCategory = dv.ToTable(true, "category_code");

                isFormLoaded = false; // ✅ Disable event triggers during setup

                // ✅ Clear ComboBoxes before adding items
                toolStripComboBox1.ComboBox.Items.Clear();
                toolStripComboBox2.ComboBox.Items.Clear();
                toolStripComboBox3.ComboBox.Items.Clear();

                // ✅ Manually add items instead of setting DataSource
                foreach (DataRow row in distinctPONo.Rows)
                {
                    toolStripComboBox1.ComboBox.Items.Add(row["po_date"].ToString());
                }

                foreach (DataRow row in distinctSupplier.Rows)
                {
                    toolStripComboBox2.ComboBox.Items.Add(row["supplier_code"].ToString());
                }

                foreach (DataRow row in distinctCategory.Rows)
                {
                    toolStripComboBox3.ComboBox.Items.Add(row["category_code"].ToString());
                }

                // ✅ Set ComboBoxes to default empty selection
                toolStripComboBox1.ComboBox.SelectedIndex = -1;
                toolStripComboBox2.ComboBox.SelectedIndex = -1;
                toolStripComboBox3.ComboBox.SelectedIndex = -1;

                // ✅ Initially enable all ComboBoxes so filtering can start from any
                toolStripComboBox1.Enabled = true;
                toolStripComboBox2.Enabled = true;
                toolStripComboBox3.Enabled = true;

                isFormLoaded = true; // ✅ Re-enable event triggers
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data! " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Setup ComboBox1 (PO Reference)
            toolStripComboBox1.ComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            toolStripComboBox1.ComboBox.AutoCompleteMode = AutoCompleteMode.None;
            toolStripComboBox1.ComboBox.TextChanged += ComboBox_TextChanged;
            comboBoxSourceMap[toolStripComboBox1.ComboBox] = toolStripComboBox1.ComboBox.Items.Cast<string>().Distinct().ToList();

            // Setup ComboBox2 (Supplier)
            toolStripComboBox2.ComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            toolStripComboBox2.ComboBox.AutoCompleteMode = AutoCompleteMode.None;
            toolStripComboBox2.ComboBox.TextChanged += ComboBox_TextChanged;
            comboBoxSourceMap[toolStripComboBox2.ComboBox] = toolStripComboBox2.ComboBox.Items.Cast<string>().Distinct().ToList();

            // Setup ComboBox3 (Category)
            toolStripComboBox3.ComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            toolStripComboBox3.ComboBox.AutoCompleteMode = AutoCompleteMode.None;
            toolStripComboBox3.ComboBox.TextChanged += ComboBox_TextChanged;
            comboBoxSourceMap[toolStripComboBox3.ComboBox] = toolStripComboBox3.ComboBox.Items.Cast<string>().Distinct().ToList();

            // Prepare item lists per ComboBox
            // (Store them based on ComboBox name or tag if needed)
        }

        private void ApplyFilters()
        {
            if (!isFormLoaded) return;

            try
            {
                System.Data.DataView dv = new System.Data.DataView(this.dataSet9.SThruReport9);
                List<string> filters = new List<string>();

                // ✅ If PO Date is selected, add it to the filter
                if (toolStripComboBox1.ComboBox.SelectedIndex != -1 && toolStripComboBox1.ComboBox.SelectedItem != null)
                {
                    string selectedPONo = toolStripComboBox1.ComboBox.SelectedItem.ToString().Trim();
                    filters.Add($"po_date = '{selectedPONo}'");
                }

                // ✅ If Supplier Code is selected, add it to the filter
                if (toolStripComboBox2.ComboBox.SelectedIndex != -1 && toolStripComboBox2.ComboBox.SelectedItem != null)
                {
                    string selectedSupplier = toolStripComboBox2.ComboBox.SelectedItem.ToString().Trim();
                    filters.Add($"supplier_code = '{selectedSupplier}'");
                }

                // ✅ If Category is selected, add it to the filter
                if (toolStripComboBox3.ComboBox.SelectedIndex != -1 && toolStripComboBox3.ComboBox.SelectedItem != null)
                {
                    string selectedCategory = toolStripComboBox3.ComboBox.SelectedItem.ToString().Trim();
                    filters.Add($"category_code = '{selectedCategory}'");
                }

                // ✅ Apply filters if any exist
                dv.RowFilter = string.Join(" AND ", filters);

                // ✅ Update DataGridView
                dataGridView1.DataSource = dv;

                // ✅ Update available filter options based on the **filtered dataset**
                UpdateComboBoxOptions(dv);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying filters! " + ex.Message, "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateComboBoxOptions(System.Data.DataView dv)
        {
            isFormLoaded = false; // ✅ Prevent accidental event triggers

            // ✅ Extract updated unique values from the **filtered dataset**
            System.Data.DataTable distinctPONo = dv.ToTable(true, "po_date");
            System.Data.DataTable distinctSupplier = dv.ToTable(true, "supplier_code");
            System.Data.DataTable distinctCategory = dv.ToTable(true, "category_code");

            // ✅ Preserve current selections (if still valid)
            string currentPONo = toolStripComboBox1.ComboBox.SelectedItem?.ToString();
            string currentSupplier = toolStripComboBox2.ComboBox.SelectedItem?.ToString();
            string currentCategory = toolStripComboBox3.ComboBox.SelectedItem?.ToString();

            // ✅ Refresh available options
            RefreshComboBox(toolStripComboBox1, distinctPONo, "po_date", currentPONo);
            RefreshComboBox(toolStripComboBox2, distinctSupplier, "supplier_code", currentSupplier);
            RefreshComboBox(toolStripComboBox3, distinctCategory, "category_code", currentCategory);

            isFormLoaded = true; // ✅ Re-enable event triggers
        }

        private void RefreshComboBox(ToolStripComboBox comboBox, System.Data.DataTable data, string column, string currentSelection)
        {
            comboBox.ComboBox.DataSource = null; // ✅ Reset DataSource before adding items
            comboBox.ComboBox.Items.Clear();

            foreach (DataRow row in data.Rows)
            {
                comboBox.ComboBox.Items.Add(row[column].ToString());
            }

            // ✅ Restore selection if still valid
            if (!string.IsNullOrEmpty(currentSelection) && comboBox.ComboBox.Items.Contains(currentSelection))
            {
                comboBox.ComboBox.SelectedItem = currentSelection;
            }
            else
            {
                comboBox.ComboBox.SelectedIndex = -1; // ✅ Clear selection if no longer valid
            }
        }




        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isFormLoaded) return;
            ApplyFilters(); // ✅ Apply filtering & update available selections
        }


        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isFormLoaded) return;
            ApplyFilters(); // ✅ Apply filtering & update available selections
        }


        private void toolStripComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isFormLoaded) return;
            ApplyFilters(); // ✅ Apply filtering & update available selections
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string reportFileName = "SellThruRpt2.rpt"; // ✅ Name of the Crystal Report file

                // ✅ Define the directory where the XML file will be saved
                string saveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "APDIRepSys", "Reports");
                Directory.CreateDirectory(saveDirectory); // ✅ Ensures directory exists

                string xmlFilePath = Path.Combine(saveDirectory, "sthrulist.xml"); // ✅ Path for XML output
                string reportFilePath = Path.Combine(saveDirectory, reportFileName); // ✅ Path for RPT file

                // ✅ Ensure an rr_no is selected before proceeding
                if (toolStripComboBox1.ComboBox.SelectedItem == null)
                {
                    MessageBox.Show("No PO No selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Retrieve selected rr_no as a string (no conversion needed)
                string selectedPONo = toolStripComboBox1.ComboBox.SelectedValue.ToString();

                // ✅ Filter dataset based on selected rr_no
                System.Data.DataView dv = new System.Data.DataView(this.dataSet9.SThruReport9);
                dv.RowFilter = $"po_date = '{selectedPONo}'"; // 🔹 Ensure string values are enclosed in single quotes

                // ✅ Check if the filter returned results
                if (dv.Count == 0)
                {
                    MessageBox.Show("No data found for the selected PO No!", "Filter Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Create a new dataset to store only the filtered data
                System.Data.DataSet filteredDataSet = new System.Data.DataSet("NewDataSet");
                System.Data.DataTable filteredTable = dv.ToTable();
                filteredTable.TableName = "SThruReport2"; // ✅ Ensure MyRep.exe expects this exact table name
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



        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data to save!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection("Host=192.168.2.152;Database=apdireports;Username=postgres;Password=d4s31n@"))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlTransaction transaction = conn.BeginTransaction()) // ✅ Ensure atomicity
                    {
                        // ✅ Generate a SINGLE sellthru_no for this transaction
                        string sellthruNo;
                        using (NpgsqlCommand seqCmd = new NpgsqlCommand("SELECT 'ST' || LPAD(nextval('system_sellthru_summary_seq')::TEXT, 5, '0')", conn, transaction))
                        {
                            sellthruNo = (string)seqCmd.ExecuteScalar(); // 🔹 Get sequence number
                        }

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue; // 🔹 Skip empty placeholder row

                            // ✅ Determine if report_period should be "6 months"
                            //string reportPeriod = row.Cells["scheduled9mosDataGridViewTextBoxColumn"].Value == DBNull.Value ? null : "6 months";

                            // Get product name from the DataGridView row

                            string productName = row.Cells["productDataGridViewTextBoxColumn"].Value?.ToString() ?? "";

                            string imagePath = null;

                            using (NpgsqlCommand imgCmd = new NpgsqlCommand("SELECT path FROM product_images WHERE name = @productName LIMIT 1", conn, transaction))
                            {
                                imgCmd.Parameters.AddWithValue("@productName", productName);
                                object result = imgCmd.ExecuteScalar(); // ✅ Get image path from database

                                if (result != DBNull.Value && result != null)
                                {
                                    imagePath = result.ToString(); // ✅ Store image path if found
                                }
                                else
                                {
                                    MessageBox.Show($"No image path found for product: {productName}", "Image Not Found! Please add the Image at MPC2 Merchandise Pictures Folder.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }


                            string insertQuery = "INSERT INTO system_sellthru_summary " +
                                "(sellthru_no, rr_date, po_reference, rr_no, supplier_code, product, description, beg_invty, current_invty, current_invty_amount, " +
                                "category_code, product_status, current_price, store_group, mos3_item_sold, " +
                                " mos6_item_sold,  mos9_item_sold, mos3_sale_rate, mos6_sale_rate, mos9_sale_rate, mos9_revenue, mos9_invty_amount, mos9_closing_invty, order_qty, image) " +
                                "VALUES (@sellthru_no, @rr_date, @po_reference, @rr_no, @supplier_code, @product, @description, @beg_invty, @current_invty, @current_invty_amount, " +
                                "@category_code, @product_status, @current_price, @store_group, @mos3_item_sold, " +
                                "@mos6_item_sold, @mos9_item_sold, @mos3_sale_rate, @mos6_sale_rate, @mos9_sale_rate, @mos9_revenue, @mos9_invty_amount, @mos9_closing_invty, @order_qty, @image)";

                            using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@sellthru_no", sellthruNo);
                                cmd.Parameters.AddWithValue("@rr_date", row.Cells["rrdateDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDateTime(row.Cells["rrdateDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@po_reference", row.Cells["podateDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["podateDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@rr_no", row.Cells["rrnoDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["rrnoDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@supplier_code", row.Cells["suppliercodeDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["suppliercodeDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@product", row.Cells["productDataGridViewTextBoxColumn"].Value?.ToString() ?? "");
                                cmd.Parameters.AddWithValue("@description", row.Cells["descriptionDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["descriptionDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@beg_invty", row.Cells["beginvtyDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToInt32(row.Cells["beginvtyDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@current_invty", row.Cells["current_invty_9mos"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToInt32(row.Cells["current_invty_9mos"].Value));
                                cmd.Parameters.AddWithValue("@current_invty_amount", row.Cells["current_invty_amt9mos"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["current_invty_amt9mos"].Value));
                                cmd.Parameters.AddWithValue("@category_code", row.Cells["categorycodeDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["categorycodeDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@product_status", row.Cells["productstatusDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["productstatusDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@current_price", row.Cells["unit_price"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["unit_price"].Value));
                                cmd.Parameters.AddWithValue("@store_group", row.Cells["storegroupDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["storegroupDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@mos3_item_sold", row.Cells["mositemsoldDataGridViewTextBoxColumn1"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToInt32(row.Cells["mositemsoldDataGridViewTextBoxColumn1"].Value));
                                cmd.Parameters.AddWithValue("@mos6_item_sold", row.Cells["mositemsoldDataGridViewTextBoxColumn2"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToInt32(row.Cells["mositemsoldDataGridViewTextBoxColumn2"].Value));
                                cmd.Parameters.AddWithValue("@mos9_item_sold", row.Cells["mositemsoldDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToInt32(row.Cells["mositemsoldDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@mos3_sale_rate", row.Cells["mossalerateDataGridViewTextBoxColumn1"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["mossalerateDataGridViewTextBoxColumn1"].Value));
                                cmd.Parameters.AddWithValue("@mos6_sale_rate", row.Cells["mossalerateDataGridViewTextBoxColumn2"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["mossalerateDataGridViewTextBoxColumn2"].Value));
                                cmd.Parameters.AddWithValue("@mos9_sale_rate", row.Cells["mossalerateDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["mossalerateDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@mos9_revenue", row.Cells["mosrevenueDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["mosrevenueDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@mos9_invty_amount", row.Cells["mosinvtyamountDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["mosinvtyamountDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@mos9_closing_invty", row.Cells["closeinvtyDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToInt32(row.Cells["closeinvtyDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@order_qty", row.Cells["orderqtyDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToInt32(row.Cells["orderqtyDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@image", imagePath ?? (object)DBNull.Value);

                                // ✅ Ensure correct handling of "report_period"
                                //cmd.Parameters.AddWithValue("@report_period", reportPeriod ?? (object)DBNull.Value);

                                // ✅ New parameter for report_period
                                //cmd.Parameters.AddWithValue("@report_period", string.IsNullOrEmpty(reportPeriod) ? (object)DBNull.Value : reportPeriod);

                                cmd.ExecuteNonQuery(); // ✅ Save record to system_sellthru_summary
                            }
                        }
                        transaction.Commit(); // ✅ Save all changes permanently
                        MessageBox.Show($"Data successfully saved!\nGenerated SellThru No: {sellthruNo}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving data! " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ResetFilters()
        {
            isFormLoaded = false; // ✅ Prevent unnecessary filtering during reset

            // ✅ Reset DataGridView to show all data
            dataGridView1.DataSource = this.dataSet9.SThruReport9;

            // ✅ Extract all distinct values from the FULL dataset
            System.Data.DataView dv = new System.Data.DataView(this.dataSet9.SThruReport9);
            System.Data.DataTable distinctPONo = dv.ToTable(true, "po_date");
            System.Data.DataTable distinctSupplier = dv.ToTable(true, "supplier_code");
            System.Data.DataTable distinctCategory = dv.ToTable(true, "category_code");

            // ✅ Reset ComboBoxes and repopulate with full data
            RefreshComboBox(toolStripComboBox1, distinctPONo, "po_date", null);
            RefreshComboBox(toolStripComboBox2, distinctSupplier, "supplier_code", null);
            RefreshComboBox(toolStripComboBox3, distinctCategory, "category_code", null);

            // ✅ Enable all ComboBoxes
            toolStripComboBox1.Enabled = true;
            toolStripComboBox2.Enabled = true;
            toolStripComboBox3.Enabled = true;

            isFormLoaded = true; // ✅ Re-enable event triggers
        }



        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ResetFilters(); // ✅ Reset all selections and show all data


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
            // 🔁 Stop the timer to prevent multiple overlapping ticks
            fuzzyFilterTimer.Stop();

            // ❌ If there's no active ComboBox or its original list is not in the map, do nothing
            if (activeComboBox == null || !comboBoxSourceMap.ContainsKey(activeComboBox)) return;

            // 🔍 Filter the original list based on the last typed text (case-insensitive)
            var filteredList = comboBoxSourceMap[activeComboBox]
                .Where(item => item.ToLower().Contains(lastSearchText))
                .ToList();

            // 🎯 Preserve cursor position in the input field
            int selectionStart = activeComboBox.SelectionStart;

            // 🛑 Temporarily unhook TextChanged to avoid recursive triggers
            activeComboBox.TextChanged -= ComboBox_TextChanged;

            // 📝 Save current input text
            string currentText = activeComboBox.Text;

            // 🧹 Clear and repopulate the ComboBox with the filtered list
            activeComboBox.Items.Clear();
            foreach (string item in filteredList)
                activeComboBox.Items.Add(item);

            // 👇 Force the dropdown to stay open after filtering
            activeComboBox.DroppedDown = true;

            // ⏳ Fix for flickering/cursor jump issue
            Cursor.Current = Cursors.Default;

            // ✏️ Restore cursor to its original position after update
            activeComboBox.SelectionStart = selectionStart;
            activeComboBox.SelectionLength = 0;

            // ✅ Restore the text (required after clearing items)
            activeComboBox.Text = currentText;

            // 🔁 Reattach TextChanged handler
            activeComboBox.TextChanged += ComboBox_TextChanged;
        }
    }
}






