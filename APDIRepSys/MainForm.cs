using APDIRepSys.GMROI;                    // Reference to GMROI form namespace
using APDIRepSys.RFMDForm;
using APDIRepSys.STRptForm;               // Reference to SellThrough report forms
using APDIRepSys.Admin;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace APDIRepSys
{
    public partial class MainForm : Form
    {
        private bool isLoadingForm = false; // Prevents multiple forms from opening simultaneously

        public MainForm()
        {
            InitializeComponent();

            // Initially hide both tree views and their close buttons
            treeView1.Visible = false;
            btnCloseTreeView.Visible = false;
            treeView2.Visible = false;
            btnCloseTreeView2.Visible = false;
            treeView3.Visible = false;
            btnCloseTreeView3.Visible = false;
        }

        // Show STR TreeView when Button1 is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Visible = true;
            btnCloseTreeView.Visible = true;
            treeView2.Visible = false;
            btnCloseTreeView2.Visible = false;
            treeView3.Visible = false;
            btnCloseTreeView3.Visible = false;
        }

        // Show GMROI TreeView when Button2 is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            treeView2.Visible = true;
            btnCloseTreeView2.Visible = true;
            treeView1.Visible = false;
            btnCloseTreeView.Visible = false;
            treeView3.Visible = false;
            btnCloseTreeView3.Visible = false;
        }

        // Show RFMD Treeview when Button3 is clicked

        private void button3_Click(object sender, EventArgs e)
        {
            treeView3.Visible = true;
            btnCloseTreeView3.Visible = true;
            treeView1.Visible = false;
            btnCloseTreeView.Visible = false;
            treeView2.Visible = false;
            btnCloseTreeView2.Visible = false;
        }

        // Close STR TreeView
        private void btnCloseTreeView_Click(object sender, EventArgs e)
        {
            treeView1.Visible = false;
            btnCloseTreeView.Visible = false;

        }

        // Close GMROI TreeView
        private void btnCloseTreeView2_Click(object sender, EventArgs e)
        {
            treeView2.Visible = false;
            btnCloseTreeView2.Visible = false;
        }

        // Close RFMD TreeView

        private void btnCloseTreeView3_Click(object sender, EventArgs e)
        {
            treeView3.Visible = false;
            btnCloseTreeView3.Visible = false;
        }

        // Hide both tree views (acts like a global "close treeviews" button)
        private void button4_Click(object sender, EventArgs e)
        {
            treeView1.Visible = false;
            btnCloseTreeView.Visible = false;
            treeView2.Visible = false;
            btnCloseTreeView2.Visible = false;
        }

        // Handle STR tree node selection
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (isLoadingForm || e.Node?.Parent == null) return; // Only trigger if not loading and a child node is selected

            isLoadingForm = true;
            ShowLoadingOverlay(); // Display "Loading..." overlay

            try
            {
                // Dynamically get the form based on selected node name
                Form selectedForm = GetFormFromNode(e.Node.Name);

                if (selectedForm != null)
                {
                    // Close loading overlay when form is shown
                    selectedForm.Shown += (s, args) =>
                    {
                        CloseLoadingOverlay();
                        selectedForm.Activate(); // Bring form to front
                    };

                    // Reset loading state when form is closed
                    selectedForm.FormClosed += (s, args) =>
                    {
                        isLoadingForm = false;
                    };

                    selectedForm.Show(); // Show the form (non-modal)
                }
                else
                {
                    isLoadingForm = false;
                    CloseLoadingOverlay(); // No form found, just close overlay
                }
            }
            catch (Exception ex)
            {
                isLoadingForm = false;
                CloseLoadingOverlay(); // On error, close overlay and show message
                MessageBox.Show("Error loading form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle GMROI tree node selection (modal display)
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Parent == null) return;

            using (GmroiForm1 gmroiform1 = new GmroiForm1())
            {
                gmroiform1.ShowDialog(); // Show as modal dialog
            }

            treeView2.SelectedNode = null; // Reset selection to allow retriggering
        }


        // Handle RFMD tree node selection (non-modal display)
        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (isLoadingForm || e.Node?.Parent == null) return; // Only trigger if not loading and a child node is selected

            isLoadingForm = true;
            ShowLoadingOverlay(); // Display "Loading..." overlay

            try
            {
                // Dynamically get the form based on selected node name
                Form selectedForm = GetFormFromNode(e.Node.Name);

                if (selectedForm != null)
                {
                    // Close loading overlay when form is shown
                    selectedForm.Shown += (s, args) =>
                    {
                        CloseLoadingOverlay();
                        selectedForm.Activate(); // Bring form to front
                    };

                    // Reset loading state when form is closed
                    selectedForm.FormClosed += (s, args) =>
                    {
                        isLoadingForm = false;
                    };

                    selectedForm.Show(); // Show the form (non-modal)
                }
                else
                {
                    isLoadingForm = false;
                    CloseLoadingOverlay(); // No form found, just close overlay
                }
            }
            catch (Exception ex)
            {
                isLoadingForm = false;
                CloseLoadingOverlay(); // On error, close overlay and show message
                MessageBox.Show("Error loading form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Returns a form instance based on node name
        private Form GetFormFromNode(string nodeName)
        {
            return nodeName switch
            {
                "str_summary" => new Sellthrough(),
                "str_list_form" => new STRpt2(),
                "str_list_form3" => new STRpt3(),
                "str_list_form6" => new STRpt6(),
                "str_list_form9" => new STRpt9(),
                "str_list_summary" => new SysSTRpt2(),
                "str_list_summary3" => new SysSTRpt3(),
                "str_list_summary6" => new SysSTRpt6(),
                "str_list_summary9" => new SysSTRpt9(),
                "image_path_validator" => new ImagePathValidatorForm(),
                "create_rfmd" => new RfmdMainForm(),
                "rfmd_list" => new RfmdRecSummary(),
                "rfmd_memo" => new RfmdMemo(),

                _ => null // Return null if node name is unrecognized
            };
        }

        // Show a simple loading form overlay
        private void ShowLoadingOverlay()
        {
            if (Application.OpenForms["LoadingOverlay"] != null) return;

            Form loadingOverlay = new Form
            {
                Name = "LoadingOverlay",
                StartPosition = FormStartPosition.CenterScreen,
                Size = new System.Drawing.Size(250, 100),
                FormBorderStyle = FormBorderStyle.None,
                ControlBox = false,
                TopMost = true,
                BackColor = System.Drawing.Color.White,
                ShowInTaskbar = false
            };

            Label loadingLabel = new Label
            {
                Text = "Loading, please wait...",
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            loadingOverlay.Controls.Add(loadingLabel);
            loadingOverlay.Show();
            loadingOverlay.Refresh(); // Ensure UI refresh
        }

        // Close and dispose the loading overlay
        private void CloseLoadingOverlay()
        {
            Form loadingOverlay = Application.OpenForms["LoadingOverlay"];

            if (loadingOverlay != null && loadingOverlay.IsHandleCreated)
            {
                if (loadingOverlay.InvokeRequired)
                {
                    loadingOverlay.Invoke(new MethodInvoker(() =>
                    {
                        loadingOverlay.Close();
                        loadingOverlay.Dispose();
                    }));
                }
                else
                {
                    loadingOverlay.Close();
                    loadingOverlay.Dispose();
                }
            }
        }

        // Optional: Reserved for startup logic
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Currently unused — safe to remove if never hooked
        }

    }
}
