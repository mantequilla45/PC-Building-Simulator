using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PC_Building_Simulator
{
    internal class DisplayManager
    {
        public MainApp mainApp;
        private buildmenu buildMenuForm;
        private productmenu productMenuForm;
        private productspecs productSpecsForm;
        public DisplayManager(buildmenu buildMenuForm)
        {
            this.buildMenuForm = buildMenuForm;
        }
        public DisplayManager(productmenu productMenuForm)
        {
            this.productMenuForm = productMenuForm;
        }
        public DisplayManager(productspecs productSpecsForm)
        {
            this.productSpecsForm = productSpecsForm;
        }
        public DisplayManager(MainApp mainApp)
        {
            this.mainApp = mainApp;
        }
        public static class ButtonAppearance
        {
            public static class Activate
            {
                public static void Build(MainApp mainApp)
                {
                    mainApp.but_build.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                    mainApp.bluebar1.Visible = true;
                    mainApp.pcicon1.Visible = false;
                    mainApp.pcicon2.Visible = true;
                }

                public static void CPU(MainApp mainApp)
                {
                    mainApp.but_cpu.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                    mainApp.bluebar2.Visible = true;
                    mainApp.cpuicon1.Visible = false;
                    mainApp.cpuicon2.Visible = true;
                }
                public static void GPU(MainApp mainApp)
                {
                    mainApp.but_gpu.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                    mainApp.bluebar3.Visible = true;
                    mainApp.gpuicon1.Visible = false;
                    mainApp.gpuicon2.Visible = true;
                }
                public static void Motherboard(MainApp mainApp)
                {
                    mainApp.but_mb.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                    mainApp.bluebar4.Visible = true;
                    mainApp.mbicon1.Visible = false;
                    mainApp.mbicon2.Visible = true;
                }
                public static void RAM(MainApp mainApp)
                {
                    mainApp.but_ram.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                    mainApp.bluebar5.Visible = true;
                    mainApp.ramicon1.Visible = false;
                    mainApp.ramicon2.Visible = true;
                }

                public static void Storage(MainApp mainApp)
                {
                    mainApp.but_storage.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                    mainApp.bluebar6.Visible = true;
                    mainApp.storageicon1.Visible = false;
                    mainApp.storageicon2.Visible = true;
                }
                public static void PSU(MainApp mainApp)
                {
                    mainApp.but_psu.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                    mainApp.bluebar7.Visible = true;
                    mainApp.psuicon1.Visible = false;
                    mainApp.psuicon2.Visible = true;
                }
                public static void Case(MainApp mainApp)
                {
                    mainApp.but_case.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                    mainApp.bluebar8.Visible = true;
                    mainApp.caseicon1.Visible = false;
                    mainApp.caseicon2.Visible = true;
                }
                public static void Cooler(MainApp mainApp)
                {
                    mainApp.but_cooler.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                    mainApp.bluebar9.Visible = true;
                    mainApp.coolericon1.Visible = false;
                    mainApp.coolericon2.Visible = true;
                }
                public static void Monitor(MainApp mainApp)
                {
                    mainApp.but_monitor.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                    mainApp.bluebar10.Visible = true;
                    mainApp.monitoricon1.Visible = false;
                    mainApp.monitoricon2.Visible = true;
                }
                public static void Keyboard(MainApp mainApp)
                {
                    mainApp.but_keyb.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                    mainApp.bluebar11.Visible = true;
                    mainApp.keybicon1.Visible = false;
                    mainApp.keybicon2.Visible = true;
                }
                public static void Mouse(MainApp mainApp)
                {
                    mainApp.but_mouse.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                    mainApp.bluebar12.Visible = true;
                    mainApp.mouseicon1.Visible = false;
                    mainApp.mouseicon2.Visible = true;
                }
                public static void Speakers(MainApp mainApp)
                {
                    mainApp.but_speakers.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                    mainApp.bluebar13.Visible = true;
                    mainApp.speakersicon1.Visible = false;
                    mainApp.speakersicon2.Visible = true;
                }
            }

            public static class Reset
            {
                public static void Build(MainApp mainApp)
                {
                    mainApp.but_build.StateCommon.Content.ShortText.Color1 = Color.DimGray;
                    mainApp.bluebar1.Visible = false;
                    mainApp.pcicon1.Visible = true;
                    mainApp.pcicon2.Visible = false;
                }

                public static void CPU(MainApp mainApp)
                {
                    mainApp.but_cpu.StateCommon.Content.ShortText.Color1 = Color.DimGray;
                    mainApp.bluebar2.Visible = false;
                    mainApp.cpuicon1.Visible = true;
                    mainApp.cpuicon2.Visible = false;
                }
                public static void GPU(MainApp mainApp)
                {
                    mainApp.but_gpu.StateCommon.Content.ShortText.Color1 = Color.DimGray;
                    mainApp.bluebar3.Visible = false;
                    mainApp.gpuicon1.Visible = true;
                    mainApp.gpuicon2.Visible = false;
                }
                public static void Motherboard(MainApp mainApp)
                {
                    mainApp.but_mb.StateCommon.Content.ShortText.Color1 = Color.DimGray;
                    mainApp.bluebar4.Visible = false;
                    mainApp.mbicon1.Visible = true;
                    mainApp.mbicon2.Visible = false;
                }
                public static void RAM(MainApp mainApp)
                {
                    mainApp.but_ram.StateCommon.Content.ShortText.Color1 = Color.DimGray;
                    mainApp.bluebar5.Visible = false;
                    mainApp.ramicon1.Visible = true;
                    mainApp.ramicon2.Visible = false;
                }
                public static void Storage(MainApp mainApp)
                {
                    mainApp.but_storage.StateCommon.Content.ShortText.Color1 = Color.DimGray;
                    mainApp.bluebar6.Visible = false;
                    mainApp.storageicon1.Visible = true;
                    mainApp.storageicon2.Visible = false;
                }
                public static void PSU(MainApp mainApp)
                {
                    mainApp.but_psu.StateCommon.Content.ShortText.Color1 = Color.DimGray;
                    mainApp.bluebar7.Visible = false;
                    mainApp.psuicon1.Visible = true;
                    mainApp.psuicon2.Visible = false;
                }
                public static void Case(MainApp mainApp)
                {
                    mainApp.but_case.StateCommon.Content.ShortText.Color1 = Color.DimGray;
                    mainApp.bluebar8.Visible = false;
                    mainApp.caseicon1.Visible = true;
                    mainApp.caseicon2.Visible = false;
                }
                public static void Cooler(MainApp mainApp)
                {
                    mainApp.but_cooler.StateCommon.Content.ShortText.Color1 = Color.DimGray;
                    mainApp.bluebar9.Visible = false;
                    mainApp.coolericon1.Visible = true;
                    mainApp.coolericon2.Visible = false;
                }
                public static void Monitor(MainApp mainApp)
                {
                    mainApp.but_monitor.StateCommon.Content.ShortText.Color1 = Color.DimGray;
                    mainApp.bluebar10.Visible = false;
                    mainApp.monitoricon1.Visible = true;
                    mainApp.monitoricon2.Visible = false;
                }
                public static void Keyboard(MainApp mainApp)
                {
                    mainApp.but_keyb.StateCommon.Content.ShortText.Color1 = Color.DimGray;
                    mainApp.bluebar11.Visible = false;
                    mainApp.keybicon1.Visible = true;
                    mainApp.keybicon2.Visible = false;
                }
                public static void Mouse(MainApp mainApp)
                {
                    mainApp.but_mouse.StateCommon.Content.ShortText.Color1 = Color.DimGray;
                    mainApp.bluebar12.Visible = false;
                    mainApp.mouseicon1.Visible = true;
                    mainApp.mouseicon2.Visible = false;
                }
                public static void Speakers(MainApp mainApp)
                {
                    mainApp.but_speakers.StateCommon.Content.ShortText.Color1 = Color.DimGray;
                    mainApp.bluebar13.Visible = false;
                    mainApp.speakersicon1.Visible = true;
                    mainApp.speakersicon2.Visible = false;
                }
            }
        }
        public void otherButton_Click(bool clicked)
        {
            clicked = false;
            ButtonAppearance.Reset.Build(mainApp);
            ButtonAppearance.Reset.CPU(mainApp);
            ButtonAppearance.Reset.GPU(mainApp);
            ButtonAppearance.Reset.Motherboard(mainApp);
            ButtonAppearance.Reset.RAM(mainApp);
            ButtonAppearance.Reset.Storage(mainApp);
            ButtonAppearance.Reset.PSU(mainApp);
            ButtonAppearance.Reset.Case(mainApp);
            ButtonAppearance.Reset.Cooler(mainApp);
            ButtonAppearance.Reset.Monitor(mainApp);
            ButtonAppearance.Reset.Keyboard(mainApp);
            ButtonAppearance.Reset.Mouse(mainApp);
            ButtonAppearance.Reset.Speakers(mainApp);
        }
        public void DisposeAllMenuForms()
        {
            if (buildMenuForm != null)
            {
                buildMenuForm.Dispose();
                buildMenuForm = null;
            }
            if (productMenuForm != null)
            {
                productMenuForm.Dispose();
                productMenuForm = null;
            }

            if (productSpecsForm != null)
            {
                productSpecsForm.Dispose();
                productSpecsForm = null;
            }
        }
        public void menuselect(int menuchoice)
        {
            MemoryManager memoryManager;
            productmenu productpanel;
            switch (menuchoice)
            {
                case 1:
                    mainApp.label_menu.Text = "Your Build";
                    mainApp.panelmain.Controls.Clear();
                    buildmenu buildpanel = new buildmenu() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    buildpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(buildpanel);
                    buildpanel.Show();
                    DisposeAllMenuForms();
                    buildMenuForm = buildpanel;
                    break;

                case 2:
                    mainApp.label_menu.Text = "CPU";
                    mainApp.panelmain.Controls.Clear();
                    productpanel = new productmenu(mainApp, 1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    productpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(productpanel);
                    DisposeAllMenuForms();
                    productpanel.Show();
                    productMenuForm = productpanel;
                    break;

                case 3:
                    mainApp.label_menu.Text = "GPU";
                    mainApp.panelmain.Controls.Clear();
                    productpanel = new productmenu(mainApp, 2) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    productpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(productpanel);
                    productpanel.Show();
                    DisposeAllMenuForms();
                    productMenuForm = productpanel;
                    break;

                case 4:
                    mainApp.label_menu.Text = "Motherboard";
                    mainApp.panelmain.Controls.Clear();
                    productpanel = new productmenu(mainApp, 3) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    productpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(productpanel);
                    productpanel.Show();
                    DisposeAllMenuForms();
                    productMenuForm = productpanel;
                    break;

                case 5:
                    mainApp.label_menu.Text = "RAM Module";
                    mainApp.panelmain.Controls.Clear();
                    productpanel = new productmenu(mainApp, 4) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    productpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(productpanel);
                    productpanel.Show();
                    DisposeAllMenuForms();
                    productMenuForm = productpanel;
                    break;

                case 6:
                    mainApp.label_menu.Text = "Drives";
                    mainApp.panelmain.Controls.Clear();
                    storagemenu storagepanel = new storagemenu(mainApp) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    storagepanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(storagepanel);
                    DisposeAllMenuForms();
                    storagepanel.Show();
                    break;

                case 7:
                    mainApp.label_menu.Text = "PSU";
                    mainApp.panelmain.Controls.Clear();
                    productpanel = new productmenu(mainApp, 6) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    productpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(productpanel);
                    productpanel.Show();
                    DisposeAllMenuForms();
                    productMenuForm = productpanel;
                    break;

                case 8:
                    mainApp.label_menu.Text = "Computer Case";
                    mainApp.panelmain.Controls.Clear();
                    productpanel = new productmenu(mainApp, 7) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    productpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(productpanel);
                    productpanel.Show();
                    DisposeAllMenuForms();
                    productMenuForm = productpanel;
                    break;

                case 9:
                    mainApp.label_menu.Text = "Cooling System";
                    mainApp.panelmain.Controls.Clear();
                    coolermenu coolerpanel = new coolermenu() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    coolerpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(coolerpanel);
                    DisposeAllMenuForms();
                    coolerpanel.Show();
                    break;

                case 10:
                    mainApp.label_menu.Text = "Monitor";
                    mainApp.panelmain.Controls.Clear();
                    productpanel = new productmenu(mainApp, 9) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    productpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(productpanel);
                    DisposeAllMenuForms();
                    productpanel.Show();
                    break;

                case 11:
                    mainApp.label_menu.Text = "Keyboard";
                    mainApp.panelmain.Controls.Clear();
                    productpanel = new productmenu(mainApp, 10) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    productpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(productpanel);
                    productpanel.Show();
                    DisposeAllMenuForms();
                    productMenuForm = productpanel;
                    break;

                case 12:
                    mainApp.label_menu.Text = "Mouse";
                    mainApp.panelmain.Controls.Clear();
                    productpanel = new productmenu(mainApp, 11) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    productpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(productpanel);
                    productpanel.Show();
                    DisposeAllMenuForms();
                    productMenuForm = productpanel;
                    break;

                case 13:
                    mainApp.label_menu.Text = "Speakers";
                    mainApp.panelmain.Controls.Clear();
                    productpanel = new productmenu(mainApp, 12) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    productpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(productpanel);
                    productpanel.Show();
                    DisposeAllMenuForms();
                    productMenuForm = productpanel;
                    break;

                case 14:
                    mainApp.label_menu.Text = "HDD";
                    mainApp.panelmain.Controls.Clear();
                    productpanel = new productmenu(mainApp, 13) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    productpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(productpanel);
                    productpanel.Show();
                    DisposeAllMenuForms();
                    productMenuForm = productpanel;
                    break;

                case 15:
                    mainApp.label_menu.Text = "SSD";
                    mainApp.panelmain.Controls.Clear();
                    productpanel = new productmenu(mainApp, 14) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    productpanel.FormBorderStyle = FormBorderStyle.None;
                    mainApp.panelmain.Controls.Add(productpanel);
                    productpanel.Show();
                    DisposeAllMenuForms();
                    productMenuForm = productpanel;
                    break;

                default:
                    break;
            }
        }
        public void cpumenu(int num, Label strprice)
        {
            string[] cpuNames = {
                "Intel Core i9-11900K", "AMD Ryzen 9 5950X", "Intel Core i7-11700K", "AMD Ryzen 7 5800X",
                "Intel Core i5-11600K", "AMD Ryzen 5 5600X", "Intel Core i3-10100", "AMD Ryzen 3 3300X",
                "Intel Core i9-10900K", "AMD Ryzen 9 5900X", "Intel Core i9-12900K", "AMD Ryzen 9 7900X",
                "Intel Core i7-12700K", "AMD Ryzen 7 7800X3D", "Intel Core i5-12600K", "AMD Ryzen 7 7700X",
                "Intel Core i5-12400", "AMD Ryzen 3 3200G", "Intel Core i9-14900K", "AMD Ryzen 9 7900X3D"
            };
            string price = strprice.Text;
            if (num >= 1 && num <= cpuNames.Length)
            {

                string cpuName = cpuNames[num - 1];
                mainApp.label_menu.Text = $"{cpuName} Specifications";

                mainApp.panelmain.Controls.Clear();

                productspecs productspecs = new productspecs(cpuName, 1, mainApp, price)
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None
                };
                mainApp.panelmain.Controls.Add(productspecs);
                DisposeAllMenuForms();
                productspecs.Show();
            }
        }
        public void gpumenu(int num, Label strprice)
        {
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
            
            string price = strprice.Text;
            if (num >= 1 && num <= gpuNames.Length)
            {
                string gpuName = gpuNames[num - 1];
                mainApp.label_menu.Text = $"{gpuName} Specifications";
                mainApp.panelmain.Controls.Clear();
                productspecs productspecs = new productspecs(gpuName, 2, mainApp, price)
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None
                };
                mainApp.panelmain.Controls.Add(productspecs);
                DisposeAllMenuForms();
                productspecs.Show();
            }
        }
        public void mbmenu(int num, Label strprice)
        {
            string[] mbNames = {
                "MSI MEG Z690 Godlike", "ASUS ROG Strix X570-E Gaming", "Gigabyte B550M Aorus Pro",
                "MSI B460M Mortar Micro ATX WiFi", "ASRock Z690 Extreme", "EVGA X570 Dark",
                "ASUS ROG Strix B550-F Gaming WiFi", "MSI MPG Z490 Gaming Carbon WiFi",
                "Gigabyte B460M DS3H", "ASRock B450M Steel Legend", "MSI B560M Mortar WiFi",
                "ASUS ROG Strix X570-I Gaming WiFi", "Gigabyte Z490 Aorus Elite", "MSI B460M Bazooka V2",
                "ASRock B550 Phantom Gaming 4", "MSI MPG X570 Gaming Plus", "ASUS Prime B460M-A",
                "Gigabyte B450M DS3H WIFI", "MSI B550M Mortar Micro ATX", "ASRock B460M Pro4"
            };

            string price = strprice.Text;
            if (num >= 1 && num <= mbNames.Length)
            {
                string mbName = mbNames[num - 1];
                mainApp.label_menu.Text = $"{mbName} Specifications";

                mainApp.panelmain.Controls.Clear();
                productspecs productspecs = new productspecs(mbName, 3, mainApp, price)
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None
                };
                mainApp.panelmain.Controls.Add(productspecs);
                DisposeAllMenuForms();
                productspecs.Show();
            }
        }

        public void rammenu(int num, Label strprice)
        {
            string[] ramNames = {
                "Vengeance RGB PRO", "TridentZ RGB Series", "T-Force Delta RGB", "Viper Steel Series DDR4",
                "Ballistix RGB", "Ripjaws V Series", "Gammix D10", "Fury Beast RGB", "T-Force Vulcan Z",
                "Aegis F4 Series", "Fury Beast RGB", "TridentZ5 RGB Series", "Vengeance RGB DDR5",
                "T-Force Delta RGB DDR5", "Ballistix MAX RGB DDR5", "XPG Lancer RGB DDR5",
                "Dominator Platinum 32GB DDR5-5200", "Ripjaws S5 Series DDR5", "Fury Renegade RGB DDR5",
                "T-Force Dark Z Alpha DDR5"
            };

            string price = strprice.Text;
            if (num >= 1 && num <= ramNames.Length)
            {
                string ramName = ramNames[num - 1];
                mainApp.label_menu.Text = $"{ramName} Specifications";

                mainApp.panelmain.Controls.Clear();
                productspecs productspecs = new productspecs(ramName, 4, mainApp, price)
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None
                };
                mainApp.panelmain.Controls.Add(productspecs);
                DisposeAllMenuForms();
                productspecs.Show();
            }
        }
        public void psumenu(int num, Label strprice)
        {
            string[] psuNames = {
                "Asus TUF Gaming 750W Bronze", "Corsair RM1000x", "EVGA B550 Bronze", "Super Flower Leadex III Gold 750W",
                "Thermaltake Toughpower Grand RGB 1200W Gold", "Thermaltake Smart 650W", "Gigabyte P850W Gold",
                "Corsair CX450M", "EVGA SuperNOVA 1600 T2", "Seasonic S12III Bronze 550W", "Corsair AX1500i",
                "EVGA G+ 1000W Gold", "Seasonic Prime PX-1000", "Seasonic PRIME TX-1600 Titanium", "NZXT C850 Gold",
                "Cooler Master MasterWatt Maker 1200 Titanium", "be quiet! Pure Power 10 CM 850W", "MSI MPG A-GF AI 850W Gold",
                "Asus ROG Thor 1200W Platinum", "Cooler Master MWE Bronze V650"
            };

            string price = strprice.Text;
            if (num >= 1 && num <= psuNames.Length)
            {
                string psuName = psuNames[num - 1];
                mainApp.label_menu.Text = $"{psuName} Specifications";
                mainApp.panelmain.Controls.Clear();

                productspecs productspecs = new productspecs(psuName, 6, mainApp, price)
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None
                };
                mainApp.panelmain.Controls.Add(productspecs);
                DisposeAllMenuForms();
                productspecs.Show();
            }   
        }
        public void casemenu(int num, Label strprice)
        {
            string[] caseNames = {
                "NZXT H510", "Fractal Design Meshify C", "Corsair 4000D Airflow", "Lian Li Lancool 215",
                "Phanteks Eclipse G360A", "Cooler Master MasterBox NR200P", "ASUS ROG Strix Helios",
                "be quiet! Pure Base 500DX", "Thermaltake S100 TG", "MSI MPG Sekira 500X",
                "NZXT H710i", "Corsair iCUE 500X RGB", "Lian Li O11 Dynamic", "Fractal Design Define 7",
                "Cooler Master MasterCase H500M", "be quiet! Silent Base 802", "Phanteks Eclipse P400A",
                "MasterBox NR200P SE", "Thermaltake H500", "MSI MPG Velox 100"
            };

            string price = strprice.Text;
            if (num >= 1 && num <= caseNames.Length)
            {
                string caseName = caseNames[num - 1];
                mainApp.label_menu.Text = $"{caseName} Specifications";

                mainApp.panelmain.Controls.Clear();
                productspecs productspecs = new productspecs(caseName, 7, mainApp, price)
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None
                };
                mainApp.panelmain.Controls.Add(productspecs);
                productspecs.Show();
            }
        }
        public void monitormenu(int num, Label strprice)
        {
            string[] monitorNames = {
                "Asus ROG Strix XG43UQ", "Samsung Odyssey G9", "LG 27GP950-B", "Acer Predator XB323QK NV",
                "MSI MEG 341CQR", "Gigabyte M32U", "AOC Agon AG352UCG6", "ViewSonic Elite XG270QG",
                "Asus ProArt Display PA32UCG", "BenQ PD3220U", "Dell UltraSharp U3223QE", "Apple Pro Display XDR",
                "LG UltraFine Ergo 32EP950-B", "Samsung Odyssey Neo G8", "HP Z34C G3", "iiyama G-Master GB3466WQSU-B1",
                "Philips Evnia 34M2C7600MV", "Lenovo ThinkVision P34w-20", "MSI Modern AM271CQP Monitor",
                "AOC CQ32G1S"
            };

            string price = strprice.Text;
            if (num >= 1 && num <= monitorNames.Length)
            {
                string monitorName = monitorNames[num - 1];
                mainApp.label_menu.Text = $"{monitorName} Specifications";

                mainApp.panelmain.Controls.Clear();
                productspecs productspecs = new productspecs(monitorName, 9, mainApp, price)
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None
                };
                mainApp.panelmain.Controls.Add(productspecs);
                productspecs.Show();
            }
        }
        public void keyboardmenu(int num, Label strprice)
        {
            string[] keyboardNames = {
                "Razer Blackwidow V3 Pro", "Logitech MX Mechanical Mini", "Apple Magic Keyboard", "CORSAIR K100 RGB",
                "SteelSeries Apex Pro TKL", "Glorious GMMK Pro", "HyperX Alloy Origins Core", "Fnatic STREAK65 LP",
                "Ducky One 3 Mini", "Leopold FC980M PD", "Niz Plum 82", "Keychron Q1", "Epomaker GK68XS",
                "Anne Pro 2", "Redragon K552", "Logitech G915 TKL", "MSI Vigor GK71", "Asus ROG Strix Scope TKL",
                "Cooler Master SK622", "NuPhy Air75"
            };

            string price = strprice.Text;
            if (num >= 1 && num <= keyboardNames.Length)
            {
                string keybName = keyboardNames[num - 1];
                mainApp.label_menu.Text = $"{keybName} Specifications";

                mainApp.panelmain.Controls.Clear();
                productspecs productspecs = new productspecs(keybName, 10, mainApp, price)
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None
                };
                mainApp.panelmain.Controls.Add(productspecs);
                productspecs.Show();
            }
        }
        public void mousemenu(int num, Label strprice)
        {
            string[] mouseNames = {
                "Logitech MX Master 3", "Razer DeathAdder V2 Mini", "Apple Magic Mouse 2", "Glorious Model O",
                "SteelSeries Rival 650 Wireless", "HyperX Pulsefire Haste", "Fnatic Flick 2", "Ducky Feather",
                "Logitech G502 Hero", "Corsair Dark Core Pro RGB SE", "Logitech M220 Silent", "Logitech G305 Lightspeed",
                "Razer Basilisk V3", "Logitech MX Anywhere 3", "SteelSeries Rival 710", "Razer Naga Trinity",
                "Glorious Model D Wireless", "Logitech G Pro Wireless", "Zowie S2-C Divina Series",
                "Logitech MX Vertical Ergonomic Mouse"
            };

            string price = strprice.Text;
            if (num >= 1 && num <= mouseNames.Length)
            {
                string mouseName = mouseNames[num - 1];
                mainApp.label_menu.Text = $"{mouseName} Specifications";

                mainApp.panelmain.Controls.Clear();
                productspecs productspecs = new productspecs(mouseName, 11, mainApp, price)
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None
                };
                mainApp.panelmain.Controls.Add(productspecs);
                productspecs.Show();
            }
        }

        public void speakersmenu(int num, Label strprice)
        {
            string[] speakerNames = {
                "Bose Companion 20", "Logitech G560 LIGHTSYNC", "Razer Nommo Chroma", "Creative Pebble Plus 2.0",
                "Edifier R1280T", "Audioengine A2+ Wireless", "Mackie CR3-XBT", "Kanto YU4", "Swan M10 Plus",
                "IK Multimedia iLoud Micro Monitor", "Micca RB42", "Edifier S350DB", "Audioengine A5+ Wireless",
                "PreSonus Eris E3.5", "JBL Studio 530", "Kali Audio LP-6", "Neumi BS5", "Monoprice DT-3BT",
                "Klipsch R-41M", "Audioengine HD3"
            };

            string price = strprice.Text;
            if (num >= 1 && num <= speakerNames.Length)
            {
                string speakerName = speakerNames[num - 1];
                mainApp.label_menu.Text = $"{speakerName} Specifications";

                mainApp.panelmain.Controls.Clear();
                productspecs productSpecs = new productspecs(speakerName, 12, mainApp, price)
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None
                };
                mainApp.panelmain.Controls.Add(productSpecs);
                productSpecs.Show();
            }
        }
        public void hddmenu(int num, Label strprice)
        {
            string[] hddNames = {
                "HGST Deskstar NAS 4TB", "HGST Ultrastar 12TB", "Hitachi Deskstar 500GB", "Hitachi Ultrastar 5TB",
                "Samsung Spinpoint 1TB", "Seagate Barracuda 3TB", "Seagate BarraCuda Pro 14TB", "Seagate Constellation 3TB",
                "Seagate FireCuda 8TB", "Seagate IronWolf 10TB", "Seagate SkyHawk 14TB", "Toshiba DT01ACA 1TB",
                "Toshiba N300 14TB", "Toshiba P300 3TB", "Toshiba X300 6TB", "WD VelociRaptor 1TB",
                "Western Digital Black 2.5TB", "Western Digital Blue 2TB", "Western Digital Gold 18TB", "Western Digital Red 8TB"
            };

            string price = strprice.Text;
            if (num >= 1 && num <= hddNames.Length)
            {
                string hddName = hddNames[num - 1];
                mainApp.label_menu.Text = $"{hddName} Specifications";

                mainApp.panelmain.Controls.Clear();
                productspecs productSpecs = new productspecs(hddName, 13, mainApp, price)
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None
                };
                mainApp.panelmain.Controls.Add(productSpecs);
                productSpecs.Show();
            }
        }

        public void ssdmenu(int num, Label strprice)
        {
            string[] ssdNames = {
                "Samsung 870 EVO 1TB", "Crucial MX500 2TB", "Western Digital Blue SSD 1TB", "SanDisk Ultra 3D SSD 2TB",
                "Kingston UV500 SSD 512GB", "Intel 545s SSD 512GB", "Seagate Barracuda SSD 2TB", "ADATA SU800 SSD 256GB",
                "Toshiba TR200 SSD 1TB", "PNY CS900 SSD 4TB", "Silicon Power Ace A55 SSD 512GB", "Transcend SSD230S SSD 2TB",
                "HP S700 SSD 1TB", "Team Group L5 3D SSD 1TB", "Patriot Burst SSD 2TB", "Gigabyte UD PRO SSD 1TB",
                "OWC Mercury Electra 6G SSD 2TB", "SK hynix Gold S31 SSD 1TB", "Mushkin Source SSD 500GB", "Kingston A400 2TB"
            };

            string price = strprice.Text;
            if (num >= 1 && num <= ssdNames.Length)
            {
                string ssdName = ssdNames[num - 1];
                mainApp.label_menu.Text = $"{ssdName} Specifications";

                mainApp.panelmain.Controls.Clear();
                productspecs productSpecs = new productspecs(ssdName, 14, mainApp, price)
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None
                };
                mainApp.panelmain.Controls.Add(productSpecs);
                productSpecs.Show();
            }
        }

    }
}
