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
    public partial class buildguide : Form
    {
        private MainApp mainApp;
        private DisplayManager displayManager;
        private object simulatedSender;
        EventArgs simulatedEventArgs = EventArgs.Empty;
        public buildguide(MainApp mainApp)
        {
            InitializeComponent();
            this.mainApp = mainApp;
            displayManager = new DisplayManager(mainApp);

            if (mainApp.label_menu.Text == "Guide")
            {
                mainApp.but_guide.StateCommon.Back.Color1 = Color.DimGray;
                mainApp.but_guide.StateCommon.Back.Color2 = Color.DimGray;
                mainApp.but_guide.StateCommon.Content.ShortText.Color1 = Color.White;
                mainApp.but_guide.StateTracking.Back.Color1 = Color.DimGray;
                mainApp.but_guide.StateTracking.Back.Color2 = Color.DimGray;
                mainApp.but_guide.StateTracking.Content.ShortText.Color1 = Color.White;
            }
            InitializeDisplayManager();
        }

        private void InitializeDisplayManager()
        {
            buildguide buildguide = this;
            DisplayManager displayManager = new DisplayManager(buildguide);
        }

        private void buildguide_Load(object sender, EventArgs e)
        {

        }

        private void choosecpu_Click(object sender, EventArgs e)
        {
            simulatedSender = kryptonButton1;
            mainApp.but_cpu_Click(simulatedSender, simulatedEventArgs);
        }

        private void choosemb_Click(object sender, EventArgs e)
        {
            simulatedSender = kryptonButton1;
            mainApp.but_mb_Click(simulatedSender, simulatedEventArgs);
        }

        private void chooseram_Click(object sender, EventArgs e)
        {
            simulatedSender = kryptonButton1;
            mainApp.but_ram_Click(simulatedSender, simulatedEventArgs);
        }

        private void choosegpu_Click(object sender, EventArgs e)
        {
            simulatedSender = kryptonButton1;
            mainApp.but_gpu_Click(simulatedSender, simulatedEventArgs);
        }

        private void choosepsu_Click(object sender, EventArgs e)
        {
            simulatedSender = kryptonButton1;
            mainApp.but_psu_Click(simulatedSender, simulatedEventArgs);
        }
        private void choosemoni_Click(object sender, EventArgs e)
        {
            simulatedSender = kryptonButton1;
            mainApp.but_monitor_Click(simulatedSender, simulatedEventArgs);
        }

        private void choosekeyb_Click(object sender, EventArgs e)
        {
            simulatedSender = kryptonButton1;
            mainApp.but_keyb_Click(simulatedSender, simulatedEventArgs);
        }

        private void choosespk_Click(object sender, EventArgs e)
        {
            simulatedSender = kryptonButton1;
            mainApp.but_speakers_Click(simulatedSender, simulatedEventArgs);
        }

        private void choosemouse_Click(object sender, EventArgs e)
        {
            simulatedSender = kryptonButton1;
            mainApp.but_mouse_Click(simulatedSender, simulatedEventArgs);
        }
        private void choosehdd_Click(object sender, EventArgs e)
        {
            DisplayManager.ButtonAppearance.Activate.Storage(displayManager.mainApp);
            displayManager.menuselect(14);
        }
        private void choosessd_Click(object sender, EventArgs e)
        {
            DisplayManager.ButtonAppearance.Activate.Storage(displayManager.mainApp);
            displayManager.menuselect(15);
        }

        private void choosem2_Click(object sender, EventArgs e)
        {
            DisplayManager.ButtonAppearance.Activate.Storage(displayManager.mainApp);
            displayManager.menuselect(16);
        }
        private void choosefans_Click(object sender, EventArgs e)
        {
            DisplayManager.ButtonAppearance.Activate.Cooler(displayManager.mainApp);
            displayManager.menuselect(17);
        }
        private void chooseair_Click(object sender, EventArgs e)
        {
            DisplayManager.ButtonAppearance.Activate.Cooler(displayManager.mainApp);
            displayManager.menuselect(18);
        }

        private void chooseaio_Click(object sender, EventArgs e)
        {
            DisplayManager.ButtonAppearance.Activate.Cooler(displayManager.mainApp);
            displayManager.menuselect(21);
        }

        
        private void label_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.FromArgb(44, 135, 195);
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.FromArgb(86, 29, 137);
        }

        private void pbox_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pbox_MouseLeave(object sender, EventArgs e)
        {

        }

    }
}
