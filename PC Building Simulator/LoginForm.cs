using System;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;
using System.Data.OleDb;

namespace PC_Building_Simulator
{
    public partial class loginform : KryptonForm
    {
        public loginform()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void loginform_Load(object sender, EventArgs e)
        {

        }

        private void signupbut1_Click(object sender, EventArgs e)
        {
            SignupForm signupbut = new SignupForm (this);
            signupbut.Show();
            this.Hide();
        }
        private void but_login1_Click(object sender, EventArgs e)
        {
            con.Open();
            // Create a new OleDbCommand instance for the login query
            string loginQuery = "SELECT * FROM users WHERE username= ? AND password= ?";
            OleDbCommand loginCmd = new OleDbCommand(loginQuery, con);
            loginCmd.Parameters.AddWithValue("@username", txtbox_uname.Text);
            loginCmd.Parameters.AddWithValue("@password", txtbox_pass.Text);
            OleDbDataReader dr = loginCmd.ExecuteReader();

            // Update the current user in the 'currentuser' table
            string checkCurrentUserQuery = "SELECT COUNT(*) FROM currentuser";
            OleDbCommand checkCurrentUserCmd = new OleDbCommand(checkCurrentUserQuery, con);
            int rowCount = (int)checkCurrentUserCmd.ExecuteScalar();

            if (rowCount > 0)
            {
                // If a row exists, update it with the latest username
                string updateCurrentUserQuery = "UPDATE currentuser SET [user] = ?";
                OleDbCommand updateCurrentUserCmd = new OleDbCommand(updateCurrentUserQuery, con);
                updateCurrentUserCmd.Parameters.AddWithValue("@user", txtbox_uname.Text);
                int rowsAffected = updateCurrentUserCmd.ExecuteNonQuery();
            }
            else
            {
                // If no row exists, insert a new row with the username
                string insertCurrentUserQuery = "INSERT INTO currentuser ([user]) VALUES (?)";
                OleDbCommand insertCurrentUserCmd = new OleDbCommand(insertCurrentUserQuery, con);
                insertCurrentUserCmd.Parameters.AddWithValue("@user", txtbox_uname.Text);
                int rowsInserted = insertCurrentUserCmd.ExecuteNonQuery();
            }

            if (txtbox_uname.Text == "" && txtbox_pass.Text == "")
            {
                txtbox_uname.StateCommon.Border.Color1 = Color.Red;
                txtbox_uname.StateCommon.Border.Color2 = Color.Red;
                txtbox_pass.StateCommon.Border.Color1 = Color.Red;
                txtbox_pass.StateCommon.Border.Color2 = Color.Red;
                label_empu.Visible = true;
                label_empp.Visible = true;

            }
            else if (txtbox_uname.Text != "" && txtbox_pass.Text == "")
            {
                txtbox_pass.StateCommon.Border.Color1 = Color.Red;
                txtbox_pass.StateCommon.Border.Color2 = Color.Red;
                label_empp.Visible = true;

            }
            else if (dr.Read())
            {
                MainApp mainAppForm = new MainApp(txtbox_uname.Text);
                mainAppForm.Show();
                this.Hide();

                txtbox_pass.Text = "";
            }
            else
            {
                txtbox_uname.StateCommon.Border.Color1 = Color.Red;
                txtbox_uname.StateCommon.Border.Color2 = Color.Red;
                txtbox_pass.StateCommon.Border.Color1 = Color.Red;
                txtbox_pass.StateCommon.Border.Color2 = Color.Red;
                label_loger.Visible = true;
                label_empp.Visible = false;
            }
            con.Close();
        }

        private void ckbx_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbx_showpass.Checked)
            {
                txtbox_pass.PasswordChar = '\0';
            }

            else
            {

                txtbox_pass.PasswordChar = '•';
            }
            
        }

        private void txtbox_uname_TextChanged(object sender, EventArgs e)
        {
            txtbox_uname.StateCommon.Border.Color1 = Color.FromArgb(224, 224, 224);
            txtbox_uname.StateCommon.Border.Color2 = Color.FromArgb(224, 224, 224);
            txtbox_pass.StateCommon.Border.Color1 = Color.FromArgb(224, 224, 224);
            txtbox_pass.StateCommon.Border.Color2 = Color.FromArgb(224, 224, 224);
            label_loger.Visible = false;
            label_empu.Visible = false;
            label_empp.Visible = false;
        }

        private void txtbox_pass_TextChanged(object sender, EventArgs e)
        {

            txtbox_uname.StateCommon.Border.Color1 = Color.FromArgb(224, 224, 224);
            txtbox_uname.StateCommon.Border.Color2 = Color.FromArgb(224, 224, 224);
            txtbox_pass.StateCommon.Border.Color1 = Color.FromArgb(224, 224, 224);
            txtbox_pass.StateCommon.Border.Color2 = Color.FromArgb(224, 224, 224);
            label_loger.Visible = false;
            label_empu.Visible = false;
            label_empp.Visible = false;
        }
    }
}
