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
    public partial class ramspecs : Form
    {
        private DatabaseManager dbManager;
        private string choice;
        public ramspecs(string ram)
        {
            InitializeComponent(); 
            dbManager = new DatabaseManager("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");
            choice = ram;
        }

        private void ramspecs_Load(object sender, EventArgs e)
        {
            Dictionary<string, Image> ramImages = new Dictionary<string, Image>
            {
                { "Vengeance RGB PRO", Properties.Resources.ram_Vengeance_RGB_PRO },
                { "TridentZ RGB Series", Properties.Resources.ram_TridentZ_RGB_Series },
                { "T-Force Delta RGB", Properties.Resources.ram_T_Force_Delta_RGB },
                { "Viper Steel Series DDR4", Properties.Resources.ram_Viper_Steel_Series_DDR4 },
                { "Ballistix RGB", Properties.Resources.ram_Ballistix_RGB },
                { "Ripjaws V Series", Properties.Resources.ram_Ripjaws_V_Series },
                { "Gammix D10", Properties.Resources.ram_Gammix_D10 },
                { "Fury Beast RGB", Properties.Resources.ram_Fury_Beast_RGB },
                { "T-Force Vulcan Z", Properties.Resources.ram_T_Force_Vulcan_Z },
                { "Aegis F4 Series", Properties.Resources.ram_Aegis_F4_Series },
                { "TridentZ5 RGB Series", Properties.Resources.ram_TridentZ5_RGB_Series },
                { "Vengeance RGB DDR5", Properties.Resources.ram_Vengeance_RGB_DDR5 },
                { "T-Force Delta RGB DDR5", Properties.Resources.ram_T_Force_Delta_RGB_DDR5 },
                { "Ballistix MAX RGB DDR5", Properties.Resources.ram_Ballistix_MAX_RGB_DDR5 },
                { "XPG Lancer RGB DDR5", Properties.Resources.ram_XPG_Lancer_RGB_DDR5 },
                { "Dominator Platinum 32GB DDR5", Properties.Resources.ram_Dominator_Platinum_32GB_DDR5_5200 },
                { "Ripjaws S5 Series DDR5", Properties.Resources.ram_Ripjaws_S5_Series_DDR5 },
                { "Fury Renegade RGB DDR5", Properties.Resources.ram_FURY_Renegade_RGB_DDR5 },
                { "T-Force Dark Z Alpha DDR5", Properties.Resources.ram_T_Force_Dark_Z_Alpha_DDR5 }
            };

            if (ramImages.ContainsKey(choice))
            {
                pictureBox2.Image = ramImages[choice];
            }
            else
            {
                MessageBox.Show("No RAM module selected.");
                return;
            }

            dbManager.OpenConnection();
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM [RAM specs] WHERE [RAM Module Name] = @name";
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
                MessageBox.Show("No data found for the selected RAM Module.");
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
                string updateQuery = "UPDATE Builds SET RAM = @ram WHERE [user] = @Username";
                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                    {
                        updateCmd.Parameters.AddWithValue("@ram", choice);
                        updateCmd.Parameters.AddWithValue("@Username", user);
                        label2.Visible = true;
                        int rowsAffected = updateCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating RAM for existing user: " + ex.Message);
                }
                finally
                {
                    dbManager.CloseConnection();
                }
            }
            else
            {
                string insertQuery = "INSERT INTO Builds (RAM, [user]) VALUES (@ram, @Username)";
                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                    {
                        insertCmd.Parameters.AddWithValue("@ram", choice);
                        insertCmd.Parameters.AddWithValue("@Username", user);
                        label2.Visible = true;
                        int rowsAffected = insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting RAM for new user: " + ex.Message);
                }
                finally
                {
                    dbManager.CloseConnection();
                }
            }
        }
    }
}
