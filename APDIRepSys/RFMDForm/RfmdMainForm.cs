using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics; // ✅ Required for Process.Start (executing MyRep.exe)
using MyRep;
using System.Xml;
using Npgsql;


namespace APDIRepSys.RFMDForm
{
    public partial class RfmdMainForm : Form
    {
        private bool isFormLoaded = false;
        private int selectedPONo = 0;
        private bool isComboBox2FirstSelection = true;
        private Dictionary<ComboBox, List<string>> comboBoxSourceMap = new();
        private ComboBox activeComboBox = null;
        private System.Windows.Forms.Timer fuzzyFilterTimer;
        private string lastSearchText = "";

        public RfmdMainForm()
        {
            InitializeComponent();
            toolStripComboBox1.ComboBox.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;

        }

        private void RfmdMainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Dock = DockStyle.Fill;

            try
            {
                // Load data first
                this.rfmdMainFormTableAdapter1.Fill(this.DataSet13.RfmdMainForm);
                dataGridView1.DataSource = this.DataSet13.RfmdMainForm;

                // ✅ Hide the original auto-generated effectivity_date column
                if (dataGridView1.Columns.Contains("effectivitydateDataGridViewTextBoxColumn"))
                {
                    dataGridView1.Columns["effectivitydateDataGridViewTextBoxColumn"].Visible = false;
                }

                // ✅ Insert CalendarColumn only if not already added
                if (!dataGridView1.Columns.Contains("effectivity_date"))
                {
                    CalendarColumn calCol = new CalendarColumn
                    {
                        Name = "effectivity_date",
                        HeaderText = "Effectivity Date",
                        DataPropertyName = "effectivity_date",  // binds to the dataset field
                        DisplayIndex = dataGridView1.Columns["effectivitydateDataGridViewTextBoxColumn"].DisplayIndex
                    };

                    // Insert after hiding dummy to prevent placement error
                    dataGridView1.Columns.Add(calCol);
                }

                // Format other columns (as before)
                dataGridView1.Columns["rrdateDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "MM/dd/yyyy";
                dataGridView1.Columns["rrdateDataGridViewTextBoxColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // ... other formatting code ...
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data! " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void ApplyFilters()
        {
            if (!isFormLoaded) return;

            try
            {
                System.Data.DataView dv = new System.Data.DataView(this.DataSet13.RfmdMainForm);
                List<string> filters = new List<string>();

                // ✅ If PO Date is selected, add it to the filter
                if (toolStripComboBox1.ComboBox.SelectedIndex != -1 && toolStripComboBox1.ComboBox.SelectedItem != null)
                {
                    string selectedPONo = toolStripComboBox1.ComboBox.SelectedItem.ToString().Trim();
                    filters.Add($"po_date = '{selectedPONo}'");
                }

                // ✅ If Supplier Code is selected, add it to the filter
                // if (toolStripComboBox2.ComboBox.SelectedIndex != -1 && toolStripComboBox2.ComboBox.SelectedItem != null)
                // {
                //     string selectedSupplier = toolStripComboBox2.ComboBox.SelectedItem.ToString().Trim();
                //     filters.Add($"supplier_code = '{selectedSupplier}'");
                // }


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
            //System.Data.DataTable distinctSupplier = dv.ToTable(true, "supplier_code");


            // ✅ Preserve current selections (if still valid)
            string currentPONo = toolStripComboBox1.ComboBox.SelectedItem?.ToString();
            //string currentSupplier = toolStripComboBox2.ComboBox.SelectedItem?.ToString();


            // ✅ Refresh available options
            RefreshComboBox(toolStripComboBox1, distinctPONo, "po_date", currentPONo);
            // RefreshComboBox(toolStripComboBox2, distinctSupplier, "supplier_code", currentSupplier);


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


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data to save!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection("Host=192.168.2.166;Database=apdireports;Username=postgres;Password=postgres"))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlTransaction transaction = conn.BeginTransaction()) // ✅ Ensure atomicity
                    {
                        // ✅ Generate a SINGLE sellthru_no for this transaction
                        string rfmdNo;
                        using (NpgsqlCommand seqCmd = new NpgsqlCommand("SELECT '25-' || LPAD(nextval('rfmd_list_summary_id_seq')::TEXT, 5, '0')", conn, transaction))
                        {
                            rfmdNo = (string)seqCmd.ExecuteScalar(); // 🔹 Get sequence number
                        }

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue; // 🔹 Skip empty placeholder row

                            // ✅ Determine if report_period should be "2 months"
                            //string reportPeriod = row.Cells["scheduled3mosDataGridViewTextBoxColumn"].Value == DBNull.Value ? null : "2 months";

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



                            string insertQuery = "INSERT INTO rfmd_list_summary " +
                            "(rfmd_no, rr_date, po_no, rr_no, supplier_code, product, description, beg_invty, unit_price, category_code, product_status, " +
                            "store_group, current_invty, new_srp, md_one, md_two, md_three, md_four, sp, request_md, remarks, sku_oh, sku_smh, branch, " +
                            "effectivity_date, image) " +
                            "VALUES (@rfmd_no, @rr_date, @po_no, @rr_no, @supplier_code, @product, @description, @beg_invty, @unit_price, @category_code, @product_status, " +
                            "@store_group, @current_invty, @new_srp, @md_one, @md_two, @md_three, @md_four, @sp, @request_md, @remarks, @sku_oh, @sku_smh, @branch, " +
                            "@effectivity_date, @image)";

                            using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@rfmd_no", rfmdNo);
                                cmd.Parameters.AddWithValue("@rr_date", row.Cells["rrdateDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDateTime(row.Cells["rrdateDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@po_no", row.Cells["podateDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["podateDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@rr_no", row.Cells["rrnoDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["rrnoDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@supplier_code", row.Cells["suppliercodeDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["suppliercodeDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@product", row.Cells["productDataGridViewTextBoxColumn"].Value?.ToString() ?? "");
                                cmd.Parameters.AddWithValue("@description", row.Cells["descriptionDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["descriptionDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@beg_invty", row.Cells["beginvtyDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToInt32(row.Cells["beginvtyDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@unit_price", row.Cells["unitpriceDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["unitpriceDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@category_code", row.Cells["categorycodeDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["categorycodeDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@product_status", row.Cells["productstatusDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["productstatusDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@store_group", row.Cells["storegroupDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["storegroupDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@current_invty", row.Cells["currentinvtyDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToInt32(row.Cells["currentinvtyDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@new_srp", row.Cells["newsrpDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["newsrpDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@md_one", row.Cells["mdoneDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["mdoneDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@md_two", row.Cells["mdtwoDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["mdtwoDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@md_three", row.Cells["mdthreeDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["mdthreeDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@md_four", row.Cells["mdfourDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["mdfourDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@sp", row.Cells["spDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["spDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@request_md", row.Cells["requestmdDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(row.Cells["requestmdDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@remarks", row.Cells["remarksDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["remarksDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@sku_oh", row.Cells["skuohDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["skuohDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@sku_smh", row.Cells["skusmhDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["skusmhDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@branch", row.Cells["branchDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : row.Cells["branchDataGridViewTextBoxColumn"].Value.ToString());
                                cmd.Parameters.AddWithValue("@effectivity_date", row.Cells["effectivitydateDataGridViewTextBoxColumn"].Value == DBNull.Value ? (object)DBNull.Value : Convert.ToDateTime(row.Cells["effectivitydateDataGridViewTextBoxColumn"].Value));
                                cmd.Parameters.AddWithValue("@image", imagePath ?? (object)DBNull.Value);

                                cmd.ExecuteNonQuery(); // ✅ Save record to system_sellthru_summary
                            }
                        }
                        transaction.Commit(); // ✅ Save all changes permanently
                        MessageBox.Show($"Data successfully saved!\nwith RFMD No: {rfmdNo}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dataGridView1.DataSource = this.DataSet13.RfmdMainForm;

            // ✅ Extract all distinct values from the FULL dataset
            System.Data.DataView dv = new System.Data.DataView(this.DataSet13.RfmdMainForm);
            System.Data.DataTable distinctPONo = dv.ToTable(true, "po_date");


            // ✅ Reset ComboBoxes and repopulate with full data
            RefreshComboBox(toolStripComboBox1, distinctPONo, "po_date", null);


            // ✅ Enable all ComboBoxes
            toolStripComboBox1.Enabled = true;


            isFormLoaded = true; // ✅ Re-enable event triggers
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }

    public class CalendarColumn : DataGridViewColumn
    {
        public CalendarColumn() : base(new CalendarCell()) { }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                    throw new InvalidCastException("Must be a CalendarCell");
                base.CellTemplate = value;
            }
        }
    }

    public class CalendarCell : DataGridViewTextBoxCell
    {
        public CalendarCell() : base()
        {
            this.Style.Format = "d"; // Format as short date
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue,
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            CalendarEditingControl ctl = DataGridView.EditingControl as CalendarEditingControl;

            if (this.Value == null || this.Value == DBNull.Value)
                ctl.Value = DateTime.Today;
            else
                ctl.Value = Convert.ToDateTime(this.Value);
        }

        public override Type EditType => typeof(CalendarEditingControl);
        public override Type ValueType => typeof(DateTime);
        public override object DefaultNewRowValue => DateTime.Today;
    }

    public class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public CalendarEditingControl()
        {
            this.Format = DateTimePickerFormat.Short;
        }

        public object EditingControlFormattedValue
        {
            get => this.Value.ToShortDateString();
            set
            {
                if (DateTime.TryParse(value?.ToString(), out DateTime dt))
                    this.Value = dt;
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) => EditingControlFormattedValue;

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        public int EditingControlRowIndex
        {
            get => rowIndex;
            set => rowIndex = value;
        }

        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey) =>
            key == Keys.Left || key == Keys.Up || key == Keys.Down || key == Keys.Right || key == Keys.Home || key == Keys.End || key == Keys.PageDown || key == Keys.PageUp;

        public void PrepareEditingControlForEdit(bool selectAll) { }

        public bool RepositionEditingControlOnValueChange => false;

        public DataGridView EditingControlDataGridView
        {
            get => dataGridView;
            set => dataGridView = value;
        }

        public bool EditingControlValueChanged
        {
            get => valueChanged;
            set => valueChanged = value;
        }

        public Cursor EditingPanelCursor => base.Cursor;

        protected override void OnValueChanged(EventArgs eventargs)
        {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }

}
