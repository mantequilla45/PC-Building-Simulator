﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Building_Simulator
{
    public partial class buildmenu : Form
    {
        public buildmenu()
        {
            InitializeComponent();
        }

        private void buildmenu_Load(object sender, EventArgs e)
        {

            string cpu = "";
            string gpu = "";
            string mb = "";
            string ram = "";
            string psu = "";
            string user = "";
            string ccase = "";
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=buildit_database.mdb";

            // Get the current user
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
            string query = "SELECT CPU, GPU, Motherboard, RAM, PSU, [Computer Case] FROM Builds WHERE [user] = @Username";
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
                            gpu = reader["GPU"].ToString();
                            mb = reader["Motherboard"].ToString();
                            ram = reader["RAM"].ToString();
                            psu = reader["PSU"].ToString();
                            ccase = reader["Computer Case"].ToString();
                        }
                    }
                }
            }
            label1.Text = cpu;
            label2.Text = gpu;
            label3.Text = mb;
            label4.Text = ram;
            label5.Text = psu;
            label6.Text = ccase;

            InitializeDisplayManager();
            
            string cpuimage = cpu.Replace(' ', '_');
            string cpuimage1 = cpuimage.Replace('-', '_');
            string resourcecpu = $"cpu_{cpuimage1}";
            pBox1.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcecpu);
            if(cpu != "")
            {
                pBox1.Visible = true;
                border1.Visible = true;
            }

            string gpuimage = gpu.Replace(' ', '_');
            string gpuimage1 = gpuimage.Replace('-', '_');
            string resourcegpu = $"{gpuimage1}";
            pBox2.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcegpu);
            if (gpu != "")
            {
                pBox2.Visible = true;
                border2.Visible = true;
            }

            string mbimage = mb.Replace(' ', '_');
            string mbimage1 = mbimage.Replace('-', '_');
            string resourcemb = $"mb_{mbimage1}";
            pBox3.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcemb);
            if (mb != "")
            {
                pBox3.Visible = true;
                border3.Visible = true;
            }

            string ramimage = ram.Replace(' ', '_');
            string ramimage1 = ramimage.Replace('-', '_');
            string resourceram = $"ram_{ramimage1}";
            pBox4.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourceram);
            if (ram != "")
            {
                pBox4.Visible = true;
                border4.Visible = true;
            }

            string psuimage = psu.Replace(' ', '_');
            string psuimage1 = psuimage.Replace('-', '_');
            string resourcepsu = $"psu_{psuimage1}";
            pBox6.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcepsu);
            if (psu != "")
            {
                pBox6.Visible = true;
                border6.Visible = true;
            }


            string caseimage = ccase.Replace(' ', '_');
            string caseimage1 = caseimage.Replace('-', '_');
            string resourcecase = $"case_{caseimage1}";
            pBox7.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcecase);
            if (ccase != "")
            {
                pBox7.Visible = true;
                border7.Visible = true;
            }


            

        }
        private void InitializeDisplayManager()
        {
            buildmenu buildMenuForm = this; 
            DisplayManager displayManager = new DisplayManager(buildMenuForm);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.FromArgb(44, 135, 195);
            label.Font = new Font(label.Font, FontStyle.Underline);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = SystemColors.ControlText;
            label.Font = new Font(label.Font, FontStyle.Regular);
        }
        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.FromArgb(44, 135, 195);
            label.Font = new Font(label.Font, FontStyle.Underline);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = SystemColors.ControlText;
            label.Font = new Font(label.Font, FontStyle.Regular);
        }
        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.FromArgb(44, 135, 195);
            label.Font = new Font(label.Font, FontStyle.Underline);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = SystemColors.ControlText;
            label.Font = new Font(label.Font, FontStyle.Regular);
        }
        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.FromArgb(44, 135, 195);
            label.Font = new Font(label.Font, FontStyle.Underline);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = SystemColors.ControlText;
            label.Font = new Font(label.Font, FontStyle.Regular);
        }


    }
}
