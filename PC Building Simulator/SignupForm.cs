using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Data.OleDb;

namespace PC_Building_Simulator
{
    public partial class SignupForm : KryptonForm
    {
        loginform signupbut1;
        public SignupForm(loginform signpar)
        {
            InitializeComponent();
            this.signupbut1 = signpar;
        }


        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void SignupForm_Load(object sender, EventArgs e)
        {

        }

        private void but_signup2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_uname2.Text == "" && txtbox_pass2.Text == "" && txtbox_conpass2.Text == "")
                {
                    txtbox_uname2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_uname2.StateCommon.Border.Color2 = Color.Red;

                    txtbox_pass2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_pass2.StateCommon.Border.Color2 = Color.Red;

                    txtbox_conpass2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_conpass2.StateCommon.Border.Color2 = Color.Red;

                    label_emptu1.Visible = true; // user empty
                    label_emptu2.Visible = true; // pass1 empty
                    label_emptu3.Visible = true; // pass2 empty

                }

                else if (txtbox_uname2.Text == "" && txtbox_pass2.Text == "" && txtbox_conpass2.Text != "")
                {
                    txtbox_uname2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_uname2.StateCommon.Border.Color2 = Color.Red;

                    txtbox_pass2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_pass2.StateCommon.Border.Color2 = Color.Red;

                    label_emptu1.Visible = true;
                    label_emptu2.Visible = true;

                }
                else if (txtbox_uname2.Text == "" && txtbox_pass2.Text != "" && txtbox_conpass2.Text == "")
                {

                    txtbox_uname2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_uname2.StateCommon.Border.Color2 = Color.Red;

                    txtbox_conpass2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_conpass2.StateCommon.Border.Color2 = Color.Red;

                    label_emptu1.Visible = true;
                    label_emptu3.Visible = true;

                }
                else if (txtbox_uname2.Text != "" && txtbox_pass2.Text == "" && txtbox_conpass2.Text == "")
                {
                    txtbox_pass2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_pass2.StateCommon.Border.Color2 = Color.Red;

                    txtbox_conpass2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_conpass2.StateCommon.Border.Color2 = Color.Red;

                    label_emptu2.Visible = true;
                    label_emptu3.Visible = true;

                }
                else if (txtbox_uname2.Text == "" && txtbox_pass2.Text != "" && txtbox_conpass2.Text != "")
                {
                    txtbox_uname2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_uname2.StateCommon.Border.Color2 = Color.Red;

                    label_emptu1.Visible = true;

                }
                else if (txtbox_uname2.Text != "" && txtbox_pass2.Text == "" && txtbox_conpass2.Text != "")
                {

                    txtbox_pass2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_pass2.StateCommon.Border.Color2 = Color.Red;

                    label_emptu2.Visible = true;

                }
                else if (txtbox_uname2.Text != "" && txtbox_pass2.Text != "" && txtbox_conpass2.Text == "")
                {
                    txtbox_conpass2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_conpass2.StateCommon.Border.Color2 = Color.Red;

                    label_emptu3.Visible = true;
                }

                else if (txtbox_uname2.Text != "" && txtbox_pass2.Text != txtbox_conpass2.Text && txtbox_conpass2.Text == "")
                {

                    txtbox_pass2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_pass2.StateCommon.Border.Color2 = Color.Red;

                    txtbox_conpass2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_conpass2.StateCommon.Border.Color2 = Color.Red;
                    label_passdn2.Visible = true;
                }

                else if (txtbox_uname2.Text != "" && txtbox_pass2.Text != txtbox_conpass2.Text)
                {

                    txtbox_pass2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_pass2.StateCommon.Border.Color2 = Color.Red;

                    txtbox_conpass2.StateCommon.Border.Color1 = Color.Red;
                    txtbox_conpass2.StateCommon.Border.Color2 = Color.Red;
                    label_passdn2.Visible = true;
                    label_conpassdn2.Visible = true;
                }


                else if (txtbox_uname2.Text != "" && txtbox_pass2.Text == txtbox_conpass2.Text)
                {

                    bool usernameExists = false;
                    string query = "SELECT COUNT(*) FROM users WHERE username = @username";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", txtbox_uname2.Text);
                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        usernameExists = count > 0;
                        con.Close();
                    }

                    if (usernameExists)
                    {
                        // Username already exists
                        txtbox_uname2.StateCommon.Border.Color1 = Color.Red;
                        txtbox_uname2.StateCommon.Border.Color2 = Color.Red;
                        label_useral.Visible = true; // Display username already exists error label
                    }
                    else
                    {
                        int lastUserID;
                        string query1 = "SELECT MAX(userID) FROM users";
                        using (OleDbCommand cmd = new OleDbCommand(query1, con))
                        {
                            con.Open();
                            object result = cmd.ExecuteScalar();
                            con.Close();

                            if (result != DBNull.Value)
                            {
                                lastUserID = Convert.ToInt32(result);
                                // Increment the lastUserID by 1 to generate a new unique userID
                                lastUserID++;
                            }
                            else
                            {
                                lastUserID = 1; // If there are no existing users, start from 1
                            }
                        }

                        con.Open();
                        string register = "INSERT INTO users VALUES('" + lastUserID + "', '" + txtbox_uname2.Text + "', '" + txtbox_pass2.Text + "', 'user')";
                        using (OleDbCommand cmd = new OleDbCommand(register, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                        label_cracc.Visible = true;
                    }
                }
            }

            catch (OleDbException ex)
            {
                con.Close();
            }
        }

        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            loginform login = new loginform();
            login.Show();
            this.Hide();
        }

        private void txtbox_uname2_TextChanged(object sender, EventArgs e)
        {
            txtbox_uname2.StateCommon.Border.Color1 = Color.FromArgb(224, 224, 224);
            txtbox_uname2.StateCommon.Border.Color2 = Color.FromArgb(224, 224, 224);
            label_emptu1.Visible = false;
            label_useral.Visible = false;

        }

        private void txtbox_pass2_TextChanged(object sender, EventArgs e)
        {
            txtbox_pass2.StateCommon.Border.Color1 = Color.FromArgb(224, 224, 224);
            txtbox_pass2.StateCommon.Border.Color2 = Color.FromArgb(224, 224, 224);
            label_emptu2.Visible = false;
            label_emptu3.Visible = false;
            label_conpassdn2.Visible = false;
            label_passdn2.Visible = false;

            if (txtbox_pass2.Text == txtbox_conpass2.Text && txtbox_pass2.Text != "")
            {
                txtbox_pass2.StateCommon.Border.Color1 = Color.FromArgb(165, 211, 149);
                txtbox_pass2.StateCommon.Border.Color2 = Color.FromArgb(165, 211, 149);

                txtbox_conpass2.StateCommon.Border.Color1 = Color.FromArgb(165, 211, 149);
                txtbox_conpass2.StateCommon.Border.Color2 = Color.FromArgb(165, 211, 149);
            }

            else
            {
                txtbox_conpass2.StateCommon.Border.Color1 = Color.FromArgb(224, 224, 224);
                txtbox_conpass2.StateCommon.Border.Color2 = Color.FromArgb(224, 224, 224);


                txtbox_pass2.StateCommon.Border.Color1 = Color.FromArgb(224, 224, 224);
                txtbox_pass2.StateCommon.Border.Color2 = Color.FromArgb(224, 224, 224);
            }


        }

        private void txtbox_conpass2_TextChanged(object sender, EventArgs e)
        {
            txtbox_conpass2.StateCommon.Border.Color1 = Color.FromArgb(224, 224, 224);
            txtbox_conpass2.StateCommon.Border.Color2 = Color.FromArgb(224, 224, 224);
            label_emptu2.Visible = false;
            label_emptu3.Visible = false;
            label_conpassdn2.Visible = false;
            label_passdn2.Visible = false;

            if (txtbox_pass2.Text == txtbox_conpass2.Text && txtbox_pass2.Text != "")
            {
                txtbox_pass2.StateCommon.Border.Color1 = Color.FromArgb(165, 211, 149);
                txtbox_pass2.StateCommon.Border.Color2 = Color.FromArgb(165, 211, 149);

                txtbox_conpass2.StateCommon.Border.Color1 = Color.FromArgb(165, 211, 149);
                txtbox_conpass2.StateCommon.Border.Color2 = Color.FromArgb(165, 211, 149);
            }

            else
            {
                txtbox_conpass2.StateCommon.Border.Color1 = Color.FromArgb(224, 224, 224);
                txtbox_conpass2.StateCommon.Border.Color2 = Color.FromArgb(224, 224, 224);


                txtbox_pass2.StateCommon.Border.Color1 = Color.FromArgb(224, 224, 224);
                txtbox_pass2.StateCommon.Border.Color2 = Color.FromArgb(224, 224, 224);
            }
                
        }

        private void ckbx_showpass2_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbx_showpass2.Checked)
            {
                txtbox_pass2.PasswordChar = '\0';
                txtbox_conpass2.PasswordChar = '\0';
            }

            else
            {

                txtbox_pass2.PasswordChar = '•';
                txtbox_conpass2.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
