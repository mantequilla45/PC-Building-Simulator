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
    public partial class psuspecs : Form
    {
        private DatabaseManager dbManager;
        private string choice;
        public psuspecs(string psu)
        {
            InitializeComponent();
            dbManager = new DatabaseManager("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");
            choice = psu;
        }
        private void psuspecs_Load(object sender, EventArgs e)
        {
            Dictionary<string, Image> psuImages = new Dictionary<string, Image>
            {
                { "Asus TUF Gaming 750W Bronze", Properties.Resources.psu_Asus_TUF_Gaming_750W_Bronze },
                { "Corsair RM1000x", Properties.Resources.psu_Corsair_RM1000x },
                { "EVGA B550 Bronze", Properties.Resources.psu_EVGA_B550_Bronze },
                { "Super Flower Leadex III Gold 750W", Properties.Resources.psu_Super_Flower_Leadex_III_Gold_750W },
                { "Thermaltake Toughpower Grand RGB 1200W Gold", Properties.Resources.psu_Thermaltake_Toughpower_Grand_RGB_1200W_Gold },
                { "Thermaltake Smart 650W", Properties.Resources.psu_Thermaltake_Smart_650W },
                { "Gigabyte P850W Gold", Properties.Resources.psu_Gigabyte_P850W_Gold },
                { "Corsair CX450M", Properties.Resources.psu_Corsair_CX450M },
                { "EVGA SuperNOVA 1600 T2", Properties.Resources.psu_EVGA_SuperNOVA_1600_T2 },
                { "Seasonic S12III Bronze 550W", Properties.Resources.psu_Seasonic_S12III_Bronze_550W },
                { "Corsair AX1500i", Properties.Resources.psu_Corsair_AX1500i },
                { "EVGA G+ 1000W Gold", Properties.Resources.psu_EVGA_G__1000W_Gold },
                { "Seasonic Prime PX-1000", Properties.Resources.psu_Seasonic_Prime_PX_1000 },
                { "Seasonic PRIME TX-1600 Titanium", Properties.Resources.psu_Seasonic_PRIME_TX_1600_Titanium },
                { "NZXT C850 Gold", Properties.Resources.psu_NZXT_C850_Gold },
                { "Cooler Master MasterWatt Maker 1200 Titanium", Properties.Resources.psu_Cooler_Master_MasterWatt_Maker_1200_Titanium },
                { "be quiet! Pure Power 10 CM 850W", Properties.Resources.psu_be_quiet__Pure_Power_10_CM_850W },
                { "MSI MPG A-GF AI 850W Gold", Properties.Resources.psu_MSI_MPG_A_GF_AI_850W_Gold },
                { "Asus ROG Thor 1200W Platinum", Properties.Resources.psu_Asus_ROG_Thor_1200W_Platinum },
                { "Cooler Master MWE Bronze V650", Properties.Resources.psu_Cooler_Master_MWE_Bronze_V650 }
            };

            if (psuImages.ContainsKey(choice))
            {
                pictureBox2.Image = psuImages[choice];
            }
            else
            {
                MessageBox.Show("No RAM module selected.");
                return;
            }

            dbManager.OpenConnection();
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM [PSU specs] WHERE [PSU Name] = @name";
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
                MessageBox.Show("No data found for the selected PSU Name.");
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
                string updateQuery = "UPDATE Builds SET PSU = @psu WHERE [user] = @Username";
                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                    {
                        updateCmd.Parameters.AddWithValue("@psu", choice);
                        updateCmd.Parameters.AddWithValue("@Username", user);
                        label2.Visible = true;
                        int rowsAffected = updateCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating PSU for existing user: " + ex.Message);
                }
                finally
                {
                    dbManager.CloseConnection();
                }
            }
            else
            {
                string insertQuery = "INSERT INTO Builds (PSU, [user]) VALUES (@psu, @Username)";
                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                    {
                        insertCmd.Parameters.AddWithValue("@psu", choice);
                        insertCmd.Parameters.AddWithValue("@Username", user);
                        label2.Visible = true;
                        int rowsAffected = insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting PSU for new user: " + ex.Message);
                }
                finally
                {
                    dbManager.CloseConnection();
                }
            }
        }
    }
}
