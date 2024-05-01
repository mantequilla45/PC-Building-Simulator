using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public int CPUQuantity { get; set; }
        public string GPU { get; set; }
        public int GPUQuantity { get; set; }
        public string Case { get; set; }
        public int CaseQuantity { get; set; }
        public string Motherboard { get; set; }
        public int MotherboardQuantity { get; set; }
        public string RAM { get; set; }
        public int RAMQuantity { get; set; }
        public string HDD { get; set; }
        public int HDDQuantity { get; set; }
        public string SSD { get; set; }
        public int SSDQuantity { get; set; }
        public string PSU { get; set; }
        public int PSUQuantity { get; set; }
        public string Fan { get; set; }
        public int FanQuantity { get; set; }
        public string CPUCooler { get; set; }
        public int CPUCoolerQuantity { get; set; }
        public string Other { get; set; }
        public int OtherQuantity { get; set; }
        public completedbuilds(MainApp mainApp, int buildnum)
        {
            InitializeComponent();
            this.buildnum = buildnum;
            this.mainApp = mainApp;
            displayManager = new DisplayManager(mainApp);
            builds();
        }

        private void completedbuilds_Load(object sender, EventArgs e)
        {

        }

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
                    Dictionary<string, (string, int, int)> parts = new Dictionary<string, (string, int, int)>()
                {
                    { "cpu", ("Intel Core i9 14900K", 550, 1) },
                    { "", ("Nvidia GeForce RTX 4080 Founders Edition", 1750, 1) },
                    { "case", ("be quiet! Pure Base 500DX", 700, 1) },
                    { "mb", ("ASRock Z690 Extreme", 275, 1) },
                    { "ram", ("Dominator Platinum 32GB DDR5", 475, 2) },
                    { "hdd", ("Western Digital Gold 18TB", 315, 4) },
                    { "m2", ("WD Black SN850 2TB", 220, 1) },
                    { "psu", ("EVGA G+ 1000W Gold", 120, 1) },
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
                                resourceName = kvp.Key + kvp.Value.Item1.Replace(" ", "_").Replace("!", "_").Replace("+", "_");
                            else if (kvp.Key == "ram")
                                resourceName = kvp.Key + "_" + kvp.Value.Item1.Replace(" ", "_").Replace("!", "_").Replace("+", "_") + "_5200";
                            else
                                resourceName = kvp.Key + "_" + kvp.Value.Item1.Replace(" ", "_").Replace("!", "_");
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
                    pbox1.Image = Properties.Resources.cpu_AMD_Ryzen_9_7900X3D;
                    pbox2.Image = Properties.Resources.ASUS_TUF_Gaming_RX_7800_XT;
                    pbox3.Image = Properties.Resources.case_ASUS_ROG_Strix_Helios;
                    break;
            }
            
        }

        private void but_add_Click(object sender, EventArgs e)
        {
            CPU = buildData[0];
            GPU = buildData[3];
            Case = buildData[6];
            Motherboard = buildData[9];
            RAM = buildData[12];
            RAMQuantity = int.Parse(buildData[14]);
            HDD = buildData[15];
            HDDQuantity = int.Parse(buildData[17]);
            SSD = buildData[18];
            SSDQuantity = int.Parse(buildData[20]);
            PSU = buildData[21];
            Fan = buildData[24];
            FanQuantity = int.Parse(buildData[26]);
            CPUCooler = buildData[27];
        }

    }
}
