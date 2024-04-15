namespace PC_Building_Simulator
{
    partial class keyboardmenu
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
            this.label_keyb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_keyb
            // 
            this.label_keyb.AutoSize = true;
            this.label_keyb.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_keyb.Location = new System.Drawing.Point(12, 9);
            this.label_keyb.Name = "label_keyb";
            this.label_keyb.Size = new System.Drawing.Size(170, 46);
            this.label_keyb.TabIndex = 10;
            this.label_keyb.Text = "Keyboard:";
            // 
            // keyboardmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(998, 699);
            this.Controls.Add(this.label_keyb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "keyboardmenu";
            this.Text = "keyboardmenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_keyb;
    }
}