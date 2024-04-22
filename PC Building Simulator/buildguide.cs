using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Building_Simulator
{
    public partial class buildguide : Form
    {
        private MainApp mainApp;

        public buildguide(MainApp mainApp)
        {
            InitializeComponent();
            this.mainApp = mainApp;

            if (mainApp.label_menu.Text == "Guide")
            {
                mainApp.but_guide.StateCommon.Back.Color1 = Color.DimGray;
                mainApp.but_guide.StateCommon.Back.Color2 = Color.DimGray;
                mainApp.but_guide.StateCommon.Content.ShortText.Color1 = Color.White;
                mainApp.but_guide.StateTracking.Back.Color1 = Color.DimGray;
                mainApp.but_guide.StateTracking.Back.Color2 = Color.DimGray;
                mainApp.but_guide.StateTracking.Content.ShortText.Color1 = Color.White;
            }

        }

        private void buildguide_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            // Simulate a button click event by passing appropriate arguments for sender and EventArgs
            object simulatedSender = kryptonButton1; // Replace `yourButton` with the actual button instance
            EventArgs simulatedEventArgs = EventArgs.Empty;

            // Call the method
            mainApp.but_cpu_Click(simulatedSender, simulatedEventArgs);
        }

    }
}
