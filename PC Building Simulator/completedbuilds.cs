using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace PC_Building_Simulator
{
    public partial class completedbuilds : Form
    {
        public int buildnum;
        private Panel[] panels;
        private List<string> buildData;
        private MainApp mainApp;
        private DisplayManager displayManager;
        public string CPU { get; set; }
    public string CPUPrice { get; set; }

    public string GPU { get; set; }
    public string GPUPrice { get; set; }

    public string Case { get; set; }
    public string CasePrice { get; set; }

    public string Motherboard { get; set; }
    public string MotherboardPrice { get; set; }

    public string RAM { get; set; }
    public int RAMQuantity { get; set; }
    public string RAMPrice { get; set; }

    public string HDD { get; set; }
    public int HDDQuantity { get; set; }
    public string HDDPrice { get; set; }

    public string SSD { get; set; }
    public int SSDQuantity { get; set; }
    public string SSDPrice { get; set; }

    public string PSU { get; set; }
    public string PSUPrice { get; set; }

    public string Fan { get; set; }
    public int FanQuantity { get; set; }
    public string FanPrice { get; set; }

    public string CPUCooler { get; set; }
    public string CPUCoolerPrice { get; set; }

        public completedbuilds(MainApp mainApp, int buildnum)
        {
            InitializeComponent();
            this.buildnum = buildnum;
            this.mainApp = mainApp;
            displayManager = new DisplayManager(mainApp);
            dbManager = new DatabaseManager("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");

            label10.Visible = false;
            InitializeDisplayManager();
            builds();
        }

        private void completedbuilds_Load(object sender, EventArgs e)
        {

        }
        private void InitializeDisplayManager()
        {
            DisplayManager displayManager = new DisplayManager(this);
        }
        private Dictionary<string, (string, int, int)> parts;
        private void builds()
        {
            mainApp.backicon.Visible = true;
            mainApp.back = 19;
            panels = new Panel[]{ panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10,
                panel11, panel12, panel13, panel14, panel15, panel16, panel17, panel18, panel19, panel20
            };
            for (int i = 0; i < 20; i++)
            {
                panels[i].Visible = false;
            }

            int index = 0;
            switch (buildnum)
            {
                case 1:
                    mainApp.label_menu.Text = "Ultimate Creator Build";
                    total_price.Text = "$6446";
                    parts = new Dictionary<string, (string, int, int)>()
                {
                    { "cpu", ("Intel Core i9-14900K", 550, 1) },
                    { "", ("Nvidia GeForce RTX 4080 Founders Edition", 1750, 1) },
                    { "case", ("be quiet! Pure Base 500DX", 120, 1) },
                    { "mb", ("ASRock Z690 Extreme", 700, 1) },
                    { "ram", ("Dominator Platinum 32GB DDR5 5200", 275, 2) },
                    { "hdd", ("Western Digital Gold 18TB", 475, 4) },
                    { "m2", ("WD Black SN850 2TB", 315, 1) },
                    { "psu", ("EVGA G+ 1000W Gold", 220, 1) },
                    { "fan", ("Scythe Kaze Flex 120 PWM", 18, 7) },
                    { "aio", ("MSI MEG CoreLiquid S360", 215, 1) }
                };

                    buildData = new List<string>(); // Initialize buildData

                    foreach (var kvp in parts)
                    {
                        panels[index].Visible = true;
                        PictureBox pictureBox = this.Controls.Find($"pbox{index + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            string resourceName;
                            if (kvp.Key == "")
                                resourceName = kvp.Key + kvp.Value.Item1.Replace(" ", "_").Replace("!", "_").Replace("+", "_").Replace("-", "_");
                            else
                                resourceName = kvp.Key + "_" + kvp.Value.Item1.Replace(" ", "_").Replace("!", "_").Replace("-", "_"); ;
                            pictureBox.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourceName);
                        }
                        Label labelname = this.Controls.Find($"labname{index + 1}", true).FirstOrDefault() as Label;
                        if (labelname != null)
                        {
                            labelname.Text = kvp.Value.Item1;
                        }

                        Label labelprice = this.Controls.Find($"labprice{index + 1}", true).FirstOrDefault() as Label;
                        if (labelprice != null)
                        {
                            labelprice.Text = $"${kvp.Value.Item2.ToString()}"; // Displaying the price
                        }

                        Label labelquantity = this.Controls.Find($"labquan{index + 1}", true).FirstOrDefault() as Label;
                        if (labelquantity != null)
                        {
                            if (kvp.Value.Item3 == 1)
                                labelquantity.Visible = false;
                            else
                                labelquantity.Text = $"{kvp.Value.Item3.ToString()} x"; // Displaying the quantity
                        }

                        // Add the data for each part to the buildData list
                        buildData.Add(kvp.Value.Item1); // Add the name of the part
                        buildData.Add(kvp.Value.Item2.ToString()); // Add the price of the part
                        buildData.Add(kvp.Value.Item3.ToString()); // Add the quantity of the part

                        index++;
                    }
                    break;

                case 2:
                    mainApp.label_menu.Text = "Ultimate Gaming Build";
                    total_price.Text = "$5525";
                    parts = new Dictionary<string, (string, int, int)>()
                    {
                        { "cpu", ("AMD Ryzen 9 7900X3D", 500, 1) },
                        { "", ("ASUS TUF Gaming RX 7800 XT", 1000, 1) },
                        { "case", ("ASUS ROG Strix Helios", 300, 1) },
                        { "mb", ("ASUS ROG Strix X670E-E Gaming WiFi", 500, 1) },
                        { "ram", ("Vengeance RGB DDR5", 210, 2) },
                        { "hdd", ("Seagate BarraCuda Pro 14TB", 425, 3) },
                        { "m2", ("Samsung 980 PRO 1TB", 165, 4) },
                        { "psu", ("Asus ROG Thor 1200W Platinum", 450, 1) },
                        { "fan", ("Corsair iCUE LINK QX120 RGB", 35, 7) },
                        { "aio", ("Iceberg Thermal IceFLOE Oasis 360mm", 175, 1) }
                    };
                    buildData = new List<string>(); // Initialize buildData

                    foreach (var kvp in parts)
                    {
                        panels[index].Visible = true;
                        PictureBox pictureBox = this.Controls.Find($"pbox{index + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            string resourceName;
                            if (kvp.Key == "")
                                resourceName = kvp.Key + kvp.Value.Item1.Replace(" ", "_").Replace("!", "_").Replace("+", "_").Replace("-", "_");
                            else
                                resourceName = kvp.Key + "_" + kvp.Value.Item1.Replace(" ", "_").Replace("!", "_").Replace("-", "_");
                            pictureBox.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourceName);
                            
                        }
                        Label labelname = this.Controls.Find($"labname{index + 1}", true).FirstOrDefault() as Label;
                        if (labelname != null)
                        {
                            labelname.Text = kvp.Value.Item1;
                        }

                        Label labelprice = this.Controls.Find($"labprice{index + 1}", true).FirstOrDefault() as Label;
                        if (labelprice != null)
                        {
                            labelprice.Text = $"${kvp.Value.Item2.ToString()}"; // Displaying the price
                        }

                        Label labelquantity = this.Controls.Find($"labquan{index + 1}", true).FirstOrDefault() as Label;
                        if (labelquantity != null)
                        {
                            if (kvp.Value.Item3 == 1)
                                labelquantity.Visible = false;
                            else
                                labelquantity.Text = $"{kvp.Value.Item3.ToString()} x"; // Displaying the quantity
                        }

                        // Add the data for each part to the buildData list
                        buildData.Add(kvp.Value.Item1); // Add the name of the part
                        buildData.Add(kvp.Value.Item2.ToString()); // Add the price of the part
                        buildData.Add(kvp.Value.Item3.ToString()); // Add the quantity of the part

                        index++;
                    }
                    break;
            }
            
        }

        private DatabaseManager dbManager;
        private string user;
        private int userCount = 0;
        private string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
        private void but_add_Click(object sender, EventArgs e)
        {
            CPU = buildData[0];
            CPUPrice = "$" + buildData[1];

            GPU = buildData[3];
            GPUPrice = "$" + buildData[4];

            Case = buildData[6];
            CasePrice = "$" + buildData[7];

            Motherboard = buildData[9];
            MotherboardPrice = "$" + buildData[10];

            RAM = buildData[12];
            RAMPrice = "$" + buildData[13];
            RAMQuantity = int.Parse(buildData[14]);

            HDD = buildData[15];
            HDDPrice = "$" + buildData[16];
            HDDQuantity = int.Parse(buildData[17]);

            SSD = buildData[18];
            SSDPrice = "$" + buildData[19];
            SSDQuantity = int.Parse(buildData[20]);

            PSU = buildData[21];
            PSUPrice = "$" + buildData[22];

            Fan = buildData[24];
            FanPrice = "$" + buildData[25];
            FanQuantity = int.Parse(buildData[26]);

            CPUCooler = buildData[27];
            CPUCoolerPrice = "$" + buildData[28];




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

            if (userCount > 0)
            {
                string updateQuery = "UPDATE Builds SET CPU = @CPU, [CPU price] = @CPUPrice, " +
                    "GPU = @GPU, [GPU price] = @GPUPrice, " +
                    "Motherboard = @Motherboard, [Motherboard price] = @MotherboardPrice, " +
                    "[RAM quantity] = @RAMQuantity, RAM = @RAM, [RAM price] = @RAMPrice, " +
                    "PSU = @PSU, [PSU price] = @PSUPrice, " +
                    "[Computer Case] = @Case, [Case price] = @CasePrice, " +
                    "[HDD quantity] = @HDDQuantity, HDD = @HDD, [HDD price] = @HDDPrice, " +
                    "[M2 SSD quantity] = @SSDQuantity, [M2 SSD] = @SSD, [M2 price] = @SSDPrice, " +
                    "[Fan quantity] = @FanQuantity, Fans = @Fan, [Fan price] = @FanPrice, " +
                    "[AIO Cooler] = @CPUCooler, [AIO Cooler price] = @CPUCoolerPrice " +
                    "WHERE [user] = @Username";

                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, dbManager.GetConnection()))
                    {
                        updateCmd.Parameters.AddWithValue("@CPU", CPU);
                        updateCmd.Parameters.AddWithValue("@CPUPrice", CPUPrice);
                        updateCmd.Parameters.AddWithValue("@GPU", GPU);
                        updateCmd.Parameters.AddWithValue("@GPUPrice", GPUPrice);
                        updateCmd.Parameters.AddWithValue("@Motherboard", Motherboard);
                        updateCmd.Parameters.AddWithValue("@MotherboardPrice", MotherboardPrice);
                        updateCmd.Parameters.AddWithValue("@RAMQuantity", RAMQuantity);
                        updateCmd.Parameters.AddWithValue("@RAM", RAM);
                        updateCmd.Parameters.AddWithValue("@RAMPrice", RAMPrice);
                        updateCmd.Parameters.AddWithValue("@PSU", PSU);
                        updateCmd.Parameters.AddWithValue("@PSUPrice", PSUPrice);
                        updateCmd.Parameters.AddWithValue("@Case", Case);
                        updateCmd.Parameters.AddWithValue("@CasePrice", CasePrice);
                        updateCmd.Parameters.AddWithValue("@HDDQuantity", HDDQuantity);
                        updateCmd.Parameters.AddWithValue("@HDD", HDD);
                        updateCmd.Parameters.AddWithValue("@HDDPrice", HDDPrice);
                        updateCmd.Parameters.AddWithValue("@SSDQuantity", SSDQuantity);
                        updateCmd.Parameters.AddWithValue("@SSD", SSD);
                        updateCmd.Parameters.AddWithValue("@SSDPrice", SSDPrice);
                        updateCmd.Parameters.AddWithValue("@FanQuantity", FanQuantity);
                        updateCmd.Parameters.AddWithValue("@Fan", Fan);
                        updateCmd.Parameters.AddWithValue("@FanPrice", FanPrice);
                        updateCmd.Parameters.AddWithValue("@CPUCooler", CPUCooler);
                        updateCmd.Parameters.AddWithValue("@CPUCoolerPrice", CPUCoolerPrice);
                        updateCmd.Parameters.AddWithValue("@Username", user);

                        label10.Visible = true;
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
                string insertQuery = "INSERT INTO Builds ([user], CPU, [CPU price], GPU, [GPU price], [Computer Case], [Case price], Motherboard, [Motherboard price], RAM, [RAM price], [RAM quantity], HDD, [HDD price], [HDD quantity], [M2 SSD], [M2 price], [M2 SSD quantity], PSU, [PSU price], Fan, [Fan price], [Fan quantity], [AIO Cooler], [AIO Cooler price]) " +
                    "VALUES (@Username, @CPU, @CPUPrice, @GPU, @GPUPrice, @Case, @CasePrice, @Motherboard, @MotherboardPrice, @RAM, @RAMPrice, @RAMQuantity, @HDD, @HDDPrice, @HDDQuantity, @SSD, @SSDPrice, @SSDQuantity, @PSU, @PSUPrice, @Fan, @FanPrice, @FanQuantity, @CPUCooler, @CPUCoolerPrice)";

                try
                {
                    dbManager.OpenConnection();
                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, dbManager.GetConnection()))
                    {
                        insertCmd.Parameters.AddWithValue("@Username", user);
                        insertCmd.Parameters.AddWithValue("@CPU", CPU);
                        insertCmd.Parameters.AddWithValue("@CPUPrice", CPUPrice);
                        insertCmd.Parameters.AddWithValue("@GPU", GPU);
                        insertCmd.Parameters.AddWithValue("@GPUPrice", GPUPrice);
                        insertCmd.Parameters.AddWithValue("@Case", Case);
                        insertCmd.Parameters.AddWithValue("@CasePrice", CasePrice);
                        insertCmd.Parameters.AddWithValue("@Motherboard", Motherboard);
                        insertCmd.Parameters.AddWithValue("@MotherboardPrice", MotherboardPrice);
                        insertCmd.Parameters.AddWithValue("@RAM", RAM);
                        insertCmd.Parameters.AddWithValue("@RAMPrice", RAMPrice);
                        insertCmd.Parameters.AddWithValue("@RAMQuantity", RAMQuantity);
                        insertCmd.Parameters.AddWithValue("@HDD", HDD);
                        insertCmd.Parameters.AddWithValue("@HDDPrice", HDDPrice);
                        insertCmd.Parameters.AddWithValue("@HDDQuantity", HDDQuantity);
                        insertCmd.Parameters.AddWithValue("@SSD", SSD);
                        insertCmd.Parameters.AddWithValue("@SSDPrice", SSDPrice);
                        insertCmd.Parameters.AddWithValue("@SSDQuantity", SSDQuantity);
                        insertCmd.Parameters.AddWithValue("@PSU", PSU);
                        insertCmd.Parameters.AddWithValue("@PSUPrice", PSUPrice);
                        insertCmd.Parameters.AddWithValue("@Fan", Fan);
                        insertCmd.Parameters.AddWithValue("@FanPrice", FanPrice);
                        insertCmd.Parameters.AddWithValue("@FanQuantity", FanQuantity);
                        insertCmd.Parameters.AddWithValue("@CPUCooler", CPUCooler);
                        insertCmd.Parameters.AddWithValue("@CPUCoolerPrice", CPUCoolerPrice);

                        label10.Visible = true;
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

    }
}
