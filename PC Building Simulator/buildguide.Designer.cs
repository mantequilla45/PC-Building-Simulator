namespace PC_Building_Simulator
{
    partial class buildguide
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(buildguide));
            this.panel2 = new System.Windows.Forms.Panel();
            this.chooseram = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.choosemb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.choosecpu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labname1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chooseram);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.choosemb);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.choosecpu);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labname1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.kryptonButton1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 675);
            this.panel2.TabIndex = 88;
            // 
            // chooseram
            // 
            this.chooseram.AutoSize = true;
            this.chooseram.BackColor = System.Drawing.Color.White;
            this.chooseram.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(135)))), ((int)(((byte)(195)))));
            this.chooseram.Location = new System.Drawing.Point(30, 565);
            this.chooseram.MaximumSize = new System.Drawing.Size(700, 0);
            this.chooseram.Name = "chooseram";
            this.chooseram.Size = new System.Drawing.Size(169, 21);
            this.chooseram.TabIndex = 95;
            this.chooseram.Text = "Choose a RAM Module";
            this.chooseram.Click += new System.EventHandler(this.chooseram_Click);
            this.chooseram.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            this.chooseram.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 488);
            this.label4.MaximumSize = new System.Drawing.Size(700, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(698, 63);
            this.label4.TabIndex = 93;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // choosemb
            // 
            this.choosemb.AutoSize = true;
            this.choosemb.BackColor = System.Drawing.Color.White;
            this.choosemb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choosemb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(135)))), ((int)(((byte)(195)))));
            this.choosemb.Location = new System.Drawing.Point(30, 435);
            this.choosemb.MaximumSize = new System.Drawing.Size(700, 0);
            this.choosemb.Name = "choosemb";
            this.choosemb.Size = new System.Drawing.Size(170, 21);
            this.choosemb.TabIndex = 92;
            this.choosemb.Text = "Choose a Motherboard";
            this.choosemb.Click += new System.EventHandler(this.choosemb_Click);
            this.choosemb.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            this.choosemb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 341);
            this.label2.MaximumSize = new System.Drawing.Size(700, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(696, 84);
            this.label2.TabIndex = 91;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // choosecpu
            // 
            this.choosecpu.AutoSize = true;
            this.choosecpu.BackColor = System.Drawing.Color.White;
            this.choosecpu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choosecpu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(135)))), ((int)(((byte)(195)))));
            this.choosecpu.Location = new System.Drawing.Point(30, 290);
            this.choosecpu.MaximumSize = new System.Drawing.Size(700, 0);
            this.choosecpu.Name = "choosecpu";
            this.choosecpu.Size = new System.Drawing.Size(108, 21);
            this.choosecpu.TabIndex = 90;
            this.choosecpu.Text = "Choose a CPU";
            this.choosecpu.Click += new System.EventHandler(this.choosecpu_Click);
            this.choosecpu.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            this.choosecpu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 194);
            this.label1.MaximumSize = new System.Drawing.Size(700, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(670, 84);
            this.label1.TabIndex = 88;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // labname1
            // 
            this.labname1.AutoSize = true;
            this.labname1.BackColor = System.Drawing.Color.White;
            this.labname1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labname1.Location = new System.Drawing.Point(30, 89);
            this.labname1.MaximumSize = new System.Drawing.Size(700, 0);
            this.labname1.Name = "labname1";
            this.labname1.Size = new System.Drawing.Size(685, 84);
            this.labname1.TabIndex = 87;
            this.labname1.Text = resources.GetString("labname1.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 30);
            this.label3.TabIndex = 86;
            this.label3.Text = "Let\'s get started with a guide!";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Enabled = false;
            this.kryptonButton1.Location = new System.Drawing.Point(3, 3);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(781, 669);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 10;
            this.kryptonButton1.TabIndex = 86;
            this.kryptonButton1.Values.Text = "";
            // 
            // buildguide
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1063, 699);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "buildguide";
            this.Text = "buildguide";
            this.Load += new System.EventHandler(this.buildguide_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private System.Windows.Forms.Label labname1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label choosecpu;
        private System.Windows.Forms.Label choosemb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label chooseram;
        private System.Windows.Forms.Label label4;
    }
}