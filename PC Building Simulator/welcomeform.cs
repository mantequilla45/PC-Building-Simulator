using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PC_Building_Simulator
{
    public partial class welcomeform : Form
    {
        public int buildnum = 0;
        private MainApp mainApp;
        private buildguide buildGuide;
        private DisplayManager displayManager;
        public welcomeform(MainApp mainApp)
        {
            InitializeComponent();
            this.mainApp = mainApp;
            displayManager = new DisplayManager(mainApp);
            InitializeControls();
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
            mainApp.butt_home.Image = Properties.Resources.Home_icon_2;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Properties.Resources.Proceed_Icon;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.Proceed_Icon1;
        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox7.Image = Properties.Resources.Proceed_Icon;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.Proceed_Icon1;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            DisplayManager.ButtonAppearance.Activate.Build(displayManager.mainApp);
            displayManager.menuselect(1);
            mainApp.butt_home.Image = Properties.Resources.Home_icon_2;
            mainApp.butt_refresh.Image = Properties.Resources.Refresh1;
        }

        private void InitializeControls()
        {
            for (int i = 1; i <= 2; i++)
            {
                Panel panelBuild = (Panel)this.Controls.Find($"panelbuild{i}", true).FirstOrDefault();
                panelBuild.Tag = i;
                KryptonButton buildBorder = (KryptonButton)this.Controls.Find($"buildborder{i}", true).FirstOrDefault();
                PictureBox pCase = (PictureBox)this.Controls.Find($"pcase{i}", true).FirstOrDefault();
                PictureBox pCpu = (PictureBox)this.Controls.Find($"pcpu{i}", true).FirstOrDefault();
                PictureBox pGpu = (PictureBox)this.Controls.Find($"pgpu{i}", true).FirstOrDefault();
                Label labelTitle = (Label)this.Controls.Find($"label_title{i}", true).FirstOrDefault();
                Label labelCase = (Label)this.Controls.Find($"labelcase{i}", true).FirstOrDefault();
                Label labelCpu = (Label)this.Controls.Find($"labelcpu{i}", true).FirstOrDefault();
                Label labelGpu = (Label)this.Controls.Find($"labelgpu{i}", true).FirstOrDefault();

                if (panelBuild != null && buildBorder != null && pCase != null && pCpu != null && pGpu != null && labelTitle != null && labelCase != null && labelCpu != null && labelGpu != null)
                {
                    panelBuild.MouseLeave += PanelBuild_MouseLeave;
                    panelBuild.MouseMove += PanelBuild_MouseMove;
                    panelBuild.MouseDown += PanelBuild_MouseDown;
                    buildBorder.MouseLeave += PanelBuild_MouseLeave;
                    buildBorder.MouseMove += PanelBuild_MouseMove;
                    buildBorder.MouseDown += PanelBuild_MouseDown;
                    pCase.MouseLeave += ChildControl_MouseLeave;
                    pCase.MouseMove += ChildControl_MouseMove;
                    pCase.MouseDown += ChildControl_MouseDown;
                    pCpu.MouseLeave += ChildControl_MouseLeave;
                    pCpu.MouseMove += ChildControl_MouseMove;
                    pCpu.MouseDown += ChildControl_MouseDown;
                    pGpu.MouseLeave += ChildControl_MouseLeave;
                    pGpu.MouseMove += ChildControl_MouseMove;
                    pGpu.MouseDown += ChildControl_MouseDown;
                    labelTitle.MouseLeave += ChildControl_MouseLeave;
                    labelTitle.MouseMove += ChildControl_MouseMove;
                    labelTitle.MouseDown += ChildControl_MouseDown;
                    labelCase.MouseLeave += ChildControl_MouseLeave;
                    labelCase.MouseMove += ChildControl_MouseMove;
                    labelCase.MouseDown += ChildControl_MouseDown;
                    labelCpu.MouseLeave += ChildControl_MouseLeave;
                    labelCpu.MouseMove += ChildControl_MouseMove;
                    labelCpu.MouseDown += ChildControl_MouseDown;
                    labelGpu.MouseLeave += ChildControl_MouseLeave;
                    labelGpu.MouseMove += ChildControl_MouseMove;
                    labelGpu.MouseDown += ChildControl_MouseDown;
                }
            }
        }

        private void PanelBuild_MouseLeave(object sender, EventArgs e)
        {
            Panel panelBuild = sender as Panel;
            if (panelBuild != null)
            {
                KryptonButton buildBorder = GetBorderFromPanel(panelBuild);
                if (buildBorder != null)
                {
                    buildBorder.StateCommon.Border.Color1 = Color.Silver; // Set border color to White (change as needed)
                }
            }
        }

        private void PanelBuild_MouseMove(object sender, MouseEventArgs e)
        {
            Panel panelBuild = sender as Panel;
            if (panelBuild != null)
            {
                KryptonButton buildBorder = GetBorderFromPanel(panelBuild);
                if (buildBorder != null)
                {
                    buildBorder.StateCommon.Border.Color1 = Color.Gray; // Set border color to Red (change as needed)
                }
            }
        }

        private void ChildControl_MouseMove(object sender, MouseEventArgs e)
        {
            Control childControl = sender as Control;
            if (childControl != null)
            {
                Panel panelBuild = GetPanelFromControl(childControl);
                if (panelBuild != null)
                {
                    PanelBuild_MouseMove(panelBuild, e);
                }
            }
        }

        private void ChildControl_MouseLeave(object sender, EventArgs e)
        {
            Control childControl = sender as Control;
            if (childControl != null)
            {
                Panel panelBuild = GetPanelFromControl(childControl);
                if (panelBuild != null)
                {
                    PanelBuild_MouseLeave(panelBuild, e);
                }
            }
        }


        private Panel GetPanelFromControl(Control control)
        {
            while (control != null && !(control is Panel))
            {
                control = control.Parent;
            }
            return control as Panel;
        }

        private KryptonButton GetBorderFromPanel(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is KryptonButton)
                {
                    return (KryptonButton)control;
                }
            }
            return null;
        }

        private void PanelBuild_MouseDown(object sender, MouseEventArgs e)
        {
            Panel panelBuild = sender as Panel;
            if (panelBuild != null && e.Button == MouseButtons.Left)
            {
                HandlePanelClick(panelBuild);
            }
        }

        private void ChildControl_MouseDown(object sender, MouseEventArgs e)
        {
            Control childControl = sender as Control;
            if (childControl != null && e.Button == MouseButtons.Left)
            {
                Panel panelBuild = GetPanelFromControl(childControl);
                if (panelBuild != null)
                {
                    HandlePanelClick(panelBuild);
                }
            }
        }

        private void HandlePanelClick(Panel panel)
        {
            mainApp.panelmain.Controls.Clear();
            mainApp.butt_home.Image = Properties.Resources.Home_icon_2;
            int buildIndex = Convert.ToInt32(panel.Tag);

            completedbuilds completedbuild = new completedbuilds(mainApp, buildIndex)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };

            mainApp.panelmain.Controls.Add(completedbuild);
            completedbuild.Show();
        }

    }
}
