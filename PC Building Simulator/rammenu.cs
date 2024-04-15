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
    public partial class rammenu : Form
    {
        private MainApp mainApp;
        public rammenu(MainApp mainApp)
        {
            InitializeComponent();
            this.mainApp = mainApp;
            for (int i = 0; i < 20; i++)
            {
                Panel panel = (Panel)this.Controls.Find($"panel{i + 1}", true).FirstOrDefault();
                PictureBox pictureBox = (PictureBox)this.Controls.Find($"pbox{i + 1}", true).FirstOrDefault();
                System.Windows.Forms.Label nameLabel = (System.Windows.Forms.Label)this.Controls.Find($"labname{i + 1}", true).FirstOrDefault();
                System.Windows.Forms.Label priceLabel = (System.Windows.Forms.Label)this.Controls.Find($"labprice{i + 1}", true).FirstOrDefault();

                if (panel != null && pictureBox != null && nameLabel != null && priceLabel != null)
                {
                    panel.MouseLeave += Panel_MouseLeave;
                    panel.MouseMove += Panel_MouseMove;
                    panel.MouseDown += Panel1_MouseDown;
                    pictureBox.MouseMove += ChildControl_MouseMove;
                    nameLabel.MouseMove += ChildControl_MouseMove;
                    priceLabel.MouseMove += ChildControl_MouseMove;
                    pictureBox.MouseLeave += ChildControl_MouseLeave;
                    nameLabel.MouseLeave += ChildControl_MouseLeave;
                    priceLabel.MouseLeave += ChildControl_MouseLeave;
                    pictureBox.MouseDown += ChildControl_MouseDown;
                    nameLabel.MouseDown += ChildControl_MouseDown;
                    priceLabel.MouseDown += ChildControl_MouseDown;
                }
            }
        }
        private void rammenu_Load(object sender, EventArgs e)
        {
            InitializeDisplayManager();
        }

        private void InitializeDisplayManager()
        {
            rammenu ramMenuForm = this;
            DisplayManager displayManager = new DisplayManager(ramMenuForm);
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BorderStyle = BorderStyle.None;
            }
        }
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null && e.Button == MouseButtons.Left)
            {
                HandlePanelClick(panel);
            }
        }
        private void ChildControl_MouseMove(object sender, MouseEventArgs e)
        {
            Panel panel = GetPanelFromControl(sender as Control);
            if (panel != null)
            {
                Panel_MouseMove(panel, e);
            }
        }
        private void ChildControl_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = GetPanelFromControl(sender as Control);
            if (panel != null)
            {
                Panel_MouseLeave(panel, e);
            }
        }
        private void ChildControl_MouseDown(object sender, MouseEventArgs e)
        {
            Panel panel = GetPanelFromControl(sender as Control);
            if (panel != null && e.Button == MouseButtons.Left)
            {
                HandlePanelClick(panel);
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
        private void HandlePanelClick(Panel panel)
        {
            DisplayManager displayManager = new DisplayManager(mainApp);
            Panel[] panels = { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10,
                panel11, panel12, panel13, panel14, panel15, panel16, panel17, panel18, panel19, panel20
            };

            for (int i = 0; i < panels.Length; i++)
            {
                if (panel == panels[i])
                {
                    int menuIndex = i + 1;
                    displayManager.rammenu(menuIndex);
                    mainApp.backicon.Visible = true;
                    break;
                }
            }
        }
    }
}
