namespace SchoolProject
{
    partial class frmMainInterface
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gunaBtnAdmin = new Guna.UI2.WinForms.Guna2Button();
            this.gunaBtnTeacher = new Guna.UI2.WinForms.Guna2Button();
            this.gunaBtnStudent = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.imgSlide1 = new System.Windows.Forms.PictureBox();
            this.imgSlide2 = new System.Windows.Forms.PictureBox();
            this.imgSlide3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(56)))));
            this.panel1.Controls.Add(this.imgSlide3);
            this.panel1.Controls.Add(this.imgSlide2);
            this.panel1.Controls.Add(this.imgSlide1);
            this.panel1.Controls.Add(this.gunaBtnAdmin);
            this.panel1.Controls.Add(this.gunaBtnTeacher);
            this.panel1.Controls.Add(this.gunaBtnStudent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 664);
            this.panel1.TabIndex = 6;
            // 
            // gunaBtnAdmin
            // 
            this.gunaBtnAdmin.BackColor = System.Drawing.Color.Transparent;
            this.gunaBtnAdmin.BorderRadius = 10;
            this.gunaBtnAdmin.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gunaBtnAdmin.CheckedState.FillColor = System.Drawing.Color.White;
            this.gunaBtnAdmin.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(128)))), ((int)(((byte)(7)))));
            this.gunaBtnAdmin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnAdmin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnAdmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gunaBtnAdmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gunaBtnAdmin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(60)))), ((int)(((byte)(51)))));
            this.gunaBtnAdmin.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaBtnAdmin.ForeColor = System.Drawing.Color.White;
            this.gunaBtnAdmin.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunaBtnAdmin.ImageOffset = new System.Drawing.Point(10, 0);
            this.gunaBtnAdmin.Location = new System.Drawing.Point(31, 384);
            this.gunaBtnAdmin.Name = "gunaBtnAdmin";
            this.gunaBtnAdmin.Size = new System.Drawing.Size(163, 43);
            this.gunaBtnAdmin.TabIndex = 5;
            this.gunaBtnAdmin.Text = "Administrator";
            this.gunaBtnAdmin.UseTransparentBackground = true;
            this.gunaBtnAdmin.CheckedChanged += new System.EventHandler(this.gunaBtnStudent_CheckedChanged);
            // 
            // gunaBtnTeacher
            // 
            this.gunaBtnTeacher.BackColor = System.Drawing.Color.Transparent;
            this.gunaBtnTeacher.BorderRadius = 10;
            this.gunaBtnTeacher.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gunaBtnTeacher.CheckedState.FillColor = System.Drawing.Color.White;
            this.gunaBtnTeacher.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(128)))), ((int)(((byte)(7)))));
            this.gunaBtnTeacher.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnTeacher.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnTeacher.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gunaBtnTeacher.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gunaBtnTeacher.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(60)))), ((int)(((byte)(51)))));
            this.gunaBtnTeacher.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaBtnTeacher.ForeColor = System.Drawing.Color.White;
            this.gunaBtnTeacher.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunaBtnTeacher.ImageOffset = new System.Drawing.Point(10, 0);
            this.gunaBtnTeacher.Location = new System.Drawing.Point(41, 222);
            this.gunaBtnTeacher.Name = "gunaBtnTeacher";
            this.gunaBtnTeacher.Size = new System.Drawing.Size(163, 43);
            this.gunaBtnTeacher.TabIndex = 4;
            this.gunaBtnTeacher.Text = "Teachers";
            this.gunaBtnTeacher.UseTransparentBackground = true;
            this.gunaBtnTeacher.CheckedChanged += new System.EventHandler(this.gunaBtnStudent_CheckedChanged);
            this.gunaBtnTeacher.Click += new System.EventHandler(this.gunaBtnTeacher_Click);
            // 
            // gunaBtnStudent
            // 
            this.gunaBtnStudent.BackColor = System.Drawing.Color.Transparent;
            this.gunaBtnStudent.BorderRadius = 10;
            this.gunaBtnStudent.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gunaBtnStudent.Checked = true;
            this.gunaBtnStudent.CheckedState.FillColor = System.Drawing.Color.White;
            this.gunaBtnStudent.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(128)))), ((int)(((byte)(7)))));
            this.gunaBtnStudent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnStudent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnStudent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gunaBtnStudent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gunaBtnStudent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(60)))), ((int)(((byte)(51)))));
            this.gunaBtnStudent.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.gunaBtnStudent.ForeColor = System.Drawing.Color.White;
            this.gunaBtnStudent.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunaBtnStudent.ImageOffset = new System.Drawing.Point(10, 0);
            this.gunaBtnStudent.Location = new System.Drawing.Point(41, 74);
            this.gunaBtnStudent.Name = "gunaBtnStudent";
            this.gunaBtnStudent.Size = new System.Drawing.Size(163, 43);
            this.gunaBtnStudent.TabIndex = 6;
            this.gunaBtnStudent.Text = "Students";
            this.gunaBtnStudent.UseTransparentBackground = true;
            this.gunaBtnStudent.CheckedChanged += new System.EventHandler(this.gunaBtnStudent_CheckedChanged);
            this.gunaBtnStudent.Click += new System.EventHandler(this.gunaBtnStudent_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(215, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.panel2.Size = new System.Drawing.Size(665, 664);
            this.panel2.TabIndex = 7;
            // 
            // imgSlide1
            // 
            this.imgSlide1.Image = global::SchoolProject.Properties.Resources.MyOwnCreate81;
            this.imgSlide1.Location = new System.Drawing.Point(186, 63);
            this.imgSlide1.Name = "imgSlide1";
            this.imgSlide1.Size = new System.Drawing.Size(31, 65);
            this.imgSlide1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgSlide1.TabIndex = 7;
            this.imgSlide1.TabStop = false;
            // 
            // imgSlide2
            // 
            this.imgSlide2.Image = global::SchoolProject.Properties.Resources.MyOwnCreate81;
            this.imgSlide2.Location = new System.Drawing.Point(186, 211);
            this.imgSlide2.Name = "imgSlide2";
            this.imgSlide2.Size = new System.Drawing.Size(31, 65);
            this.imgSlide2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgSlide2.TabIndex = 8;
            this.imgSlide2.TabStop = false;
            // 
            // imgSlide3
            // 
            this.imgSlide3.Image = global::SchoolProject.Properties.Resources.MyOwnCreate81;
            this.imgSlide3.Location = new System.Drawing.Point(185, 373);
            this.imgSlide3.Name = "imgSlide3";
            this.imgSlide3.Size = new System.Drawing.Size(31, 65);
            this.imgSlide3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgSlide3.TabIndex = 9;
            this.imgSlide3.TabStop = false;
            // 
            // frmMainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 664);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMainInterface";
            this.Text = "frmMainInterface";
            this.Load += new System.EventHandler(this.frmMainInterface_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button gunaBtnAdmin;
        private Guna.UI2.WinForms.Guna2Button gunaBtnTeacher;
        private Guna.UI2.WinForms.Guna2Button gunaBtnStudent;
        private System.Windows.Forms.PictureBox imgSlide1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox imgSlide3;
        private System.Windows.Forms.PictureBox imgSlide2;
    }
}