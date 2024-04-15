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
    public partial class gpuspecs : Form
    {
        private DatabaseManager dbManager;
        private string selectedGPU;
        public gpuspecs(string gpu)
        {
            InitializeComponent();
            dbManager = new DatabaseManager("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");
            selectedGPU = gpu;
        }

        private void gpuspecs_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            Dictionary<string, Image> gpuImages = new Dictionary<string, Image>
            {
                { "XFX Radeon RX 5700 XT", Properties.Resources.XFX_Radeon_RX_5700_XT },
                { "PowerColor Radeon RX 580", Properties.Resources.PowerColor_Radeon_RX_580 },
                { "Gigabyte GeForce GTX 1080 Ti", Properties.Resources.Gigabyte_GeForce_GTX_1080_Ti },
                { "Gigabyte GeForce GTX 1070", Properties.Resources.Gigabyte_GeForce_GTX_1070 },
                { "Gigabyte GeForce GTX 1660 Ti", Properties.Resources.Gigabyte_GeForce_GTX_1660_Ti },
                { "EVGA GeForce RTX 2080 Super", Properties.Resources.EVGA_GeForce_RTX_2080_Super },
                { "Gigabyte GeForce RTX 3080 Ti", Properties.Resources.Gigabyte_GeForce_RTX_3080_Ti },
                { "XFX Radeon RX 6700 XT", Properties.Resources.XFX_Radeon_RX_6700_XT },
                { "MSI GeForce RTX 3070", Properties.Resources.MSI_GeForce_RTX_3070 },
                { "Asus ROG Strix GeForce GTX 1060", Properties.Resources.Asus_ROG_Strix_GeForce_GTX_1060 },
                { "PowerColor Radeon RX 6800 XT", Properties.Resources.PowerColor_Radeon_RX_6800_XT },
                { "Gigabyte GeForce RTX 2070 Super", Properties.Resources.Gigabyte_GeForce_RTX_2070_Super },
                { "XFX RX 5600 XT", Properties.Resources.XFX_RX_5600_XT },
                { "Intel Arc A770", Properties.Resources.Intel_Arc_A770 },
                { "Nvidia GeForce RTX 4080 Founders Edition", Properties.Resources.Nvidia_GeForce_RTX_4080_Founders_Edition },
                { "ASUS TUF Gaming RX 7800 XT", Properties.Resources.ASUS_TUF_Gaming_RX_7800_XT },
                { "Sapphire NITRO+ Radeon RX 6600 XT", Properties.Resources.Sapphire_NITRO__Radeon_RX_6600_XT },
                { "Nvidia GeForce RTX 3060 Ti Founders Edition", Properties.Resources.Nvidia_GeForce_RTX_3060_Ti_Founders_Edition },
                { "Sapphire PULSE Radeon RX 570 8G G5", Properties.Resources.Sapphire_PULSE_Radeon_RX_570_8G_G5 },
                { "ASRock AMD Radeon RX 6600 Challenger D 8GB", Properties.Resources.ASRock_AMD_Radeon_RX_6600_Challenger_D_8GB }
            };

            if (gpuImages.ContainsKey(selectedGPU))
            {
                pictureBox2.Image = gpuImages[selectedGPU];
            }
            else
            {
                // Handle the case when the selected GPU is not found in the dictionary
                MessageBox.Show("No GPU image found for the selected GPU.");
            }




            if (string.IsNullOrEmpty(selectedGPU))
            {
                MessageBox.Show("No GPU selected.");
                return;
            }
            dbManager.OpenConnection();

            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM [GPU Specs] WHERE [Graphics Card Name] = @gpuName";
            using (OleDbCommand cmd = new OleDbCommand(query, dbManager.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@gpuName", selectedGPU);
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
                MessageBox.Show("No data found for the selected GPU.");
            }
        }
        private void but_gpuadd_Click(object sender, EventArgs e)
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
                string updateQuery = "UPDATE Builds SET GPU = @GPU WHERE [user] = @Username";
                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                    {
                        updateCmd.Parameters.AddWithValue("@GPU", selectedGPU);
                        updateCmd.Parameters.AddWithValue("@Username", user);
                        label2.Visible = true;
                        int rowsAffected = updateCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating GPU for existing user: " + ex.Message);
                }
                finally
                {
                    dbManager.CloseConnection();
                }
            }
            else
            {
                string insertQuery = "INSERT INTO Builds (GPU, [user]) VALUES (@GPU, @Username)";
                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                    {
                        insertCmd.Parameters.AddWithValue("@GPU", selectedGPU);
                        insertCmd.Parameters.AddWithValue("@Username", user);
                        label2.Visible = true;
                        int rowsAffected = insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting GPU for new user: " + ex.Message);
                }
                finally
                {
                    dbManager.CloseConnection();
                }
            }
        }

        private void dataGridView1_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            if (dataGridView1.DefaultCellStyle.WrapMode == DataGridViewTriState.True)
            {
                // Iterate through cells in the row to find the maximum height
                int maxHeight = 0;
                foreach (DataGridViewCell cell in e.Row.Cells)
                {
                    // Calculate the preferred height for the cell content
                    int preferredHeight = TextRenderer.MeasureText(
                        Convert.ToString(cell.Value), dataGridView1.Font, cell.Size, TextFormatFlags.WordBreak).Height;

                    // Update the maximum height if the preferred height is greater
                    if (preferredHeight > maxHeight)
                    {
                        maxHeight = preferredHeight;
                    }
                }

                // Set the row height to the maximum height
                e.Row.Height = maxHeight;
            }
        }
    }
}
