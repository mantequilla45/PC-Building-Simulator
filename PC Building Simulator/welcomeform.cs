using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Building_Simulator
{
    public partial class welcomeform : Form
    {
        private MainApp mainApp;
        private buildguide buildGuide;
        private DisplayManager displayManager;
        public welcomeform(MainApp mainApp)
        {
            InitializeComponent();
            this.mainApp = mainApp;
            displayManager = new DisplayManager(mainApp);
            InitializeDisplayManager();
        }

        private void InitializeDisplayManager()
        {
            welcomeform welcomeform = this;
            DisplayManager displayManager = new DisplayManager(welcomeform);
        }

        private void welcomeform_Load(object sender, EventArgs e)
        {
            label_name.Text = mainApp.username;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            mainApp.label_menu.Text = "Guide";
            mainApp.panelmain.Controls.Clear();
            buildguide buildGuide = new buildguide(mainApp) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            buildGuide.FormBorderStyle = FormBorderStyle.None;
            mainApp.panelmain.Controls.Add(buildGuide);
            buildGuide.Show();
        }
    }
}
