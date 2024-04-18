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

namespace PC_Building_Simulator
{
    public partial class buildmenu : Form
    {
        private string user = "";
        public buildmenu()
        {
            InitializeComponent();
            InitializeDisplayManager();
        }

        private void buildmenu_Load(object sender, EventArgs e)
        {
            string cpu = "";
            string gpu = "";
            string mb = "";
            string ram = "";
            string psu = "";
            string ccase = "";
            string moni = "";
            string keyb = "";
            string mouse = "";
            string spk = "";
            string hdd = "";
            string ssd = "";
            string m2 = "";
            string ramquan = "";
            string cpuprice = "";
            string gpuprice = "";
            string mbprice = "";
            string ramprice = "";
            string psuprice = "";
            string caseprice = "";
            string moniprice = "";
            string keybprice = "";
            string mouseprice = "";
            string spkprice = "";
            string hddprice = "";
            string ssdprice = "";
            string m2price = "";

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
                "Mouse, [Mouse price], Speakers, [Speakers price], HDD, [HDD price], SSD, [SSD price], [M2 SSDs], [M2 price] FROM Builds WHERE [user] = @Username";
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
                            m2 = reader["M2 SSDs"].ToString();
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
                    }
                }
            }
            label1.Text = cpu;
            label2.Text = gpu;
            label3.Text = mb;
            label4.Text = ram;
            label5.Text = hdd;
            label6.Text = psu;
            label7.Text = ccase;
            label9.Text = moni;
            label10.Text = keyb;
            label11.Text = mouse;
            label12.Text = spk;
            quan_ram.Text = ramquan;
            price_cpu.Text = cpuprice;
            price_gpu.Text = gpuprice;
            price_mb.Text = mbprice;
            price_ram.Text = ramprice;
            price_drive1.Text = hddprice;
            price_psu.Text = psuprice;
            price_case.Text = caseprice;
            price_moni.Text = moniprice;
            price_keyb.Text = keybprice;
            price_mou.Text = mouseprice;
            price_spk.Text = spkprice;

            // Displaying images for components
            string cpuimage = cpu.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
            string resourcecpu = $"cpu_{cpuimage}";
            pBox1.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcecpu);
            if (cpu != "")
            {
                pBox1.Visible = true;
                border1.Visible = true;
                price_cpu.Visible = true;
                quan_cpu.Visible = true;
                remove_cpu.Visible = true;
            }

            string gpuimage = gpu.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
            string resourcegpu = $"{gpuimage}";
            pBox2.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcegpu);
            if (gpu != "")
            {
                pBox2.Visible = true;
                border2.Visible = true;
                price_gpu.Visible = true;
                quan_gpu.Visible = true;
                remove_gpu.Visible = true;
            }

            string mbimage = mb.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
            string resourcemb = $"mb_{mbimage}";
            pBox3.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcemb);
            if (mb != "")
            {
                pBox3.Visible = true;
                border3.Visible = true;
                price_mb.Visible = true;
                quan_mb.Visible = true;
                remove_mb.Visible = true;
            }

            string ramimage = ram.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
            string resourceram = $"ram_{ramimage}";
            pBox4.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourceram);
            if (ram != "")
            {
                pBox4.Visible = true;
                border4.Visible = true;
                price_ram.Visible = true;
                quan_ram.Visible = true;
                remove_ram.Visible = true;
            }

            //panel5.Size = new Size(1017, 110);
            string hddimage = hdd.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
            string resourcehdd = $"hdd_{hddimage}";
            pBox5.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcehdd);
            if (hdd != "")
            {
                pBox5.Visible = true;
                border5.Visible = true;
                price_drive1.Visible = true;
                quan_drive1.Visible = true;
            }

            string psuimage = psu.Replace(' ', '_').Replace('-', '_').Replace('!', '_');
            string resourcepsu = $"psu_{psuimage}";
            pBox6.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourcepsu);
            if (psu != "")
            {
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
                pBox12.Visible = true;
                border12.Visible = true;
                price_spk.Visible = true;
                quan_spk.Visible = true;
                remove_spk.Visible = true;
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
