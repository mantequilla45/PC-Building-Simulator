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
    public partial class cpuspecs : Form
    {
        private DatabaseManager dbManager;
        private string selectedCPU;
        public cpuspecs(string cpu)
        {
            InitializeComponent();
            dbManager = new DatabaseManager("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");
            selectedCPU = cpu;
        }
        private void cpuspecs_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            Dictionary<string, Image> cpuImages = new Dictionary<string, Image>
            {
                { "Intel Core i9-11900K", Properties.Resources.cpu_Intel_Core_i9_11900K },
                { "AMD Ryzen 9 5950X", Properties.Resources.cpu_AMD_Ryzen_9_5950X },
                { "Intel Core i7-11700K", Properties.Resources.cpu_Intel_Core_i7_11700K },
                { "AMD Ryzen 7 5800X", Properties.Resources.cpu_AMD_Ryzen_7_5800X },
                { "Intel Core i5-11600K", Properties.Resources.cpu_Intel_Core_i5_11600K },
                { "AMD Ryzen 5 5600X", Properties.Resources.cpu_AMD_Ryzen_5_5600X },
                { "Intel Core i3-10100", Properties.Resources.cpu_Intel_Core_i3_10100 },
                { "AMD Ryzen 3 3300X", Properties.Resources.cpu_AMD_Ryzen_3_3300X },
                { "Intel Core i9-10900K", Properties.Resources.cpu_Intel_Core_i9_10900K },
                { "AMD Ryzen 9 5900X", Properties.Resources.cpu_AMD_Ryzen_9_5900X },
                { "Intel Core i9-12900K", Properties.Resources.cpu_Intel_Core_i9_12900K },
                { "AMD Ryzen 9 7900X", Properties.Resources.cpu_AMD_Ryzen_9_7900X },
                { "Intel Core i7-12700K", Properties.Resources.cpu_Intel_Core_i7_12700K },
                { "AMD Ryzen 7 7800X3D", Properties.Resources.cpu_AMD_Ryzen_7_7800X3D },
                { "Intel Core i5-12600K", Properties.Resources.cpu_Intel_Core_i5_12600K },
                { "AMD Ryzen 7 7700X", Properties.Resources.cpu_AMD_Ryzen_7_7700X },
                { "Intel Core i5-12400", Properties.Resources.cpu_Intel_Core_i5_12400 },
                { "AMD Ryzen 3 3200G", Properties.Resources.cpu_AMD_Ryzen_3_3200G },
                { "Intel Core i9-14900K", Properties.Resources.cpu_Intel_Core_i9_14900K },
                { "AMD Ryzen 9 7900X3D", Properties.Resources.cpu_AMD_Ryzen_9_7900X3D }
            };

            if (cpuImages.ContainsKey(selectedCPU))
            {
                pictureBox2.Image = cpuImages[selectedCPU];
            }
            else
            {
                MessageBox.Show("1No CPU selected.");
                return;
            }



            if (string.IsNullOrEmpty(selectedCPU))
            {
                MessageBox.Show("No CPU selected.");
                return;
            }
            dbManager.OpenConnection();

            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM [CPU Specs] WHERE [Processor Name] = @cpuName";
            using (OleDbCommand cmd = new OleDbCommand(query, dbManager.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@cpuName", selectedCPU);
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
                MessageBox.Show("No data found for the selected CPU.");
            }
        }

        private void but_cpuadd_Click(object sender, EventArgs e)
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
                string updateQuery = "UPDATE Builds SET CPU = @CPU WHERE [user] = @Username";
                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                    {
                        updateCmd.Parameters.AddWithValue("@CPU", selectedCPU);
                        updateCmd.Parameters.AddWithValue("@Username", user);
                        label2.Visible = true;
                        int rowsAffected = updateCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating CPU for existing user: " + ex.Message);
                }
                finally
                {
                    dbManager.CloseConnection();
                }
            }
            else
            {
                string insertQuery = "INSERT INTO Builds (CPU, [user]) VALUES (@CPU, @Username)";
                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                    {
                        insertCmd.Parameters.AddWithValue("@CPU", selectedCPU);
                        insertCmd.Parameters.AddWithValue("@Username", user);
                        label2.Visible = true;
                        int rowsAffected = insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting CPU for new user: " + ex.Message);
                }
                finally
                {
                    dbManager.CloseConnection();
                }
            }
        }
    }
}
