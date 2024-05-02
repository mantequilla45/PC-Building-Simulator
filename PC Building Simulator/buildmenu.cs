using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static PC_Building_Simulator.DisplayManager;

namespace PC_Building_Simulator
{
    public partial class buildmenu : Form
    {
        private object simulatedSender;
        EventArgs simulatedEventArgs = EventArgs.Empty;
        private DisplayManager displayManager;
        private productspecs productSpecsForm;
        private MainApp mainApp;
        private int showspecs = 0;
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
        public static string aiocooler = "";
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
        public static string aiocoolerprice = "";
        public static string hddquan = "";
        public static string ssdquan = "";
        public static string m2quan = "";
        public static string fanquan = "";
        public static string formattedTotalPrice = "";
        private string compbuildcpu = "";
        private string compbuildgpu = "";
        private string compbuildcase = "";
        private string compbuildmb = "";
        private string compbuildram = "";
        private string compbuilddrive1 = "";
        private string compbuilddrive2 = "";
        private string compbuilddrive3 = "";
        private string compbuildpsu = "";
        private string compbuildfans = "";
        private string compbuildcpucooler = "";
        private bool completedbuild = false;

        enum CoolerType { None, AirCooler, AioCooler }
        CoolerType currentCoolerType = CoolerType.None;

        public buildmenu(MainApp mainApp)
        {
            InitializeComponent();
            this.mainApp = mainApp;
            displayManager = new DisplayManager(mainApp);
            InitializeDisplayManager();
        }
        private void buildmenu_Load(object sender, EventArgs e)
        {
            LoadUserData();
            total_price.Text = "$"+CalculateTotalPrice().ToString();

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
                showspecs = 1;
                label1.Click += LabelClicked;

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
                showspecs = 2;
                label2.Click += LabelClicked;
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
                showspecs = 3;
                label3.Click += LabelClicked;
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
                showspecs = 4;
                label4.Click += LabelClicked;
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
                showspecs = 6;
                label6.Click += LabelClicked;
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
                label7.Click += LabelClicked;
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
                label9.Click += LabelClicked;
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
                label10.Click += LabelClicked;
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
                label11.Click += LabelClicked;
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
                label12.Click += LabelClicked;
            }
            
            string fanimage = fans.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('+', '_').Replace('.', '_');
            string resourcefans = $"fan_{fanimage}";
            pBoxfans.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcefans);
            if (fans != "")
            {
                label_fans.Text = fans;
                label_fans.Visible = true;
                price_fans.Text = fanprice;
                pBoxfans.Visible = true;
                borderfans.Visible = true;
                price_fans.Visible = true;
                quan_fans.Visible = true;
                quan_fans.Text = fanquan;
                remove_fans.Visible = true;
                remove_fans.Click += removefan_Click;

                label_fans.Click += LabelClicked;

                if (aircooler != "" || aiocooler != "")
                {
                    panel8.Size = new Size(1017, 108);
                    pBoxcpucool.Location = new Point(314, 68);
                    bordercpucool.Location = new Point(310, 62);
                    label_cpucooler.Location = new Point(361, 70);
                    quan_cpucool.Location = new Point(781, 70);
                    price_cpucool.Location = new Point(866, 70);
                    remove_cpucool.Location = new Point(969, 76);
                }
            }

            else if (fans == "")
            {
                panel8.Size = new Size(1017, 55);
                pBoxcpucool.Location = new Point(314, 15);
                bordercpucool.Location = new Point(310, 9);
                label_cpucooler.Location = new Point(361, 19);
                quan_cpucool.Location = new Point(781, 19);
                price_cpucool.Location = new Point(866, 19);
                remove_cpucool.Location = new Point(969, 25);
            }
            string cpucoolimage;
            string resourcecpucool;
            string userToUpdate = user;

            if (aircooler != "" && currentCoolerType != CoolerType.AirCooler)
            {
                currentCoolerType = CoolerType.AirCooler;
                cpucoolimage = aircooler.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('+', '_').Replace('.', '_');
                resourcecpucool = $"air_{cpucoolimage}";
                pBoxcpucool.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcecpucool);
                label_cpucooler.Text = aircooler;
                label_cpucooler.Visible = true;
                price_cpucool.Text = aircoolerprice;
                pBoxcpucool.Visible = true;
                bordercpucool.Visible = true;
                price_cpucool.Visible = true;
                quan_cpucool.Visible = true;
                remove_cpucool.Visible = true;
                remove_cpucool.Click += removeairc_Click;
                label_cpucooler.Click += LabelClicked;

            }

            if (aiocooler != "" && currentCoolerType != CoolerType.AioCooler)
            {
                currentCoolerType = CoolerType.AioCooler;
                cpucoolimage = aiocooler.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('+', '_').Replace('.', '_');
                resourcecpucool = $"aio_{cpucoolimage}";
                pBoxcpucool.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcecpucool);
                label_cpucooler.Text = aiocooler;
                label_cpucooler.Visible = true;
                price_cpucool.Text = aiocoolerprice;
                pBoxcpucool.Visible = true;
                bordercpucool.Visible = true;
                price_cpucool.Visible = true;
                quan_cpucool.Visible = true;
                remove_cpucool.Visible = true;
                remove_cpucool.Click += removeaioc_Click;
                label_cpucooler.Click += LabelClicked;
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
            drive1quan.Text = hddquan;
            drive1pbox.Image = (Image)Properties.Resources.ResourceManager.GetObject(image);
            drive1pbox.Visible = true;
            drive1border.Visible = true;
            drive1price.Visible = true;
            drive1quan.Visible = true;
            remove_drive1.Visible = true;
            remove_drive1.Click += removehdd_Click;
            drive1name.Click += LabelClicked;
        }

        private void selectedssd_1()
        {
            string driveimage = ssd.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string image = $"ssd_{driveimage}";
            drive1name.Visible = true;
            drive1name.Text = ssd;
            drive1price.Text = ssdprice;
            drive1quan.Text= ssdquan;
            drive1pbox.Image = (Image)Properties.Resources.ResourceManager.GetObject(image);
            drive1pbox.Visible = true;
            drive1border.Visible = true;
            drive1price.Visible = true;
            drive1quan.Visible = true;
            remove_drive1.Visible = true;
            remove_drive1.Click += removessd_Click;
            drive1name.Click += LabelClicked;
        }
        private void selectedm2_1()
        {
            string driveimage = m2.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string image = $"m2_{driveimage}";
            drive1name.Visible = true;
            drive1name.Text = m2;
            drive1price.Text = m2price;
            drive1quan.Text = m2quan;
            drive1pbox.Image = (Image)Properties.Resources.ResourceManager.GetObject(image);
            drive1pbox.Visible = true;
            drive1border.Visible = true;
            drive1price.Visible = true;
            drive1quan.Visible = true;
            remove_drive1.Visible = true;
            remove_drive1.Click += removem2_Click;
            drive1name.Click += LabelClicked;
        }
        private void selectedssd_2()
        {
            string driveimage = ssd.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string image = $"ssd_{driveimage}";
            drive2name.Visible = true;
            drive2name.Text = ssd;
            drive2price.Text = ssdprice;
            drive2quan.Text = ssdquan;
            drive2pbox.Image = (Image)Properties.Resources.ResourceManager.GetObject(image);
            drive2pbox.Visible = true;
            drive2border.Visible = true;
            drive2price.Visible = true;
            drive2quan.Visible = true;
            remove_drive2.Visible = true;
            remove_drive2.Click += removessd_Click;
            drive2name.Click += LabelClicked;
        }

        private void selectedm2_2()
        {
            string driveimage = m2.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string image = $"m2_{driveimage}";
            drive2name.Visible = true;
            drive2name.Text = m2;
            drive2price.Text = m2price;
            drive2quan.Text = m2quan;
            drive2pbox.Image = (Image)Properties.Resources.ResourceManager.GetObject(image);
            drive2pbox.Visible = true;
            drive2border.Visible = true;
            drive2price.Visible = true;
            drive2quan.Visible = true;
            remove_drive2.Visible = true;
            remove_drive2.Click += removem2_Click;
            drive2name.Click += LabelClicked;
        }

        private void selectedm2_3()
        {
            string driveimage = m2.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('.', '_');
            string image = $"m2_{driveimage}";
            drive3name.Visible = true;
            drive3name.Text = m2;
            drive3price.Text = m2price;
            drive3quan.Text = m2quan;
            drive3pbox.Image = (Image)Properties.Resources.ResourceManager.GetObject(image);
            drive3pbox.Visible = true;
            drive3border.Visible = true;
            drive3price.Visible = true;
            drive3quan.Visible = true;
            remove_drive3.Visible = true;
            remove_drive3.Click += removem2_Click;
            drive3name.Click += LabelClicked;
        }
        private void LoadUserData()
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string query1 = "SELECT TOP 1 [user] FROM currentuser";

            try
            {
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
                    "Mouse, [Mouse price], Speakers, [Speakers price], [HDD quantity], HDD, [HDD price], [SSD quantity], SSD, [SSD price], [M2 SSD quantity], " +
                    "[M2 SSD], [M2 price], [Fan quantity], Fans, [Fan price], [CPU Air Cooler], [CPU Air Cooler price], [AIO Cooler], [AIO Cooler price] FROM Builds WHERE [user] = @Username";

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
                                aiocooler = reader["AIO Cooler"].ToString();
                                aiocoolerprice = reader["AIO Cooler price"].ToString();
                                hddquan = reader["HDD quantity"].ToString();
                                ssdquan = reader["SSD quantity"].ToString();
                                m2quan = reader["M2 SSD quantity"].ToString();
                                fanquan = reader["Fan quantity"].ToString();
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
                                aiocooler = "";
                                aiocoolerprice = "";
                                hddquan = "";
                                ssdquan = "";
                                m2quan = "";
                                fanquan = "";
                                ramquan = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }
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
        private int CalculateTotalPrice()
        {
            double totalPrice = 0.0;

            if (!string.IsNullOrEmpty(cpuprice)) totalPrice += double.Parse(cpuprice.Replace("$", ""));
            if (!string.IsNullOrEmpty(gpuprice)) totalPrice += double.Parse(gpuprice.Replace("$", ""));
            if (!string.IsNullOrEmpty(mbprice)) totalPrice += double.Parse(mbprice.Replace("$", ""));
            if (!string.IsNullOrEmpty(psuprice)) totalPrice += double.Parse(psuprice.Replace("$", ""));
            if (!string.IsNullOrEmpty(caseprice)) totalPrice += double.Parse(caseprice.Replace("$", ""));
            if (!string.IsNullOrEmpty(moniprice)) totalPrice += double.Parse(moniprice.Replace("$", ""));
            if (!string.IsNullOrEmpty(keybprice)) totalPrice += double.Parse(keybprice.Replace("$", ""));
            if (!string.IsNullOrEmpty(mouseprice)) totalPrice += double.Parse(mouseprice.Replace("$", ""));
            if (!string.IsNullOrEmpty(spkprice)) totalPrice += double.Parse(spkprice.Replace("$", ""));
            if (!string.IsNullOrEmpty(aircoolerprice)) totalPrice += double.Parse(aircoolerprice.Replace("$", ""));
            if (!string.IsNullOrEmpty(aiocoolerprice)) totalPrice += double.Parse(aiocoolerprice.Replace("$", ""));

            if (!string.IsNullOrEmpty(ramprice) && !string.IsNullOrEmpty(ramquan))
            {
                double ramPrice = double.Parse(ramprice.Replace("$", ""));
                int ramQuantity = int.Parse(ramquan);
                totalPrice += ramPrice * ramQuantity;
            }

            if (!string.IsNullOrEmpty(fanprice) && !string.IsNullOrEmpty(fanquan))
            {
                double fanPrice = double.Parse(fanprice.Replace("$", ""));
                int fanQuantity = int.Parse(fanquan);
                totalPrice += fanPrice * fanQuantity;
            }

            if (!string.IsNullOrEmpty(hddprice) && !string.IsNullOrEmpty(hddquan))
            {
                double hddPrice = double.Parse(hddprice.Replace("$", ""));
                int hddQuantity = int.Parse(hddquan);
                totalPrice += hddPrice * hddQuantity;
            }

            if (!string.IsNullOrEmpty(ssdprice) && !string.IsNullOrEmpty(ssdquan))
            {
                double ssdPrice = double.Parse(ssdprice.Replace("$", ""));
                int ssdQuantity = int.Parse(ssdquan);
                totalPrice += ssdPrice * ssdQuantity;
            }

            if (!string.IsNullOrEmpty(m2price) && !string.IsNullOrEmpty(m2quan))
            {
                double m2Price = double.Parse(m2price.Replace("$", ""));
                int m2Quantity = int.Parse(m2quan);
                totalPrice += m2Price * m2Quantity;
            }

            // Return the total price as an integer
            return (int)totalPrice;
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
        private void removefan_Click(object sender, EventArgs e)
        {
            label_fans.Text = "";
            price_fans.Text = "";
            pBoxfans.Visible = false;
            borderfans.Visible = false;
            quan_fans.Visible = false;
            remove_fans.Visible = false;
            panel8.Size = new Size(1017, 55);
            pBoxcpucool.Location = new Point(314, 15);
            bordercpucool.Location = new Point(310, 9);
            label_cpucooler.Location = new Point(361, 19);
            quan_cpucool.Location = new Point(781, 19);
            price_cpucool.Location = new Point(885, 19);
            remove_cpucool.Location = new Point(969, 25);
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET [Fan quantity] = '', Fans = '', [Fan price] = ''WHERE [user] = @UserToUpdate";

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
        private void removeairc_Click(object sender, EventArgs e)
        {
            currentCoolerType = CoolerType.None;
            panel8.Size = new Size(1017, 55);
            label_cpucooler.Text = "";
            price_cpucool.Text = "";
            pBoxcpucool.Visible = false;
            bordercpucool.Visible = false;
            quan_cpucool.Visible = false;
            remove_cpucool.Visible = false;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;

            string updateQuery = "UPDATE Builds SET [CPU Air Cooler] = '', [CPU Air Cooler price] = ''WHERE [user] = @UserToUpdate";

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
        private void removeaioc_Click(object sender, EventArgs e)
        {
            currentCoolerType = CoolerType.None;
            panel8.Size = new Size(1017, 55);
            label_cpucooler.Text = "";
            price_cpucool.Text = "";
            pBoxcpucool.Visible = false;
            bordercpucool.Visible = false;
            quan_cpucool.Visible = false;
            remove_cpucool.Visible = false;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;
            string updateQuery = "UPDATE Builds SET [AIO Cooler] = '', [AIO Cooler price] = ''WHERE [user] = @UserToUpdate";

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
            if (panel5.Size == new Size(1017, 55))
            {
                
            }    
        }
        private void removehdd_Click(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;
            string updateQuery = "UPDATE Builds SET [HDD quantity] = '', HDD = '', [HDD price] = '' WHERE [user] = @UserToUpdate";

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

            if (panel5.Size == new Size(1017, 161))
            {
                panel5.Size = new Size(1017, 108);
            }
            else if (panel5.Size == new Size(1017, 55))
            {
                border1.Visible = false;
                drive1pbox.Visible = false;
                drive1price.Visible = false;
                drive1name.Visible = false;
                remove_drive1.Visible = false;
                drive1border.Visible = false;
                drive1quan.Visible = false;

            }
        }

        private void removessd_Click(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;
            string updateQuery = "UPDATE Builds SET [SSD quantity] = '', SSD = '', [SSD price] = '' WHERE [user] = @UserToUpdate";

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
            if (panel5.Size == new Size(1017, 161))
            {
                panel5.Size = new Size(1017, 108);
            }
            else if (panel5.Size == new Size(1017, 108))
            {
                panel5.Size = new Size(1017, 55);
            }
        }

        private void removem2_Click(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
            string userToUpdate = user;
            string updateQuery = "UPDATE Builds SET [M2 SSD quantity] = '', [M2 SSD] = '', [M2 price] = '' WHERE [user] = @UserToUpdate";

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
            if(panel5.Size == new Size(1017, 161))
            {
                panel5.Size = new Size(1017, 108);
            }
            else if(panel5.Size == new Size(1017, 161))
            {
                panel5.Size = new Size(1017, 55);

            }
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
        private void LabelClicked(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            KryptonButton dummy = new KryptonButton();
            ButtonAppearance.Reset.Build(mainApp);
            if (clickedLabel == label1)
            {
                showspecs = 1;
                PriceClicked(cpu, cpuprice);
                DisplayManager.ButtonAppearance.Activate.CPU(mainApp);
            }
            else if (clickedLabel == label2)
            {
                showspecs = 2;
                PriceClicked(gpu, gpuprice);
                DisplayManager.ButtonAppearance.Activate.GPU(mainApp);
            }
            else if (clickedLabel == label3)
            {
                showspecs = 3;
                PriceClicked(mb, mbprice);
                DisplayManager.ButtonAppearance.Activate.Motherboard(mainApp);
            }
            else if (clickedLabel == label4)
            {
                showspecs = 4;
                PriceClicked(ram, ramprice);
                DisplayManager.ButtonAppearance.Activate.RAM(mainApp);
            }
            else if (clickedLabel == label6)
            {
                showspecs = 6;
                PriceClicked(psu, psuprice);
                DisplayManager.ButtonAppearance.Activate.PSU(mainApp);
            }
            else if (clickedLabel == label7)
            {
                showspecs = 7;
                PriceClicked(ccase, caseprice);
                DisplayManager.ButtonAppearance.Activate.Case(mainApp);
            }
            else if (clickedLabel == label9)
            {
                showspecs = 9;
                PriceClicked(moni, moniprice);
                DisplayManager.ButtonAppearance.Activate.Monitor(mainApp);
            }
            else if (clickedLabel == label10)
            {
                showspecs = 10;
                PriceClicked(keyb, keybprice);
                DisplayManager.ButtonAppearance.Activate.Keyboard(mainApp);
            }
            else if (clickedLabel == label11)
            {
                showspecs = 11;
                PriceClicked(mouse, mouseprice);
                DisplayManager.ButtonAppearance.Activate.Mouse(mainApp);
            }
            else if (clickedLabel == label12)
            {
                showspecs = 12;
                PriceClicked(spk, spkprice);
                DisplayManager.ButtonAppearance.Activate.Speakers(mainApp);
            }

            else if (clickedLabel == label_fans)
            {
                showspecs = 16;
                PriceClicked(fans, fanprice);
                DisplayManager.ButtonAppearance.Activate.Cooler(mainApp);
            }
            else if(clickedLabel == label_cpucooler)
            {
                if(aircooler != "")
                {
                    showspecs = 17;
                    PriceClicked(aircooler, aircoolerprice);
                }
                if (aiocooler != "")
                {
                    showspecs = 18;
                    PriceClicked(aiocooler, aiocoolerprice);
                }
                DisplayManager.ButtonAppearance.Activate.Cooler(mainApp);
            }
            else if(clickedLabel == drive1name)
            {
                if(drive1name.Text == hdd)
                {
                    showspecs = 13;
                    PriceClicked(hdd, hddprice);
                }
                else if(drive1name.Text == ssd)
                {
                    showspecs = 14;
                    PriceClicked(ssd, ssdprice);
                }
                else if (drive1name.Text == m2)
                {
                    showspecs = 15;
                    PriceClicked(m2, m2price);
                }

                DisplayManager.ButtonAppearance.Activate.Storage(mainApp);
            }

            else if(clickedLabel == drive2name)
            {
                if (drive2name.Text == ssd)
                {
                    showspecs = 14;
                    PriceClicked(ssd, ssdprice);
                }
                else if (drive2name.Text == m2)
                {
                    showspecs = 15;
                    PriceClicked(m2, m2price);
                }
                DisplayManager.ButtonAppearance.Activate.Storage(mainApp);
            }

            else if (clickedLabel == drive3name)
            {
                showspecs = 15;
                PriceClicked(m2, m2price);
                DisplayManager.ButtonAppearance.Activate.Storage(mainApp);
            }
        }
        private void PriceClicked(string component, string price)
        {
            switch(showspecs)
            {
                case 1:
                    componentspecs(component, 1, price);
                    break;
                case 2:
                    componentspecs(component, 2, price);
                    break;
                case 3:
                    componentspecs(component, 3, price);
                    break;
                case 4:
                    componentspecs(component, 4, price);
                    break;
                case 6:
                    componentspecs(component, 6, price);
                    break;
                case 7:
                    componentspecs(component, 7, price);
                    break;
                case 9:
                    componentspecs(component, 9, price);
                    break;
                case 10:
                    componentspecs(component, 10, price);
                    break;
                case 11:
                    componentspecs(component, 11, price);
                    break;
                case 12:
                    componentspecs(component, 12, price);
                    break;
                case 13:
                    componentspecs(component, 13, price);
                    break;
                case 14:
                    componentspecs(component, 14, price);
                    break;
                case 15:
                    componentspecs(component, 15, price);
                    break;
                case 16:
                    componentspecs(component, 16, price);
                    break;
                case 17:
                    componentspecs(component, 17, price);
                    break;
                case 18:
                    componentspecs(component, 18, price);
                    break;
                case 19:
                    componentspecs(component, 19, price);
                    break;

            }
        }
        private void componentspecs(string component, int menu, string price)
        {
            mainApp.back = menu;
            mainApp.backicon.Visible = true;
            mainApp.butt_refresh.Image = Properties.Resources.Refresh2;
            mainApp.label_menu.Text = $"{component} Specifications";
            mainApp.panelmain.Controls.Clear();
            productspecs productspecs = new productspecs(component, menu, mainApp, price)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            mainApp.panelmain.Controls.Add(productspecs);
            productspecs.Show();
        }
        private void ResetDriveComponent(Control name, Control price, Control quan, PictureBox pbox, KryptonButton border, Control remove, EventHandler removeClick)
        {
            name.Visible = false;
            price.Text = "";
            quan.Text = "";
            pbox.Image = null;
            pbox.Visible = false;
            border.Visible = false;
            remove.Visible = false;
            remove.Click -= removeClick;
        }
        private void DeleteUserDataButton_Click(object sender, EventArgs e)
        {
            confirmdelete confirmationDialog = new confirmdelete();
            if (confirmationDialog.ShowDialog() != DialogResult.OK)
            {
                if (confirmationDialog.remove == true)
                {
                    string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";
                    string setClause = "SET CPU = null, [CPU price] = null, GPU = null, [GPU price] = null, Motherboard = null, [Motherboard price] = null, [RAM quantity] = null, RAM = null, ";
                    setClause += "[RAM price] = null, PSU = null, [PSU price] = null, [Computer Case] = null, [Case price] = null, Monitor = null, [Monitor price] = null, Keyboard = null, [Keyboard price] = null, ";
                    setClause += "Mouse = null, [Mouse price] = null, Speakers = null, [Speakers price] = null, [HDD quantity] = null, HDD = null, [HDD price] = null, [SSD quantity] = null, SSD = null, [SSD price] = null, [M2 SSD quantity] = null, ";
                    setClause += "[M2 SSD] = null, [M2 price] = null, [Fan quantity] = null, Fans = null, [Fan price] = null, [CPU Air Cooler] = null, [CPU Air Cooler price] = null, [AIO Cooler] = null, [AIO Cooler price] = null";

                    string query = $"UPDATE Builds {setClause} WHERE [user] = @Username";

                    try
                    {
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            connection.Open();
                            using (OleDbCommand command = new OleDbCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Username", user);
                                int rowsAffected = command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting user data: {ex.Message}");
                    }
                    total_price.Text = "$0";
                    label1.Text = "";
                    price_cpu.Text = "";
                    pBox1.Image = null;
                    pBox1.Visible = false;
                    border1.Visible = false;
                    quan_cpu.Visible = false;
                    remove_cpu.Visible = false;

                    label2.Text = "";
                    price_gpu.Text = "";
                    pBox2.Image = null;
                    pBox2.Visible = false;
                    border2.Visible = false;
                    quan_gpu.Visible = false;
                    remove_gpu.Visible = false;

                    label3.Text = "";
                    price_mb.Text = "";
                    pBox3.Image = null;
                    pBox3.Visible = false;
                    border3.Visible = false;
                    quan_mb.Visible = false;
                    remove_mb.Visible = false;

                    label4.Text = "";
                    price_ram.Text = "";
                    pBox4.Image = null;
                    pBox4.Visible = false;
                    border4.Visible = false;
                    quan_ram.Visible = false;
                    remove_ram.Visible = false;

                    label6.Text = "";
                    price_psu.Text = "";
                    pBox6.Image = null;
                    pBox6.Visible = false;
                    border6.Visible = false;
                    quan_psu.Visible = false;
                    remove_psu.Visible = false;

                    label7.Text = "";
                    price_case.Text = "";
                    pBox7.Image = null;
                    pBox7.Visible = false;
                    border7.Visible = false;
                    quan_case.Visible = false;
                    remove_case.Visible = false;

                    label9.Text = "";
                    price_moni.Text = "";
                    pBox9.Image = null;
                    pBox9.Visible = false;
                    border9.Visible = false;
                    quan_moni.Visible = false;
                    remove_moni.Visible = false;

                    label10.Text = "";
                    price_keyb.Text = "";
                    pBox10.Image = null;
                    pBox10.Visible = false;
                    border10.Visible = false;
                    quan_keyb.Visible = false;
                    remove_keyb.Visible = false;

                    label11.Text = "";
                    price_mou.Text = "";
                    pBox11.Image = null;
                    pBox11.Visible = false;
                    border11.Visible = false;
                    quan_mous.Visible = false;
                    remove_mous.Visible = false;

                    label12.Text = "";
                    price_spk.Text = "";
                    pBox12.Image = null;
                    pBox12.Visible = false;
                    border12.Visible = false;
                    quan_spk.Visible = false;
                    remove_spk.Visible = false;

                    label_fans.Text = "";
                    price_fans.Text = "";
                    pBoxfans.Image = null;
                    pBoxfans.Visible = false;
                    borderfans.Visible = false;
                    quan_fans.Visible = false;
                    remove_fans.Visible = false;

                    label_cpucooler.Text = "";
                    price_cpucool.Text = "";
                    pBoxcpucool.Image = null;
                    pBoxcpucool.Visible = false;
                    bordercpucool.Visible = false;
                    quan_cpucool.Visible = false;
                    remove_cpucool.Visible = false;

                    panel5.Size = new Size(1017, 55);
                    panel8.Size = new Size(1017, 55);
                    drivecount = 1;
                    ResetDriveComponent(drive1name, drive1price, drive1quan, drive1pbox, drive1border, remove_drive1, removehdd_Click);
                    ResetDriveComponent(drive2name, drive2price, drive2quan, drive2pbox, drive2border, remove_drive2, removessd_Click);
                    ResetDriveComponent(drive3name, drive3price, drive3quan, drive3pbox, drive3border, remove_drive3, removem2_Click);
                    confirmationDialog.remove = false;
                }
                else
                {
                    confirmationDialog.remove = false;
                }
            }
        }
    }
}
