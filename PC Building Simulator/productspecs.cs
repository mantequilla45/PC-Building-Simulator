using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PC_Building_Simulator
{
    public partial class productspecs : Form
    {
        private DatabaseManager dbManager;
        private string choice;
        private int menuchoice;
        private int quantity = 1;
        private MainApp mainApp;
        private DisplayManager displayManager;
        private string price;
        private buildmenu buildMenu;
        private string user;
        private int userCount = 0;
        private string update;
        private string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
        private string motherboardName = "";
        private string cpuName = "";
        private string hddName = "";
        private string ssdName = "";
        private string mb_cpuSocket = "";
        private string cpusocketype = "";
        private string mbmemoryslots = "";
        private string mbmemoryType = "";
        private string ramtype = "";
        private string mbsataports = "";
        private string mbm2slots = "";
        private string pciegen = "";
        private int hddquan = 0;
        private int ssdquan = 0;
        public productspecs(string prodchoice, int num, MainApp mainApp, string price)
        {
            InitializeComponent();
            dbManager = new DatabaseManager("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");
            choice = prodchoice;
            menuchoice = num;
            this.price = price;
            this.mainApp = mainApp;
            displayManager = new DisplayManager(mainApp);
            buildMenu = new buildmenu(mainApp);
            display(choice);
            InitializeDisplayManager();
            compatibilitychecker();
            getcurrentuser();
        }
        private void getcurrentuser()
        {
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
        }
        private void productmenu_Load(object sender, EventArgs e)
        {
        }

        private void InitializeDisplayManager()
        {
            productspecs productspecsform = this;
            DisplayManager displayManager = new DisplayManager(productspecsform);
        }
        string GetSingleValue(string query, string parameterName, string parameterValue, string columnName)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue(parameterName, parameterValue);
                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    return reader.Read() ? reader[columnName].ToString() : "";
                }
            }
        }
        Dictionary<string, string> GetMultipleValues(string query, string parameterName, string parameterValue, params string[] columnNames)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue(parameterName, parameterValue);
                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        foreach (string columnName in columnNames)
                        {
                            values[columnName] = reader[columnName].ToString();
                        }
                    }
                }
            }

            return values;
        }
        private void compatibilitychecker()
        {
            getcurrentuser();
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            motherboardName = GetSingleValue("SELECT Motherboard FROM Builds WHERE [user] = @UserToUpdate", "@UserToUpdate", userToUpdate, "Motherboard");
            hddName = GetSingleValue("SELECT HDD FROM Builds WHERE [user] = @UserToUpdate", "@UserToUpdate", userToUpdate, "HDD");
            cpuName = GetSingleValue("SELECT CPU FROM Builds WHERE [user] = @UserToUpdate", "@UserToUpdate", userToUpdate, "CPU");
            ssdName = GetSingleValue("SELECT SSD FROM Builds WHERE [user] = @UserToUpdate", "@UserToUpdate", userToUpdate, "SSD");

            Dictionary<string, string> motherboardstports = GetMultipleValues("SELECT [SATA Ports], [M2 Slots], [PCIe Generation] FROM [Motherboard specs] WHERE [Motherboard Name] = @MotherboardName", "@MotherboardName", motherboardName, "SATA Ports", "M2 Slots", "PCIe Generation");
            mbsataports = motherboardstports.ContainsKey("SATA Ports") ? motherboardstports["SATA Ports"] : "";
            mbm2slots = motherboardstports.ContainsKey("M2 Slots") ? motherboardstports["M2 Slots"] : "";
            pciegen = motherboardstports.ContainsKey("PCIe Generation") ? motherboardstports["PCIe Generation"] : "";

            Dictionary<string, string> sataquan = GetMultipleValues("SELECT [HDD quantity], [SSD quantity] FROM [Builds] WHERE [user] = @user", "@user", user, "HDD quantity", "SSD quantity");
            hddquan = sataquan.ContainsKey("HDD quantity") && !string.IsNullOrEmpty(sataquan["HDD quantity"]) ? int.Parse(sataquan["HDD quantity"]) : 0;
            ssdquan = sataquan.ContainsKey("SSD quantity") && !string.IsNullOrEmpty(sataquan["SSD quantity"]) ? int.Parse(sataquan["SSD quantity"]) : 0;


            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                switch (menuchoice)
                {
                    case 1: //CPU
                        mb_cpuSocket = GetSingleValue("SELECT [CPU Socket] FROM [Motherboard specs] WHERE [Motherboard Name] = @MotherboardName", "@MotherboardName", motherboardName, "CPU Socket");
                        cpusocketype = GetSingleValue("SELECT [Socket Type] FROM [CPU specs] WHERE [Processor Name] = @prodchoice", "@prodchoice", choice, "Socket Type");
                        comp1.Visible = true;
                        spec1.Visible = true;
                        border1.Visible = true;

                        if (motherboardName != "")
                        {
                            comp1.Text = $"{motherboardName} CPU Slot";
                            spec1.Text = mb_cpuSocket;
                        }
                        else
                        {
                            comp1.Text = "No motherboard selected.";
                            spec1.Visible = false;
                            border1.Visible = false;
                        }
                        break;

                    case 3: //MB
                        cpusocketype = GetSingleValue("SELECT [Socket Type] FROM [CPU specs] WHERE [Processor Name] = @prodchoice", "@prodchoice", cpuName, "Socket Type");
                        mb_cpuSocket = GetSingleValue("SELECT [CPU Socket] FROM [Motherboard specs] WHERE [Motherboard Name] = @prodchoice", "@prodchoice", choice, "CPU Socket");

                        comp1.Visible = true;
                        spec1.Visible = true;
                        border1.Visible = true;
                        if (cpuName != "")
                        {
                            comp1.Text = $"{cpuName} Socket Type";
                            spec1.Text = cpusocketype;
                        }
                        else
                        {
                            comp1.Text = "No CPU selected.";
                            spec1.Visible = false;
                            border1.Visible = false;
                        }
                        break;

                    case 4: //RAM

                        Dictionary<string, string> motherboardsockets = GetMultipleValues("SELECT [Memory Slots], [Memory Type] FROM [Motherboard specs] WHERE [Motherboard Name] = @MotherboardName", "@MotherboardName", motherboardName, "Memory Slots", "Memory Type");
                        mbmemoryslots = motherboardsockets.ContainsKey("Memory Slots") ? motherboardsockets["Memory Slots"] : "";
                        mbmemoryType = motherboardsockets.ContainsKey("Memory Type") ? motherboardsockets["Memory Type"] : "";
                        ramtype = GetSingleValue("SELECT [Memory Type] FROM [RAM specs] WHERE [RAM Module Name] = @prodchoice", "@prodchoice", choice, "Memory Type");

                        comp1.Visible = true;
                        spec1.Visible = true;
                        border1.Visible = true;
                        comp2.Visible = true;
                        spec2.Visible = true;
                        border2.Visible = true;
                        if (motherboardName != "")
                        {
                            comp1.Text = $"{motherboardName} Memory Slots";
                            spec1.Text = mbmemoryslots;
                            comp2.Text = $"{motherboardName} Memory Type";
                            spec2.Text = mbmemoryType;
                        }
                        else
                        {
                            comp1.Text = "No motherboard selected.";
                            spec1.Visible = false;
                            border1.Visible = false;
                            border2.Visible = false;
                            comp2.Visible = false;
                            spec2.Visible = false;
                        }
                        break;

                    case 13: //HDD
                        comp1.Visible = true;
                        spec1.Visible = true;
                        comp2.Visible = true;
                        spec2.Visible = true;
                        border1.Visible = true;
                        border2.Visible = true;
                        if (motherboardName != "")
                        {
                            comp1.Text = $"{motherboardName} SATA Ports";
                            spec1.Text = mbsataports;
                        }
                        else
                        {
                            comp1.Text = "No motherboard selected.";
                            spec1.Visible = false;
                            border1.Visible = false;
                        }
                        if(ssdName != "")
                        {
                            comp2.Text = ssdName;
                            spec2.Text = $"x {ssdquan}";
                        }

                        else
                        {
                            comp2.Visible = false;
                            spec2.Visible = false;
                            border2.Visible = false;
                        }
                        break;

                    case 14: //SSD
                        comp1.Visible = true;
                        spec1.Visible = true;
                        comp2.Visible = true;
                        spec2.Visible = true;
                        border1.Visible = true;
                        border2.Visible = true;
                        if (motherboardName != "")
                        {
                            comp1.Text = $"{motherboardName} SATA Ports";
                            spec1.Text = mbsataports;
                        }
                        else
                        {
                            comp1.Text = "No motherboard selected.";
                            spec1.Visible = false;
                            border1.Visible = false;
                        }
                        if (hddName != "")
                        {
                            comp2.Text = hddName;
                            spec2.Text = $"x {hddquan}";
                        }

                        else
                        {
                            comp2.Visible = false;
                            spec2.Visible = false;
                            border2.Visible = false;
                        }
                        break;

                    case 15: //M2
                        comp1.Visible = true;
                        spec1.Visible = true;
                        border1.Visible = true;
                        comp2.Visible = true;
                        spec2.Visible = true;
                        border2.Visible = true;

                        if (motherboardName != "")
                        {
                            comp1.Text = $"{motherboardName} M2 Slots";
                            spec1.Text = mbm2slots;
                            comp2.Text = "PCIe Generation";
                            spec2.Text = pciegen;
                        }
                        else
                        {
                            comp1.Text = "No motherboard selected.";
                            spec1.Visible = false;
                            border1.Visible = false;
                        }
                        break;
                }
            }
        }

        private void but_add_Click(object sender, EventArgs e)
        {
            getcurrentuser();
            int mbsata, m2slot, usedsata;
            switch (menuchoice)
            {
                case 1:
                    if (mb_cpuSocket == "" || mb_cpuSocket == cpusocketype)
                    {
                        if (userCount > 0)
                        {
                            string updateQuery = "UPDATE Builds SET CPU = @CPU, [CPU price] = @price WHERE [user] = @Username";
                            try
                            {
                                dbManager.OpenConnection();
                                using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                                {

                                    updateCmd.Parameters.AddWithValue("@CPU", choice);
                                    updateCmd.Parameters.AddWithValue("@price", price);
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
                            string insertQuery = "INSERT INTO Builds ([user], [CPU], [CPU price]) VALUES (@Username, @CPU, @price)";
                            try
                            {
                                dbManager.OpenConnection();
                                using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                                {
                                    insertCmd.Parameters.AddWithValue("@Username", user);
                                    insertCmd.Parameters.AddWithValue("@CPU", choice);
                                    insertCmd.Parameters.AddWithValue("@price", price);
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

                    else
                    {
                        label2.Visible = true;
                        label2.ForeColor = Color.FromArgb(180, 18, 0);
                        label2.Text = "Incompatible with Motherboard";
                    }

                    break;

                case 2:
                    if (userCount > 0)
                    {
                        string updateQuery = "UPDATE Builds SET GPU = @GPU, [GPU price] = @price WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@GPU", choice);
                                updateCmd.Parameters.AddWithValue("@price", price);
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
                        string insertQuery = "INSERT INTO Builds ([user], GPU, [GPU price]) VALUES (@Username, @GPU, @price)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@Username", user);
                                insertCmd.Parameters.AddWithValue("@GPU", choice);
                                insertCmd.Parameters.AddWithValue("@price", price);
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

                    if (cpusocketype == "" || cpusocketype == mb_cpuSocket)
                    {
                        if (userCount > 0)
                        {
                            string updateQuery = "UPDATE Builds SET Motherboard = @mb, [Motherboard price] = @price WHERE [user] = @Username";
                            try
                            {
                                dbManager.OpenConnection();
                                using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                                {
                                    updateCmd.Parameters.AddWithValue("@mb", choice);
                                    updateCmd.Parameters.AddWithValue("@price", price);
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
                            string insertQuery = "INSERT INTO Builds (Motherboard, [user], [Motherboard price]) VALUES (@mb, @Username, @price)";
                            try
                            {
                                dbManager.OpenConnection();
                                using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                                {
                                    insertCmd.Parameters.AddWithValue("@mb", choice);
                                    insertCmd.Parameters.AddWithValue("@price", price);
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

                    else
                    {
                        label2.Visible = true;
                        label2.ForeColor = Color.FromArgb(180, 18, 0);
                        label2.Text = "Incompatible with Processor";
                    }
                    break;

                case 4:

                    if (mbmemoryslots == "" || mbmemoryslots.Substring(2) == ramtype)
                    {
                        if (userCount > 0)
                        {
                            quantity = int.Parse(comboBox1.Text);
                            string updateQuery = "UPDATE Builds SET RAM = @ram, [RAM Quantity] = @ramQuantity, [RAM price] = @price WHERE [user] = @Username";
                            try
                            {
                                dbManager.OpenConnection();
                                using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                                {
                                    updateCmd.Parameters.AddWithValue("@ram", choice);
                                    updateCmd.Parameters.AddWithValue("@ramQuantity", quantity);
                                    updateCmd.Parameters.AddWithValue("@price", price);
                                    updateCmd.Parameters.AddWithValue("@Username", user);
                                    label2.Visible = true;
                                    int rowsAffected = updateCmd.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error updating RAM and RAM quantity for existing user: " + ex.Message);
                            }
                            finally
                            {
                                dbManager.CloseConnection();
                            }
                        }
                        else
                        {
                            string insertQuery = "INSERT INTO Builds (RAM, [RAM Quantity], [user], [RAM price]) VALUES (@ram, @ramQuantity, @Username, @price)";
                            try
                            {
                                dbManager.OpenConnection();
                                using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                                {
                                    insertCmd.Parameters.AddWithValue("@ram", choice);
                                    insertCmd.Parameters.AddWithValue("@ramQuantity", quantity);
                                    insertCmd.Parameters.AddWithValue("@price", price);
                                    insertCmd.Parameters.AddWithValue("@Username", user);
                                    label2.Visible = true;
                                    int rowsAffected = insertCmd.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error inserting RAM and RAM quantity for new user: " + ex.Message);
                            }
                            finally
                            {
                                dbManager.CloseConnection();
                            }
                        }
                    }

                    else
                    {
                        label2.Visible = true;
                        label2.ForeColor = Color.FromArgb(180, 18, 0);
                        label2.Text = "Incompatible with Motherboard";
                    }
                    break;


                case 6:
                    if (userCount > 0)
                    {
                        string updateQuery = "UPDATE Builds SET PSU = @psu, [PSU price] = @price WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@psu", choice);
                                updateCmd.Parameters.AddWithValue("@price", price);
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
                        string insertQuery = "INSERT INTO Builds (PSU, [user], [PSU price]) VALUES (@psu, @Username, @price)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@psu", choice);
                                insertCmd.Parameters.AddWithValue("@price", price);
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
                        string updateQuery = "UPDATE Builds SET [Computer Case] = @ccase, [Case price] = @price WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@ccase", choice);
                                updateCmd.Parameters.AddWithValue("@price", price);
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
                        string insertQuery = "INSERT INTO Builds ([Computer Case], [user], [Case price]) VALUES (@ccase, @Username, @price)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@ccase", choice);
                                insertCmd.Parameters.AddWithValue("@price", price);
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
                        string updateQuery = "UPDATE Builds SET [Monitor] = @monitor, [Monitor price] = @price WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@monitor", choice);
                                updateCmd.Parameters.AddWithValue("@price", price);
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
                        string insertQuery = "INSERT INTO Builds ([Monitor], [user], [Monitor price]) VALUES (@monitor, @Username, @price)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@monitor", choice);
                                insertCmd.Parameters.AddWithValue("@price", price);
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
                        string updateQuery = "UPDATE Builds SET [Keyboard] = @keyboard, [Keyboard price] = @price WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@keyboard", choice);
                                updateCmd.Parameters.AddWithValue("@price", price);
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
                        string insertQuery = "INSERT INTO Builds ([Keyboard], [user], [Keyboard price]) VALUES (@keyboard, @Username, @price)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@keyboard", choice);
                                insertCmd.Parameters.AddWithValue("@price", price);
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
                        string updateQuery = "UPDATE Builds SET [Mouse] = @mouse, [Mouse price] = @price WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@mouse", choice);
                                updateCmd.Parameters.AddWithValue("@price", price);
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
                        string insertQuery = "INSERT INTO Builds ([Mouse], [user], [Mouse price]) VALUES (@mouse, @Username, @price)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@mouse", choice);
                                insertCmd.Parameters.AddWithValue("@price", price);
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
                        string updateQuery = "UPDATE Builds SET [Speakers] = @speaker, [Speakers price] = @price WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@speaker", choice);
                                updateCmd.Parameters.AddWithValue("@price", price);
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
                        string insertQuery = "INSERT INTO Builds ([Speaker], [user], [Speakers price]) VALUES (@speaker, @Username, @price)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@speaker", choice);
                                insertCmd.Parameters.AddWithValue("@price", price);
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
                    quantity = int.Parse(comboBox1.Text); 
                    mbsata = int.Parse(mbsataports.Substring(0, 1));
                    usedsata = int.Parse(spec2.Text.Replace("x", "").Replace(" ", "")) + quantity;
                    MessageBox.Show(usedsata.ToString());
                    if (mbsata >= usedsata)
                    {
                        if (userCount > 0)
                        {
                            string updateQuery = "UPDATE Builds SET [HDD quantity] = @quan, [HDD] = @hdd, [HDD price] = @price WHERE [user] = @Username";
                            try
                            {
                                dbManager.OpenConnection();
                                using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                                {
                                    updateCmd.Parameters.AddWithValue("@quan", quantity);
                                    updateCmd.Parameters.AddWithValue("@hdd", choice);
                                    updateCmd.Parameters.AddWithValue("@price", price);
                                    updateCmd.Parameters.AddWithValue("@Username", user);
                                    label2.Visible = true;
                                    label2.ForeColor = SystemColors.ControlText;
                                    label2.Text = "Added to your build!";
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
                            string insertQuery = "INSERT INTO Builds ([HDD quantity], [HDD], [user], [HDD price]) VALUES (@quan, @hdd, @Username, @price)";
                            try
                            {
                                dbManager.OpenConnection();
                                using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                                {
                                    insertCmd.Parameters.AddWithValue("@quan", quantity);
                                    insertCmd.Parameters.AddWithValue("@hdd", choice);
                                    insertCmd.Parameters.AddWithValue("@price", price);
                                    insertCmd.Parameters.AddWithValue("@Username", user);
                                    label2.Visible = true; 
                                    label2.ForeColor = SystemColors.ControlText;
                                    label2.Text = "Added to your build!";
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
                    }
                    else
                    {
                        label2.Visible = true;
                        label2.ForeColor = Color.FromArgb(180, 18, 0);
                        label2.Text = "Not enough SATA ports.";
                    }
                    break;

                case 14:
                    quantity = int.Parse(comboBox1.Text);
                    mbsata = int.Parse(mbsataports.Substring(0, 1));
                    usedsata = int.Parse(spec2.Text.Replace("x", "").Replace(" ", "")) + quantity;
                    MessageBox.Show(usedsata.ToString());
                    if (mbsata >= usedsata)
                    {
                        if (userCount > 0)
                        {
                            string updateQuery = "UPDATE Builds SET [SSD quantity] = @quan, [SSD] = @ssd, [SSD price] = @price WHERE [user] = @Username";
                            try
                            {
                                dbManager.OpenConnection();
                                using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                                {
                                    updateCmd.Parameters.AddWithValue("@quan", quantity);
                                    updateCmd.Parameters.AddWithValue("@ssd", choice);
                                    updateCmd.Parameters.AddWithValue("@price", price);
                                    updateCmd.Parameters.AddWithValue("@Username", user);
                                    label2.Visible = true;
                                    label2.ForeColor = SystemColors.ControlText;
                                    label2.Text = "Added to your build!";
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
                            string insertQuery = "INSERT INTO Builds ([SSD quantity], [SSD], [user], [SSD price]) VALUES (@quan, @ssd, @Username, @price)";
                            try
                            {
                                dbManager.OpenConnection();
                                using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                                {
                                    insertCmd.Parameters.AddWithValue("@quan", quantity);
                                    insertCmd.Parameters.AddWithValue("@ssd", choice);
                                    insertCmd.Parameters.AddWithValue("@price", price);
                                    insertCmd.Parameters.AddWithValue("@Username", user);
                                    label2.Visible = true;
                                    label2.ForeColor = SystemColors.ControlText;
                                    label2.Text = "Added to your build!";
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
                    }
                    else
                    {
                        label2.Visible = true;
                        label2.ForeColor = Color.FromArgb(180, 18, 0);
                        label2.Text = "Not enough SATA ports.";
                    }

                    break;
                case 15:
                    quantity = int.Parse(comboBox1.Text);
                    m2slot = int.Parse(mbm2slots.Substring(0, 1));
                    if (m2slot >= quantity)
                    {
                        if (userCount > 0)
                        {
                            string updateQuery = "UPDATE Builds SET [M2 SSD quantity] = @quan, [M2 SSD] = @m2Ssd, [M2 price] = @price WHERE [user] = @Username";
                            try
                            {
                                dbManager.OpenConnection();
                                using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                                {
                                    updateCmd.Parameters.AddWithValue("@quan", quantity);
                                    updateCmd.Parameters.AddWithValue("@m2Ssd", choice);
                                    updateCmd.Parameters.AddWithValue("@price", price);
                                    updateCmd.Parameters.AddWithValue("@Username", user);
                                    label2.Visible = true;
                                    label2.ForeColor = SystemColors.ControlText;
                                    label2.Text = "Added to your build!";
                                    int rowsAffected = updateCmd.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error updating M.2 SSD for existing user: " + ex.Message);
                            }
                            finally
                            {
                                dbManager.CloseConnection();
                            }
                        }
                        else
                        {
                            string insertQuery = "INSERT INTO Builds ([M2 SSD quantity], [M2 SSD], [user], [M2 price]) VALUES (@quan, @m2Ssd, @Username, @price)";
                            try
                            {
                                dbManager.OpenConnection();
                                using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                                {
                                    insertCmd.Parameters.AddWithValue("@quan", quantity);
                                    insertCmd.Parameters.AddWithValue("@m2Ssd", choice);
                                    insertCmd.Parameters.AddWithValue("@price", price);
                                    insertCmd.Parameters.AddWithValue("@Username", user);
                                    label2.Visible = true;
                                    label2.ForeColor = SystemColors.ControlText;
                                    label2.Text = "Added to your build!";
                                    int rowsAffected = insertCmd.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error inserting M.2 SSD for new user: " + ex.Message);
                            }
                            finally
                            {
                                dbManager.CloseConnection();
                            }
                        }
                    }
                    else
                    {
                        label2.Visible = true;
                        label2.ForeColor = Color.FromArgb(180, 18, 0);
                        label2.Text = "Not enough M2 slots.";
                    }

                    break;

                case 16:
                    quantity = int.Parse(comboBox1.Text);
                    if (userCount > 0)
                    {
                        string updateQuery = "UPDATE Builds SET [Fan quantity] = @quan, [Fans] = @fans, [Fan price] = @price WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@quan", quantity);
                                updateCmd.Parameters.AddWithValue("@fans", choice);
                                updateCmd.Parameters.AddWithValue("@price", price);
                                updateCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = updateCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating computer fans for existing user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }

                    else
                    {
                        string insertQuery = "INSERT INTO Builds ([Fans quantity], [Fans], [user], [Fan price]) VALUES (@quan, @fans, @Username, @price)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@quan", quantity);
                                insertCmd.Parameters.AddWithValue("@fans", choice);
                                insertCmd.Parameters.AddWithValue("@price", price);
                                insertCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = insertCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inserting computer fans for new user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }

                    break;

                case 17:
                    if (userCount > 0)
                    {
                        string updateQuery = "UPDATE Builds SET [CPU Air Cooler] = @cpuCooler, [CPU Air Cooler price] = @price WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@cpuCooler", choice);
                                updateCmd.Parameters.AddWithValue("@price", price);
                                updateCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = updateCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating CPU Cooler for existing user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO Builds ([CPU Air Cooler], [user], [CPU Air Cooler price]) VALUES (@cpuCooler, @Username, @price)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@cpuCooler", choice);
                                insertCmd.Parameters.AddWithValue("@price", price);
                                insertCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = insertCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inserting CPU Cooler for new user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    update = "UPDATE Builds SET [AIO Cooler] = '', [AIO Cooler price] = '' WHERE [user] = @UserToUpdate";

                    try
                    {
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            using (OleDbCommand command = new OleDbCommand(update, connection))
                            {
                                command.Parameters.AddWithValue("@UserToUpdate", user);

                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating data: " + ex.Message);
                    }

                    break;
                case 18:
                    if (userCount > 0)
                    {
                        string updateQuery = "UPDATE Builds SET [AIO Cooler] = @aioCooler, [AIO Cooler price] = @price WHERE [user] = @Username";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                            {
                                updateCmd.Parameters.AddWithValue("@aioCooler", choice);
                                updateCmd.Parameters.AddWithValue("@price", price);
                                updateCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = updateCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating AIO Cooler for existing user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO Builds ([AIO Cooler], [user], [AIO Cooler price]) VALUES (@aioCooler, @Username, @price)";
                        try
                        {
                            dbManager.OpenConnection();
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@aioCooler", choice);
                                insertCmd.Parameters.AddWithValue("@price", price);
                                insertCmd.Parameters.AddWithValue("@Username", user);
                                label2.Visible = true;
                                int rowsAffected = insertCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inserting AIO Cooler for new user: " + ex.Message);
                        }
                        finally
                        {
                            dbManager.CloseConnection();
                        }

                    }
                    update = "UPDATE Builds SET [CPU Air Cooler] = '', [CPU Air Cooler price] = '' WHERE [user] = @UserToUpdate";

                    try
                    {
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            using (OleDbCommand command = new OleDbCommand(update, connection))
                            {
                                command.Parameters.AddWithValue("@UserToUpdate", user);

                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating data: " + ex.Message);
                    }
                    break;

            }


            
        }

        private void display(string choice)
        {
            Dictionary<string, System.Drawing.Image> images = null;
            string query = null;
            int quan = 1;
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
                        { "Dominator Platinum 32GB DDR5-5200", Properties.Resources.ram_Dominator_Platinum_32GB_DDR5_5200 },
                        { "Ripjaws S5 Series DDR5", Properties.Resources.ram_Ripjaws_S5_Series_DDR5 },
                        { "Fury Renegade RGB DDR5", Properties.Resources.ram_FURY_Renegade_RGB_DDR5 },
                        { "T-Force Dark Z Alpha DDR5", Properties.Resources.ram_T_Force_Dark_Z_Alpha_DDR5 }
                    };
                    query = "SELECT * FROM [RAM specs] WHERE [RAM Module Name] = @name";
                    comboBox1.Items.Insert(1, "2");
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
                        { "Klipsch R-41M", Properties.Resources.spe_Klipsch_R_41M },
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
                        { "Seagate BarraCuda Pro 14TB", Properties.Resources.hdd_Seagate_BarraCuda_Pro_14TB },
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
                    for (int i = 2; i <= 10; i++)
                    {
                        comboBox1.Items.Add(i.ToString());
                    }

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
                    for (int i = 2; i <= 10; i++)
                    {
                        comboBox1.Items.Add(i.ToString());
                    }

                    break;


                case 15:
                    mainApp.back = 15;
                    images = new Dictionary<string, System.Drawing.Image>
                    {
                        { "Sandisk SSD Plus M.2 NVME 500GB", Properties.Resources.m2_Sandisk_SSD_Plus_M_2_NVME_500GB },
                        { "Transcend PCIe SSD 250H 4TB", Properties.Resources.m2_Transcend_PCIe_SSD_250H_4TB },
                        { "Mushkin Enhanced Vortex M.2 2280 512GB", Properties.Resources.m2_Mushkin_Enhanced_Vortex_M_2_2280_512GB },
                        { "OWC Aura Pro X2 1TB", Properties.Resources.m2_OWC_Aura_Pro_X2_1TB },
                        { "Gigabyte AORUS NVMe Gen4 SSD 1TB", Properties.Resources.m2_Gigabyte_AORUS_NVMe_Gen4_SSD_1TB },
                        { "PNY CS900 M.2 SATA III SSD 500GB", Properties.Resources.m2_PNY_CS900_M_2_SATA_III_SSD_500GB },
                        { "Lexar NM710 M.2 1TB", Properties.Resources.m2_Lexar_NM710_M_2_1TB },
                        { "Patriot Memory Scorch 512GB", Properties.Resources.m2_Patriot_Memory_Scorch_512GB },
                        { "Team Group MP33 PRO 1TB", Properties.Resources.m2_Team_Group_MP33_PRO_1TB },
                        { "Silicon Power Ace A55 1TB", Properties.Resources.m2_Silicon_Power_Ace_A55_1TB },
                        { "Toshiba XG6 SSD 512GB", Properties.Resources.m2_Toshiba_XG6_SSD_512GB },
                        { "Corsair Force Series MP510 500GB", Properties.Resources.m2_Corsair_Force_Series_MP510_500GB },
                        { "Intel SSD 545s 256GB", Properties.Resources.m2_Intel_SSD_545s_256GB },
                        { "Seagate Barracuda PCIe 2TB", Properties.Resources.m2_Seagate_Barracuda_PCIe_2TB },
                        { "Adata SU800 512GB", Properties.Resources.m2_Adata_SU800_512GB },
                        { "Kingston UV500 240GB", Properties.Resources.m2_Kingston_UV500_240GB },
                        { "Crucial P5 Plus 2TB", Properties.Resources.m2_Crucial_P5_Plus_2TB },
                        { "WD Black SN850 2TB", Properties.Resources.m2_WD_Black_SN850_2TB },
                        { "Samsung 980 PRO 1TB", Properties.Resources.m2_Samsung_980_PRO_1TB },
                        { "HP S700 Pro 512GB", Properties.Resources.m2_HP_S700_Pro_512GB }
                    };
                    query = "SELECT * FROM [M2 SSD specs] WHERE [M2 Name] = @name";
                    for (int i = 2; i <= 5; i++)
                    {
                        comboBox1.Items.Add(i.ToString());
                    }

                    break;

                case 16:
                    mainApp.back = 16;
                    images = new Dictionary<string, System.Drawing.Image>
                    {
                        { "Be Quiet! Silent Wings 3", Properties.Resources.fan_Be_Quiet__Silent_Wings_3 },
                        { "Lian Li UNI FAN SL120 V2 RGB", Properties.Resources.fan_Lian_Li_UNI_FAN_SL120_V2_RGB },
                        { "EK-Vardar EVO 120ER RGB", Properties.Resources.fan_EK_Vardar_EVO_120ER_RGB },
                        { "Phanteks PH-F120MP", Properties.Resources.fan_Phanteks_PH_F120MP },
                        { "Thermaltake ToughFan 12 Turbo", Properties.Resources.fan_Thermaltake_ToughFan_12_Turbo },
                        { "Be Quiet! PURE WINGS 2", Properties.Resources.fan_Be_Quiet__PURE_WINGS_2 },
                        { "MSI MEG SILENT GALE P12", Properties.Resources.fan_MSI_MEG_SILENT_GALE_P12 },
                        { "NZXT Aer P 120MM", Properties.Resources.fan_NZXT_Aer_P_120MM },
                        { "Cooler Master MasterFan MF120 Halo RGB", Properties.Resources.fan_Cooler_Master_MasterFan_MF120_Halo_RGB },
                        { "DeepCool CF120-3 IN 1", Properties.Resources.fan_DeepCool_CF120_3_IN_1 },
                        { "Corsair ML120 PRO", Properties.Resources.fan_Corsair_ML120_PRO },
                        { "ROG STRIX XF 120", Properties.Resources.fan_ROG_STRIX_XF_120 },
                        { "Corsair iCUE AR120 Digital RGB 120mm", Properties.Resources.fan_Corsair_iCUE_AR120_Digital_RGB_120mm },
                        { "MSI MAG MAX F20A-1", Properties.Resources.fan_MSI_MAG_MAX_F20A_1 },
                        { "Asus TUF Gaming TF120 ARGB", Properties.Resources.fan_Asus_TUF_Gaming_TF120_ARGB },
                        { "Noctua NF-A12x25 PWM", Properties.Resources.fan_Noctua_NF_A12x25_PWM },
                        { "Noctua NF-P12 redux-1700", Properties.Resources.fan_Noctua_NF_P12_redux_1700 },
                        { "Scythe Kaze Flex 120 PWM", Properties.Resources.fan_Scythe_Kaze_Flex_120_PWM },
                        { "Corsair iCUE LINK QX120 RGB", Properties.Resources.fan_Corsair_iCUE_LINK_QX120_RGB },
                        { "NZXT F120 RGB Duo", Properties.Resources.fan_NZXT_F120_RGB_Duo }
                    };
                    query = "SELECT * FROM [Fan specs] WHERE [Fan Name] = @name";
                    for (int i = 2; i <= 10; i++)
                    {
                        comboBox1.Items.Add(i.ToString());
                    }

                    break;

                case 17:
                    mainApp.back = 17;
                    images = new Dictionary<string, System.Drawing.Image>
                    {
                        { "Thermalright Phantom Spirit 120 EVO", Properties.Resources.air_Thermalright_Phantom_Spirit_120_EVO },
                        { "Thermalright Peerless Assassin 120 SE", Properties.Resources.air_Thermalright_Peerless_Assassin_120_SE },
                        { "Deepcool AS500 Plus", Properties.Resources.air_Deepcool_AS500_Plus },
                        { "Noctua NH-U14S", Properties.Resources.air_Noctua_NH_U14S },
                        { "Be Quiet! Pure Rock 2", Properties.Resources.air_Be_Quiet__Pure_Rock_2 },
                        { "Noctua NH-D15 Chromax Black", Properties.Resources.air_Noctua_NH_D15_Chromax_Black },
                        { "Cooler Master Hyper 212 Halo", Properties.Resources.air_Cooler_Master_Hyper_212_Halo },
                        { "Cryorig C7", Properties.Resources.air_Cryorig_C7 },
                        { "Thermalright AXP120-X67", Properties.Resources.air_Thermalright_AXP120_X67 },
                        { "ID-Cooling SE-214-XT ARGB", Properties.Resources.air_ID_Cooling_SE_214_XT_ARGB },
                        { "DeepCool Assassin IV", Properties.Resources.air_DeepCool_Assassin_IV },
                        { "Jonsbo CR-1200", Properties.Resources.air_Jonsbo_CR_1200 },
                        { "Corsair A115", Properties.Resources.air_Corsair_A115 },
                        { "DeepCool AK620", Properties.Resources.air_DeepCool_AK620 },
                        { "Cooler Master Hyper H412R", Properties.Resources.air_Cooler_Master_Hyper_H412R },
                        { "Noctua NH-L9 series", Properties.Resources.air_Noctua_NH_L9_series },
                        { "Cooler Master Hyper 212 EVO V2", Properties.Resources.air_Cooler_Master_Hyper_212_EVO_V2 },
                        { "Cryorig H7", Properties.Resources.air_Cryorig_H7 },
                        { "be Quiet! Dark Rock Pro 4", Properties.Resources.air_be_Quiet__Dark_Rock_Pro_4 },
                        { "Corsair A500", Properties.Resources.air_Corsair_A500 }
                    };
                    query = "SELECT * FROM [CPU Air Cooler specs] WHERE [CPU Air Cooler] = @name";
                    break;

                case 18:
                    mainApp.back = 18;
                    images = new Dictionary<string, System.Drawing.Image>
                    {
                        { "Iceberg Thermal IceFLOE Oasis 360mm", Properties.Resources.aio_Iceberg_Thermal_IceFLOE_Oasis_360mm },
                        { "Silverstone IceMyst 360", Properties.Resources.aio_Silverstone_IceMyst_360 },
                        { "Corsair iCUE H170i Elite LCD XT", Properties.Resources.aio_Corsair_iCUE_H170i_Elite_LCD_XT },
                        { "Lian Li Galahad II LCD 280", Properties.Resources.aio_Lian_Li_Galahad_II_LCD_280 },
                        { "Lian Li Galahad II Trinity Performance 240", Properties.Resources.aio_Lian_Li_Galahad_II_Trinity_Performance_240 },
                        { "Arctic Liquid Freezer III 280 A-RGB", Properties.Resources.aio_Arctic_Liquid_Freezer_III_280_A_RGB },
                        { "Corsair iCUE H170i Elite Capellix XT", Properties.Resources.aio_Corsair_iCUE_H170i_Elite_Capellix_XT },
                        { "Deepcool Gammaxx L240 V2", Properties.Resources.aio_Deepcool_Gammaxx_L240_V2 },
                        { "Arctic Liquid Freezer II 360 ARGB", Properties.Resources.aio_Arctic_Liquid_Freezer_II_360_ARGB },
                        { "MSI MEG CoreLiquid S360", Properties.Resources.aio_MSI_MEG_CoreLiquid_S360 },
                        { "NZXT Kraken Elite 360 RGB", Properties.Resources.aio_NZXT_Kraken_Elite_360 },
                        { "Corsair H55 Liquid Cooler", Properties.Resources.aio_Corsair_H55_Liquid_Cooler },
                        { "Corsair iCUE H100i RGB Elite Liquid CPU Cooler", Properties.Resources.aio_iCUE_H100i_RGB_Elite_Liquid_CPU_Cooler },
                        { "Cooler Master MasterLiquid ML240L V2 RGB", Properties.Resources.aio_CoolerMaster_MasterLiquid_ML240L_V2_RGB },
                        { "be quiet! Silent Loop 2 120mm", Properties.Resources.aio_be_quiet__Silent_Loop_2_120mm },
                        { "Antec Vortex 240 ARGB", Properties.Resources.aio_Antec_Vortex_240_ARGB },
                        { "EK Nucleus AIO CR240 Lux D-RGB", Properties.Resources.aio_EK_Nucleus_AIO_CR240_Lux_D_RGB },
                        { "Phanteks Glacier One 240 T30", Properties.Resources.aio_Phanteks_Glacier_One_240_T30 },
                        { "Thermaltake TH420 V2 ARGB Sync", Properties.Resources.aio_Thermaltake_TH420_V2_ARGB_Sync },
                        { "Alphacool Eisbaer Aurora", Properties.Resources.aio_Alphacool_Eisbaer_Aurora }
                    };
                    query = "SELECT * FROM [AIO Cooler specs] WHERE [AIO Cooler Name] = @name";
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

        void compatabilitydisplay()
        {

        }
    }
}
