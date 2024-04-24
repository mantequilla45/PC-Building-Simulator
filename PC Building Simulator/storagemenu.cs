using ComponentFactory.Krypton.Toolkit;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace PC_Building_Simulator
{
    public partial class storagemenu : Form
    {
        private MainApp mainApp;
        private DisplayManager displayManager;
        public storagemenu(MainApp mainApp)
        {
            InitializeComponent();
            InitializeControls();
            this.mainApp = mainApp;
            displayManager = new DisplayManager(mainApp);
            InitializeDisplayManager();
        }
        private void InitializeDisplayManager()
        {
            storagemenu storagemenuform = this;
            DisplayManager displayManager = new DisplayManager(storagemenuform);
        }

        private void storagemenu_Load(object sender, EventArgs e)
        {
            
        }

        private void InitializeControls()
        {
            for (int i = 0; i < 3; i++)
            {
                Panel panel = (Panel)this.Controls.Find($"panel{i + 1}", true).FirstOrDefault();
                PictureBox pictureBox = (PictureBox)this.Controls.Find($"pBox{i + 1}", true).FirstOrDefault();
                KryptonButton border = (KryptonButton)this.Controls.Find($"border{i + 1}", true).FirstOrDefault();

                if (panel != null && pictureBox != null && border != null)
                {
                    panel.MouseLeave += Panel_MouseLeave;
                    panel.MouseMove += Panel_MouseMove;
                    panel.MouseDown += Panel_MouseDown;
                    border.MouseLeave += Panel_MouseLeave;
                    border.MouseMove += Panel_MouseMove;
                    border.MouseDown += Panel_MouseDown;
                    pictureBox.MouseLeave += ChildControl_MouseLeave;
                    pictureBox.MouseMove += ChildControl_MouseMove;
                    pictureBox.MouseDown += ChildControl_MouseDown;
                }
            }
        }
        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = GetPanelFromControl(sender as Control);
            if (panel != null)
            {
                KryptonButton border = GetBorderFromPanel(panel);
                if (border != null)
                {
                    border.StateCommon.Border.Color1 = Color.White; // Set border color to White (change as needed)
                }
            }
        }
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            Panel panel = GetPanelFromControl(sender as Control);
            if (panel != null)
            {
                KryptonButton border = GetBorderFromPanel(panel);
                if (border != null)
                {
                    border.StateCommon.Border.Color1 = Color.Silver; // Set border color to Red (change as needed)
                }
            }
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

        private void Panel_MouseDown(object sender, MouseEventArgs e)
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
            Panel[] panels = { panel1, panel2, panel3};

            for (int i = 0; i < panels.Length; i++)
            {
                if (panel == panels[i])
                {
                    int menuIndex = i + 1;
                    switch (menuIndex)
                    {
                        case 1:
                            displayManager.menuselect(14);
                            break;
                        case 2:
                            displayManager.menuselect(15);
                            break;
                        case 3:
                            displayManager.menuselect(16);
                            break;
                            // Add more cases for other menus if needed
                    }
                }
            }
            mainApp.backicon.Visible = true;
        }
    }
}
