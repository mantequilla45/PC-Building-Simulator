using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
                        string psuImage = psuName.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
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

                case 9:
                    string[] monitorNames = {
                        "Asus ROG Strix XG43UQ", "Samsung Odyssey G9", "LG 27GP950-B", "Acer Predator XB323QK NV",
                        "MSI MEG 341CQR", "Gigabyte M32U", "AOC Agon AG352UCG6", "ViewSonic Elite XG270QG",
                        "Asus ProArt Display PA32UCG", "BenQ PD3220U", "Dell UltraSharp U3223QE", "Apple Pro Display XDR",
                        "LG UltraFine Ergo 32EP950-B", "Samsung Odyssey Neo G8", "HP Z34C G3", "iiyama G-Master GB3466WQSU-B1",
                        "Philips Evnia 34M2C7600MV", "Lenovo ThinkVision P34w-20", "MSI Modern AM271CQP Monitor",
                        "AOC CQ32G1S"
                    };

                    price = new int[]{
                        70, 80, 80, 70, 100,
                        80, 300, 120, 70, 150,
                        180, 150, 140, 170, 120,
                        200, 80, 80, 80, 100
                    };

                    for (int i = 0; i < monitorNames.Length; i++)
                    {
                        string monitorName = monitorNames[i];
                        string monitorImage = monitorName.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
                        string resourceMonitor = $"mon_{monitorImage}";

                        PictureBox pictureBox = Controls.Find($"pbox{i + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourceMonitor);
                        }

                        Label priceLabel = pricelabels[i];
                        if (priceLabel != null)
                        {
                            priceLabel.Text = $"${price[i]}";
                        }

                        Label nameLabel = namelabels[i];
                        if (nameLabel != null)
                        {
                            nameLabel.Text = monitorName;
                        }
                    }
                break;

                case 10:
                    string[] keyboardNames = {
                        "Razer Blackwidow V3 Pro", "Logitech MX Mechanical Mini", "Apple Magic Keyboard", "CORSAIR K100 RGB",
                        "SteelSeries Apex Pro TKL", "Glorious GMMK Pro", "HyperX Alloy Origins Core", "Fnatic STREAK65 LP",
                        "Ducky One 3 Mini", "Leopold FC980M PD", "Niz Plum 82", "Keychron Q1", "Epomaker GK68XS",
                        "Anne Pro 2", "Redragon K552", "Logitech G915 TKL", "MSI Vigor GK71", "Asus ROG Strix Scope TKL",
                        "Cooler Master SK622", "NuPhy Air75"
                    };

                    price = new int[] {
                        155, 125, 115, 200, 175,
                        145, 100, 125, 140, 275,
                        200, 175, 100, 85, 40,
                        200, 120, 150, 85, 140
                    };

                    for (int i = 0; i < keyboardNames.Length; i++)
                    {
                        string keyboardName = keyboardNames[i];
                        string keyboardImage = keyboardName.Replace(' ', '_').Replace('-', '_').Replace('!', '_');

                        PictureBox pictureBox = Controls.Find($"pbox{i + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            string resourceKeyboard = $"key_{keyboardImage}";
                            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourceKeyboard);
                        }

                        Label priceLabel = pricelabels[i];
                        if (priceLabel != null)
                        {
                            priceLabel.Text = $"${price[i]}";
                        }

                        Label nameLabel = namelabels[i];
                        if (nameLabel != null)
                        {
                            nameLabel.Text = keyboardName;
                        }
                    }
                    break;

                case 11:
                    string[] mouseNames = {
                        "Logitech MX Master 3", "Razer DeathAdder V2 Mini", "Apple Magic Mouse 2", "Glorious Model O",
                        "SteelSeries Rival 650 Wireless", "HyperX Pulsefire Haste", "Fnatic Flick 2", "Ducky Feather",
                        "Logitech G502 Hero", "Corsair Dark Core Pro RGB SE", "Logitech M220 Silent", "Logitech G305 Lightspeed",
                        "Razer Basilisk V3", "Logitech MX Anywhere 3", "SteelSeries Rival 710", "Razer Naga Trinity",
                        "Glorious Model D Wireless", "Logitech G Pro Wireless", "Zowie S2-C Divina Series", "Logitech MX Vertical Ergonomic Mouse"
                    };

                     price = new int[]{
                        100, 60, 80, 65, 100,
                        60, 70, 70, 65, 100,
                        25, 50, 70, 85, 70,
                        100, 100, 120, 90, 85
                    };

                    for (int i = 0; i < mouseNames.Length; i++)
                    {
                        string mouseName = mouseNames[i];
                        string mouseImage = mouseName.Replace(' ', '_').Replace('-', '_').Replace('!', '_');

                        PictureBox pictureBox = Controls.Find($"pbox{i + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            string resourceMouse = $"mou_{mouseImage}";
                            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourceMouse);
                        }

                        Label priceLabel = pricelabels[i];
                        if (priceLabel != null)
                        {
                            priceLabel.Text = $"${price[i]}";
                        }

                        Label nameLabel = namelabels[i];
                        if (nameLabel != null)
                        {
                            nameLabel.Text = mouseName;
                        }
                    }
                    break;

                case 12:
                    string[] speakerNames = {
                        "Bose Companion 20", "Logitech G560 LIGHTSYNC", "Razer Nommo Chroma", "Creative Pebble Plus 2.0",
                        "Edifier R1280T", "Audioengine A2+ Wireless", "Mackie CR3-XBT", "Kanto YU4", "Swan M10 Plus",
                        "IK Multimedia iLoud Micro Monitor", "Micca RB42", "Edifier S350DB", "Audioengine A5+ Wireless",
                        "PreSonus Eris E3.5", "JBL Studio 530", "Kali Audio LP-6", "Neumi BS5", "Monoprice DT-3BT",
                        "Klipsch R-41M", "Audioengine HD3"
                    };

                    price = new int[]{
                        40, 200, 150, 40, 120,
                        300, 200, 250, 156, 200,
                        150, 200, 400, 150, 200,
                        350, 250, 150, 150, 350
                    };

                    for (int i = 0; i < speakerNames.Length; i++)
                    {
                        string speakerName = speakerNames[i];
                        string speakerImage = speakerName.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('+', '_').Replace('.', '_');

                        PictureBox pictureBox = Controls.Find($"pbox{i + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            string resourceSpeaker = $"spe_{speakerImage}";
                            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourceSpeaker);
                        }

                        Label priceLabel = pricelabels[i];
                        if (priceLabel != null)
                        {
                            priceLabel.Text = $"${price[i]}";
                        }

                        Label nameLabel = namelabels[i];
                        if (nameLabel != null)
                        {
                            nameLabel.Text = speakerName;
                        }
                    }
                    break;

                case 13:
                    string[] hddNames = {
                        "HGST Deskstar NAS 4TB", "HGST Ultrastar 12TB", "Hitachi Deskstar 500GB", "Hitachi Ultrastar 5TB",
                        "Samsung Spinpoint 1TB", "Seagate Barracuda 3TB", "Seagate BarraCuda Pro 14TB", "Seagate Constellation 3TB",
                        "Seagate FireCuda 8TB", "Seagate IronWolf 10TB", "Seagate SkyHawk 14TB", "Toshiba DT01ACA 1TB",
                        "Toshiba N300 14TB", "Toshiba P300 3TB", "Toshiba X300 6TB", "WD VelociRaptor 1TB",
                        "Western Digital Black 2.5TB", "Western Digital Blue 2TB", "Western Digital Gold 18TB", "Western Digital Red 8TB"
                    };

                    price = new int[]{
                        115, 450, 25, 175, 45,
                        70, 425, 125, 225, 275,
                        375, 35, 325, 70, 135,
                        200, 90, 50, 475, 225
                    };


                    for (int i = 0; i < hddNames.Length; i++)
                    {
                        string hddName = hddNames[i];
                        string hddImage = hddName.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('+', '_').Replace('.', '_');

                        PictureBox pictureBox = Controls.Find($"pbox{i + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            string resourceHDD = $"hdd_{hddImage}";
                            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourceHDD);
                        }

                        Label priceLabel = pricelabels[i];
                        if (priceLabel != null)
                        {
                            priceLabel.Text = $"${price[i]}";
                        }

                        Label nameLabel = namelabels[i];
                        if (nameLabel != null)
                        {
                            nameLabel.Text = hddName;
                        }
                    }
                    break;

                case 14:
                    string[] ssdNames = {
                        "Samsung 870 EVO 1TB", "Crucial MX500 2TB", "Western Digital Blue SSD 1TB", "SanDisk Ultra 3D SSD 2TB",
                        "Kingston UV500 SSD 512GB", "Intel 545s SSD 512GB", "Seagate Barracuda SSD 2TB", "ADATA SU800 SSD 256GB",
                        "Toshiba TR200 SSD 1TB", "PNY CS900 SSD 4TB", "Silicon Power Ace A55 SSD 512GB", "Transcend SSD230S SSD 2TB",
                        "HP S700 SSD 1TB", "Team Group L5 3D SSD 1TB", "Patriot Burst SSD 2TB", "Gigabyte UD PRO SSD 1TB",
                        "OWC Mercury Electra 6G SSD 2TB", "SK hynix Gold S31 SSD 1TB", "Mushkin Source SSD 500GB", "Kingston A400 2TB"
                    };

                    price = new int[]{
                        120, 200, 100, 175,
                        50, 175, 180, 50,
                        95, 400, 40, 160,
                        100, 85, 140, 170,
                        120, 200, 100, 175
                    };

                    for (int i = 0; i < ssdNames.Length; i++)
                    {
                        string ssdName = ssdNames[i];
                        string ssdImage = ssdName.Replace(' ', '_').Replace('-', '_').Replace('!', '_').Replace('+', '_').Replace('.', '_');

                        PictureBox pictureBox = Controls.Find($"pbox{i + 1}", true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            string resourceSSD = $"ssd_{ssdImage}";
                            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(resourceSSD);
                        }

                        Label priceLabel = pricelabels[i];
                        if (priceLabel != null)
                        {
                            priceLabel.Text = $"${price[i]}";
                        }

                        Label nameLabel = namelabels[i];
                        if (nameLabel != null)
                        {
                            nameLabel.Text = ssdName;
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
                        case 9:
                            displayManager.monitormenu(menuIndex);
                            break;
                        case 10:
                            displayManager.keyboardmenu(menuIndex);
                            break;
                        case 11:
                            displayManager.mousemenu(menuIndex);
                            break;
                        case 12:
                            displayManager.speakersmenu(menuIndex);
                            break;
                        case 13:
                            displayManager.hddmenu(menuIndex);
                            break;
                        case 14:
                            displayManager.ssdmenu(menuIndex);
                            break;

                    }
                    mainApp.backicon.Visible = true;
                }
            }
        }
        private void InitializeControls()
        {
            for (int i = 0; i < 20; i++)
            {
                Panel panel = (Panel)this.Controls.Find($"panel{i + 1}", true).FirstOrDefault();
                PictureBox pictureBox = (PictureBox)this.Controls.Find($"pbox{i + 1}", true).FirstOrDefault();
                Label nameLabel = (Label)this.Controls.Find($"labname{i + 1}", true).FirstOrDefault();
                Label priceLabel = (Label)this.Controls.Find($"labprice{i + 1}", true).FirstOrDefault();
                KryptonButton border = (KryptonButton)this.Controls.Find($"border{i + 1}", true).FirstOrDefault();

                if (panel != null && pictureBox != null && nameLabel != null && priceLabel != null)
                {
                    panel.MouseLeave += Panel_MouseLeave;
                    panel.MouseMove += Panel_MouseMove;
                    panel.MouseDown += Panel_MouseDown;
                    border.MouseLeave += Panel_MouseLeave;
                    border.MouseMove += Panel_MouseMove;
                    border.MouseDown += Panel_MouseDown;
                    pictureBox.MouseLeave += ChildControl_MouseLeave;
                    pictureBox.MouseMove += ChildControl_MouseMove;
                    pictureBox.MouseDown += ChildControl_MouseDown;
                    nameLabel.MouseLeave += ChildControl_MouseLeave;
                    nameLabel.MouseMove += ChildControl_MouseMove;
                    nameLabel.MouseDown += ChildControl_MouseDown;
                    priceLabel.MouseLeave += ChildControl_MouseLeave;
                    priceLabel.MouseMove += ChildControl_MouseMove;
                    priceLabel.MouseDown += ChildControl_MouseDown;
                }
            }
        }
        private void productmenu_Load(object sender, EventArgs e)
        {

            InitializeDisplayManager();
        }

        private void InitializeDisplayManager()
        {
            productmenu productmenuform = this;
            MemoryManager displayManager = new MemoryManager(productmenuform);
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = GetPanelFromControl(sender as Control);
            if (panel != null)
            {
                KryptonButton border = GetBorderFromPanel(panel);
                if (border != null)
                {
                    border.StateCommon.Border.Color1 = Color.White; // Set border color to White (change as needed)
                }
            }
        }
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            Panel panel = GetPanelFromControl(sender as Control);
            if (panel != null)
            {
                KryptonButton border = GetBorderFromPanel(panel);
                if (border != null)
                {
                    border.StateCommon.Border.Color1 = Color.Silver; // Set border color to Red (change as needed)
                }
            }
        }
        private KryptonButton GetBorderFromPanel(Panel panel)
        {

            foreach (Control control in panel.Controls)
            {
                if (control is KryptonButton)
                {
                    return (KryptonButton)control;
                }
            }
            return null;
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
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
    }
}
