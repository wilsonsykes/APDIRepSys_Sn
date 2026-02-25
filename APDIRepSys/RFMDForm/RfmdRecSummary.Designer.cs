namespace APDIRepSys.RFMDForm
{
    partial class RfmdRecSummary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RfmdRecSummary));
            rfmd_rec_summary_bindingSource1 = new BindingSource(components);
            DataSet15 = new DataSet.DataSet15();
            rfmdRecSummaryTableAdapter1 = new DataSet.DataSet15TableAdapters.RfmdRecSummaryTableAdapter();
            miniToolStrip = new ToolStrip();
            toolStrip2 = new ToolStrip();
            dataGridView1 = new DataGridView();
            rfmdnoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rrdateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ponoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rrnoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            suppliercodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            beginvtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            unitpriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categorycodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            storegroupDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            currentinvtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            newsrpDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mdoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mdtwoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mdthreeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mdfourDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            spDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            requestmdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            remarksDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            skuohDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            skusmhDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            branchDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            effectivitydateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            memo_no = new DataGridViewTextBoxColumn();
            memo_to = new DataGridViewTextBoxColumn();
            memo_cc = new DataGridViewTextBoxColumn();
            memo_from = new DataGridViewTextBoxColumn();
            memo_re = new DataGridViewTextBoxColumn();
            memo_prepared_by = new DataGridViewTextBoxColumn();
            memo_date = new DataGridViewTextBoxColumn();
            memo_effective_date = new DataGridViewTextBoxColumn();
            memo_body = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripLabel1 = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            toolStripComboBox1 = new ToolStripComboBox();
            textBoxTo = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBoxCc = new TextBox();
            label5 = new Label();
            textBoxMemoNo = new TextBox();
            label6 = new Label();
            textBoxRe = new TextBox();
            label1 = new Label();
            textBoxPreparedBy = new TextBox();
            dateTimePickerDate = new DateTimePicker();
            label7 = new Label();
            label8 = new Label();
            dateTimePickerEffectiveDate = new DateTimePicker();
            label9 = new Label();
            textBoxContent = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label10 = new Label();
            textBoxFrom = new TextBox();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)rfmd_rec_summary_bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataSet15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // rfmd_rec_summary_bindingSource1
            // 
            rfmd_rec_summary_bindingSource1.DataMember = "RfmdRecSummary";
            rfmd_rec_summary_bindingSource1.DataSource = DataSet15;
            // 
            // DataSet15
            // 
            DataSet15.DataSetName = "DataSet15";
            DataSet15.Namespace = "http://tempuri.org/RfmdRecSummary.xsd";
            DataSet15.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rfmdRecSummaryTableAdapter1
            // 
            rfmdRecSummaryTableAdapter1.ClearBeforeFill = true;
            // 
            // miniToolStrip
            // 
            miniToolStrip.AccessibleName = "New item selection";
            miniToolStrip.AccessibleRole = AccessibleRole.ButtonDropDown;
            miniToolStrip.AutoSize = false;
            miniToolStrip.CanOverflow = false;
            miniToolStrip.Dock = DockStyle.None;
            miniToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            miniToolStrip.Location = new Point(0, 0);
            miniToolStrip.Name = "miniToolStrip";
            miniToolStrip.Size = new Size(1484, 25);
            miniToolStrip.TabIndex = 1;
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.Bottom;
            toolStrip2.Location = new Point(0, 536);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1484, 25);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { rfmdnoDataGridViewTextBoxColumn, rrdateDataGridViewTextBoxColumn, ponoDataGridViewTextBoxColumn, rrnoDataGridViewTextBoxColumn, suppliercodeDataGridViewTextBoxColumn, productDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, beginvtyDataGridViewTextBoxColumn, unitpriceDataGridViewTextBoxColumn, categorycodeDataGridViewTextBoxColumn, storegroupDataGridViewTextBoxColumn, currentinvtyDataGridViewTextBoxColumn, newsrpDataGridViewTextBoxColumn, mdoneDataGridViewTextBoxColumn, mdtwoDataGridViewTextBoxColumn, mdthreeDataGridViewTextBoxColumn, mdfourDataGridViewTextBoxColumn, spDataGridViewTextBoxColumn, requestmdDataGridViewTextBoxColumn, remarksDataGridViewTextBoxColumn, skuohDataGridViewTextBoxColumn, skusmhDataGridViewTextBoxColumn, branchDataGridViewTextBoxColumn, effectivitydateDataGridViewTextBoxColumn, memo_no, memo_to, memo_cc, memo_from, memo_re, memo_prepared_by, memo_date, memo_effective_date, memo_body });
            dataGridView1.DataSource = rfmd_rec_summary_bindingSource1;
            dataGridView1.Location = new Point(3, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1478, 250);
            dataGridView1.TabIndex = 2;
            // 
            // rfmdnoDataGridViewTextBoxColumn
            // 
            rfmdnoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            rfmdnoDataGridViewTextBoxColumn.DataPropertyName = "rfmd_no";
            rfmdnoDataGridViewTextBoxColumn.HeaderText = "RFMD No";
            rfmdnoDataGridViewTextBoxColumn.Name = "rfmdnoDataGridViewTextBoxColumn";
            rfmdnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rrdateDataGridViewTextBoxColumn
            // 
            rrdateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            rrdateDataGridViewTextBoxColumn.DataPropertyName = "rr_date";
            rrdateDataGridViewTextBoxColumn.HeaderText = "RR Date";
            rrdateDataGridViewTextBoxColumn.Name = "rrdateDataGridViewTextBoxColumn";
            rrdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ponoDataGridViewTextBoxColumn
            // 
            ponoDataGridViewTextBoxColumn.DataPropertyName = "po_no";
            ponoDataGridViewTextBoxColumn.HeaderText = "PO No";
            ponoDataGridViewTextBoxColumn.Name = "ponoDataGridViewTextBoxColumn";
            ponoDataGridViewTextBoxColumn.ReadOnly = true;
            ponoDataGridViewTextBoxColumn.Width = 120;
            // 
            // rrnoDataGridViewTextBoxColumn
            // 
            rrnoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            rrnoDataGridViewTextBoxColumn.DataPropertyName = "rr_no";
            rrnoDataGridViewTextBoxColumn.HeaderText = "RR No";
            rrnoDataGridViewTextBoxColumn.Name = "rrnoDataGridViewTextBoxColumn";
            rrnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // suppliercodeDataGridViewTextBoxColumn
            // 
            suppliercodeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            suppliercodeDataGridViewTextBoxColumn.DataPropertyName = "supplier_code";
            suppliercodeDataGridViewTextBoxColumn.HeaderText = "Supplier";
            suppliercodeDataGridViewTextBoxColumn.Name = "suppliercodeDataGridViewTextBoxColumn";
            suppliercodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productDataGridViewTextBoxColumn
            // 
            productDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            productDataGridViewTextBoxColumn.DataPropertyName = "product";
            productDataGridViewTextBoxColumn.HeaderText = "Product";
            productDataGridViewTextBoxColumn.Name = "productDataGridViewTextBoxColumn";
            productDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // beginvtyDataGridViewTextBoxColumn
            // 
            beginvtyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            beginvtyDataGridViewTextBoxColumn.DataPropertyName = "beg_invty";
            beginvtyDataGridViewTextBoxColumn.HeaderText = "Beg Invty";
            beginvtyDataGridViewTextBoxColumn.Name = "beginvtyDataGridViewTextBoxColumn";
            beginvtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitpriceDataGridViewTextBoxColumn
            // 
            unitpriceDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            unitpriceDataGridViewTextBoxColumn.DataPropertyName = "unit_price";
            unitpriceDataGridViewTextBoxColumn.HeaderText = "SRP";
            unitpriceDataGridViewTextBoxColumn.Name = "unitpriceDataGridViewTextBoxColumn";
            unitpriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categorycodeDataGridViewTextBoxColumn
            // 
            categorycodeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            categorycodeDataGridViewTextBoxColumn.DataPropertyName = "category_code";
            categorycodeDataGridViewTextBoxColumn.HeaderText = "Category";
            categorycodeDataGridViewTextBoxColumn.Name = "categorycodeDataGridViewTextBoxColumn";
            categorycodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // storegroupDataGridViewTextBoxColumn
            // 
            storegroupDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            storegroupDataGridViewTextBoxColumn.DataPropertyName = "store_group";
            storegroupDataGridViewTextBoxColumn.HeaderText = "Store Group";
            storegroupDataGridViewTextBoxColumn.Name = "storegroupDataGridViewTextBoxColumn";
            storegroupDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currentinvtyDataGridViewTextBoxColumn
            // 
            currentinvtyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            currentinvtyDataGridViewTextBoxColumn.DataPropertyName = "current_invty";
            currentinvtyDataGridViewTextBoxColumn.HeaderText = "Current Invty";
            currentinvtyDataGridViewTextBoxColumn.Name = "currentinvtyDataGridViewTextBoxColumn";
            currentinvtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // newsrpDataGridViewTextBoxColumn
            // 
            newsrpDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            newsrpDataGridViewTextBoxColumn.DataPropertyName = "new_srp";
            newsrpDataGridViewTextBoxColumn.HeaderText = "New SRP";
            newsrpDataGridViewTextBoxColumn.Name = "newsrpDataGridViewTextBoxColumn";
            newsrpDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mdoneDataGridViewTextBoxColumn
            // 
            mdoneDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            mdoneDataGridViewTextBoxColumn.DataPropertyName = "md_one";
            mdoneDataGridViewTextBoxColumn.HeaderText = "MD1";
            mdoneDataGridViewTextBoxColumn.Name = "mdoneDataGridViewTextBoxColumn";
            mdoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mdtwoDataGridViewTextBoxColumn
            // 
            mdtwoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            mdtwoDataGridViewTextBoxColumn.DataPropertyName = "md_two";
            mdtwoDataGridViewTextBoxColumn.HeaderText = "MD2";
            mdtwoDataGridViewTextBoxColumn.Name = "mdtwoDataGridViewTextBoxColumn";
            mdtwoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mdthreeDataGridViewTextBoxColumn
            // 
            mdthreeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            mdthreeDataGridViewTextBoxColumn.DataPropertyName = "md_three";
            mdthreeDataGridViewTextBoxColumn.HeaderText = "MD3";
            mdthreeDataGridViewTextBoxColumn.Name = "mdthreeDataGridViewTextBoxColumn";
            mdthreeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mdfourDataGridViewTextBoxColumn
            // 
            mdfourDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            mdfourDataGridViewTextBoxColumn.DataPropertyName = "md_four";
            mdfourDataGridViewTextBoxColumn.HeaderText = "MD4";
            mdfourDataGridViewTextBoxColumn.Name = "mdfourDataGridViewTextBoxColumn";
            mdfourDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // spDataGridViewTextBoxColumn
            // 
            spDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            spDataGridViewTextBoxColumn.DataPropertyName = "sp";
            spDataGridViewTextBoxColumn.HeaderText = "SP";
            spDataGridViewTextBoxColumn.Name = "spDataGridViewTextBoxColumn";
            spDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requestmdDataGridViewTextBoxColumn
            // 
            requestmdDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            requestmdDataGridViewTextBoxColumn.DataPropertyName = "request_md";
            requestmdDataGridViewTextBoxColumn.HeaderText = "Request MD";
            requestmdDataGridViewTextBoxColumn.Name = "requestmdDataGridViewTextBoxColumn";
            requestmdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remarksDataGridViewTextBoxColumn
            // 
            remarksDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            remarksDataGridViewTextBoxColumn.DataPropertyName = "remarks";
            remarksDataGridViewTextBoxColumn.HeaderText = "Remarks";
            remarksDataGridViewTextBoxColumn.Name = "remarksDataGridViewTextBoxColumn";
            remarksDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // skuohDataGridViewTextBoxColumn
            // 
            skuohDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            skuohDataGridViewTextBoxColumn.DataPropertyName = "sku_oh";
            skuohDataGridViewTextBoxColumn.HeaderText = "OH SKU";
            skuohDataGridViewTextBoxColumn.Name = "skuohDataGridViewTextBoxColumn";
            skuohDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // skusmhDataGridViewTextBoxColumn
            // 
            skusmhDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            skusmhDataGridViewTextBoxColumn.DataPropertyName = "sku_smh";
            skusmhDataGridViewTextBoxColumn.HeaderText = "SMH SKU";
            skusmhDataGridViewTextBoxColumn.Name = "skusmhDataGridViewTextBoxColumn";
            skusmhDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // branchDataGridViewTextBoxColumn
            // 
            branchDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            branchDataGridViewTextBoxColumn.DataPropertyName = "branch";
            branchDataGridViewTextBoxColumn.HeaderText = "Branch";
            branchDataGridViewTextBoxColumn.Name = "branchDataGridViewTextBoxColumn";
            branchDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // effectivitydateDataGridViewTextBoxColumn
            // 
            effectivitydateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            effectivitydateDataGridViewTextBoxColumn.DataPropertyName = "effectivity_date";
            effectivitydateDataGridViewTextBoxColumn.HeaderText = "Effectivity Date";
            effectivitydateDataGridViewTextBoxColumn.Name = "effectivitydateDataGridViewTextBoxColumn";
            effectivitydateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // memo_no
            // 
            memo_no.DataPropertyName = "memo_no";
            memo_no.HeaderText = "memo_no";
            memo_no.Name = "memo_no";
            memo_no.Visible = false;
            // 
            // memo_to
            // 
            memo_to.DataPropertyName = "memo_to";
            memo_to.HeaderText = "memo_to";
            memo_to.Name = "memo_to";
            memo_to.Visible = false;
            // 
            // memo_cc
            // 
            memo_cc.DataPropertyName = "memo_cc";
            memo_cc.HeaderText = "memo_cc";
            memo_cc.Name = "memo_cc";
            memo_cc.Visible = false;
            // 
            // memo_from
            // 
            memo_from.DataPropertyName = "memo_from";
            memo_from.HeaderText = "memo_from";
            memo_from.Name = "memo_from";
            memo_from.Visible = false;
            // 
            // memo_re
            // 
            memo_re.DataPropertyName = "memo_re";
            memo_re.HeaderText = "memo_re";
            memo_re.Name = "memo_re";
            memo_re.Visible = false;
            // 
            // memo_prepared_by
            // 
            memo_prepared_by.DataPropertyName = "memo_prepared_by";
            memo_prepared_by.HeaderText = "memo_prepared_by";
            memo_prepared_by.Name = "memo_prepared_by";
            memo_prepared_by.Visible = false;
            // 
            // memo_date
            // 
            memo_date.DataPropertyName = "memo_date";
            memo_date.HeaderText = "memo_date";
            memo_date.Name = "memo_date";
            memo_date.Visible = false;
            // 
            // memo_effective_date
            // 
            memo_effective_date.DataPropertyName = "memo_effective_date";
            memo_effective_date.HeaderText = "memo_effective_date";
            memo_effective_date.Name = "memo_effective_date";
            memo_effective_date.Visible = false;
            // 
            // memo_body
            // 
            memo_body.DataPropertyName = "memo_body";
            memo_body.HeaderText = "memo_body";
            memo_body.Name = "memo_body";
            memo_body.Visible = false;
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripLabel1, toolStripSeparator1, toolStripLabel2, toolStripComboBox1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1484, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(36, 36);
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(208, 36);
            toolStripLabel1.Text = "Load and Print this Report";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(136, 36);
            toolStripLabel2.Text = "Select RFMD No.";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 39);
            // 
            // textBoxTo
            // 
            textBoxTo.Location = new Point(113, 366);
            textBoxTo.Name = "textBoxTo";
            textBoxTo.Size = new Size(138, 29);
            textBoxTo.TabIndex = 3;
            textBoxTo.TextChanged += textBox1_TextChanged_2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 317);
            label2.Name = "label2";
            label2.Size = new Size(112, 21);
            label2.TabIndex = 5;
            label2.Text = "Create Memo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 369);
            label3.Name = "label3";
            label3.Size = new Size(28, 21);
            label3.TabIndex = 6;
            label3.Text = "To:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 413);
            label4.Name = "label4";
            label4.Size = new Size(30, 21);
            label4.TabIndex = 8;
            label4.Text = "Cc:";
            // 
            // textBoxCc
            // 
            textBoxCc.Location = new Point(113, 410);
            textBoxCc.Name = "textBoxCc";
            textBoxCc.Size = new Size(138, 29);
            textBoxCc.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(136, 320);
            label5.Name = "label5";
            label5.Size = new Size(86, 21);
            label5.TabIndex = 10;
            label5.Text = "Memo No.:";
            // 
            // textBoxMemoNo
            // 
            textBoxMemoNo.Location = new Point(246, 317);
            textBoxMemoNo.Name = "textBoxMemoNo";
            textBoxMemoNo.Size = new Size(138, 29);
            textBoxMemoNo.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(283, 369);
            label6.Name = "label6";
            label6.Size = new Size(31, 21);
            label6.TabIndex = 12;
            label6.Text = "Re:";
            // 
            // textBoxRe
            // 
            textBoxRe.Location = new Point(409, 366);
            textBoxRe.Name = "textBoxRe";
            textBoxRe.Size = new Size(138, 29);
            textBoxRe.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(283, 413);
            label1.Name = "label1";
            label1.Size = new Size(97, 21);
            label1.TabIndex = 14;
            label1.Text = "Prepared by:";
            // 
            // textBoxPreparedBy
            // 
            textBoxPreparedBy.Location = new Point(409, 410);
            textBoxPreparedBy.Name = "textBoxPreparedBy";
            textBoxPreparedBy.Size = new Size(138, 29);
            textBoxPreparedBy.TabIndex = 13;
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Location = new Point(831, 408);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(85, 29);
            dateTimePickerDate.TabIndex = 15;
            dateTimePickerDate.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(780, 413);
            label7.Name = "label7";
            label7.Size = new Size(45, 21);
            label7.TabIndex = 16;
            label7.Text = "Date:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(573, 413);
            label8.Name = "label8";
            label8.Size = new Size(107, 21);
            label8.TabIndex = 18;
            label8.Text = "Effective Date:";
            // 
            // dateTimePickerEffectiveDate
            // 
            dateTimePickerEffectiveDate.Location = new Point(686, 410);
            dateTimePickerEffectiveDate.Name = "dateTimePickerEffectiveDate";
            dateTimePickerEffectiveDate.Size = new Size(85, 29);
            dateTimePickerEffectiveDate.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(3, 466);
            label9.Name = "label9";
            label9.Size = new Size(65, 21);
            label9.TabIndex = 20;
            label9.Text = "Content";
            // 
            // textBoxContent
            // 
            textBoxContent.Location = new Point(113, 463);
            textBoxContent.Multiline = true;
            textBoxContent.Name = "textBoxContent";
            textBoxContent.Size = new Size(638, 83);
            textBoxContent.TabIndex = 19;
            // 
            // button1
            // 
            button1.BackColor = Color.Purple;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(406, 315);
            button1.Name = "button1";
            button1.Size = new Size(141, 31);
            button1.TabIndex = 21;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ButtonSaveMemo_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(569, 315);
            button2.Name = "button2";
            button2.Size = new Size(141, 31);
            button2.TabIndex = 22;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = false;
            button2.Click += buttonClearMemo_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(570, 369);
            label10.Name = "label10";
            label10.Size = new Size(50, 21);
            label10.TabIndex = 24;
            label10.Text = "From:";
            // 
            // textBoxFrom
            // 
            textBoxFrom.Location = new Point(696, 366);
            textBoxFrom.Name = "textBoxFrom";
            textBoxFrom.Size = new Size(138, 29);
            textBoxFrom.TabIndex = 23;
            // 
            // button3
            // 
            button3.BackColor = Color.ForestGreen;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ControlLightLight;
            button3.Location = new Point(728, 315);
            button3.Name = "button3";
            button3.Size = new Size(141, 31);
            button3.TabIndex = 25;
            button3.Text = "Print Memo";
            button3.UseVisualStyleBackColor = false;
            button3.Click += Button3_Click;
            // 
            // RfmdRecSummary
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1484, 561);
            Controls.Add(button3);
            Controls.Add(label10);
            Controls.Add(textBoxFrom);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label9);
            Controls.Add(textBoxContent);
            Controls.Add(label8);
            Controls.Add(dateTimePickerEffectiveDate);
            Controls.Add(label7);
            Controls.Add(dateTimePickerDate);
            Controls.Add(label1);
            Controls.Add(textBoxPreparedBy);
            Controls.Add(label6);
            Controls.Add(textBoxRe);
            Controls.Add(label5);
            Controls.Add(textBoxMemoNo);
            Controls.Add(label4);
            Controls.Add(textBoxCc);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxTo);
            Controls.Add(toolStrip1);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "RfmdRecSummary";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RFMD Saved Records";
            WindowState = FormWindowState.Maximized;
            Load += RfmdRecSummary_Load;
            ((System.ComponentModel.ISupportInitialize)rfmd_rec_summary_bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataSet15).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource rfmd_rec_summary_bindingSource1;
        private DataSet.DataSet15 DataSet15;
        private DataSet.DataSet15TableAdapters.RfmdRecSummaryTableAdapter rfmdRecSummaryTableAdapter1;
        private ToolStrip miniToolStrip;
        private ToolStrip toolStrip2;
        private DataGridView dataGridView1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox toolStripComboBox1;
        private TextBox textBoxTo;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxCc;
        private Label label5;
        private TextBox textBoxMemoNo;
        private Label label6;
        private TextBox textBoxRe;
        private Label label1;
        private TextBox textBoxPreparedBy;
        private DateTimePicker dateTimePickerDate;
        private Label label7;
        private Label label8;
        private DateTimePicker dateTimePickerEffectiveDate;
        private Label label9;
        private TextBox textBoxContent;
        private Button button1;
        private Button button2;
        private DataGridViewTextBoxColumn rfmdnoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rrdateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ponoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rrnoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn suppliercodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn beginvtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn unitpriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categorycodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn storegroupDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn currentinvtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn newsrpDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mdoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mdtwoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mdthreeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mdfourDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn spDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn requestmdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn remarksDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn skuohDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn skusmhDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn branchDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn effectivitydateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn memo_no;
        private DataGridViewTextBoxColumn memo_to;
        private DataGridViewTextBoxColumn memo_cc;
        private DataGridViewTextBoxColumn memo_from;
        private DataGridViewTextBoxColumn memo_re;
        private DataGridViewTextBoxColumn memo_prepared_by;
        private DataGridViewTextBoxColumn memo_date;
        private DataGridViewTextBoxColumn memo_effective_date;
        private DataGridViewTextBoxColumn memo_body;
        private Label label10;
        private TextBox textBoxFrom;
        private Button button3;
    }
}
