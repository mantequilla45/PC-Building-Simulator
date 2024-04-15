using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace PC_Building_Simulator
{
    public partial class productmenu : Form
    {
        private DatabaseManager dbManager;
        private MainApp mainApp;
        private int choice;

        public productmenu(MainApp mainApp, int menuchoice)
        {
            InitializeComponent();
            choice = menuchoice;
            this.mainApp = mainApp;
            display(choice);
            InitializeControls();
        }
        private void InitializeControls()
        {
            for (int i = 0; i < 20; i++)
            {
                Panel panel = (Panel)this.Controls.Find($"panel{i + 1}", true).FirstOrDefault();
                PictureBox pictureBox = (PictureBox)this.Controls.Find($"pbox{i + 1}", true).FirstOrDefault();
                Label nameLabel = (Label)this.Controls.Find($"labname{i + 1}", true).FirstOrDefault();
                Label priceLabel = (Label)this.Controls.Find($"labprice{i + 1}", true).FirstOrDefault();

                if (panel != null && pictureBox != null && nameLabel != null && priceLabel != null)
                {
                    panel.MouseLeave += Panel_MouseLeave;
                    panel.MouseMove += Panel_MouseMove;
                    panel.MouseDown += Panel1_MouseDown;
                    pictureBox.MouseMove += ChildControl_MouseMove;
                    nameLabel.MouseMove += ChildControl_MouseMove;
                    priceLabel.MouseMove += ChildControl_MouseMove;
                    pictureBox.MouseLeave += ChildControl_MouseLeave;
                    nameLabel.MouseLeave += ChildControl_MouseLeave;
                    priceLabel.MouseLeave += ChildControl_MouseLeave;
                    pictureBox.MouseDown += ChildControl_MouseDown;
                    nameLabel.MouseDown += ChildControl_MouseDown;
                    priceLabel.MouseDown += ChildControl_MouseDown;
                }
            }
        }
        private void display(int menuchoice)
        {
            dbManager = new DatabaseManager("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb");
            Label[] pricelabels = {
                        labprice1, labprice2, labprice3, labprice4, labprice5,
                        labprice6, labprice7, labprice8, labprice9, labprice10,
                        labprice11, labprice12, labprice13, labprice14, labprice15,
                        labprice16, labprice17, labprice18, labprice19, labprice20
                    };

            Label[] namelabels = {
                        labname1, labname2, labname3, labname4, labname5,
                        labname6, labname7, labname8, labname9, labname10,
                        labname11, labname12, labname13, labname14, labname15,
                        labname16, labname17, labname18, labname19, labname20
                    };
            int[] price;


            switch (choice)
            {
                case 1:
                    string[] cpuNames = {
                        "Intel Core i9-11900K", "AMD Ryzen 9 5950X", "Intel Core i7-11700K", "AMD Ryzen 7 5800X",
                        "Intel Core i5-11600K", "AMD Ryzen 5 5600X", "Intel Core i3-10100", "AMD Ryzen 3 3300X",
                        "Intel Core i9-10900K", "AMD Ryzen 9 5900X", "Intel Core i9-12900K", "AMD Ryzen 9 7900X",
                        "Intel Core i7-12700K", "AMD Ryzen 7 7800X3D", "Intel Core i5-12600K", "AMD Ryzen 7 7700X",
                        "Intel Core i5-12400", "AMD Ryzen 3 3200G", "Intel Core i9-14900K", "AMD Ryzen 9 7900X3D"
                    };

                    price = new int[] {
                        550, 800, 450, 500, 300,
                        350, 150, 200, 550, 600,
                        700, 600, 450, 400, 350,
                        350, 200, 90, 550, 500
                    };

                    for (int i = 0; i < cpuNames.Length; i++)
                    {
                        string cpuname = cpuNames[i];
                        string cpuimage = cpuname.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
                        string resourcecpu = $"cpu_{cpuimage}";

                        PictureBox pictureBox = Controls.Find($"pbox{i + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourcecpu);
                        }

                        Label priceLabel = pricelabels[i];
                        if (priceLabel != null)
                        {
                            priceLabel.Text = $"${price[i]}";
                        }

                        Label nameLabel = namelabels[i];
                        if (nameLabel != null)
                        {
                            nameLabel.Text = cpuname;
                        }
                    }
                    break;
                case 2:
                    string[] gpuNames = {
                        "XFX Radeon RX 5700 XT", "PowerColor Radeon RX 580", "Gigabyte GeForce GTX 1080 Ti",
                        "Gigabyte GeForce GTX 1070", "Gigabyte GeForce GTX 1660 Ti", "EVGA GeForce RTX 2080 Super",
                        "Gigabyte GeForce RTX 3080 Ti", "XFX Radeon RX 6700 XT", "MSI GeForce RTX 3070",
                        "Asus ROG Strix GeForce GTX 1060", "PowerColor Radeon RX 6800 XT", "Gigabyte GeForce RTX 2070 Super",
                        "XFX RX 5600 XT", "Intel Arc A770", "Nvidia GeForce RTX 4080 Founders Edition",
                        "ASUS TUF Gaming RX 7800 XT", "Sapphire NITRO+ Radeon RX 6600 XT",
                        "Nvidia GeForce RTX 3060 Ti Founders Edition", "Sapphire PULSE Radeon RX 570 8G G5",
                        "ASRock AMD Radeon RX 6600 Challenger D 8GB"
                    };

                    price = new int[]{
                        350, 250, 500, 325, 250,
                        600, 1500, 600, 850, 200,
                        700, 500, 250, 350, 1750,
                        1000, 500, 650, 125, 350
                    };


                    for (int i = 0; i < gpuNames.Length; i++)
                    {
                        string gpuName = gpuNames[i];
                        string gpuImage = gpuName.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
                        string resourceGpu = $"{gpuImage}";

                        PictureBox pictureBox = Controls.Find($"pbox{i + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourceGpu);
                        }

                        Label priceLabel = pricelabels[i];
                        if (priceLabel != null)
                        {
                            priceLabel.Text = $"${price[i]}";
                        }

                        Label nameLabel = namelabels[i];
                        if (nameLabel != null)
                        {
                            nameLabel.Text = gpuName;
                        }
                    }

                    break;

                case 3:
                    string[] mbNames = {
                        "MSI MEG Z690 Godlike", "ASUS ROG Strix X570-E Gaming", "Gigabyte B550M Aorus Pro",
                        "MSI B460M Mortar Micro ATX WiFi", "ASRock Z690 Extreme", "EVGA X570 Dark",
                        "ASUS ROG Strix B550-F Gaming WiFi", "MSI MPG Z490 Gaming Carbon WiFi",
                        "Gigabyte B460M DS3H", "ASRock B450M Steel Legend", "MSI B560M Mortar WiFi",
                        "ASUS ROG Strix X570-I Gaming WiFi", "Gigabyte Z490 Aorus Elite", "MSI B460M Bazooka V2",
                        "ASRock B550 Phantom Gaming 4", "MSI MPG X570 Gaming Plus", "ASUS Prime B460M-A",
                        "Gigabyte B450M DS3H WIFI", "MSI B550M Mortar Micro ATX", "ASRock B460M Pro4"
                    };
                    int[] motherboardPrices = {
                        1000, 500, 175, 125, 700,
                        525, 300, 350, 100, 125,
                        145, 350, 300, 100, 215,
                        400, 85, 145, 175, 150
                    };

                    for (int i = 0; i < mbNames.Length; i++)
                    {
                        string motherboardName = mbNames[i];
                        string motherboardImage = motherboardName.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
                        string resourceMotherboard = $"mb_{motherboardImage}";

                        PictureBox pictureBox = Controls.Find($"pbox{i + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourceMotherboard);
                        }

                        Label priceLabel = pricelabels[i];
                        if (priceLabel != null)
                        {
                            priceLabel.Text = $"${motherboardPrices[i]}";
                        }

                        Label nameLabel = namelabels[i];
                        if (nameLabel != null)
                        {
                            nameLabel.Text = motherboardName;
                        }
                    }
                    break;

                case 4:
                    string[] ramNames = {
                        "Vengeance RGB PRO", "TridentZ RGB Series", "T-Force Delta RGB", "Viper Steel Series DDR4",
                        "Ballistix RGB", "Ripjaws V Series", "Gammix D10", "Fury Beast RGB", "T-Force Vulcan Z",
                        "Aegis F4 Series", "Fury Beast RGB", "TridentZ5 RGB Series", "Vengeance RGB DDR5",
                        "T-Force Delta RGB DDR5", "Ballistix MAX RGB DDR5", "XPG Lancer RGB DDR5",
                        "Dominator Platinum 32GB DDR5-5200", "Ripjaws S5 Series DDR5", "FURY Renegade RGB DDR5",
                        "T-Force Dark Z Alpha DDR5"
                    };

                    int[] ramPrices = {
                        125, 150, 140, 110, 120,
                        100, 105, 115, 100, 90,
                        200, 225, 210, 230, 215,
                        240, 275, 190, 220, 220
                    };

                    for (int i = 0; i < ramNames.Length; i++)
                    {
                        string ramName = ramNames[i];
                        string ramImage = ramName.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
                        string resourceRam = $"ram_{ramImage}";

                        PictureBox pictureBox = Controls.Find($"pbox{i + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourceRam);
                        }

                        Label priceLabel = pricelabels[i];
                        if (priceLabel != null)
                        {
                            priceLabel.Text = $"${ramPrices[i]}";
                        }

                        Label nameLabel = namelabels[i];
                        if (nameLabel != null)
                        {
                            nameLabel.Text = ramName;
                        }
                    }
                    break;
                case 6:
                    string[] psuNames = {
                        "Asus TUF Gaming 750W Bronze", "Corsair RM1000x", "EVGA B550 Bronze", "Super Flower Leadex III Gold 750W",
                        "Thermaltake Toughpower Grand RGB 1200W Gold", "Thermaltake Smart 650W", "Gigabyte P850W Gold",
                        "Corsair CX450M", "EVGA SuperNOVA 1600 T2", "Seasonic S12III Bronze 550W", "Corsair AX1500i",
                        "EVGA G+ 1000W Gold", "Seasonic Prime PX-1000", "Seasonic PRIME TX-1600 Titanium", "NZXT C850 Gold",
                        "Cooler Master MasterWatt Maker 1200 Titanium", "be quiet! Pure Power 10 CM 850W", "MSI MPG A-GF AI 850W Gold",
                        "Asus ROG Thor 1200W Platinum", "Cooler Master MWE Bronze V650"
                    };

                    int[] psuPrices = {
                        135, 155, 125, 155, 160,
                        70, 180, 90, 250, 105,
                        350, 220, 280, 400, 170,
                        380, 110, 200, 450, 60
                    };

                    for (int i = 0; i < psuNames.Length; i++)
                    {
                        string psuName = psuNames[i];
                        string psuImage = psuName.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('+', '_');
                        string resourcePsu = $"psu_{psuImage}";

                        PictureBox pictureBox = Controls.Find($"pbox{i + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourcePsu);
                        }

                        Label priceLabel = pricelabels[i];
                        if (priceLabel != null)
                        {
                            priceLabel.Text = $"${psuPrices[i]}";
                        }

                        Label nameLabel = namelabels[i];
                        if (nameLabel != null)
                        {
                            nameLabel.Text = psuName;
                        }
                    }



                    break;

                case 7:
                    string[] casenames = {
                        "NZXT H510", "Fractal Design Meshify C", "Corsair 4000D Airflow",
                        "Lian Li Lancool 215", "Phanteks Eclipse G360A", "Cooler Master MasterBox NR200P",
                        "ASUS ROG Strix Helios", "be quiet! Pure Base 500DX", "Thermaltake S100 TG", 
                        "MSI MPG Sekira 500X", "NZXT H710i", "Corsair iCUE 500X RGB", "Lian Li O11 Dynamic", 
                        "Fractal Design Define 7", "Cooler Master MasterCase H500M", "be quiet! Silent Base 802", 
                        "Phanteks Eclipse P400A", "MasterBox NR200P SE", "Thermaltake H500", "MSI MPG Velox 100"
                    };

                    price = new int[] {
                        70, 80, 80, 70, 100,
                        80, 300, 120, 70, 150,
                        180, 150, 140, 170, 120,
                        200, 80, 80, 80, 100
                    };
                    
                    for (int i = 0; i < casenames.Length; i++)
                    {
                        string casename = casenames[i];
                        string caseimage = casename.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
                        string resourcecase = $"case_{caseimage}";

                        PictureBox pictureBox = Controls.Find($"pbox{i + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourcecase);
                        }

                        Label priceLabel = pricelabels[i];
                        if (priceLabel != null)
                        {
                            priceLabel.Text = $"${price[i]}";
                        }

                        Label nameLabel = namelabels[i];
                        if (nameLabel != null)
                        {
                            nameLabel.Text = casename;
                        }
                    }
                    break;


            }
        }
        
        private void HandlePanelClick(Panel panel)
        {
            DisplayManager displayManager = new DisplayManager(mainApp);
            Panel[] panels = { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10,
                panel11, panel12, panel13, panel14, panel15, panel16, panel17, panel18, panel19, panel20
            };

            for (int i = 0; i < panels.Length; i++)
            {
                if (panel == panels[i])
                {
                    int menuIndex = i + 1;
                    switch(choice)
                    {
                        case 1:
                            displayManager.cpumenu(menuIndex);
                            break;
                        case 2:
                            displayManager.gpumenu(menuIndex);
                            break;
                        case 3:
                            displayManager.mbmenu(menuIndex);
                            break;
                        case 4:
                            displayManager.rammenu(menuIndex);
                            break;
                        case 6:
                            displayManager.psumenu(menuIndex);
                            break;
                        case 7:
                            displayManager.casemenu(menuIndex);
                            break;
                    }
                    mainApp.backicon.Visible = true;
                }
            }
        }
        private void productmenu_Load(object sender, EventArgs e)
        {

            InitializeDisplayManager();
        }

        private void InitializeDisplayManager()
        {
            productmenu caseMenuForm = this;
            DisplayManager displayManager = new DisplayManager(caseMenuForm);
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BorderStyle = BorderStyle.None;
            }
        }
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null && e.Button == MouseButtons.Left)
            {
                HandlePanelClick(panel);
            }
        }
        private void ChildControl_MouseMove(object sender, MouseEventArgs e)
        {
            Panel panel = GetPanelFromControl(sender as Control);
            if (panel != null)
            {
                Panel_MouseMove(panel, e);
            }
        }
        private void ChildControl_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = GetPanelFromControl(sender as Control);
            if (panel != null)
            {
                Panel_MouseLeave(panel, e);
            }
        }
        private void ChildControl_MouseDown(object sender, MouseEventArgs e)
        {
            Panel panel = GetPanelFromControl(sender as Control);
            if (panel != null && e.Button == MouseButtons.Left)
            {
                HandlePanelClick(panel);
            }
        }
        private Panel GetPanelFromControl(Control control)
        {
            while (control != null && !(control is Panel))
            {
                control = control.Parent;
            }
            return control as Panel;
        }

        private void labname1_Click(object sender, EventArgs e)
        {

        }

        private void labname2_Click(object sender, EventArgs e)
        {

        }

        private void labname3_Click(object sender, EventArgs e)
        {

        }

        private void labname4_Click(object sender, EventArgs e)
        {

        }

        private void labname8_Click(object sender, EventArgs e)
        {

        }

        private void labname6_Click(object sender, EventArgs e)
        {

        }

        private void labname5_Click(object sender, EventArgs e)
        {

        }
    }
}
