namespace APDIRepSys
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            TreeNode treeNode1 = new TreeNode("Create RFMD");
            TreeNode treeNode2 = new TreeNode("RFMD List");
            TreeNode treeNode3 = new TreeNode("RFMD", new TreeNode[] { treeNode1, treeNode2 });
            TreeNode treeNode4 = new TreeNode("GMROI Summary");
            TreeNode treeNode5 = new TreeNode("GMROI", new TreeNode[] { treeNode4 });
            TreeNode treeNode6 = new TreeNode("STR Summary");
            TreeNode treeNode7 = new TreeNode("STR List Form 2 Months");
            TreeNode treeNode8 = new TreeNode("STR List Form 3 Months");
            TreeNode treeNode9 = new TreeNode("STR List Form 6 Months");
            TreeNode treeNode10 = new TreeNode("STR List Form 9 Months");
            TreeNode treeNode11 = new TreeNode("STR List Summary 2 Mos");
            TreeNode treeNode12 = new TreeNode("STR List Summary 3 Mos");
            TreeNode treeNode13 = new TreeNode("STR List Summary 6 Mos");
            TreeNode treeNode14 = new TreeNode("STR List Summary 9 Mos");
            TreeNode treeNode15 = new TreeNode("Image Path Validator (Admin)");
            TreeNode treeNode16 = new TreeNode("Sell-Thru Report", new TreeNode[] { treeNode6, treeNode7, treeNode8, treeNode9, treeNode10, treeNode11, treeNode12, treeNode13, treeNode14, treeNode15 });
            panel1 = new Panel();
            btnCloseTreeView3 = new Button();
            treeView3 = new TreeView();
            mainstrptbutton3 = new Button();
            btnCloseTreeView2 = new Button();
            treeView2 = new TreeView();
            mainstrptbutton2 = new Button();
            btnCloseTreeView = new Button();
            treeView1 = new TreeView();
            mainstrptbutton1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(btnCloseTreeView3);
            panel1.Controls.Add(treeView3);
            panel1.Controls.Add(mainstrptbutton3);
            panel1.Controls.Add(btnCloseTreeView2);
            panel1.Controls.Add(treeView2);
            panel1.Controls.Add(mainstrptbutton2);
            panel1.Controls.Add(btnCloseTreeView);
            panel1.Controls.Add(treeView1);
            panel1.Controls.Add(mainstrptbutton1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1040, 573);
            panel1.TabIndex = 1;
            // 
            // btnCloseTreeView3
            // 
            btnCloseTreeView3.BackColor = Color.Red;
            btnCloseTreeView3.FlatStyle = FlatStyle.Flat;
            btnCloseTreeView3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCloseTreeView3.Location = new Point(616, 395);
            btnCloseTreeView3.Name = "btnCloseTreeView3";
            btnCloseTreeView3.Size = new Size(35, 34);
            btnCloseTreeView3.TabIndex = 8;
            btnCloseTreeView3.Text = "X";
            btnCloseTreeView3.UseVisualStyleBackColor = false;
            btnCloseTreeView3.Click += btnCloseTreeView3_Click;
            // 
            // treeView3
            // 
            treeView3.BackColor = Color.DarkMagenta;
            treeView3.BorderStyle = BorderStyle.None;
            treeView3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            treeView3.ForeColor = Color.White;
            treeView3.Location = new Point(320, 395);
            treeView3.Name = "treeView3";
            treeNode1.Name = "create_rfmd";
            treeNode1.Text = "Create RFMD";
            treeNode2.Name = "rfmd_list";
            treeNode2.Text = "RFMD List";
            treeNode3.Name = "Node0";
            treeNode3.Text = "RFMD";
            treeView3.Nodes.AddRange(new TreeNode[] { treeNode3 });
            treeView3.Size = new Size(290, 94);
            treeView3.TabIndex = 7;
            treeView3.AfterSelect += treeView3_AfterSelect;
            // 
            // mainstrptbutton3
            // 
            mainstrptbutton3.BackColor = Color.DarkMagenta;
            mainstrptbutton3.FlatStyle = FlatStyle.Popup;
            mainstrptbutton3.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mainstrptbutton3.ForeColor = Color.White;
            mainstrptbutton3.Location = new Point(22, 395);
            mainstrptbutton3.Name = "mainstrptbutton3";
            mainstrptbutton3.Size = new Size(260, 175);
            mainstrptbutton3.TabIndex = 6;
            mainstrptbutton3.Text = "Request For MD";
            mainstrptbutton3.UseVisualStyleBackColor = false;
            mainstrptbutton3.Click += button3_Click;
            // 
            // btnCloseTreeView2
            // 
            btnCloseTreeView2.BackColor = Color.Red;
            btnCloseTreeView2.FlatStyle = FlatStyle.Flat;
            btnCloseTreeView2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCloseTreeView2.Location = new Point(616, 203);
            btnCloseTreeView2.Name = "btnCloseTreeView2";
            btnCloseTreeView2.Size = new Size(35, 34);
            btnCloseTreeView2.TabIndex = 5;
            btnCloseTreeView2.Text = "X";
            btnCloseTreeView2.UseVisualStyleBackColor = false;
            btnCloseTreeView2.Click += btnCloseTreeView2_Click;
            // 
            // treeView2
            // 
            treeView2.BackColor = Color.DarkMagenta;
            treeView2.BorderStyle = BorderStyle.None;
            treeView2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            treeView2.ForeColor = Color.White;
            treeView2.Location = new Point(320, 203);
            treeView2.Name = "treeView2";
            treeNode4.Name = "str_acctg";
            treeNode4.Text = "GMROI Summary";
            treeNode5.Name = "gmroi_root";
            treeNode5.Text = "GMROI";
            treeView2.Nodes.AddRange(new TreeNode[] { treeNode5 });
            treeView2.Size = new Size(290, 67);
            treeView2.TabIndex = 4;
            treeView2.AfterSelect += treeView2_AfterSelect;
            // 
            // mainstrptbutton2
            // 
            mainstrptbutton2.BackColor = Color.DarkMagenta;
            mainstrptbutton2.FlatStyle = FlatStyle.Popup;
            mainstrptbutton2.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mainstrptbutton2.ForeColor = Color.White;
            mainstrptbutton2.Location = new Point(22, 203);
            mainstrptbutton2.Name = "mainstrptbutton2";
            mainstrptbutton2.Size = new Size(260, 175);
            mainstrptbutton2.TabIndex = 3;
            mainstrptbutton2.Text = "GMROI";
            mainstrptbutton2.UseVisualStyleBackColor = false;
            mainstrptbutton2.Click += button2_Click;
            // 
            // btnCloseTreeView
            // 
            btnCloseTreeView.BackColor = Color.Red;
            btnCloseTreeView.FlatStyle = FlatStyle.Flat;
            btnCloseTreeView.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCloseTreeView.Location = new Point(616, 12);
            btnCloseTreeView.Name = "btnCloseTreeView";
            btnCloseTreeView.Size = new Size(35, 34);
            btnCloseTreeView.TabIndex = 2;
            btnCloseTreeView.Text = "X";
            btnCloseTreeView.UseVisualStyleBackColor = false;
            btnCloseTreeView.Click += btnCloseTreeView_Click;
            // 
            // treeView1
            // 
            treeView1.BackColor = Color.DarkMagenta;
            treeView1.BorderStyle = BorderStyle.None;
            treeView1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            treeView1.ForeColor = Color.White;
            treeView1.FullRowSelect = true;
            treeView1.HideSelection = false;
            treeView1.Location = new Point(320, 12);
            treeView1.Name = "treeView1";
            treeNode6.Name = "str_summary";
            treeNode6.Text = "STR Summary";
            treeNode7.Name = "str_list_form";
            treeNode7.Text = "STR List Form 2 Months";
            treeNode8.Name = "str_list_form3";
            treeNode8.Text = "STR List Form 3 Months";
            treeNode9.Name = "str_list_form6";
            treeNode9.Text = "STR List Form 6 Months";
            treeNode10.Name = "str_list_form9";
            treeNode10.Text = "STR List Form 9 Months";
            treeNode11.Name = "str_list_summary";
            treeNode11.Text = "STR List Summary 2 Mos";
            treeNode12.Name = "str_list_summary3";
            treeNode12.Text = "STR List Summary 3 Mos";
            treeNode13.Name = "str_list_summary6";
            treeNode13.Text = "STR List Summary 6 Mos";
            treeNode14.Name = "str_list_summary9";
            treeNode14.Text = "STR List Summary 9 Mos";
            treeNode15.Name = "image_path_validator";
            treeNode15.Text = "Image Path Validator (Admin)";
            treeNode16.ForeColor = Color.White;
            treeNode16.Name = "STR_Root";
            treeNode16.Text = "Sell-Thru Report";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode16 });
            treeView1.Size = new Size(290, 138);
            treeView1.TabIndex = 1;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // mainstrptbutton1
            // 
            mainstrptbutton1.BackColor = Color.DarkMagenta;
            mainstrptbutton1.FlatStyle = FlatStyle.Popup;
            mainstrptbutton1.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mainstrptbutton1.ForeColor = Color.White;
            mainstrptbutton1.Location = new Point(22, 12);
            mainstrptbutton1.Name = "mainstrptbutton1";
            mainstrptbutton1.Size = new Size(260, 175);
            mainstrptbutton1.TabIndex = 0;
            mainstrptbutton1.Text = "Sell-Thru Report";
            mainstrptbutton1.UseVisualStyleBackColor = false;
            mainstrptbutton1.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 573);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "APDI Reports";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button mainstrptbutton1;
        private TreeView treeView1;
        private Button btnCloseTreeView;
        private TreeView treeView2;
        private Button mainstrptbutton2;
        private Button btnCloseTreeView2;
        private Button mainstrptbutton3;
        private Button btnCloseTreeView3;
        private TreeView treeView3;
    }
}
