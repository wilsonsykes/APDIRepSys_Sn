namespace APDIRepSys.RFMDForm
{
    partial class RfmdMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RfmdMainForm));
            toolStrip1 = new ToolStrip();
            toolStripLabel2 = new ToolStripLabel();
            toolStripComboBox1 = new ToolStripComboBox();
            toolStripButton2 = new ToolStripButton();
            toolStripLabel5 = new ToolStripLabel();
            toolStripSeparator7 = new ToolStripSeparator();
            toolStripLabel6 = new ToolStripLabel();
            toolStrip2 = new ToolStrip();
            dataGridView1 = new DataGridView();
            rrdateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            podateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rrnoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            suppliercodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            beginvtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            unitpriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categorycodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productstatusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
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
            rfmd_mainform_bindingSource1 = new BindingSource(components);
            DataSet13 = new DataSet.DataSet13();
            rfmdMainFormTableAdapter1 = new DataSet.DataSet13TableAdapters.RfmdMainFormTableAdapter();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rfmd_mainform_bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataSet13).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel2, toolStripComboBox1, toolStripButton2, toolStripLabel5, toolStripSeparator7, toolStripLabel6 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1522, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(83, 36);
            toolStripLabel2.Text = "Select PO No.";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(95, 39);
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(28, 36);
            toolStripButton2.Click += toolStripButton1_Click;
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(34, 36);
            toolStripLabel5.Text = "Save";
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 39);
            // 
            // toolStripLabel6
            // 
            toolStripLabel6.BackColor = SystemColors.HotTrack;
            toolStripLabel6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            toolStripLabel6.ForeColor = SystemColors.ControlText;
            toolStripLabel6.Name = "toolStripLabel6";
            toolStripLabel6.Size = new Size(41, 36);
            toolStripLabel6.Text = "Reset";
            toolStripLabel6.Click += toolStripLabel6_Click;
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.Bottom;
            toolStrip2.Location = new Point(0, 710);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1522, 25);
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { rrdateDataGridViewTextBoxColumn, podateDataGridViewTextBoxColumn, rrnoDataGridViewTextBoxColumn, suppliercodeDataGridViewTextBoxColumn, productDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, beginvtyDataGridViewTextBoxColumn, unitpriceDataGridViewTextBoxColumn, categorycodeDataGridViewTextBoxColumn, productstatusDataGridViewTextBoxColumn, storegroupDataGridViewTextBoxColumn, currentinvtyDataGridViewTextBoxColumn, newsrpDataGridViewTextBoxColumn, mdoneDataGridViewTextBoxColumn, mdtwoDataGridViewTextBoxColumn, mdthreeDataGridViewTextBoxColumn, mdfourDataGridViewTextBoxColumn, spDataGridViewTextBoxColumn, requestmdDataGridViewTextBoxColumn, remarksDataGridViewTextBoxColumn, skuohDataGridViewTextBoxColumn, skusmhDataGridViewTextBoxColumn, branchDataGridViewTextBoxColumn, effectivitydateDataGridViewTextBoxColumn });
            dataGridView1.DataSource = rfmd_mainform_bindingSource1;
            dataGridView1.Location = new Point(0, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.Size = new Size(1522, 665);
            dataGridView1.TabIndex = 2;
            // 
            // rrdateDataGridViewTextBoxColumn
            // 
            rrdateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            rrdateDataGridViewTextBoxColumn.DataPropertyName = "rr_date";
            rrdateDataGridViewTextBoxColumn.Frozen = true;
            rrdateDataGridViewTextBoxColumn.HeaderText = "RR Date";
            rrdateDataGridViewTextBoxColumn.Name = "rrdateDataGridViewTextBoxColumn";
            rrdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // podateDataGridViewTextBoxColumn
            // 
            podateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            podateDataGridViewTextBoxColumn.DataPropertyName = "po_date";
            podateDataGridViewTextBoxColumn.Frozen = true;
            podateDataGridViewTextBoxColumn.HeaderText = "PO No";
            podateDataGridViewTextBoxColumn.Name = "podateDataGridViewTextBoxColumn";
            podateDataGridViewTextBoxColumn.ReadOnly = true;
            podateDataGridViewTextBoxColumn.Width = 120;
            // 
            // rrnoDataGridViewTextBoxColumn
            // 
            rrnoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            rrnoDataGridViewTextBoxColumn.DataPropertyName = "rr_no";
            rrnoDataGridViewTextBoxColumn.Frozen = true;
            rrnoDataGridViewTextBoxColumn.HeaderText = "RR No";
            rrnoDataGridViewTextBoxColumn.Name = "rrnoDataGridViewTextBoxColumn";
            rrnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // suppliercodeDataGridViewTextBoxColumn
            // 
            suppliercodeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            suppliercodeDataGridViewTextBoxColumn.DataPropertyName = "supplier_code";
            suppliercodeDataGridViewTextBoxColumn.Frozen = true;
            suppliercodeDataGridViewTextBoxColumn.HeaderText = "Supplier Form";
            suppliercodeDataGridViewTextBoxColumn.Name = "suppliercodeDataGridViewTextBoxColumn";
            suppliercodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productDataGridViewTextBoxColumn
            // 
            productDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            productDataGridViewTextBoxColumn.DataPropertyName = "product";
            productDataGridViewTextBoxColumn.Frozen = true;
            productDataGridViewTextBoxColumn.HeaderText = "Product";
            productDataGridViewTextBoxColumn.Name = "productDataGridViewTextBoxColumn";
            productDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            descriptionDataGridViewTextBoxColumn.Frozen = true;
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // beginvtyDataGridViewTextBoxColumn
            // 
            beginvtyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            beginvtyDataGridViewTextBoxColumn.DataPropertyName = "beg_invty";
            beginvtyDataGridViewTextBoxColumn.HeaderText = "RR Qty";
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
            categorycodeDataGridViewTextBoxColumn.HeaderText = "Category Code";
            categorycodeDataGridViewTextBoxColumn.Name = "categorycodeDataGridViewTextBoxColumn";
            categorycodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productstatusDataGridViewTextBoxColumn
            // 
            productstatusDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            productstatusDataGridViewTextBoxColumn.DataPropertyName = "product_status";
            productstatusDataGridViewTextBoxColumn.HeaderText = "Product Status";
            productstatusDataGridViewTextBoxColumn.Name = "productstatusDataGridViewTextBoxColumn";
            productstatusDataGridViewTextBoxColumn.ReadOnly = true;
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
            // 
            // remarksDataGridViewTextBoxColumn
            // 
            remarksDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            remarksDataGridViewTextBoxColumn.DataPropertyName = "remarks";
            remarksDataGridViewTextBoxColumn.HeaderText = "Remarks";
            remarksDataGridViewTextBoxColumn.Name = "remarksDataGridViewTextBoxColumn";
            // 
            // skuohDataGridViewTextBoxColumn
            // 
            skuohDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            skuohDataGridViewTextBoxColumn.DataPropertyName = "sku_oh";
            skuohDataGridViewTextBoxColumn.HeaderText = "OH SKU";
            skuohDataGridViewTextBoxColumn.Name = "skuohDataGridViewTextBoxColumn";
            // 
            // skusmhDataGridViewTextBoxColumn
            // 
            skusmhDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            skusmhDataGridViewTextBoxColumn.DataPropertyName = "sku_smh";
            skusmhDataGridViewTextBoxColumn.HeaderText = "SKU SMH";
            skusmhDataGridViewTextBoxColumn.Name = "skusmhDataGridViewTextBoxColumn";
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
            // 
            // rfmd_mainform_bindingSource1
            // 
            rfmd_mainform_bindingSource1.DataMember = "RfmdMainForm";
            rfmd_mainform_bindingSource1.DataSource = DataSet13;
            // 
            // DataSet13
            // 
            DataSet13.DataSetName = "DataSet13";
            DataSet13.Namespace = "http://tempuri.org/DataSet1.xsd";
            DataSet13.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rfmdMainFormTableAdapter1
            // 
            rfmdMainFormTableAdapter1.ClearBeforeFill = true;
            // 
            // RfmdMainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1522, 735);
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "RfmdMainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RFMD Form";
            WindowState = FormWindowState.Maximized;
            Load += RfmdMainForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)rfmd_mainform_bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataSet13).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripButton toolStripButton2;
        private ToolStripLabel toolStripLabel5;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripLabel toolStripLabel6;
        private DataGridView dataGridView1;
        private DataSet.DataSet13 DataSet13;
        private DataSet.DataSet13TableAdapters.RfmdMainFormTableAdapter rfmdMainFormTableAdapter1;
        private BindingSource rfmd_mainform_bindingSource1;
        private DataGridViewTextBoxColumn rrdateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn podateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rrnoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn suppliercodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn beginvtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn unitpriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categorycodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productstatusDataGridViewTextBoxColumn;
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
    }
}