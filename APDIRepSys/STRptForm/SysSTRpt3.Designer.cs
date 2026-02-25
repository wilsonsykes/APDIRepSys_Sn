namespace APDIRepSys.STRptForm
{
    partial class SysSTRpt3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysSTRpt3));
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            toolStripComboBox1 = new ToolStripComboBox();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripButton2 = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            toolStripButton3 = new ToolStripButton();
            toolStrip2 = new ToolStrip();
            dataGridView1 = new DataGridView();
            sellthrunoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rrdateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            poreferenceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rrnoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            suppliercodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            beginvtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            currentinvtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            currentinvtyamountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categorycodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productstatusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            currentpriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            storegroupDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nextscheddateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            reportperiodDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mos3itemsoldDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mos3closinginvtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mos3salerateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mos3revenueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mos3invtyamountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            orderqtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            orderamountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sys_sell_thruBindingSource4 = new BindingSource(components);
            dataSet12 = new DataSet.DataSet12();
            syssThruReport3TableAdapter1 = new DataSet.DataSet12TableAdapters.SysSThruReport3TableAdapter();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sys_sell_thruBindingSource4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataSet12).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripSeparator1, toolStripLabel1, toolStripSeparator2, toolStripSeparator3, toolStripLabel2, toolStripComboBox1, toolStripSeparator4, toolStripSeparator5, toolStripButton2, toolStripSeparator6, toolStripButton3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1184, 39);
            toolStrip1.TabIndex = 0;
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
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(208, 36);
            toolStripLabel1.Text = "Load and Print this Report";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 39);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 39);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(160, 36);
            toolStripLabel2.Text = "Select Sell-Thru No.";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 39);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 39);
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 39);
            // 
            // toolStripButton2
            // 
            toolStripButton2.BackColor = Color.Plum;
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(116, 36);
            toolStripButton2.Text = "Save Current Invty";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 39);
            // 
            // toolStripButton3
            // 
            toolStripButton3.BackColor = Color.Plum;
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(110, 36);
            toolStripButton3.Text = "Change Store Grp";
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.Bottom;
            toolStrip2.Location = new Point(0, 500);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1184, 25);
            toolStrip2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { sellthrunoDataGridViewTextBoxColumn, rrdateDataGridViewTextBoxColumn, poreferenceDataGridViewTextBoxColumn, rrnoDataGridViewTextBoxColumn, suppliercodeDataGridViewTextBoxColumn, productDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, beginvtyDataGridViewTextBoxColumn, currentinvtyDataGridViewTextBoxColumn, currentinvtyamountDataGridViewTextBoxColumn, categorycodeDataGridViewTextBoxColumn, productstatusDataGridViewTextBoxColumn, currentpriceDataGridViewTextBoxColumn, storegroupDataGridViewTextBoxColumn, nextscheddateDataGridViewTextBoxColumn, reportperiodDataGridViewTextBoxColumn, mos3itemsoldDataGridViewTextBoxColumn, mos3closinginvtyDataGridViewTextBoxColumn, mos3salerateDataGridViewTextBoxColumn, mos3revenueDataGridViewTextBoxColumn, mos3invtyamountDataGridViewTextBoxColumn, orderqtyDataGridViewTextBoxColumn, orderamountDataGridViewTextBoxColumn });
            dataGridView1.DataSource = sys_sell_thruBindingSource4;
            dataGridView1.Location = new Point(0, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1184, 457);
            dataGridView1.TabIndex = 2;
            // 
            // sellthrunoDataGridViewTextBoxColumn
            // 
            sellthrunoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            sellthrunoDataGridViewTextBoxColumn.DataPropertyName = "sellthru_no";
            sellthrunoDataGridViewTextBoxColumn.Frozen = true;
            sellthrunoDataGridViewTextBoxColumn.HeaderText = "Sell-Thru No";
            sellthrunoDataGridViewTextBoxColumn.Name = "sellthrunoDataGridViewTextBoxColumn";
            sellthrunoDataGridViewTextBoxColumn.ReadOnly = true;
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
            // poreferenceDataGridViewTextBoxColumn
            // 
            poreferenceDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            poreferenceDataGridViewTextBoxColumn.DataPropertyName = "po_reference";
            poreferenceDataGridViewTextBoxColumn.Frozen = true;
            poreferenceDataGridViewTextBoxColumn.HeaderText = "PO Reference";
            poreferenceDataGridViewTextBoxColumn.Name = "poreferenceDataGridViewTextBoxColumn";
            poreferenceDataGridViewTextBoxColumn.ReadOnly = true;
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
            suppliercodeDataGridViewTextBoxColumn.HeaderText = "Supplier Code";
            suppliercodeDataGridViewTextBoxColumn.Name = "suppliercodeDataGridViewTextBoxColumn";
            suppliercodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productDataGridViewTextBoxColumn
            // 
            productDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            productDataGridViewTextBoxColumn.DataPropertyName = "product";
            productDataGridViewTextBoxColumn.Frozen = true;
            productDataGridViewTextBoxColumn.HeaderText = "Stock No";
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
            beginvtyDataGridViewTextBoxColumn.HeaderText = "Beg. Invty";
            beginvtyDataGridViewTextBoxColumn.Name = "beginvtyDataGridViewTextBoxColumn";
            beginvtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currentinvtyDataGridViewTextBoxColumn
            // 
            currentinvtyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            currentinvtyDataGridViewTextBoxColumn.DataPropertyName = "current_invty";
            currentinvtyDataGridViewTextBoxColumn.HeaderText = "Current Invty";
            currentinvtyDataGridViewTextBoxColumn.Name = "currentinvtyDataGridViewTextBoxColumn";
            // 
            // currentinvtyamountDataGridViewTextBoxColumn
            // 
            currentinvtyamountDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            currentinvtyamountDataGridViewTextBoxColumn.DataPropertyName = "current_invty_amount";
            currentinvtyamountDataGridViewTextBoxColumn.HeaderText = "Current Invty Amt";
            currentinvtyamountDataGridViewTextBoxColumn.Name = "currentinvtyamountDataGridViewTextBoxColumn";
            currentinvtyamountDataGridViewTextBoxColumn.ReadOnly = true;
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
            // currentpriceDataGridViewTextBoxColumn
            // 
            currentpriceDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            currentpriceDataGridViewTextBoxColumn.DataPropertyName = "current_price";
            currentpriceDataGridViewTextBoxColumn.HeaderText = "Current Price";
            currentpriceDataGridViewTextBoxColumn.Name = "currentpriceDataGridViewTextBoxColumn";
            currentpriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // storegroupDataGridViewTextBoxColumn
            // 
            storegroupDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            storegroupDataGridViewTextBoxColumn.DataPropertyName = "store_group";
            storegroupDataGridViewTextBoxColumn.HeaderText = "Store Group";
            storegroupDataGridViewTextBoxColumn.Name = "storegroupDataGridViewTextBoxColumn";
            // 
            // nextscheddateDataGridViewTextBoxColumn
            // 
            nextscheddateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            nextscheddateDataGridViewTextBoxColumn.DataPropertyName = "next_sched_date";
            nextscheddateDataGridViewTextBoxColumn.HeaderText = "Next Sell-Thru Date";
            nextscheddateDataGridViewTextBoxColumn.Name = "nextscheddateDataGridViewTextBoxColumn";
            nextscheddateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // reportperiodDataGridViewTextBoxColumn
            // 
            reportperiodDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            reportperiodDataGridViewTextBoxColumn.DataPropertyName = "report_period";
            reportperiodDataGridViewTextBoxColumn.HeaderText = "Report Period";
            reportperiodDataGridViewTextBoxColumn.Name = "reportperiodDataGridViewTextBoxColumn";
            reportperiodDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mos3itemsoldDataGridViewTextBoxColumn
            // 
            mos3itemsoldDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            mos3itemsoldDataGridViewTextBoxColumn.DataPropertyName = "mos3_item_sold";
            mos3itemsoldDataGridViewTextBoxColumn.HeaderText = "Item Sold";
            mos3itemsoldDataGridViewTextBoxColumn.Name = "mos3itemsoldDataGridViewTextBoxColumn";
            mos3itemsoldDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mos3closinginvtyDataGridViewTextBoxColumn
            // 
            mos3closinginvtyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            mos3closinginvtyDataGridViewTextBoxColumn.DataPropertyName = "mos3_closing_invty";
            mos3closinginvtyDataGridViewTextBoxColumn.HeaderText = "Closing Invty";
            mos3closinginvtyDataGridViewTextBoxColumn.Name = "mos3closinginvtyDataGridViewTextBoxColumn";
            mos3closinginvtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mos3salerateDataGridViewTextBoxColumn
            // 
            mos3salerateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            mos3salerateDataGridViewTextBoxColumn.DataPropertyName = "mos3_sale_rate";
            mos3salerateDataGridViewTextBoxColumn.HeaderText = "Sale Rate";
            mos3salerateDataGridViewTextBoxColumn.Name = "mos3salerateDataGridViewTextBoxColumn";
            mos3salerateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mos3revenueDataGridViewTextBoxColumn
            // 
            mos3revenueDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            mos3revenueDataGridViewTextBoxColumn.DataPropertyName = "mos3_revenue";
            mos3revenueDataGridViewTextBoxColumn.HeaderText = "Revenue";
            mos3revenueDataGridViewTextBoxColumn.Name = "mos3revenueDataGridViewTextBoxColumn";
            mos3revenueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mos3invtyamountDataGridViewTextBoxColumn
            // 
            mos3invtyamountDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            mos3invtyamountDataGridViewTextBoxColumn.DataPropertyName = "mos3_invty_amount";
            mos3invtyamountDataGridViewTextBoxColumn.HeaderText = "Invty Amount";
            mos3invtyamountDataGridViewTextBoxColumn.Name = "mos3invtyamountDataGridViewTextBoxColumn";
            mos3invtyamountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderqtyDataGridViewTextBoxColumn
            // 
            orderqtyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            orderqtyDataGridViewTextBoxColumn.DataPropertyName = "order_qty";
            orderqtyDataGridViewTextBoxColumn.HeaderText = "Order Qty";
            orderqtyDataGridViewTextBoxColumn.Name = "orderqtyDataGridViewTextBoxColumn";
            // 
            // orderamountDataGridViewTextBoxColumn
            // 
            orderamountDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            orderamountDataGridViewTextBoxColumn.DataPropertyName = "order_amount";
            orderamountDataGridViewTextBoxColumn.HeaderText = "Order Amount";
            orderamountDataGridViewTextBoxColumn.Name = "orderamountDataGridViewTextBoxColumn";
            // 
            // sys_sell_thruBindingSource4
            // 
            sys_sell_thruBindingSource4.DataMember = "SysSThruReport3";
            sys_sell_thruBindingSource4.DataSource = dataSet12;
            // 
            // dataSet12
            // 
            dataSet12.DataSetName = "DataSet12";
            dataSet12.Namespace = "http://tempuri.org/DataSet12.xsd";
            dataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // syssThruReport3TableAdapter1
            // 
            syssThruReport3TableAdapter1.ClearBeforeFill = true;
            // 
            // SysSTRpt3
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 525);
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "SysSTRpt3";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sell-Thru Summary";
            WindowState = FormWindowState.Maximized;
            Load += SysSTRpt3_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sys_sell_thruBindingSource4).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataSet12).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStrip toolStrip2;
        private DataGridView dataGridView1;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private DataSet.DataSet12 dataSet12;
        private DataSet.DataSet12TableAdapters.SysSThruReport3TableAdapter syssThruReport3TableAdapter1;
        private BindingSource sys_sell_thruBindingSource4;
        private ToolStripButton toolStripButton2;
        private DataGridViewTextBoxColumn sellthrunoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rrdateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn poreferenceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rrnoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn suppliercodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn beginvtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn currentinvtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn currentinvtyamountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categorycodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productstatusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn currentpriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn storegroupDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nextscheddateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn reportperiodDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mos3itemsoldDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mos3closinginvtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mos3salerateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mos3revenueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mos3invtyamountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderqtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderamountDataGridViewTextBoxColumn;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton toolStripButton3;
    }
}