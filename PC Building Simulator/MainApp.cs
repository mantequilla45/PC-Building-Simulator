using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Data.OleDb;

namespace PC_Building_Simulator
{
    public partial class MainApp : KryptonForm
    {
        bool clicked;
        public int back = 0;
        public string username;
        private DisplayManager displayManager;
        private DatabaseManager dbManager;
        string user1;
        public MainApp(string username)
        {
            InitializeComponent();
            string user1 = username;
            this.username = username;
            userlabel.Text = username;
            displayManager = new DisplayManager(this);
            displayManager.menuselect(1);
            dbManager = new DatabaseManager("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");
            dbManager.OpenConnection();
            string checkAdminQuery = "SELECT * FROM users WHERE username = @Username AND usertype = @UserType";
            using (OleDbCommand cmd = new OleDbCommand(checkAdminQuery, dbManager.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Username", username); 
                cmd.Parameters.AddWithValue("@UserType", "admin");

                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        label_admin.Visible = true;
                    }
                }
            }
            string saveBuildQuery = "INSERT INTO Builds ([user]) SELECT @Username WHERE NOT EXISTS (SELECT 1 FROM Builds WHERE [user] = @Username)";

            using (OleDbCommand cmd = new OleDbCommand(saveBuildQuery, dbManager.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Username", username);
            }
            dbManager.CloseConnection();

            but_build_Click(this, EventArgs.Empty);
        }

        private void MainApp_Load(object sender, EventArgs e)
        {
        }
        //------------------------------ build button -----------------------------
        private void but_build_Click(object sender, EventArgs e)
        {
            if(label_menu.Text == "Your Build")
            {

            }
            else
            {
                backicon.Visible = false;
                clicked = true;
                displayManager.otherButton_Click(clicked);
                displayManager.menuselect(1);
                DisplayManager.ButtonAppearance.Activate.Build(displayManager.mainApp);

            }
        }
        private void but_build_MouseMove(object sender, MouseEventArgs e)
        {
           if (clicked && !bluebar1.Visible)
            {
                DisplayManager.ButtonAppearance.Activate.Build(displayManager.mainApp);
                bluebar1.Visible = false;
            }
        }
        private void but_build_MouseLeave(object sender, EventArgs e)
        {
            if (clicked && !bluebar1.Visible)
            {
                DisplayManager.ButtonAppearance.Reset.Build(displayManager.mainApp);
            }
        }
        //---------------------------------------------------------------------------

        //------------------------------ cpu menu -----------------------------------
        private void but_cpu_Click(object sender, EventArgs e)
        {
            if (label_menu.Text == "CPU")
            {

            }
            else
            {
                backicon.Visible = false;
                back = 1;
                clicked = true;
                displayManager.otherButton_Click(clicked);
                displayManager.menuselect(2);
                DisplayManager.ButtonAppearance.Activate.CPU(displayManager.mainApp);
            }
        }
        private void but_cpu_MouseMove(object sender, MouseEventArgs e)
        {
            if(!clicked)
            {
                DisplayManager.ButtonAppearance.Activate.CPU(displayManager.mainApp);
                bluebar2.Visible = false;
            }

            else if (clicked && !bluebar2.Visible)
            {
                DisplayManager.ButtonAppearance.Activate.CPU(displayManager.mainApp);
                bluebar2.Visible = false;
            }
        }

        private void but_cpu_MouseLeave(object sender, EventArgs e)
        {
            if (!clicked)
                DisplayManager.ButtonAppearance.Reset.CPU(displayManager.mainApp);

            else if (clicked && !bluebar2.Visible)
            {
                DisplayManager.ButtonAppearance.Reset.CPU(displayManager.mainApp);
                bluebar2.Visible = false;
            }
        }
        //---------------------------------------------------------------------------

        //------------------------------ gpu menu -----------------------------------
        private void but_gpu_Click(object sender, EventArgs e)
        {
            if (label_menu.Text == "GPU")
            {

            }
            else
            {
                backicon.Visible = false;
                back = 2;
                clicked = true;
                displayManager.otherButton_Click(clicked);
                displayManager.menuselect(3);
                DisplayManager.ButtonAppearance.Activate.GPU(displayManager.mainApp);
            }
        }

        private void but_gpu_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clicked)
            {
                DisplayManager.ButtonAppearance.Activate.GPU(displayManager.mainApp);
                bluebar3.Visible = false;
            }

            else if (clicked && !bluebar3.Visible)
            {
                DisplayManager.ButtonAppearance.Activate.GPU(displayManager.mainApp);
                bluebar3.Visible = false;
            }
        }

        private void but_gpu_MouseLeave(object sender, EventArgs e)
        {
            if (!clicked)
                DisplayManager.ButtonAppearance.Reset.GPU(displayManager.mainApp);

            else if (clicked && !bluebar3.Visible)
            {
                DisplayManager.ButtonAppearance.Reset.GPU(displayManager.mainApp);
                bluebar3.Visible = false;
            }
        }
        //---------------------------------------------------------------------------

        //------------------------------ motherboard menu ---------------------------
        private void but_mb_Click(object sender, EventArgs e)
        {
            if (label_menu.Text == "Motherboard")
            {

            }
            else
            {
                backicon.Visible = false;
                back = 3;
                clicked = true;
                displayManager.otherButton_Click(clicked);
                displayManager.menuselect(4);
                DisplayManager.ButtonAppearance.Activate.Motherboard(displayManager.mainApp);
            }
        }
        private void but_mb_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clicked)
            {
                DisplayManager.ButtonAppearance.Activate.Motherboard(displayManager.mainApp);
                bluebar4.Visible = false;
            }

            else if (clicked && !bluebar4.Visible)
            {
                DisplayManager.ButtonAppearance.Activate.Motherboard(displayManager.mainApp);
                bluebar4.Visible = false;
            }
        }

        private void but_mb_MouseLeave(object sender, EventArgs e)
        {
            if (!clicked)
                DisplayManager.ButtonAppearance.Reset.Motherboard(displayManager.mainApp);

            else if (clicked && !bluebar4.Visible)
            {
                DisplayManager.ButtonAppearance.Reset.Motherboard(displayManager.mainApp);
                bluebar4.Visible = false;
            }
        }

        //---------------------------------------------------------------------------

        //------------------------------ ram menu -----------------------------------
        private void but_ram_Click(object sender, EventArgs e)
        {
            if (label_menu.Text == "RAM Module")
            {

            }
            else
            {
                backicon.Visible = false;
                back = 4;
                clicked = true;
                displayManager.otherButton_Click(clicked);
                displayManager.menuselect(5);
                DisplayManager.ButtonAppearance.Activate.RAM(displayManager.mainApp);
            }
        }
        private void but_ram_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clicked)
            {
                DisplayManager.ButtonAppearance.Activate.RAM(displayManager.mainApp);
                bluebar5.Visible = false;
            }

            else if (clicked && !bluebar5.Visible)
            {
                DisplayManager.ButtonAppearance.Activate.RAM(displayManager.mainApp);
                bluebar5.Visible = false;
            }
        }

        private void but_ram_MouseLeave(object sender, EventArgs e)
        {
            if (!clicked)
                DisplayManager.ButtonAppearance.Reset.RAM(displayManager.mainApp);

            else if (clicked && !bluebar5.Visible)
            {
                DisplayManager.ButtonAppearance.Reset.RAM(displayManager.mainApp);
                bluebar5.Visible = false;
            }
        }
        //---------------------------------------------------------------------------

        //------------------------------ storage menu -------------------------------
        private void but_storage_Click(object sender, EventArgs e)
        {
            backicon.Visible = false;
            back = 5;
            clicked = true;
            displayManager.otherButton_Click(clicked);
            displayManager.menuselect(6);
            DisplayManager.ButtonAppearance.Activate.Storage(displayManager.mainApp);
        }

        private void but_storage_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clicked)
            {
                DisplayManager.ButtonAppearance.Activate.Storage(displayManager.mainApp);
                bluebar6.Visible = false;
            }

            else if (clicked && !bluebar6.Visible)
            {
                DisplayManager.ButtonAppearance.Activate.Storage(displayManager.mainApp);
                bluebar6.Visible = false;
            }
        }

        private void but_storage_MouseLeave(object sender, EventArgs e)
        {
            if (!clicked)
                DisplayManager.ButtonAppearance.Reset.Storage(displayManager.mainApp);

            else if (clicked && !bluebar6.Visible)
            {
                DisplayManager.ButtonAppearance.Reset.Storage(displayManager.mainApp);
                bluebar6.Visible = false;
            }
        }
        //---------------------------------------------------------------------------

        //------------------------------ psu menu -----------------------------------
        private void but_psu_Click(object sender, EventArgs e)
        {
            if (label_menu.Text == "PSU")
            {

            }
            else
            {
                backicon.Visible = false;
                back = 6;
                clicked = true;
                displayManager.otherButton_Click(clicked);
                displayManager.menuselect(7);
                DisplayManager.ButtonAppearance.Activate.PSU(displayManager.mainApp);
            }
        }
        private void but_psu_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clicked)
            {
                DisplayManager.ButtonAppearance.Activate.PSU(displayManager.mainApp);
                bluebar7.Visible = false;
            }

            else if (clicked && !bluebar7.Visible)
            {
                DisplayManager.ButtonAppearance.Activate.PSU(displayManager.mainApp);
                bluebar7.Visible = false;
            }
        }

        private void but_psu_MouseLeave(object sender, EventArgs e)
        {
            if (!clicked)
                DisplayManager.ButtonAppearance.Reset.PSU(displayManager.mainApp);

            else if (clicked && !bluebar7.Visible)
            {
                DisplayManager.ButtonAppearance.Reset.PSU(displayManager.mainApp);
                bluebar7.Visible = false;
            }
        }
        //---------------------------------------------------------------------------

        //------------------------------ case menu ----------------------------------
        private void but_case_Click(object sender, EventArgs e)
        {
            if (label_menu.Text == "Computer Case")
            {

            }
            else
            {
                backicon.Visible = false;
                back = 7;
                clicked = true;
                displayManager.otherButton_Click(clicked);
                displayManager.menuselect(8);
                DisplayManager.ButtonAppearance.Activate.Case(displayManager.mainApp);
            }
        }

        private void but_case_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clicked)
            {
                DisplayManager.ButtonAppearance.Activate.Case(displayManager.mainApp);
                bluebar8.Visible = false;
            }

            else if (clicked && !bluebar8.Visible)
            {
                DisplayManager.ButtonAppearance.Activate.Case(displayManager.mainApp);
                bluebar8.Visible = false;
            }
        }

        private void but_case_MouseLeave(object sender, EventArgs e)
        {
            if (!clicked)
                DisplayManager.ButtonAppearance.Reset.Case(displayManager.mainApp);

            else if (clicked && !bluebar8.Visible)
            {
                DisplayManager.ButtonAppearance.Reset.Case(displayManager.mainApp);
                bluebar8.Visible = false;
            }
        }
        //---------------------------------------------------------------------------

        //------------------------------ cooler menu --------------------------------
        private void but_cooler_Click(object sender, EventArgs e)
        {
            backicon.Visible = false;
            back = 8;
            clicked = true;
            displayManager.otherButton_Click(clicked);
            displayManager.menuselect(9);
            DisplayManager.ButtonAppearance.Activate.Cooler(displayManager.mainApp);
        }

        private void but_cooler_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clicked)
            {
                DisplayManager.ButtonAppearance.Activate.Cooler(displayManager.mainApp);
                bluebar9.Visible = false;
            }

            else if (clicked && !bluebar9.Visible)
            {
                DisplayManager.ButtonAppearance.Activate.Cooler(displayManager.mainApp);
                bluebar9.Visible = false;
            }
        }

        private void but_cooler_MouseLeave(object sender, EventArgs e)
        {
            if (!clicked)
                DisplayManager.ButtonAppearance.Reset.Cooler(displayManager.mainApp);

            else if (clicked && !bluebar9.Visible)
            {
                DisplayManager.ButtonAppearance.Reset.Cooler(displayManager.mainApp);
                bluebar9.Visible = false;
            }
        }
        //---------------------------------------------------------------------------

        //------------------------------ monitor menu -------------------------------
        private void but_monitor_Click(object sender, EventArgs e)
        {
            if (label_menu.Text == "Monitor")
            {
                
            }
            else
            {
                backicon.Visible = false;
                back = 9;
                clicked = true;
                displayManager.otherButton_Click(clicked);
                displayManager.menuselect(10);
                DisplayManager.ButtonAppearance.Activate.Monitor(displayManager.mainApp);
            }
                
        }

        private void but_monitor_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clicked)
            {
                DisplayManager.ButtonAppearance.Activate.Monitor(displayManager.mainApp);
                bluebar10.Visible = false;
            }

            else if (clicked && !bluebar10.Visible)
            {
                DisplayManager.ButtonAppearance.Activate.Monitor(displayManager.mainApp);
                bluebar10.Visible = false;
            }
        }

        private void but_monitor_MouseLeave(object sender, EventArgs e)
        {
            if (!clicked)
                DisplayManager.ButtonAppearance.Reset.Monitor(displayManager.mainApp);

            else if (clicked && !bluebar10.Visible)
            {
                DisplayManager.ButtonAppearance.Reset.Monitor(displayManager.mainApp);
                bluebar10.Visible = false;
            }
        }
        //---------------------------------------------------------------------------

        //------------------------------ keyboard menu ------------------------------
        private void but_keyb_Click(object sender, EventArgs e)
        {
            if (label_menu.Text == "Keyboard")
            {

            }
            else
            {
                backicon.Visible = false;
                back = 10;
                clicked = true;
                displayManager.otherButton_Click(clicked);
                displayManager.menuselect(11);
                DisplayManager.ButtonAppearance.Activate.Keyboard(displayManager.mainApp);
            }
        }

        private void but_keyb_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clicked)
            {
                DisplayManager.ButtonAppearance.Activate.Keyboard(displayManager.mainApp);
                bluebar11.Visible = false;
            }

            else if (clicked && !bluebar11.Visible)
            {
                DisplayManager.ButtonAppearance.Activate.Keyboard(displayManager.mainApp);
                bluebar11.Visible = false;
            }
        }

        private void but_keyb_MouseLeave(object sender, EventArgs e)
        {
            if (!clicked)
                DisplayManager.ButtonAppearance.Reset.Keyboard(displayManager.mainApp);

            else if (clicked && !bluebar11.Visible)
            {
                DisplayManager.ButtonAppearance.Reset.Keyboard(displayManager.mainApp);
                bluebar11.Visible = false;
            }
        }
        //---------------------------------------------------------------------------

        //------------------------------ mouse menu ---------------------------------
        private void but_mouse_Click(object sender, EventArgs e)
        {
            if (label_menu.Text == "Mouse")
            {

            }
            else
            {
                backicon.Visible = false;
                back = 11;
                clicked = true;
                displayManager.otherButton_Click(clicked);
                displayManager.menuselect(12);
                DisplayManager.ButtonAppearance.Activate.Mouse(displayManager.mainApp);
            }
        }

        private void but_mouse_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clicked)
            {
                DisplayManager.ButtonAppearance.Activate.Mouse(displayManager.mainApp);
                bluebar12.Visible = false;
            }

            else if (clicked && !bluebar12.Visible)
            {
                DisplayManager.ButtonAppearance.Activate.Mouse(displayManager.mainApp);
                bluebar12.Visible = false;
            }
        }

        private void but_mouse_MouseLeave(object sender, EventArgs e)
        {
            if (!clicked)
                DisplayManager.ButtonAppearance.Reset.Mouse(displayManager.mainApp);

            else if (clicked && !bluebar12.Visible)
            {
                DisplayManager.ButtonAppearance.Reset.Mouse(displayManager.mainApp);
                bluebar12.Visible = false;
            }
        }
        //---------------------------------------------------------------------------

        //------------------------------ speakers menu ------------------------------
        private void but_speakers_Click(object sender, EventArgs e)
        {
            if (label_menu.Text == "Speakers")
            {

            }
            else
            {
                backicon.Visible = false;
                back = 12;
                clicked = true;
                displayManager.otherButton_Click(clicked);
                displayManager.menuselect(13);
                DisplayManager.ButtonAppearance.Activate.Speakers(displayManager.mainApp);
            }
        }

        private void but_speakers_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clicked)
            {
                DisplayManager.ButtonAppearance.Activate.Speakers(displayManager.mainApp);
                bluebar13.Visible = false;
            }

            else if (clicked && !bluebar13.Visible)
            {
                DisplayManager.ButtonAppearance.Activate.Speakers(displayManager.mainApp);
                bluebar13.Visible = false;
            }
        }

        private void but_speakers_MouseLeave(object sender, EventArgs e)
        {
            if (!clicked)
                DisplayManager.ButtonAppearance.Reset.Speakers(displayManager.mainApp);

            else if (clicked && !bluebar13.Visible)
            {
                DisplayManager.ButtonAppearance.Reset.Speakers(displayManager.mainApp);
                bluebar13.Visible = false;
            }
        }

        //---------------------------------------------------------------------------

        //------------------------------ logout -------------------------------------
        private void label_logout_Click(object sender, EventArgs e)
        {

            this.Hide();
            loginform loginFormInstance = Application.OpenForms["loginform"] as loginform;
            if (loginFormInstance == null)
            {
                loginFormInstance = new loginform();
            }
            loginFormInstance.Show();
        }
        //---------------------------------------------------------------------------

        //------------------------------ profile menu -------------------------------


        private void lab_profile_Click(object sender, EventArgs e)
        {
            backicon.Visible = false;
            clicked = true;
            panelmain.Controls.Clear();
            profilemenu profilepanel = new profilemenu() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            profilepanel.FormBorderStyle = FormBorderStyle.None;
            panelmain.Controls.Add(profilepanel);
            displayManager.otherButton_Click(clicked); label_menu.Text = "Profile";
            profilepanel.Show();
        }

        private adminpanel adforms;
        private void label_admin_Click(object sender, EventArgs e)
        {
            // Check if the admin panel form is null or disposed
            if (adforms == null || adforms.IsDisposed)
            {
                // If it is, create a new instance
                adforms = new adminpanel();
                adforms.FormClosed += (s, args) => adforms = null; // Reset the reference when the form is closed
                adforms.Show();
            }
            else
            {
                // If it's already open, bring it to the front
                adforms.BringToFront();
            }
        }

        private void label_admin_MouseLeave(object sender, EventArgs e)
        {
            label_admin.ForeColor = Color.Black;
        }

        private void label_admin_MouseMove(object sender, MouseEventArgs e)
        {
            label_admin.ForeColor = Color.FromArgb(86, 29, 137);
        }

        private void backicon_Click(object sender, EventArgs e)
        {
            MainApp mainApp = new MainApp(username);
            switch (back)
            {

                case 1:
                    displayManager.menuselect(2);
                    backicon.Visible = false;
                    break;
                case 2:
                    displayManager.menuselect(3);
                    backicon.Visible = false;
                    break;
                case 3:
                    displayManager.menuselect(4);
                    backicon.Visible = false;
                    break;
                case 4:
                    displayManager.menuselect(5);
                    backicon.Visible = false;
                    break;
                case 5:
                    displayManager.menuselect(6);
                    backicon.Visible = false;
                    break;
                case 6:
                    displayManager.menuselect(7);
                    backicon.Visible = false;
                    break;
                case 7:
                    displayManager.menuselect(8);
                    backicon.Visible = false;
                    break;
                case 8:
                    displayManager.menuselect(9);
                    backicon.Visible = false;
                    break;
                case 9:
                    displayManager.menuselect(10);
                    backicon.Visible = false;
                    break;
                case 10:
                    displayManager.menuselect(11);
                    backicon.Visible = false;
                    break;
                case 11:
                    displayManager.menuselect(12);
                    backicon.Visible = false;
                    break;
                case 12:
                    displayManager.menuselect(13);
                    backicon.Visible = false;
                    break;
                case 13:
                    displayManager.menuselect(14);
                    back = 5;
                    break;

                default:
                    break;

            }
        }


        private void lab_profile_MouseLeave(object sender, EventArgs e)
        {
            lab_profile.ForeColor = Color.Black;
        }

        private void lab_profile_MouseMove(object sender, MouseEventArgs e)
        {

            lab_profile.ForeColor = Color.FromArgb(86, 29, 137);
        }

        private void backicon_MouseLeave(object sender, EventArgs e)
        {
            backicon.BackColor = Color.WhiteSmoke;
        }

        private void keybicon2_Click(object sender, EventArgs e)
        {

        }
    }
}
