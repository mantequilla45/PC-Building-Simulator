using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ComponentFactory.Krypton.Toolkit;

namespace PC_Building_Simulator
{
    public partial class buildmenu : Form
    {
        private PictureBox drive2pbox = new PictureBox();
        private PictureBox drive3pbox = new PictureBox();
        private KryptonButton drive2border = new KryptonButton();
        private KryptonButton drive3border = new KryptonButton();
        private Label drive2price = new Label();
        private Label drive3price = new Label();
        private Label drive2quan = new Label();
        private Label drive3quan = new Label();
        private Label drive2name = new Label();
        private Label drive3name = new Label();
        private Label remove_drive2 = new Label();
        private Label remove_drive3 = new Label();
        private int drivecount = 1;
        private string user = "";
        public static string cpu = "";
        public static string gpu = "";
        public static string mb = "";
        public static string ram = "";
        public static string psu = "";
        public static string ccase = "";
        public static string moni = "";
        public static string keyb = "";
        public static string mouse = "";
        public static string spk = "";
        public static string hdd = "";
        public static string ssd = "";
        public static string m2 = "";
        public static string fans = "";
        public static string aircooler = "";
        public static string ramquan = "";
        public static string cpuprice = "";
        public static string gpuprice = "";
        public static string mbprice = "";
        public static string ramprice = "";
        public static string psuprice = "";
        public static string caseprice = "";
        public static string moniprice = "";
        public static string keybprice = "";
        public static string mouseprice = "";
        public static string spkprice = "";
        public static string hddprice = "";
        public static string ssdprice = "";
        public static string m2price = "";
        public static string fanprice = "";
        public static string aircoolerprice = "";
        public buildmenu()
        {
            InitializeComponent();
            InitializeDisplayManager();
        }

        private void buildmenu_Load(object sender, EventArgs e)
        {

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";

            string query1 = "SELECT TOP 1 [user] FROM currentuser";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query1, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        user = result.ToString();
                    }
                }
            }
            string query = "SELECT CPU, [CPU price], GPU, [GPU price], Motherboard, [Motherboard price], [RAM quantity], RAM, " +
                "[RAM price], PSU, [PSU price], [Computer Case], [Case price], Monitor, [Monitor price], Keyboard, [Keyboard price], " +
                "Mouse, [Mouse price], Speakers, [Speakers price], HDD, [HDD price], SSD, [SSD price], [M2 SSD], [M2 price], " +
                "Fans, [Fan price], [CPU Air Cooler], [CPU Air Cooler price] FROM Builds WHERE [user] = @Username";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user);
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cpu = reader["CPU"].ToString();
                            cpuprice = reader["CPU price"].ToString();
                            gpu = reader["GPU"].ToString();
                            gpuprice = reader["GPU price"].ToString();
                            mb = reader["Motherboard"].ToString();
                            ram = reader["RAM"].ToString();
                            psu = reader["PSU"].ToString();
                            ccase = reader["Computer Case"].ToString();
                            moni = reader["Monitor"].ToString();
                            keyb = reader["Keyboard"].ToString();
                            mouse = reader["Mouse"].ToString();
                            spk = reader["Speakers"].ToString();
                            hdd = reader["HDD"].ToString();
                            ssd = reader["SSD"].ToString();
                            m2 = reader["M2 SSD"].ToString();
                            fans = reader["Fans"].ToString();
                            aircooler = reader["CPU Air Cooler"].ToString();
                            aircoolerprice = reader["CPU Air Cooler price"].ToString();
                            fanprice = reader["Fan price"].ToString();
                            ramquan = reader["RAM quantity"].ToString(); 
                            mbprice = reader["Motherboard price"].ToString();
                            ramprice = reader["RAM price"].ToString();
                            psuprice = reader["PSU price"].ToString();
                            caseprice = reader["Case price"].ToString();
                            moniprice = reader["Monitor price"].ToString();
                            keybprice = reader["Keyboard price"].ToString();
                            mouseprice = reader["Mouse price"].ToString();
                            spkprice = reader["Speakers price"].ToString();
                            hddprice = reader["HDD price"].ToString();
                            ssdprice = reader["SSD price"].ToString();
                            m2price = reader["M2 price"].ToString();

                        }
                        else
                        {
                            cpu = "";
                            cpuprice = "";
                            gpu = "";
                            gpuprice = "";
                            mb = "";
                            ram = "";
                            psu = "";
                            ccase = "";
                            moni = "";
                            keyb = "";
                            mouse = "";
                            spk = "";
                            hdd = "";
                            ssd = "";
                            m2 = "";
                            fans = "";
                            aircooler = "";
                            aircoolerprice = "";
                            fanprice = "";
                            ramquan = "";
                            mbprice = "";
                            ramprice = "";
                            psuprice = "";
                            caseprice = "";
                            moniprice = "";
                            keybprice = "";
                            mouseprice = "";
                            spkprice = "";
                            hddprice = "";
                            ssdprice = "";
                            m2price = "";

                        }
                    }
                }
            }

            // Displaying images for components
            string cpuimage = cpu.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string resourcecpu = $"cpu_{cpuimage}";
            pBox1.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcecpu);
            if (cpu != "")
            {
                label1.Text = cpu;
                label1.Visible = true;
                price_cpu.Text = cpuprice;
                pBox1.Visible = true;
                border1.Visible = true;
                price_cpu.Visible = true;
                quan_cpu.Visible = true;
                remove_cpu.Visible = true;
            }

            string gpuimage = gpu.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string resourcegpu = $"{gpuimage}";
            pBox2.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcegpu);
            if (gpu != "")
            {
                label2.Text = gpu;
                label2.Visible = true;
                price_gpu.Text = gpuprice;
                pBox2.Visible = true;
                border2.Visible = true;
                price_gpu.Visible = true;
                quan_gpu.Visible = true;
                remove_gpu.Visible = true;
            }

            string mbimage = mb.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string resourcemb = $"mb_{mbimage}";
            pBox3.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcemb);
            if (mb != "")
            {
                label3.Text = mb;
                label3.Visible = true;
                price_mb.Text = mbprice;
                pBox3.Visible = true;
                border3.Visible = true;
                price_mb.Visible = true;
                quan_mb.Visible = true;
                remove_mb.Visible = true;
            }

            string ramimage = ram.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string resourceram = $"ram_{ramimage}";
            pBox4.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourceram);
            if (ram != "")
            {
                label4.Text = ram;
                label4.Visible = true;
                quan_ram.Text = ramquan;
                price_ram.Text = ramprice;
                pBox4.Visible = true;
                border4.Visible = true;
                price_ram.Visible = true;
                quan_ram.Visible = true;
                remove_ram.Visible = true;
            }

            string psuimage = psu.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
            string resourcepsu = $"psu_{psuimage}";
            pBox6.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcepsu);
            if (psu != "")
            {
                label6.Text = psu;
                label6.Visible = true;
                price_psu.Text = psuprice;
                pBox6.Visible = true;
                border6.Visible = true;
                price_psu.Visible = true;
                quan_psu.Visible = true;
                remove_psu.Visible = true;
            }

            string caseimage = ccase.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
            string resourcecase = $"case_{caseimage}";
            pBox7.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcecase);
            if (ccase != "")
            {
                label7.Text = ccase;
                label7.Visible = true;
                price_case.Text = caseprice;
                pBox7.Visible = true;
                border7.Visible = true;
                price_case.Visible = true;
                quan_case.Visible = true;
                remove_case.Visible = true;
            }

            string monitorimage = moni.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
            string resourcemoni = $"mon_{monitorimage}";
            pBox9.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcemoni);
            if (moni != "")
            {
                label9.Text = moni;
                label9.Visible = true;
                price_moni.Text = moniprice;
                pBox9.Visible = true;
                border9.Visible = true;
                price_moni.Visible = true;
                quan_moni.Visible = true;
                remove_moni.Visible = true;
            }

            string keybimage = keyb.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
            string resourcekeyb = $"key_{keybimage}";
            pBox10.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcekeyb);
            if (keyb != "")
            {
                label10.Text = keyb;
                label10.Visible = true;
                price_keyb.Text = keybprice;
                pBox10.Visible = true;
                border10.Visible = true;
                price_keyb.Visible = true;
                quan_keyb.Visible = true;
                remove_keyb.Visible = true;
            }

            string mouseimage = mouse.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
            string resourcemou = $"mou_{mouseimage}";
            pBox11.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcemou);
            if (mouse != "")
            {
                label11.Text = mouse;
                label11.Visible = true;
                price_mou.Text = mouseprice;
                pBox11.Visible = true;
                border11.Visible = true;
                price_mou.Visible = true;
                quan_mous.Visible = true;
                remove_mous.Visible = true;
            }

            string spkimage = spk.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('+', '_').Replace('.', '_');
            string resourcespk = $"spe_{spkimage}";
            pBox12.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcespk);
            if (spk != "")
            {
                label12.Text = spk;
                label12.Visible = true;
                price_spk.Text = spkprice;
                pBox12.Visible = true;
                border12.Visible = true;
                price_spk.Visible = true;
                quan_spk.Visible = true;
                remove_spk.Visible = true;
            }

            string fanimage = fans.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('+', '_').Replace('.', '_');
            string resourcefans = $"fan_{fanimage}";
            pBoxfans.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcefans);
            if (fans != "")
            {
                label_fans.Text = fans;
                label_fans.Visible = true ;
                price_fans.Text = fanprice;
                pBoxfans.Visible = true;
                borderfans.Visible = true;
                price_fans.Visible = true;
                quan_fans.Visible = true;
                remove_fans.Visible = true;
            }

            string cpucoolimage = aircooler.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('+', '_').Replace('.', '_');
            string resourcecpucool = $"air_{cpucoolimage}";
            pBoxcpucool.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcecpucool);
            if (aircooler != "")
            {
                label_cpucooler.Text = aircooler;
                label_cpucooler.Visible = true;
                price_cpucool.Text = aircoolerprice;
                pBoxcpucool.Visible = true;
                bordercpucool.Visible = true;
                price_cpucool.Visible = true;
                quan_cpucool.Visible = true;
                remove_cpucool.Visible = true;
            }

            if (hdd != "" && ssd != "" && m2 == "")
            {
                drivecount = 2;
            }
            else if (hdd == "" && ssd != "" && m2 != "")
            {
                drivecount = 2;
            }

            else if (hdd != "" && ssd == "" && m2 != "")
            {
                drivecount = 2;
            }

            else if (hdd != "" && ssd != "" && m2 != "")
            {
                drivecount = 3;
            }
            drivepanels();


            if (drivecount == 1)
            {
                panel5.Size = new Size(1017, 55);
                if (hdd != "")
                {
                    selectedhdd_1();
                }

                else if (ssd != "")
                {
                    selectedssd_1();
                }

                else if (m2 != "")
                {
                    selectedm2_1();
                }
            }

            else if (drivecount == 2)
            {
                panel5.Size = new Size(1017, 108);
                if (hdd != "" && ssd != "")
                {
                    selectedhdd_1();
                    selectedssd_2();
                }

                else if(ssd != "" && m2 != "")
                {
                    selectedssd_1();
                    selectedm2_2();
                }

                else if(hdd != "" && m2 != "")
                {
                    selectedhdd_1();
                    selectedm2_2();
                }

            }

            else if(drivecount == 3)
            {
                panel5.Size = new Size(1017, 161);
                selectedhdd_1();
                selectedssd_2();
                selectedm2_3();
            }
        }

        private void selectedhdd_1()
        {
            string driveimage = hdd.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string image = $"hdd_{driveimage}";
            drive1name.Visible = true;
            drive1name.Text = hdd;
            drive1price.Text = hddprice;
            drive1pbox.Image = (Image)Properties.Resources.ResourceManager.GetObject(image);
            drive1pbox.Visible = true;
            drive1border.Visible = true;
            drive1price.Visible = true;
            drive1quan.Visible = true;
            remove_drive1.Visible = true;
            remove_drive1.Click += removehdd_Click;
        }

        private void selectedssd_1()
        {
            string driveimage = ssd.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string image = $"ssd_{driveimage}";
            drive1name.Visible = true;
            drive1name.Text = ssd;
            drive1price.Text = ssdprice;
            drive1pbox.Image = (Image)Properties.Resources.ResourceManager.GetObject(image);
            drive1pbox.Visible = true;
            drive1border.Visible = true;
            drive1price.Visible = true;
            drive1quan.Visible = true;
            remove_drive1.Visible = true;
            remove_drive1.Click += removessd_Click;
        }
        private void selectedssd_2()
        {
            string driveimage = ssd.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string image = $"ssd_{driveimage}";
            drive2name.Visible = true;
            drive2name.Text = ssd;
            drive2price.Text = ssdprice;
            drive2pbox.Image = (Image)Properties.Resources.ResourceManager.GetObject(image);
            drive2pbox.Visible = true;
            drive2border.Visible = true;
            drive2price.Visible = true;
            drive2quan.Text = "1";
            drive2quan.Visible = true;
            remove_drive2.Visible = true;
            remove_drive2.Click += removessd_Click;
        }
        private void selectedm2_1()
        {
            string driveimage = m2.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string image = $"m2_{driveimage}";
            drive1name.Visible = true;
            drive1name.Text = m2;
            drive1price.Text = m2price;
            drive1pbox.Image = (Image)Properties.Resources.ResourceManager.GetObject(image);
            drive1pbox.Visible = true;
            drive1border.Visible = true;
            drive1price.Visible = true;
            drive1quan.Visible = true;
            remove_drive1.Visible = true;
            remove_drive1.Click += removem2_Click;
        }

        private void selectedm2_2()
        {
            string driveimage = m2.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string image = $"m2_{driveimage}";
            drive2name.Visible = true;
            drive2name.Text = m2;
            drive2price.Text = m2price;
            drive2pbox.Image = (Image)Properties.Resources.ResourceManager.GetObject(image);
            drive2pbox.Visible = true;
            drive2border.Visible = true;
            drive2price.Visible = true;
            drive2quan.Text = "1";
            drive2quan.Visible = true;
            remove_drive2.Visible = true;
            remove_drive2.Click += removem2_Click;
        }

        private void selectedm2_3()
        {
            string driveimage = m2.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string image = $"m2_{driveimage}";
            drive3name.Visible = true;
            drive3name.Text = m2;
            drive3price.Text = m2price;
            drive3pbox.Image = (Image)Properties.Resources.ResourceManager.GetObject(image);
            drive3pbox.Visible = true;
            drive3border.Visible = true;
            drive3price.Visible = true;
            drive3quan.Text = "1";
            drive3quan.Visible = true;
            remove_drive3.Visible = true;
            remove_drive3.Click += removem2_Click;
        }
        private void InitializeDisplayManager()
        {
            buildmenu buildMenuForm = this; 
            DisplayManager displayManager = new DisplayManager(buildMenuForm);
        }
        private void label_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = SystemColors.ControlText;
            label.Font = new Font(label.Font, FontStyle.Regular);
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.FromArgb(44, 135, 195);
            label.Font = new Font(label.Font, FontStyle.Underline);
        }

        private void removecpu_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            price_cpu.Text = "";
            pBox1.Visible = false;
            border1.Visible = false;
            quan_cpu.Visible = false;
            remove_cpu.Visible = false;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET CPU = '', [CPU price] = '' WHERE [user] = @UserToUpdate";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserToUpdate", userToUpdate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }

        private void removegpu_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            price_gpu.Text = "";
            pBox2.Visible = false;
            border2.Visible = false;
            quan_gpu.Visible = false;
            remove_gpu.Visible = false;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET GPU = '', [GPU price] = '' WHERE [user] = @UserToUpdate";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserToUpdate", userToUpdate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }
        private void removemb_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            price_mb.Text = "";
            pBox3.Visible = false;
            border3.Visible = false;
            quan_mb.Visible = false;
            remove_mb.Visible = false;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET Motherboard = '', [Motherboard price] = '' WHERE [user] = @UserToUpdate";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserToUpdate", userToUpdate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }
        private void removeram_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            price_ram.Text = "";
            pBox4.Visible = false;
            border4.Visible = false;
            quan_ram.Visible = false;
            remove_ram.Visible = false;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET RAM = '', [RAM price] = '', [RAM quantity] = '' WHERE [user] = @UserToUpdate";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserToUpdate", userToUpdate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }

        private void removepsu_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            price_psu.Text = "";
            pBox6.Visible = false;
            border6.Visible = false;
            quan_psu.Visible = false;
            remove_psu.Visible = false;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET PSU = '', [PSU price] = ''WHERE [user] = @UserToUpdate";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserToUpdate", userToUpdate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }
        private void removecase_Click(object sender, EventArgs e)
        {
            label7.Text = "";
            price_case.Text = "";
            pBox7.Visible = false;
            border7.Visible = false;
            quan_case.Visible = false;
            remove_case.Visible = false;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET [Computer Case] = '', [Case price] = ''WHERE [user] = @UserToUpdate";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserToUpdate", userToUpdate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }

        private void removemoni_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            price_moni.Text = "";
            pBox9.Visible = false;
            border9.Visible = false;
            quan_moni.Visible = false;
            remove_moni.Visible = false;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET Monitor = '', [Monitor price] = ''WHERE [user] = @UserToUpdate";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserToUpdate", userToUpdate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }
        private void removekeyb_Click(object sender, EventArgs e)
        {
            label10.Text = "";
            price_keyb.Text = "";
            pBox10.Visible = false;
            border10.Visible = false;
            quan_keyb.Visible = false;
            remove_keyb.Visible = false;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET Keyboard = '', [Keyboard price] = ''WHERE [user] = @UserToUpdate";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserToUpdate", userToUpdate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }

        private void removemous_Click(object sender, EventArgs e)
        {
            label11.Text = "";
            price_mou.Text = "";
            pBox11.Visible = false;
            border11.Visible = false;
            quan_mous.Visible = false;
            remove_mous.Visible = false;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET Mouse = '', [Mouse price] = ''WHERE [user] = @UserToUpdate";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserToUpdate", userToUpdate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }
        private void removespk_Click(object sender, EventArgs e)
        {
            label12.Text = "";
            price_spk.Text = "";
            pBox12.Visible = false;
            border12.Visible = false;
            quan_spk.Visible = false;
            remove_spk.Visible = false;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET Speakers = '', [Speakers price] = ''WHERE [user] = @UserToUpdate";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserToUpdate", userToUpdate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }

        private void removehdd_Click(object sender, EventArgs e)
        {

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET HDD = '', [HDD price] = '' WHERE [user] = @UserToUpdate";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserToUpdate", userToUpdate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }

            if (drivecount == 1)
            {
                drive1name.Visible = false;
                drive1name.Text = "";
                drive1price.Text = "";
                drive1pbox.Visible = false;
                drive1border.Visible = false;
                drive1price.Visible = false;
                drive1quan.Visible = false;
                remove_drive1.Visible = false;
            }

            else if(drivecount == 2 && ssd != "")
            {
                selectedssd_1();
                panel5.Size = new Size(1017, 55);
                drivecount = 1;
            }
            else if (drivecount == 2 && m2 != "")
            {
                selectedm2_1();
                panel5.Size = new Size(1017, 55);
                drivecount = 1;
            }

            else if (drivecount == 3)
            {
                selectedssd_1();
                selectedm2_2();
                panel5.Size = new Size(1017, 108);
                drivecount = 2;
            }

        }
        private void removessd_Click(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET SSD = '', [SSD price] = '' WHERE [user] = @UserToUpdate";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserToUpdate", userToUpdate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
            if (drivecount == 1)
            {
                drive1name.Visible = false;
                drive1name.Text = "";
                drive1price.Text = "";
                drive1pbox.Visible = false;
                drive1border.Visible = false;
                drive1price.Visible = false;
                drive1quan.Visible = false;
                remove_drive1.Visible = false;
            }
            else if(drivecount == 2 && hdd != "")
            {
                selectedhdd_1();
                panel5.Size = new Size(1017, 55);
                drivecount = 1;

            }
            else if (drivecount == 2 && m2 != "")
            {
                selectedm2_1();
                panel5.Size = new Size(1017, 55);
                drivecount = 1;
            }
            else if(drivecount == 3)
            {
                selectedhdd_1();
                selectedm2_2();
                panel5.Size = new Size(1017, 108);
                drivecount = 2;
            }
        }

        private void removem2_Click(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET [M2 SSD] = '', [M2 price] = '' WHERE [user] = @UserToUpdate";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserToUpdate", userToUpdate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
            if (drivecount == 1)
            {
                drive1name.Text = "";
                drive1price.Text = "";
                drive1pbox.Visible = false;
                drive1border.Visible = false;
                drive1price.Visible = false;
                drive1quan.Visible = false;
                remove_drive1.Visible = false;
            }

            else if (drivecount == 2 && hdd != "")
            {
                selectedhdd_1();
                panel5.Size = new Size(1017, 55);
                drivecount = 1;

            }
            else if (drivecount == 2 && ssd != "")
            {
                selectedssd_1();
                panel5.Size = new Size(1017, 55);
                drivecount = 1;
            }

            else if (drivecount == 3)
            {
                selectedhdd_1();
                selectedssd_2();
                panel5.Size = new Size(1017, 108);
                drivecount = 2;
            }
        }

        private void drivepanels()
        {
            // pbox 2 and 3
            drive2pbox.Size = drive1pbox.Size;
            drive2pbox.BackColor = Color.White;
            drive2pbox.SizeMode = drive1pbox.SizeMode;
            drive2pbox.Location = new Point(314, 68);
            panel5.Controls.Add(drive2pbox);

            drive3pbox.Size = drive1pbox.Size;
            drive3pbox.BackColor = Color.White;
            drive3pbox.SizeMode = drive1pbox.SizeMode;
            drive3pbox.Location = new Point(314, 121);
            panel5.Controls.Add(drive3pbox);

            // border 2 && 3

            drive2border.Enabled = false;
            drive2border.StateCommon.Back.Color1 = Color.White;
            drive2border.StateCommon.Back.Color2 = Color.White;
            drive2border.StateCommon.Border.Color1 = Color.LightGray;
            drive2border.StateCommon.Border.Rounding = 3;
            drive2border.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;
            drive2border.Size = drive1border.Size;
            drive2border.Location = new Point(310, 62);
            panel5.Controls.Add(drive2border);

            drive3border.Enabled = false;
            drive3border.StateCommon.Back.Color1 = Color.White;
            drive3border.StateCommon.Back.Color2 = Color.White;
            drive3border.StateCommon.Border.Color1 = Color.LightGray;
            drive3border.StateCommon.Border.Rounding = 3;
            drive3border.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;
            drive3border.Size = drive1border.Size;
            drive3border.Location = new Point(310, 115);
            panel5.Controls.Add(drive3border);

            // name 2 and 3 label

            drive2name.Location = new Point(361, 74);
            drive2name.Font = drive1name.Font;
            drive2name.AutoSize = true;
            drive2name.MouseLeave += label_MouseLeave;
            drive2name.MouseMove += label_MouseMove;
            panel5.Controls.Add(drive2name);

            drive3name.Location = new Point(361, 127);
            drive3name.Font = drive1name.Font;
            drive3name.AutoSize = true;
            drive3name.MouseLeave += label_MouseLeave;
            drive3name.MouseMove += label_MouseMove;
            panel5.Controls.Add(drive3name);

            // quantity 2 and 3 label

            drive2quan.Location = new Point(781, 74);
            drive2quan.Font = drive1name.Font;
            drive2quan.AutoSize = true;
            panel5.Controls.Add(drive2quan);

            drive3quan.Location = new Point(781, 127);
            drive3quan.Font = drive1name.Font;
            drive3quan.AutoSize = true;
            panel5.Controls.Add(drive3quan);

            // price 2 and 3 label

            drive2price.Location = new Point(885, 74);
            drive2price.Font = drive1name.Font;
            drive2price.AutoSize = true;
            panel5.Controls.Add(drive2price);

            drive3price.Location = new Point(885, 127);
            drive3price.Font = drive1name.Font;
            drive3price.AutoSize = true;
            panel5.Controls.Add(drive3price);

            // remove 2 and 3

            remove_drive2.Location = new Point(969, 79);
            remove_drive2.Text = remove_drive1.Text;
            remove_drive2.Font = remove_drive1.Font; 
            remove_drive2.MouseLeave += remove_MouseLeave;
            remove_drive2.MouseMove += remove_MouseMove;
            remove_drive2.AutoSize = true;
            panel5.Controls.Add(remove_drive2);

            remove_drive3.Location = new Point(969, 133);
            remove_drive3.Text = remove_drive1.Text;
            remove_drive3.Font = remove_drive1.Font;
            remove_drive3.MouseLeave += remove_MouseLeave;
            remove_drive3.MouseMove += remove_MouseMove;
            remove_drive3.AutoSize = true;
            panel5.Controls.Add(remove_drive3);

        }
        private void remove_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = SystemColors.ControlText;
        }

        private void remove_MouseMove(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.FromArgb(180,18,0);
        }
        
    }
}
