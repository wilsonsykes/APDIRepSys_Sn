namespace APDIRepSys.STRptForm
{
    partial class Sellthrough
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sellthrough));
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            toolStripComboBox1 = new ToolStripComboBox();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStrip2 = new ToolStrip();
            dataGridView1 = new DataGridView();
            yearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            unitpriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productcategoryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            countofproductDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            soldqtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rrqtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalsalesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            salescontributionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            roiDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            inventorylevelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sell_through_bindingSource1 = new BindingSource(components);
            dataSet1 = new DataSet.DataSet1();
            sThruReportTableAdapter1 = new DataSet.DataSet1TableAdapters.SThruReportTableAdapter();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sell_through_bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataSet1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripSeparator2, toolStripLabel1, toolStripSeparator1, toolStripSeparator5, toolStripLabel2, toolStripComboBox1, toolStripSeparator3, toolStripSeparator4 });
            resources.ApplyResources(toolStrip1, "toolStrip1");
            toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(toolStripButton1, "toolStripButton1");
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripLabel1
            // 
            resources.ApplyResources(toolStripLabel1, "toolStripLabel1");
            toolStripLabel1.Name = "toolStripLabel1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(toolStripSeparator5, "toolStripSeparator5");
            // 
            // toolStripLabel2
            // 
            resources.ApplyResources(toolStripLabel2, "toolStripLabel2");
            toolStripLabel2.Name = "toolStripLabel2";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            resources.ApplyResources(toolStripComboBox1, "toolStripComboBox1");
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(toolStripSeparator4, "toolStripSeparator4");
            // 
            // toolStrip2
            // 
            resources.ApplyResources(toolStrip2, "toolStrip2");
            toolStrip2.Name = "toolStrip2";
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
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { yearDataGridViewTextBoxColumn, unitpriceDataGridViewTextBoxColumn, productcategoryDataGridViewTextBoxColumn, countofproductDataGridViewTextBoxColumn, soldqtyDataGridViewTextBoxColumn, rrqtyDataGridViewTextBoxColumn, totalsalesDataGridViewTextBoxColumn, salescontributionDataGridViewTextBoxColumn, roiDataGridViewTextBoxColumn, inventorylevelDataGridViewTextBoxColumn });
            dataGridView1.DataSource = sell_through_bindingSource1;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            // 
            // yearDataGridViewTextBoxColumn
            // 
            yearDataGridViewTextBoxColumn.DataPropertyName = "year";
            resources.ApplyResources(yearDataGridViewTextBoxColumn, "yearDataGridViewTextBoxColumn");
            yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            yearDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitpriceDataGridViewTextBoxColumn
            // 
            unitpriceDataGridViewTextBoxColumn.DataPropertyName = "unit_price";
            resources.ApplyResources(unitpriceDataGridViewTextBoxColumn, "unitpriceDataGridViewTextBoxColumn");
            unitpriceDataGridViewTextBoxColumn.Name = "unitpriceDataGridViewTextBoxColumn";
            unitpriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productcategoryDataGridViewTextBoxColumn
            // 
            productcategoryDataGridViewTextBoxColumn.DataPropertyName = "product_category";
            resources.ApplyResources(productcategoryDataGridViewTextBoxColumn, "productcategoryDataGridViewTextBoxColumn");
            productcategoryDataGridViewTextBoxColumn.Name = "productcategoryDataGridViewTextBoxColumn";
            productcategoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countofproductDataGridViewTextBoxColumn
            // 
            countofproductDataGridViewTextBoxColumn.DataPropertyName = "count_of_product";
            resources.ApplyResources(countofproductDataGridViewTextBoxColumn, "countofproductDataGridViewTextBoxColumn");
            countofproductDataGridViewTextBoxColumn.Name = "countofproductDataGridViewTextBoxColumn";
            countofproductDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // soldqtyDataGridViewTextBoxColumn
            // 
            soldqtyDataGridViewTextBoxColumn.DataPropertyName = "sold_qty";
            resources.ApplyResources(soldqtyDataGridViewTextBoxColumn, "soldqtyDataGridViewTextBoxColumn");
            soldqtyDataGridViewTextBoxColumn.Name = "soldqtyDataGridViewTextBoxColumn";
            soldqtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rrqtyDataGridViewTextBoxColumn
            // 
            rrqtyDataGridViewTextBoxColumn.DataPropertyName = "rr_qty";
            resources.ApplyResources(rrqtyDataGridViewTextBoxColumn, "rrqtyDataGridViewTextBoxColumn");
            rrqtyDataGridViewTextBoxColumn.Name = "rrqtyDataGridViewTextBoxColumn";
            rrqtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalsalesDataGridViewTextBoxColumn
            // 
            totalsalesDataGridViewTextBoxColumn.DataPropertyName = "total_sales";
            resources.ApplyResources(totalsalesDataGridViewTextBoxColumn, "totalsalesDataGridViewTextBoxColumn");
            totalsalesDataGridViewTextBoxColumn.Name = "totalsalesDataGridViewTextBoxColumn";
            totalsalesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salescontributionDataGridViewTextBoxColumn
            // 
            salescontributionDataGridViewTextBoxColumn.DataPropertyName = "sales_contribution";
            resources.ApplyResources(salescontributionDataGridViewTextBoxColumn, "salescontributionDataGridViewTextBoxColumn");
            salescontributionDataGridViewTextBoxColumn.Name = "salescontributionDataGridViewTextBoxColumn";
            salescontributionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // roiDataGridViewTextBoxColumn
            // 
            roiDataGridViewTextBoxColumn.DataPropertyName = "roi";
            resources.ApplyResources(roiDataGridViewTextBoxColumn, "roiDataGridViewTextBoxColumn");
            roiDataGridViewTextBoxColumn.Name = "roiDataGridViewTextBoxColumn";
            roiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inventorylevelDataGridViewTextBoxColumn
            // 
            inventorylevelDataGridViewTextBoxColumn.DataPropertyName = "inventory_level";
            resources.ApplyResources(inventorylevelDataGridViewTextBoxColumn, "inventorylevelDataGridViewTextBoxColumn");
            inventorylevelDataGridViewTextBoxColumn.Name = "inventorylevelDataGridViewTextBoxColumn";
            inventorylevelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sell_through_bindingSource1
            // 
            sell_through_bindingSource1.DataMember = "SThruReport";
            sell_through_bindingSource1.DataSource = dataSet1;
            // 
            // dataSet1
            // 
            dataSet1.DataSetName = "DataSet1";
            dataSet1.Namespace = "http://tempuri.org/DataSet1.xsd";
            dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sThruReportTableAdapter1
            // 
            sThruReportTableAdapter1.ClearBeforeFill = true;
            // 
            // Sellthrough
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Sellthrough";
            ShowIcon = false;
            Load += Sellthrough_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sell_through_bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataSet1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStrip toolStrip2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderreferenceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn deliverydateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private BindingSource sell_through_bindingSource1;
        private DataSet.DataSet1 dataSet1;
        private DataSet.DataSet1TableAdapters.SThruReportTableAdapter sThruReportTableAdapter1;
        private DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn unitpriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productcategoryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn countofproductDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn soldqtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rrqtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalsalesDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn salescontributionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn inventorylevelDataGridViewTextBoxColumn;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripLabel toolStripLabel2;
    }
}
