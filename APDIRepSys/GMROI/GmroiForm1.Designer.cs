namespace APDIRepSys.GMROI
{
    partial class GmroiForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GmroiForm1));
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
            toolStrip2 = new ToolStrip();
            dataGridView1 = new DataGridView();
            imageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rrdateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            podateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rrnoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            suppliercodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            beginvtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalinvtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            currentpriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categorycodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productstatusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            closinginventoryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mositemsoldDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mossalerateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mosrevenueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            mosinvtyamountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            orderqtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            orderamountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            costDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalinvtycostDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalsalescostDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            grossmarginDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            marginDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            gmroiDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            gmroi_summarybindingSource1 = new BindingSource(components);
            dataSet3 = new DataSet.DataSet3();
            gmroiReport1TableAdapter1 = new DataSet.DataSet3TableAdapters.GmroiReport1TableAdapter();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gmroi_summarybindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataSet3).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripSeparator1, toolStripLabel1, toolStripSeparator2, toolStripSeparator3, toolStripLabel2, toolStripComboBox1, toolStripSeparator4, toolStripSeparator5 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1184, 39);
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
            toolStripButton1.Text = "toolStripButton1";
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
            toolStripLabel2.Size = new Size(111, 36);
            toolStripLabel2.Text = "Select RR No.";
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
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.Bottom;
            toolStrip2.Location = new Point(0, 500);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1184, 25);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.GrayText;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { imageDataGridViewTextBoxColumn, rrdateDataGridViewTextBoxColumn, podateDataGridViewTextBoxColumn, rrnoDataGridViewTextBoxColumn, suppliercodeDataGridViewTextBoxColumn, productDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, beginvtyDataGridViewTextBoxColumn, totalinvtyDataGridViewTextBoxColumn, currentpriceDataGridViewTextBoxColumn, categorycodeDataGridViewTextBoxColumn, productstatusDataGridViewTextBoxColumn, closinginventoryDataGridViewTextBoxColumn, mositemsoldDataGridViewTextBoxColumn, mossalerateDataGridViewTextBoxColumn, mosrevenueDataGridViewTextBoxColumn, mosinvtyamountDataGridViewTextBoxColumn, orderqtyDataGridViewTextBoxColumn, orderamountDataGridViewTextBoxColumn, costDataGridViewTextBoxColumn, totalinvtycostDataGridViewTextBoxColumn, totalsalescostDataGridViewTextBoxColumn, grossmarginDataGridViewTextBoxColumn, marginDataGridViewTextBoxColumn, gmroiDataGridViewTextBoxColumn });
            dataGridView1.DataSource = gmroi_summarybindingSource1;
            dataGridView1.Location = new Point(0, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1184, 455);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // imageDataGridViewTextBoxColumn
            // 
            imageDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            imageDataGridViewTextBoxColumn.DataPropertyName = "image";
            imageDataGridViewTextBoxColumn.HeaderText = "Image";
            imageDataGridViewTextBoxColumn.Name = "imageDataGridViewTextBoxColumn";
            imageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rrdateDataGridViewTextBoxColumn
            // 
            rrdateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            rrdateDataGridViewTextBoxColumn.DataPropertyName = "rr_date";
            rrdateDataGridViewTextBoxColumn.HeaderText = "RR Date";
            rrdateDataGridViewTextBoxColumn.Name = "rrdateDataGridViewTextBoxColumn";
            rrdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // podateDataGridViewTextBoxColumn
            // 
            podateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            podateDataGridViewTextBoxColumn.DataPropertyName = "po_date";
            podateDataGridViewTextBoxColumn.HeaderText = "PO Date";
            podateDataGridViewTextBoxColumn.Name = "podateDataGridViewTextBoxColumn";
            podateDataGridViewTextBoxColumn.ReadOnly = true;
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
            suppliercodeDataGridViewTextBoxColumn.HeaderText = "Supplier Code";
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
            // totalinvtyDataGridViewTextBoxColumn
            // 
            totalinvtyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            totalinvtyDataGridViewTextBoxColumn.DataPropertyName = "total_invty";
            totalinvtyDataGridViewTextBoxColumn.HeaderText = "Total Invty";
            totalinvtyDataGridViewTextBoxColumn.Name = "totalinvtyDataGridViewTextBoxColumn";
            totalinvtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currentpriceDataGridViewTextBoxColumn
            // 
            currentpriceDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            currentpriceDataGridViewTextBoxColumn.DataPropertyName = "current_price";
            currentpriceDataGridViewTextBoxColumn.HeaderText = "Current Price";
            currentpriceDataGridViewTextBoxColumn.Name = "currentpriceDataGridViewTextBoxColumn";
            currentpriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categorycodeDataGridViewTextBoxColumn
            // 
            categorycodeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            categorycodeDataGridViewTextBoxColumn.DataPropertyName = "category_code";
            categorycodeDataGridViewTextBoxColumn.HeaderText = "Category";
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
            // closinginventoryDataGridViewTextBoxColumn
            // 
            closinginventoryDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            closinginventoryDataGridViewTextBoxColumn.DataPropertyName = "closing_inventory";
            closinginventoryDataGridViewTextBoxColumn.HeaderText = "Closing Invty";
            closinginventoryDataGridViewTextBoxColumn.Name = "closinginventoryDataGridViewTextBoxColumn";
            closinginventoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mositemsoldDataGridViewTextBoxColumn
            // 
            mositemsoldDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            mositemsoldDataGridViewTextBoxColumn.DataPropertyName = "2_mos_item_sold";
            mositemsoldDataGridViewTextBoxColumn.HeaderText = "2 Mos Item Sold";
            mositemsoldDataGridViewTextBoxColumn.Name = "mositemsoldDataGridViewTextBoxColumn";
            mositemsoldDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mossalerateDataGridViewTextBoxColumn
            // 
            mossalerateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            mossalerateDataGridViewTextBoxColumn.DataPropertyName = "2_mos_sale_rate";
            mossalerateDataGridViewTextBoxColumn.HeaderText = "2 Mos Sale Rate";
            mossalerateDataGridViewTextBoxColumn.Name = "mossalerateDataGridViewTextBoxColumn";
            mossalerateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mosrevenueDataGridViewTextBoxColumn
            // 
            mosrevenueDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            mosrevenueDataGridViewTextBoxColumn.DataPropertyName = "2_mos_revenue";
            mosrevenueDataGridViewTextBoxColumn.HeaderText = "2 Mos Revenue";
            mosrevenueDataGridViewTextBoxColumn.Name = "mosrevenueDataGridViewTextBoxColumn";
            mosrevenueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mosinvtyamountDataGridViewTextBoxColumn
            // 
            mosinvtyamountDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            mosinvtyamountDataGridViewTextBoxColumn.DataPropertyName = "2_mos_invty_amount";
            mosinvtyamountDataGridViewTextBoxColumn.HeaderText = "2 Mos Invty Amount";
            mosinvtyamountDataGridViewTextBoxColumn.Name = "mosinvtyamountDataGridViewTextBoxColumn";
            mosinvtyamountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderqtyDataGridViewTextBoxColumn
            // 
            orderqtyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            orderqtyDataGridViewTextBoxColumn.DataPropertyName = "order_qty";
            orderqtyDataGridViewTextBoxColumn.HeaderText = "Order Qty";
            orderqtyDataGridViewTextBoxColumn.Name = "orderqtyDataGridViewTextBoxColumn";
            orderqtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderamountDataGridViewTextBoxColumn
            // 
            orderamountDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            orderamountDataGridViewTextBoxColumn.DataPropertyName = "order_amount";
            orderamountDataGridViewTextBoxColumn.HeaderText = "Order Amount";
            orderamountDataGridViewTextBoxColumn.Name = "orderamountDataGridViewTextBoxColumn";
            orderamountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costDataGridViewTextBoxColumn
            // 
            costDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            costDataGridViewTextBoxColumn.DataPropertyName = "cost";
            costDataGridViewTextBoxColumn.HeaderText = "Cost";
            costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            costDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalinvtycostDataGridViewTextBoxColumn
            // 
            totalinvtycostDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            totalinvtycostDataGridViewTextBoxColumn.DataPropertyName = "total_invty_cost";
            totalinvtycostDataGridViewTextBoxColumn.HeaderText = "Total Invty Cost";
            totalinvtycostDataGridViewTextBoxColumn.Name = "totalinvtycostDataGridViewTextBoxColumn";
            totalinvtycostDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalsalescostDataGridViewTextBoxColumn
            // 
            totalsalescostDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            totalsalescostDataGridViewTextBoxColumn.DataPropertyName = "total_sales_cost";
            totalsalescostDataGridViewTextBoxColumn.HeaderText = "Total Sales Cost";
            totalsalescostDataGridViewTextBoxColumn.Name = "totalsalescostDataGridViewTextBoxColumn";
            totalsalescostDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // grossmarginDataGridViewTextBoxColumn
            // 
            grossmarginDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grossmarginDataGridViewTextBoxColumn.DataPropertyName = "gross_margin";
            grossmarginDataGridViewTextBoxColumn.HeaderText = "Gross Margin";
            grossmarginDataGridViewTextBoxColumn.Name = "grossmarginDataGridViewTextBoxColumn";
            grossmarginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // marginDataGridViewTextBoxColumn
            // 
            marginDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            marginDataGridViewTextBoxColumn.DataPropertyName = "margin";
            marginDataGridViewTextBoxColumn.HeaderText = "Margin";
            marginDataGridViewTextBoxColumn.Name = "marginDataGridViewTextBoxColumn";
            marginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gmroiDataGridViewTextBoxColumn
            // 
            gmroiDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            gmroiDataGridViewTextBoxColumn.DataPropertyName = "gmroi";
            gmroiDataGridViewTextBoxColumn.HeaderText = "GMROI";
            gmroiDataGridViewTextBoxColumn.Name = "gmroiDataGridViewTextBoxColumn";
            gmroiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gmroi_summarybindingSource1
            // 
            gmroi_summarybindingSource1.DataMember = "GmroiReport1";
            gmroi_summarybindingSource1.DataSource = dataSet3;
            // 
            // dataSet3
            // 
            dataSet3.DataSetName = "DataSet3";
            dataSet3.Namespace = "http://tempuri.org/DataSet3.xsd";
            dataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gmroiReport1TableAdapter1
            // 
            gmroiReport1TableAdapter1.ClearBeforeFill = true;
            // 
            // GmroiForm1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 525);
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            Name = "GmroiForm1";
            Text = "GMROI Item Summary";
            Load += GmroiForm1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gmroi_summarybindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataSet3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private DataGridView dataGridView1;
        private DataSet.DataSet3 dataSet3;
        private BindingSource gmroi_summarybindingSource1;
        private DataSet.DataSet3TableAdapters.GmroiReport1TableAdapter gmroiReport1TableAdapter1;
        private DataGridViewTextBoxColumn imageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rrdateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn podateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rrnoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn suppliercodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn beginvtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalinvtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn currentpriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categorycodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productstatusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn closinginventoryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mositemsoldDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mossalerateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mosrevenueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mosinvtyamountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderqtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderamountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalinvtycostDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalsalescostDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn grossmarginDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn marginDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn gmroiDataGridViewTextBoxColumn;
    }
}