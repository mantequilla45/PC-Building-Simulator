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
    public partial class loginform : KryptonForm
    {
        public loginform()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_users.mdb");
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
            string login = "SELECT * FROM table_users WHERE username= '" + txtbox_uname.Text + "' and password= '" + txtbox_pass.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

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

            else if (txtbox_uname.Text == "" && txtbox_pass.Text != "")
            {

                txtbox_uname.StateCommon.Border.Color1 = Color.Red;
                txtbox_uname.StateCommon.Border.Color2 = Color.Red;

                label_empu.Visible = true;

            }


            else if (dr.Read() == true)
            {
                new MainApp().Show();
                this.Hide();
            }

            else
            {
                txtbox_uname.StateCommon.Border.Color1 = Color.Red;
                txtbox_uname.StateCommon.Border.Color2 = Color.Red;

                label_loger.Visible = true;

                label_empp.Visible = false;
            }
            con.Close();


            
        }

        private void label_emptu1_Click(object sender, EventArgs e)
        {

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
