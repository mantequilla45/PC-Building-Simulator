namespace PC_Building_Simulator
{
    partial class loginform
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginform));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbox_uname = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtbox_pass = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.but_login1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.but_signup1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ckbx_showpass = new System.Windows.Forms.CheckBox();
            this.label_loger = new System.Windows.Forms.Label();
            this.label_empu = new System.Windows.Forms.Label();
            this.label_empp = new System.Windows.Forms.Label();
            this.kryptonPalette = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(141, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sign in";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(31, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(31, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // txtbox_uname
            // 
            this.txtbox_uname.Location = new System.Drawing.Point(36, 146);
            this.txtbox_uname.Name = "txtbox_uname";
            this.txtbox_uname.Size = new System.Drawing.Size(274, 34);
            this.txtbox_uname.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtbox_uname.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtbox_uname.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtbox_uname.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtbox_uname.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtbox_uname.StateCommon.Border.Rounding = 20;
            this.txtbox_uname.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            this.txtbox_uname.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_uname.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtbox_uname.TabIndex = 1;
            this.txtbox_uname.Text = "admin";
            this.txtbox_uname.TextChanged += new System.EventHandler(this.txtbox_uname_TextChanged);
            // 
            // txtbox_pass
            // 
            this.txtbox_pass.Location = new System.Drawing.Point(36, 237);
            this.txtbox_pass.Name = "txtbox_pass";
            this.txtbox_pass.PasswordChar = '•';
            this.txtbox_pass.Size = new System.Drawing.Size(274, 34);
            this.txtbox_pass.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtbox_pass.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtbox_pass.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtbox_pass.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtbox_pass.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtbox_pass.StateCommon.Border.Rounding = 20;
            this.txtbox_pass.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            this.txtbox_pass.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_pass.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtbox_pass.TabIndex = 2;
            this.txtbox_pass.Text = "123";
            this.txtbox_pass.TextChanged += new System.EventHandler(this.txtbox_pass_TextChanged);
            // 
            // but_login1
            // 
            this.but_login1.Location = new System.Drawing.Point(36, 328);
            this.but_login1.Name = "but_login1";
            this.but_login1.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.but_login1.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.but_login1.OverrideDefault.Back.ColorAngle = 45F;
            this.but_login1.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.but_login1.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.but_login1.OverrideDefault.Border.ColorAngle = 45F;
            this.but_login1.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.but_login1.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.but_login1.OverrideDefault.Border.Rounding = 18;
            this.but_login1.OverrideDefault.Border.Width = 1;
            this.but_login1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.but_login1.Size = new System.Drawing.Size(274, 44);
            this.but_login1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.but_login1.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.but_login1.StateCommon.Back.ColorAngle = 45F;
            this.but_login1.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.but_login1.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.but_login1.StateCommon.Border.ColorAngle = 45F;
            this.but_login1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.but_login1.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.but_login1.StateCommon.Border.Rounding = 18;
            this.but_login1.StateCommon.Border.Width = 1;
            this.but_login1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.but_login1.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.but_login1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_login1.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(146)))), ((int)(((byte)(197)))));
            this.but_login1.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(122)))), ((int)(((byte)(206)))));
            this.but_login1.StatePressed.Back.ColorAngle = 130F;
            this.but_login1.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(146)))), ((int)(((byte)(197)))));
            this.but_login1.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(122)))), ((int)(((byte)(206)))));
            this.but_login1.StatePressed.Border.ColorAngle = 130F;
            this.but_login1.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.but_login1.StatePressed.Border.Rounding = 18;
            this.but_login1.StatePressed.Border.Width = 1;
            this.but_login1.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.but_login1.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.but_login1.StateTracking.Back.ColorAngle = 45F;
            this.but_login1.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.but_login1.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(142)))), ((int)(((byte)(244)))));
            this.but_login1.StateTracking.Border.ColorAngle = 45F;
            this.but_login1.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.but_login1.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.but_login1.StateTracking.Border.Rounding = 18;
            this.but_login1.StateTracking.Border.Width = 1;
            this.but_login1.TabIndex = 4;
            this.but_login1.Values.Text = "Login";
            this.but_login1.Click += new System.EventHandler(this.but_login1_Click);
            // 
            // but_signup1
            // 
            this.but_signup1.Location = new System.Drawing.Point(36, 378);
            this.but_signup1.Name = "but_signup1";
            this.but_signup1.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.but_signup1.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.but_signup1.OverrideDefault.Back.ColorAngle = 45F;
            this.but_signup1.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.but_signup1.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.but_signup1.OverrideDefault.Border.ColorAngle = 45F;
            this.but_signup1.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.but_signup1.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.but_signup1.OverrideDefault.Border.Rounding = 18;
            this.but_signup1.OverrideDefault.Border.Width = 1;
            this.but_signup1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.but_signup1.Size = new System.Drawing.Size(274, 44);
            this.but_signup1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.but_signup1.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.but_signup1.StateCommon.Back.ColorAngle = 45F;
            this.but_signup1.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.but_signup1.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.but_signup1.StateCommon.Border.ColorAngle = 45F;
            this.but_signup1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.but_signup1.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.but_signup1.StateCommon.Border.Rounding = 18;
            this.but_signup1.StateCommon.Border.Width = 1;
            this.but_signup1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.but_signup1.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.but_signup1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_signup1.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(146)))), ((int)(((byte)(197)))));
            this.but_signup1.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(122)))), ((int)(((byte)(206)))));
            this.but_signup1.StatePressed.Back.ColorAngle = 130F;
            this.but_signup1.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(146)))), ((int)(((byte)(197)))));
            this.but_signup1.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(122)))), ((int)(((byte)(206)))));
            this.but_signup1.StatePressed.Border.ColorAngle = 130F;
            this.but_signup1.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.but_signup1.StatePressed.Border.Rounding = 18;
            this.but_signup1.StatePressed.Border.Width = 1;
            this.but_signup1.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.but_signup1.StateTracking.Back.Color1 = System.Drawing.Color.AliceBlue;
            this.but_signup1.StateTracking.Back.Color2 = System.Drawing.Color.LightCyan;
            this.but_signup1.StateTracking.Back.ColorAngle = 45F;
            this.but_signup1.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.but_signup1.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(142)))), ((int)(((byte)(244)))));
            this.but_signup1.StateTracking.Border.ColorAngle = 45F;
            this.but_signup1.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.but_signup1.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.but_signup1.StateTracking.Border.Rounding = 18;
            this.but_signup1.StateTracking.Border.Width = 1;
            this.but_signup1.TabIndex = 5;
            this.but_signup1.Values.Text = "Signup";
            this.but_signup1.Click += new System.EventHandler(this.signupbut1_Click);
            // 
            // ckbx_showpass
            // 
            this.ckbx_showpass.AutoSize = true;
            this.ckbx_showpass.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbx_showpass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ckbx_showpass.Location = new System.Drawing.Point(188, 277);
            this.ckbx_showpass.Name = "ckbx_showpass";
            this.ckbx_showpass.Size = new System.Drawing.Size(122, 21);
            this.ckbx_showpass.TabIndex = 3;
            this.ckbx_showpass.Text = "Show Password";
            this.ckbx_showpass.UseVisualStyleBackColor = true;
            this.ckbx_showpass.CheckedChanged += new System.EventHandler(this.ckbx_showpass_CheckedChanged);
            // 
            // label_loger
            // 
            this.label_loger.AutoSize = true;
            this.label_loger.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_loger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_loger.Location = new System.Drawing.Point(33, 183);
            this.label_loger.Name = "label_loger";
            this.label_loger.Size = new System.Drawing.Size(195, 26);
            this.label_loger.TabIndex = 20;
            this.label_loger.Text = "The username or password you entered \r\nisn’t connected to an account. ";
            this.label_loger.Visible = false;
            // 
            // label_empu
            // 
            this.label_empu.AutoSize = true;
            this.label_empu.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_empu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_empu.Location = new System.Drawing.Point(33, 183);
            this.label_empu.Name = "label_empu";
            this.label_empu.Size = new System.Drawing.Size(76, 13);
            this.label_empu.TabIndex = 21;
            this.label_empu.Text = "Can\'t be empty";
            this.label_empu.Visible = false;
            // 
            // label_empp
            // 
            this.label_empp.AutoSize = true;
            this.label_empp.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_empp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_empp.Location = new System.Drawing.Point(33, 277);
            this.label_empp.Name = "label_empp";
            this.label_empp.Size = new System.Drawing.Size(76, 13);
            this.label_empp.TabIndex = 22;
            this.label_empp.Text = "Can\'t be empty";
            this.label_empp.Visible = false;
            // 
            // kryptonPalette
            // 
            this.kryptonPalette.ButtonSpecs.FormClose.Image = ((System.Drawing.Image)(resources.GetObject("kryptonPalette.ButtonSpecs.FormClose.Image")));
            this.kryptonPalette.ButtonSpecs.FormMax.Image = ((System.Drawing.Image)(resources.GetObject("kryptonPalette.ButtonSpecs.FormMax.Image")));
            this.kryptonPalette.ButtonSpecs.FormMin.Image = ((System.Drawing.Image)(resources.GetObject("kryptonPalette.ButtonSpecs.FormMin.Image")));
            this.kryptonPalette.ButtonSpecs.FormRestore.Image = ((System.Drawing.Image)(resources.GetObject("kryptonPalette.ButtonSpecs.FormRestore.Image")));
            this.kryptonPalette.ButtonStyles.ButtonForm.StatePressed.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.kryptonPalette.ButtonStyles.ButtonForm.StatePressed.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.kryptonPalette.ButtonStyles.ButtonForm.StatePressed.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonPalette.ButtonStyles.ButtonForm.StatePressed.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonPalette.ButtonStyles.ButtonForm.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette.ButtonStyles.ButtonForm.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kryptonPalette.ButtonStyles.ButtonForm.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kryptonPalette.ButtonStyles.ButtonForm.StateTracking.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonPalette.ButtonStyles.ButtonForm.StateTracking.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonPalette.ButtonStyles.ButtonForm.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette.ButtonStyles.ButtonFormClose.StatePressed.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.kryptonPalette.ButtonStyles.ButtonFormClose.StatePressed.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.kryptonPalette.ButtonStyles.ButtonFormClose.StatePressed.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonPalette.ButtonStyles.ButtonFormClose.StatePressed.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonPalette.ButtonStyles.ButtonFormClose.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette.ButtonStyles.ButtonFormClose.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kryptonPalette.ButtonStyles.ButtonFormClose.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kryptonPalette.ButtonStyles.ButtonFormClose.StateTracking.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonPalette.ButtonStyles.ButtonFormClose.StateTracking.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonPalette.ButtonStyles.ButtonFormClose.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonPalette.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonPalette.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.WhiteSmoke;
            this.kryptonPalette.FormStyles.FormMain.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.kryptonPalette.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette.FormStyles.FormMain.StateCommon.Border.Rounding = 12;
            this.kryptonPalette.HeaderStyles.HeaderCommon.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonPalette.HeaderStyles.HeaderCommon.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonPalette.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonPalette.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.kryptonPalette.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 12;
            this.kryptonPalette.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            // 
            // loginform
            // 
            this.AcceptButton = this.but_login1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(345, 481);
            this.Controls.Add(this.label_empp);
            this.Controls.Add(this.label_empu);
            this.Controls.Add(this.label_loger);
            this.Controls.Add(this.ckbx_showpass);
            this.Controls.Add(this.but_signup1);
            this.Controls.Add(this.but_login1);
            this.Controls.Add(this.txtbox_pass);
            this.Controls.Add(this.txtbox_uname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(361, 520);
            this.Name = "loginform";
            this.Palette = this.kryptonPalette;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PC BuildIt";
            this.Load += new System.EventHandler(this.loginform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton but_login1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton but_signup1;
        private System.Windows.Forms.CheckBox ckbx_showpass;
        private System.Windows.Forms.Label label_loger;
        private System.Windows.Forms.Label label_empu;
        private System.Windows.Forms.Label label_empp;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbox_pass;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbox_uname;
    }
}

