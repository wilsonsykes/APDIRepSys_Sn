using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;


namespace APDIRepSys
{
    

    public partial class SplashScreen : Form
    {

        private Label loadingLabel;
        private Timer dotTimer;
        private int dotCount = 0;
        public SplashScreen()
        {
            InitializeComponent();

            // 🔹 Create and style the label
            loadingLabel = new Label();
            loadingLabel.Text = "Loading";
            loadingLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            loadingLabel.AutoSize = true;
            loadingLabel.ForeColor = Color.Black;
            loadingLabel.BackColor = Color.Transparent;
            loadingLabel.Location = new Point((this.Width / 2) - 50, this.Height - 120);
            this.Controls.Add(loadingLabel);

            // 🔹 Timer to animate dots
            dotTimer = new Timer();
            dotTimer.Interval = 500; // every half second
            dotTimer.Tick += (s, e) =>
            {
                dotCount = (dotCount + 1) % 4;
                loadingLabel.Text = "Loading" + new string('.', dotCount);
            };
            dotTimer.Start();




            Timer closeTimer = new Timer();
            closeTimer.Interval = 3000; // 3 seconds (adjust as needed)
            closeTimer.Tick += (s, e) =>
            {
                closeTimer.Stop(); // stop the timer so it only triggers once
                this.Close();      // close the splash screen
            };
            closeTimer.Start();


            string imagePath = Path.Combine(Application.StartupPath, "Resources", "apdi_loadingscreen.png");
            if (File.Exists(imagePath))
            {
                this.BackgroundImage = Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                MessageBox.Show("Splash image not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Optional: Set window style
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.BackColor = Color.White; // Ensure a clean background if needed


        }


        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
