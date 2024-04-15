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

namespace PC_Building_Simulator
{
    public partial class mbspecs : Form
    {
        private DatabaseManager dbManager;
        private string choice;
        public mbspecs(string mb)
        {
            InitializeComponent();
            dbManager = new DatabaseManager("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");
            choice = mb;
        }

        private void mbspecs_Load(object sender, EventArgs e)
        {
            Dictionary<string, Image> motherboardImages = new Dictionary<string, Image>
            {
                { "MSI MEG Z690 Godlike", Properties.Resources.mb_MSI_MEG_Z690_Godlike },
                { "ASUS ROG Strix X570-E Gaming", Properties.Resources.mb_ASUS_ROG_Strix_X570_E_Gaming },
                { "Gigabyte B550M Aorus Pro", Properties.Resources.mb_Gigabyte_B550M_Aorus_Pro },
                { "MSI B460M Mortar Micro ATX WiFi", Properties.Resources.mb_MSI_B460M_Mortar_Micro_ATX_WiFi },
                { "ASRock Z690 Extreme", Properties.Resources.mb_ASRock_Z690_Extreme },
                { "EVGA X570 Dark", Properties.Resources.mb_EVGA_X570_Dark },
                { "ASUS ROG Strix B550-F Gaming WiFi", Properties.Resources.mb_ASUS_ROG_Strix_B550_F_Gaming_WiFi },
                { "MSI MPG Z490 Gaming Carbon WiFi", Properties.Resources.mb_MSI_MPG_Z490_Gaming_Carbon_WiFi },
                { "Gigabyte B460M DS3H", Properties.Resources.mb_Gigabyte_B460M_DS3H },
                { "ASRock B450M Steel Legend", Properties.Resources.mb_ASRock_B450M_Steel_Legend },
                { "MSI B560M Mortar WiFi", Properties.Resources.mb_MSI_B560M_Mortar_WiFi },
                { "ASUS ROG Strix X570-I Gaming WiFi", Properties.Resources.mb_ASUS_ROG_Strix_X570_I_Gaming_WiFi },
                { "Gigabyte Z490 Aorus Elite", Properties.Resources.mb_Gigabyte_Z490_Aorus_Elite },
                { "MSI B460M Bazooka V2", Properties.Resources.mb_MSI_B460M_Bazooka_V2 },
                { "ASRock B550 Phantom Gaming 4", Properties.Resources.mb_ASRock_B550_Phantom_Gaming_4 },
                { "MSI MPG X570 Gaming Plus", Properties.Resources.mb_MSI_MPG_X570_Gaming_Plus },
                { "ASUS Prime B460M-A", Properties.Resources.mb_ASUS_Prime_B460M_A },
                { "Gigabyte B450M DS3H WIFI", Properties.Resources.mb_Gigabyte_B450M_DS3H_WIFI },
                { "MSI B550M Mortar Micro ATX", Properties.Resources.mb_MSI_B550M_Mortar_Micro_ATX },
                { "ASRock B460M Pro4", Properties.Resources.mb_ASRock_B460M_Pro4 }
            };

            if (motherboardImages.ContainsKey(choice))
            {
                pictureBox2.Image = motherboardImages[choice];
            }
            else
            {
                MessageBox.Show("No motherboard selected.");
                return;
            }

            dbManager.OpenConnection();
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM [Motherboard specs] WHERE [Motherboard Name] = @name";
            using (OleDbCommand cmd = new OleDbCommand(query, dbManager.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@name", choice);
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            dbManager.CloseConnection();

            if (dataTable.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("Property", "Property");
                dataGridView1.Columns.Add("Value", "Value");

                foreach (DataColumn column in dataTable.Columns)
                {
                    dataGridView1.Rows.Add(column.ColumnName, dataTable.Rows[0][column]);
                }
            }
            else
            {
                MessageBox.Show("No data found for the selected Motherboard.");
            }
        }
        private void but_add_Click(object sender, EventArgs e)
        {
            string user;
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string query = "SELECT TOP 1 [user] FROM currentuser";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        user = result.ToString();
                    }
                    else
                    {
                        user = "";
                    }
                }
            }
            string selectQuery = "SELECT COUNT(*) FROM Builds WHERE [user] = @Username";
            int userCount = 0;

            try
            {
                using (OleDbCommand selectCmd = new OleDbCommand(selectQuery, dbManager.GetConnection()))
                {
                    selectCmd.Parameters.AddWithValue("@Username", user);
                    dbManager.OpenConnection();
                    userCount = (int)selectCmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking existing user: " + ex.Message);
            }
            finally
            {
                dbManager.CloseConnection();
            }
            if (userCount > 0)
            {
                string updateQuery = "UPDATE Builds SET Motherboard = @mb WHERE [user] = @Username";
                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                    {
                        updateCmd.Parameters.AddWithValue("@mb", choice);
                        updateCmd.Parameters.AddWithValue("@Username", user);
                        label2.Visible = true;
                        int rowsAffected = updateCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating Motherboard for existing user: " + ex.Message);
                }
                finally
                {
                    dbManager.CloseConnection();
                }
            }
            else
            {
                string insertQuery = "INSERT INTO Builds (Motherboard, [user]) VALUES (@mb, @Username)";
                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                    {
                        insertCmd.Parameters.AddWithValue("@mb", choice);
                        insertCmd.Parameters.AddWithValue("@Username", user);
                        label2.Visible = true;
                        int rowsAffected = insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting motherboard for new user: " + ex.Message);
                }
                finally
                {
                    dbManager.CloseConnection();
                }
            }
        }
    }
}
