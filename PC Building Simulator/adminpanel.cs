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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PC_Building_Simulator
{
    public partial class adminpanel : KryptonForm
    {
        private DatabaseManager dbManager; 
        int indexRow;
        public adminpanel()
        {
            InitializeComponent();
            dbManager = new DatabaseManager("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");
        }

        private void adminpanel_Load(object sender, EventArgs e)
        {
            
            loaddata();
        }
        private void loaddata()
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM users", dbManager.GetConnection()))
            {
                DataSet ds = new DataSet();
                dbManager.OpenConnection();
                da.Fill(ds, "users");
                dgvadmin.DataSource = ds.Tables["users"];
            }
        }
        private void dgvadmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell belongs to the 4th column
            if (e.ColumnIndex == 4 && e.RowIndex >= 0 && e.RowIndex < dgvadmin.Rows.Count)
            {
                // Toggle the value of the clicked cell
                DataGridViewCheckBoxCell cell = dgvadmin.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                if (cell != null)
                {
                    cell.Value = !(cell.Value as bool?);
                }
            }
            else if (e.RowIndex >= 0 && e.RowIndex < dgvadmin.Rows.Count)
            {
                // Update text boxes with data from the clicked row
                indexRow = e.RowIndex;
                DataGridViewRow row = dgvadmin.Rows[indexRow];
                txt_id.Text = row.Cells[0].Value.ToString();
                txt_adusername.Text = row.Cells[1].Value.ToString();
                txt_adpass.Text = row.Cells[2].Value.ToString();
                cbox_adus.Text = row.Cells[3].Value.ToString();
            }
        }


        private void butt_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_adusername.Text) || string.IsNullOrWhiteSpace(txt_adpass.Text) || string.IsNullOrWhiteSpace(txt_id.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }
                string checkQuery = "SELECT COUNT(*) FROM users WHERE [username] = @uname";
                using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, dbManager.GetConnection()))
                {
                    checkCmd.Parameters.AddWithValue("@uname", txt_adusername.Text);

                    dbManager.OpenConnection();
                    int count = (int)checkCmd.ExecuteScalar();
                    dbManager.CloseConnection();

                    if (count > 0)
                    {
                        MessageBox.Show("Username already exists.");
                        return; // Exit the method to prevent insertion of duplicate username
                    }
                }

                // If username doesn't exist, proceed with insertion
                string insertQuery = "INSERT INTO users ([username], [password], [usertype], [userID]) VALUES (@uname, @pass, @type, @id)";
                using (OleDbCommand cmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@uname", txt_adusername.Text);
                    cmd.Parameters.AddWithValue("@pass", txt_adpass.Text);
                    cmd.Parameters.AddWithValue("@type", cbox_adus.Text);
                    cmd.Parameters.AddWithValue("@id", txt_id.Text);

                    dbManager.OpenConnection();
                    cmd.ExecuteNonQuery();
                    dbManager.CloseConnection();
                }
                loaddata();
            }
            catch (OleDbException ex)
            {
                if (ex.ErrorCode == -2147467259)
                {
                    MessageBox.Show("An error occurred: Duplicate ID.");
                }
                else
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }


        }

        private void but_del_Click(object sender, EventArgs e)
        {
            if (txt_adusername.Text != "" || txt_adpass.Text != "" || txt_id.Text != "")
            {
                string query = "DELETE FROM users WHERE userID = @id";
                using (OleDbCommand cmd = new OleDbCommand(query, dbManager.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", dgvadmin.CurrentRow.Cells[0].Value);

                    dbManager.OpenConnection();
                    cmd.ExecuteNonQuery();
                    dbManager.CloseConnection();
                }
                loaddata();
            }
            else
            {
                MessageBox.Show("Please select a cell.");
            }
        }

        private void butt_upd_Click(object sender, EventArgs e)
        {
            if (txt_adusername.Text != "" && txt_adpass.Text != "" && txt_id.Text != "")
            {

                // Check if the new username already exists
                string checkQuery = "SELECT COUNT(*) FROM users WHERE [username] = @uname OR (userID = @id AND username <> @uname)";
                using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, dbManager.GetConnection()))
                {
                    checkCmd.Parameters.AddWithValue("@uname", txt_adusername.Text);
                    checkCmd.Parameters.AddWithValue("@id", txt_id.Text);

                    dbManager.OpenConnection();
                    int count = (int)checkCmd.ExecuteScalar();
                    dbManager.CloseConnection();

                    if (count > 0)
                    {
                        if (count == 2)
                        {
                            MessageBox.Show("Username already exists and the specified ID already exists for another user.");
                        }
                        else if (count == 1)
                        {
                            string query = "UPDATE users SET [username] = @uname, [password] = @pass, [usertype] = @type WHERE userID = @id";

                            using (OleDbCommand cmd = new OleDbCommand(query, dbManager.GetConnection()))
                            {
                                cmd.Parameters.AddWithValue("@uname", txt_adusername.Text);
                                cmd.Parameters.AddWithValue("@pass", txt_adpass.Text);
                                cmd.Parameters.AddWithValue("@type", cbox_adus.Text);
                                cmd.Parameters.AddWithValue("@id", txt_id.Text);

                                try
                                {
                                    dbManager.OpenConnection();
                                    cmd.ExecuteNonQuery();
                                    dbManager.CloseConnection();
                                    loaddata();
                                }
                                catch (OleDbException ex)
                                {
                                    MessageBox.Show("An error occurred: " + ex.Message);
                                }
                            }

                            string updatePasswordQuery = "UPDATE users SET [password] = @pass, [usertype] = @type WHERE userID = @id";

                            using (OleDbCommand updatePasswordCmd = new OleDbCommand(updatePasswordQuery, dbManager.GetConnection()))
                            {
                                updatePasswordCmd.Parameters.AddWithValue("@pass", txt_adpass.Text);
                                updatePasswordCmd.Parameters.AddWithValue("@type", cbox_adus.Text);
                                updatePasswordCmd.Parameters.AddWithValue("@id", txt_id.Text);

                                try
                                {
                                    dbManager.OpenConnection();
                                    updatePasswordCmd.ExecuteNonQuery();
                                    dbManager.CloseConnection();
                                    loaddata();
                                    return; // Exit the method since we only updated password and usertype
                                }
                                catch (OleDbException ex)
                                {
                                    MessageBox.Show("An error occurred: " + ex.Message);
                                    return; // Exit the method due to error
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("The specified ID already exists for another user.");
                        }
                        return; // Exit the method to prevent updating with a duplicate username or ID
                    }
                }

                // Update the user's information
                
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }
    }
}
