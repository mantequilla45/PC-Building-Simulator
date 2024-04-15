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
    public partial class casespecs : Form
    {
        private DatabaseManager dbManager;
        private string choice;
        public casespecs(string ccase)
        {
            InitializeComponent();
            dbManager = new DatabaseManager("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");
            choice = ccase;
        }

        private void casespecs_Load(object sender, EventArgs e)
        {
            Dictionary<string, Image> caseImages = new Dictionary<string, Image>
            {
                { "NZXT H510", Properties.Resources.case_NZXT_H510 },
                { "Fractal Design Meshify C", Properties.Resources.case_Fractal_Design_Meshify_C },
                { "Corsair 4000D Airflow", Properties.Resources.case_Corsair_4000D_Airflow },
                { "Lian Li Lancool 215", Properties.Resources.case_Lian_Li_Lancool_215 },
                { "Phanteks Eclipse G360A", Properties.Resources.case_Phanteks_Eclipse_G360A },
                { "Cooler Master MasterBox NR200P", Properties.Resources.case_Cooler_Master_MasterBox_NR200P },
                { "ASUS ROG Strix Helios", Properties.Resources.case_ASUS_ROG_Strix_Helios },
                { "be quiet! Pure Base 500DX", Properties.Resources.case_be_quiet__Pure_Base_500DX },
                { "Thermaltake S100 TG", Properties.Resources.case_Thermaltake_S100_TG },
                { "MSI MPG Sekira 500X", Properties.Resources.case_MSI_MPG_Sekira_500X },
                { "NZXT H710i", Properties.Resources.case_NZXT_H710i },
                { "Corsair iCUE 500X RGB", Properties.Resources.case_Corsair_iCUE_500X_RGB },
                { "Lian Li O11 Dynamic", Properties.Resources.case_Lian_Li_O11_Dynamic },
                { "Fractal Design Define 7", Properties.Resources.case_Fractal_Design_Define_7 },
                { "Cooler Master MasterCase H500M", Properties.Resources.case_Cooler_Master_MasterCase_H500M },
                { "be quiet! Silent Base 802", Properties.Resources.case_be_quiet__Silent_Base_802 },
                { "Phanteks Eclipse P400A", Properties.Resources.case_Phanteks_Eclipse_P400A },
                { "MasterBox NR200P SE", Properties.Resources.case_MasterBox_NR200P_SE },
                { "Thermaltake H500", Properties.Resources.case_Thermaltake_H500 },
                { "MSI MPG Velox 100", Properties.Resources.case_MSI_MPG_Velox_100 }
            };

            if (caseImages.ContainsKey(choice))
            {
                pictureBox2.Image = caseImages[choice];
            }

            dbManager.OpenConnection();
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM [Case specs] WHERE [Computer Case Name] = @name";
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
                string updateQuery = "UPDATE Builds SET [Computer Case] = @ccase WHERE [user] = @Username";
                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                    {
                        updateCmd.Parameters.AddWithValue("@ccase", choice);
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
                string insertQuery = "INSERT INTO Builds ([Computer Case], [user]) VALUES (@ccase, @Username)";
                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                    {
                        insertCmd.Parameters.AddWithValue("@ccase", choice);
                        insertCmd.Parameters.AddWithValue("@Username", user);
                        label2.Visible = true;
                        int rowsAffected = insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting Case for new user: " + ex.Message);
                }
                finally
                {
                    dbManager.CloseConnection();
                }
            }
        }
    }
}
