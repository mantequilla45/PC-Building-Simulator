namespace PC_Building_Simulator
{
    partial class storagemenu
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
            this.label_storage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_storage
            // 
            this.label_storage.AutoSize = true;
            this.label_storage.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_storage.Location = new System.Drawing.Point(12, 9);
            this.label_storage.Name = "label_storage";
            this.label_storage.Size = new System.Drawing.Size(119, 46);
            this.label_storage.TabIndex = 5;
            this.label_storage.Text = "Drives:";
            // 
            // storagemenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(998, 699);
            this.Controls.Add(this.label_storage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "storagemenu";
            this.Text = "storagemenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_storage;
    }
}