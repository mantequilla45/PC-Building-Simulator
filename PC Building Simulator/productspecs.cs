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
using static System.Net.Mime.MediaTypeNames;

namespace PC_Building_Simulator
{
    public partial class productspecs : Form
    {
        private DatabaseManager dbManager;
        private string choice;
        private int menuchoice;
        private MainApp mainApp;
        private DisplayManager displayManager;
        public productspecs(string ccase, int num, MainApp mainApp)
        {
            InitializeComponent();
            dbManager = new DatabaseManager("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");
            choice = ccase;
            menuchoice = num;
            this.mainApp = mainApp;
            displayManager = new DisplayManager(mainApp);
        }
        private void casespecs_Load(object sender, EventArgs e)
        {
            display(choice);
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
            
            switch (menuchoice)
            {
                case 1:
                    if (userCount > 0)
                    {
                        string updateQuery = "UPDATE Builds SET CPU = @CPU WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@CPU", choice);
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
                                insertCmd.Parameters.AddWithValue("@CPU", choice);
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
                break;

                case 2:
                    if (userCount > 0)
                    {
                        string updateQuery = "UPDATE Builds SET GPU = @GPU WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@GPU", choice);
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
                                insertCmd.Parameters.AddWithValue("@GPU", choice);
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
                    break;
                case 3:
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
                    break;

                case 4:
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
                    break;

                case 6:
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
                    break;
                case 7:
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
                            MessageBox.Show("Error updating Case for existing user: " + ex.Message);
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
                    break;

                case 9:
                    if (userCount > 0)
                    {
                        string updateQuery = "UPDATE Builds SET [Monitor] = @monitor WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@monitor", choice);
                                updateCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = updateCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating Monitor for existing user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO Builds ([Monitor], [user]) VALUES (@monitor, @Username)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@monitor", choice);
                                insertCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = insertCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inserting Monitor for new user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    break;

                case 10:
                    if (userCount > 0)
                    {
                        string updateQuery = "UPDATE Builds SET [Keyboard] = @keyboard WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@keyboard", choice);
                                updateCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = updateCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating Keyboard for existing user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO Builds ([Keyboard], [user]) VALUES (@keyboard, @Username)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@keyboard", choice);
                                insertCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = insertCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inserting Keyboard for new user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    break;
                case 11:
                    if (userCount > 0)
                    {
                        string updateQuery = "UPDATE Builds SET [Mouse] = @mouse WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@mouse", choice);
                                updateCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = updateCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating Mouse for existing user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO Builds ([Mouse], [user]) VALUES (@mouse, @Username)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@mouse", choice);
                                insertCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = insertCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inserting Mouse for new user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    break;
                case 12:
                    if (userCount > 0)
                    {
                        string updateQuery = "UPDATE Builds SET [Speakers] = @speaker WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@speaker", choice);
                                updateCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = updateCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating Speaker for existing user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO Builds ([Speaker], [user]) VALUES (@speaker, @Username)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@speaker", choice);
                                insertCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = insertCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inserting Speaker for new user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    break;
                case 13:
                    if (userCount > 0)
                    {
                        string updateQuery = "UPDATE Builds SET [HDD] = @hdd WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@hdd", choice);
                                updateCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = updateCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating HDD for existing user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO Builds ([HDD], [user]) VALUES (@hdd, @Username)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@hdd", choice);
                                insertCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = insertCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inserting HDD for new user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    break;

                case 14:
                    if (userCount > 0)
                    {
                        string updateQuery = "UPDATE Builds SET [SSD] = @ssd WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@ssd", choice);
                                updateCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = updateCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating SSD for existing user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO Builds ([SSD], [user]) VALUES (@ssd, @Username)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@ssd", choice);
                                insertCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = insertCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inserting SSD for new user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    break;


            }
        }

        private void display(string choice)
        {
            Dictionary<string, System.Drawing.Image> images = null;
            string query = null;

            switch (menuchoice)
            {
                case 1:
                    images = new Dictionary<string, System.Drawing.Image>
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
                    query = "SELECT * FROM [CPU specs] WHERE [Processor Name] = @name";
                    break;

                case 2:
                    images = new Dictionary<string, System.Drawing.Image>
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
                    query = "SELECT * FROM [GPU specs] WHERE [Graphics Card Name] = @name";
                    break;

                case 3:
                    images = new Dictionary<string, System.Drawing.Image>
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
                    query = "SELECT * FROM [Motherboard specs] WHERE [Motherboard Name] = @name";
                    break;

                case 4:
                    images = new Dictionary<string, System.Drawing.Image>
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
                    query = "SELECT * FROM [RAM specs] WHERE [RAM Module Name] = @name";
                    break;

                case 6:
                    images = new Dictionary<string, System.Drawing.Image>
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
                    query = "SELECT * FROM [PSU specs] WHERE [PSU Name] = @name";
                    break;

                case 7:
                    images = new Dictionary<string, System.Drawing.Image>
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
                    query = "SELECT * FROM [Case specs] WHERE [Computer Case Name] = @name";
                    break;

                case 9:
                    images = new Dictionary<string, System.Drawing.Image>
                    {
                        { "Asus ROG Strix XG43UQ", Properties.Resources.mon_Asus_ROG_Strix_XG43UQ },
                        { "Samsung Odyssey G9", Properties.Resources.mon_Samsung_Odyssey_G9 },
                        { "LG 27GP950-B", Properties.Resources.mon_LG_27GP950_B },
                        { "Acer Predator XB323QK NV", Properties.Resources.mon_Acer_Predator_XB323QK_NV },
                        { "MSI MEG 341CQR", Properties.Resources.mon_MSI_MEG_341CQR },
                        { "Gigabyte M32U", Properties.Resources.mon_Gigabyte_M32U },
                        { "AOC Agon AG352UCG6", Properties.Resources.mon_AOC_Agon_AG352UCG6 },
                        { "ViewSonic Elite XG270QG", Properties.Resources.mon_ViewSonic_Elite_XG270QG },
                        { "Asus ProArt Display PA32UCG", Properties.Resources.mon_Asus_ProArt_Display_PA32UCG },
                        { "BenQ PD3220U", Properties.Resources.mon_BenQ_PD3220U },
                        { "Dell UltraSharp U3223QE", Properties.Resources.mon_Dell_UltraSharp_U3223QE },
                        { "Apple Pro Display XDR", Properties.Resources.mon_Apple_Pro_Display_XDR },
                        { "LG UltraFine Ergo 32EP950-B", Properties.Resources.mon_LG_UltraFine_Ergo_32EP950_B },
                        { "Samsung Odyssey Neo G8", Properties.Resources.mon_Samsung_Odyssey_Neo_G8 },
                        { "HP Z34C G3", Properties.Resources.mon_HP_Z34C_G3 },
                        { "iiyama G-Master GB3466WQSU-B1", Properties.Resources.mon_iiyama_G_Master_GB3466WQSU_B1 },
                        { "Philips Evnia 34M2C7600MV", Properties.Resources.mon_Philips_Evnia_34M2C7600MV },
                        { "Lenovo ThinkVision P34w-20", Properties.Resources.mon_Lenovo_ThinkVision_P34w_20 },
                        { "MSI Modern AM271CQP Monitor", Properties.Resources.mon_MSI_Modern_AM271CQP_Monitor },
                        { "AOC CQ32G1S", Properties.Resources.mon_AOC_CQ32G1S }
                    };
                    query = "SELECT * FROM [Monitor specs] WHERE [Monitor Name] = @name";
                    break;

                case 10:
                    images = new Dictionary<string, System.Drawing.Image>
                    {
                        { "Razer Blackwidow V3 Pro", Properties.Resources.key_Razer_Blackwidow_V3_Pro },
                        { "Logitech MX Mechanical Mini", Properties.Resources.key_Logitech_MX_Mechanical_Mini },
                        { "Apple Magic Keyboard", Properties.Resources.key_Apple_Magic_Keyboard },
                        { "CORSAIR K100 RGB", Properties.Resources.key_CORSAIR_K100_RGB },
                        { "SteelSeries Apex Pro TKL", Properties.Resources.key_SteelSeries_Apex_Pro_TKL },
                        { "Glorious GMMK Pro", Properties.Resources.key_Glorious_GMMK_Pro },
                        { "HyperX Alloy Origins Core", Properties.Resources.key_HyperX_Alloy_Origins_Core },
                        { "Fnatic STREAK65 LP", Properties.Resources.key_Fnatic_STREAK65_LP },
                        { "Ducky One 3 Mini", Properties.Resources.key_Ducky_One_3_Mini },
                        { "Leopold FC980M PD", Properties.Resources.key_Leopold_FC980M_PD },
                        { "Niz Plum 82", Properties.Resources.key_Niz_Plum_82 },
                        { "Keychron Q1", Properties.Resources.key_Keychron_Q1 },
                        { "Epomaker GK68XS", Properties.Resources.key_Epomaker_GK68XS },
                        { "Anne Pro 2", Properties.Resources.key_Anne_Pro_2 },
                        { "Redragon K552", Properties.Resources.key_Redragon_K552 },
                        { "Logitech G915 TKL", Properties.Resources.key_Logitech_G915_TKL },
                        { "MSI Vigor GK71", Properties.Resources.key_MSI_Vigor_GK71 },
                        { "Asus ROG Strix Scope TKL", Properties.Resources.key_Asus_ROG_Strix_Scope_TKL },
                        { "Cooler Master SK622", Properties.Resources.key_Cooler_Master_SK622 },
                        { "NuPhy Air75", Properties.Resources.key_NuPhy_Air75 }
                    };
                    query = "SELECT * FROM [Keyboard specs] WHERE [Keyboard Name] = @name";
                    break;
                case 11:
                    images = new Dictionary<string, System.Drawing.Image>
                    {
                        { "Logitech MX Master 3", Properties.Resources.mou_Logitech_MX_Master_3 },
                        { "Razer DeathAdder V2 Mini", Properties.Resources.mou_Razer_DeathAdder_V2_Mini },
                        { "Apple Magic Mouse 2", Properties.Resources.mou_Apple_Magic_Mouse_2 },
                        { "Glorious Model O", Properties.Resources.mou_Glorious_Model_O },
                        { "SteelSeries Rival 650 Wireless", Properties.Resources.mou_SteelSeries_Rival_650_Wireless },
                        { "HyperX Pulsefire Haste", Properties.Resources.mou_HyperX_Pulsefire_Haste },
                        { "Fnatic Flick 2", Properties.Resources.mou_Fnatic_Flick_2 },
                        { "Ducky Feather", Properties.Resources.mou_Ducky_Feather },
                        { "Logitech G502 Hero", Properties.Resources.mou_Logitech_G502_Hero },
                        { "Corsair Dark Core Pro RGB SE", Properties.Resources.mou_Corsair_Dark_Core_Pro_RGB_SE },
                        { "Logitech M220 Silent", Properties.Resources.mou_Logitech_M220_Silent },
                        { "Logitech G305 Lightspeed", Properties.Resources.mou_Logitech_G305_Lightspeed },
                        { "Razer Basilisk V3", Properties.Resources.mou_Razer_Basilisk_V3 },
                        { "Logitech MX Anywhere 3", Properties.Resources.mou_Logitech_MX_Anywhere_3 },
                        { "SteelSeries Rival 710", Properties.Resources.mou_SteelSeries_Rival_710 },
                        { "Razer Naga Trinity", Properties.Resources.mou_Razer_Naga_Trinity },
                        { "Glorious Model D Wireless", Properties.Resources.mou_Glorious_Model_D_Wireless },
                        { "Logitech G Pro Wireless", Properties.Resources.mou_Logitech_G_Pro_Wireless },
                        { "Zowie S2-C Divina Series", Properties.Resources.mou_Zowie_S2_C_Divina_Series },
                        { "Logitech MX Vertical Ergonomic Mouse", Properties.Resources.mou_Logitech_MX_Vertical_Ergonomic_Mouse }
                    };
                    query = "SELECT * FROM [Mouse specs] WHERE [Mouse Name] = @name";
                    break;


                case 12:
                    images = new Dictionary<string, System.Drawing.Image>
                    {
                        { "Bose Companion 20", Properties.Resources.spe_Bose_Companion_20 },
                        { "Logitech G560 LIGHTSYNC", Properties.Resources.spe_Logitech_G560_LIGHTSYNC },
                        { "Razer Nommo Chroma", Properties.Resources.spe_Razer_Nommo_Chroma },
                        { "Creative Pebble Plus 2.0", Properties.Resources.spe_Creative_Pebble_Plus_2_0 },
                        { "Edifier R1280T", Properties.Resources.spe_Edifier_R1280T },
                        { "Audioengine A2+ Wireless", Properties.Resources.spe_Audioengine_A2__Wireless },
                        { "Mackie CR3-XBT", Properties.Resources.spe_Mackie_CR3_XBT },
                        { "Kanto YU4", Properties.Resources.spe_Kanto_YU4 },
                        { "Swan M10 Plus", Properties.Resources.spe_Swan_M10_Plus },
                        { "IK Multimedia iLoud Micro Monitor", Properties.Resources.spe_IK_Multimedia_iLoud_Micro_Monitor },
                        { "Micca RB42", Properties.Resources.spe_Micca_RB42 },
                        { "Edifier S350DB", Properties.Resources.spe_Edifier_S350DB },
                        { "Audioengine A5+ Wireless", Properties.Resources.spe_Audioengine_A5__Wireless },
                        { "PreSonus Eris E3.5", Properties.Resources.spe_PreSonus_Eris_E3_5 },
                        { "JBL Studio 530", Properties.Resources.spe_JBL_Studio_530 },
                        { "Kali Audio LP-6", Properties.Resources.spe_Kali_Audio_LP_6 },
                        { "Neumi BS5", Properties.Resources.spe_Neumi_BS5 },
                        { "Monoprice DT-3BT", Properties.Resources.spe_Monoprice_DT_3BT },
                        { "Wave Master Diamond 10", Properties.Resources.spe_Klipsch_R_41M },
                        { "Audioengine HD3", Properties.Resources.spe_Audioengine_HD3 }
                    };
                    query = "SELECT * FROM [Speakers specs] WHERE [Speaker Name] = @name";
                    break;
                case 13:
                    mainApp.back = 13;
                    images = new Dictionary<string, System.Drawing.Image>
                    {
                        { "HGST Deskstar NAS 4TB", Properties.Resources.hdd_HGST_Deskstar_NAS_4TB },
                        { "HGST Ultrastar 12TB", Properties.Resources.hdd_HGST_Ultrastar_12TB },
                        { "Hitachi Deskstar 500GB", Properties.Resources.hdd_Hitachi_Deskstar_500GB },
                        { "Hitachi Ultrastar 5TB", Properties.Resources.hdd_Hitachi_Ultrastar_5TB },
                        { "Samsung Spinpoint 1TB", Properties.Resources.hdd_Samsung_Spinpoint_1TB },
                        { "Seagate Barracuda 3TB", Properties.Resources.hdd_Seagate_Barracuda_3TB },
                        { "Seagate BarraCuda Pro 16TB", Properties.Resources.hdd_Seagate_BarraCuda_Pro_14TB },
                        { "Seagate Constellation 3TB", Properties.Resources.hdd_Seagate_Constellation_3TB },
                        { "Seagate FireCuda 8TB", Properties.Resources.hdd_Seagate_FireCuda_8TB },
                        { "Seagate IronWolf 10TB", Properties.Resources.hdd_Seagate_IronWolf_10TB },
                        { "Seagate SkyHawk 14TB", Properties.Resources.hdd_Seagate_SkyHawk_14TB },
                        { "Toshiba DT01ACA 1TB", Properties.Resources.hdd_Toshiba_DT01ACA_1TB },
                        { "Toshiba N300 14TB", Properties.Resources.hdd_Toshiba_N300_14TB },
                        { "Toshiba P300 3TB", Properties.Resources.hdd_Toshiba_P300_3TB },
                        { "Toshiba X300 6TB", Properties.Resources.hdd_Toshiba_X300_6TB },
                        { "WD VelociRaptor 1TB", Properties.Resources.hdd_WD_VelociRaptor_1TB },
                        { "Western Digital Black 2.5TB", Properties.Resources.hdd_Western_Digital_Black_2_5TB },
                        { "Western Digital Blue 2TB", Properties.Resources.hdd_Western_Digital_Blue_2TB },
                        { "Western Digital Gold 18TB", Properties.Resources.hdd_Western_Digital_Gold_18TB },
                        { "Western Digital Red 8TB", Properties.Resources.hdd_Western_Digital_Red_8TB }
                    };
                    query = "SELECT * FROM [HDD specs] WHERE [HDD Name] = @name";
                    break;

                case 14:
                    mainApp.back = 14;
                    images = new Dictionary<string, System.Drawing.Image>
                    {
                        { "Samsung 870 EVO 1TB", Properties.Resources.ssd_Samsung_870_EVO_1TB },
                        { "Crucial MX500 2TB", Properties.Resources.ssd_Crucial_MX500_2TB },
                        { "Western Digital Blue SSD 1TB", Properties.Resources.ssd_Western_Digital_Blue_SSD_1TB },
                        { "SanDisk Ultra 3D SSD 2TB", Properties.Resources.ssd_SanDisk_Ultra_3D_SSD_2TB },
                        { "Kingston UV500 SSD 512GB", Properties.Resources.ssd_Kingston_UV500_SSD_512GB },
                        { "Intel 545s SSD 512GB", Properties.Resources.ssd_Intel_545s_SSD_512GB },
                        { "Seagate Barracuda SSD 2TB", Properties.Resources.ssd_Seagate_Barracuda_SSD_2TB },
                        { "ADATA SU800 SSD 256GB", Properties.Resources.ssd_ADATA_SU800_SSD_256GB },
                        { "Toshiba TR200 SSD 1TB", Properties.Resources.ssd_Toshiba_TR200_SSD_1TB },
                        { "PNY CS900 SSD 4TB", Properties.Resources.ssd_PNY_CS900_SSD_4TB },
                        { "Silicon Power Ace A55 SSD 512GB", Properties.Resources.ssd_Silicon_Power_Ace_A55_SSD_512GB },
                        { "Transcend SSD230S SSD 2TB", Properties.Resources.ssd_Transcend_SSD230S_SSD_2TB },
                        { "HP S700 SSD 1TB", Properties.Resources.ssd_HP_S700_SSD_1TB },
                        { "Team Group L5 3D SSD 1TB", Properties.Resources.ssd_Team_Group_L5_3D_SSD_1TB },
                        { "Patriot Burst SSD 2TB", Properties.Resources.ssd_Patriot_Burst_SSD_2TB },
                        { "Gigabyte UD PRO SSD 1TB", Properties.Resources.ssd_Gigabyte_UD_PRO_SSD_1TB },
                        { "OWC Mercury Electra 6G SSD 2TB", Properties.Resources.ssd_OWC_Mercury_Electra_6G_SSD_2TB },
                        { "SK hynix Gold S31 SSD 1TB", Properties.Resources.ssd_SK_hynix_Gold_S31_SSD_1TB },
                        { "Mushkin Source SSD 500GB", Properties.Resources.ssd_Mushkin_Source_SSD_500GB },
                        { "Kingston A400 2TB", Properties.Resources.ssd_Kingston_A400_2TB }
                    };
                    query = "SELECT * FROM [SSD specs] WHERE [SSD Name] = @name";
                    break;

            }
            DisplayImageAndSpecs(choice, query, images);
        }

        void DisplayImageAndSpecs(string specschoice, string specsquery, Dictionary<string, System.Drawing.Image> specsimages = null)
        {
            DataTable dataTable = new DataTable();
            if (specsimages != null && specsimages.ContainsKey(specschoice))
            {
                pictureBox2.Image = specsimages[specschoice];
            }

            dbManager.OpenConnection();
            using (OleDbCommand cmd = new OleDbCommand(specsquery, dbManager.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@name", specschoice);
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
        private void productmenu_Load(object sender, EventArgs e)
        {

            InitializeDisplayManager();
        }

        private void InitializeDisplayManager()
        {
            productspecs productspecsform = this;
            DisplayManager displayManager = new DisplayManager(productspecsform);
        }
    }
}
