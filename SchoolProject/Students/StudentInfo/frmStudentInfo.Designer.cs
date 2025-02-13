namespace SchoolProject.Students.StudentInfo
{
    partial class frmStudentInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.gunaBtnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.imgSlide1 = new System.Windows.Forms.PictureBox();
            this.gunaBtnGrade = new Guna.UI2.WinForms.Guna2Button();
            this.imgSlide4 = new System.Windows.Forms.PictureBox();
            this.imgSlide3 = new System.Windows.Forms.PictureBox();
            this.imgSlide2 = new System.Windows.Forms.PictureBox();
            this.gunaBtnMessage = new Guna.UI2.WinForms.Guna2Button();
            this.gunaBtnInfo = new Guna.UI2.WinForms.Guna2Button();
            this.gunaBtnSubject = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gunaBtnLogout);
            this.panel1.Controls.Add(this.imgSlide1);
            this.panel1.Controls.Add(this.gunaBtnGrade);
            this.panel1.Controls.Add(this.imgSlide4);
            this.panel1.Controls.Add(this.imgSlide3);
            this.panel1.Controls.Add(this.imgSlide2);
            this.panel1.Controls.Add(this.gunaBtnMessage);
            this.panel1.Controls.Add(this.gunaBtnInfo);
            this.panel1.Controls.Add(this.gunaBtnSubject);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 566);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(74, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "SIS";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(180, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.panel2.Size = new System.Drawing.Size(753, 566);
            this.panel2.TabIndex = 5;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // gunaBtnLogout
            // 
            this.gunaBtnLogout.BackColor = System.Drawing.Color.Transparent;
            this.gunaBtnLogout.BorderRadius = 10;
            this.gunaBtnLogout.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gunaBtnLogout.CheckedState.FillColor = System.Drawing.Color.White;
            this.gunaBtnLogout.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.gunaBtnLogout.CheckedState.Image = global::SchoolProject.Properties.Resources.icons8_info_50__2_;
            this.gunaBtnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gunaBtnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gunaBtnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.gunaBtnLogout.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaBtnLogout.ForeColor = System.Drawing.Color.White;
            this.gunaBtnLogout.Image = global::SchoolProject.Properties.Resources.icons8_logout_50;
            this.gunaBtnLogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunaBtnLogout.ImageOffset = new System.Drawing.Point(10, 0);
            this.gunaBtnLogout.Location = new System.Drawing.Point(25, 497);
            this.gunaBtnLogout.Name = "gunaBtnLogout";
            this.gunaBtnLogout.Size = new System.Drawing.Size(54, 43);
            this.gunaBtnLogout.TabIndex = 11;
            this.gunaBtnLogout.UseTransparentBackground = true;
            this.gunaBtnLogout.Click += new System.EventHandler(this.gunaBtnLogout_Click);
            // 
            // imgSlide1
            // 
            this.imgSlide1.Image = global::SchoolProject.Properties.Resources.MyOwnCreate7;
            this.imgSlide1.Location = new System.Drawing.Point(153, 86);
            this.imgSlide1.Name = "imgSlide1";
            this.imgSlide1.Size = new System.Drawing.Size(27, 65);
            this.imgSlide1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgSlide1.TabIndex = 10;
            this.imgSlide1.TabStop = false;
            this.imgSlide1.Visible = false;
            // 
            // gunaBtnGrade
            // 
            this.gunaBtnGrade.BackColor = System.Drawing.Color.Transparent;
            this.gunaBtnGrade.BorderRadius = 10;
            this.gunaBtnGrade.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gunaBtnGrade.Checked = true;
            this.gunaBtnGrade.CheckedState.FillColor = System.Drawing.Color.White;
            this.gunaBtnGrade.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.gunaBtnGrade.CheckedState.Image = global::SchoolProject.Properties.Resources.icons8_grades_50__1_;
            this.gunaBtnGrade.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnGrade.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnGrade.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gunaBtnGrade.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gunaBtnGrade.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.gunaBtnGrade.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.gunaBtnGrade.ForeColor = System.Drawing.Color.White;
            this.gunaBtnGrade.Image = global::SchoolProject.Properties.Resources.icons8_grades_50__2_;
            this.gunaBtnGrade.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunaBtnGrade.ImageOffset = new System.Drawing.Point(10, 0);
            this.gunaBtnGrade.Location = new System.Drawing.Point(14, 97);
            this.gunaBtnGrade.Name = "gunaBtnGrade";
            this.gunaBtnGrade.Size = new System.Drawing.Size(163, 43);
            this.gunaBtnGrade.TabIndex = 6;
            this.gunaBtnGrade.Text = "Grades";
            this.gunaBtnGrade.UseTransparentBackground = true;
            this.gunaBtnGrade.CheckedChanged += new System.EventHandler(this.gunaBtnGrade_CheckedChanged);
            this.gunaBtnGrade.Click += new System.EventHandler(this.gunaBtnGrade_Click);
            // 
            // imgSlide4
            // 
            this.imgSlide4.Image = global::SchoolProject.Properties.Resources.MyOwnCreate7;
            this.imgSlide4.Location = new System.Drawing.Point(153, 359);
            this.imgSlide4.Name = "imgSlide4";
            this.imgSlide4.Size = new System.Drawing.Size(27, 65);
            this.imgSlide4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgSlide4.TabIndex = 9;
            this.imgSlide4.TabStop = false;
            this.imgSlide4.Visible = false;
            // 
            // imgSlide3
            // 
            this.imgSlide3.Image = global::SchoolProject.Properties.Resources.MyOwnCreate7;
            this.imgSlide3.Location = new System.Drawing.Point(153, 257);
            this.imgSlide3.Name = "imgSlide3";
            this.imgSlide3.Size = new System.Drawing.Size(27, 65);
            this.imgSlide3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgSlide3.TabIndex = 8;
            this.imgSlide3.TabStop = false;
            this.imgSlide3.Visible = false;
            // 
            // imgSlide2
            // 
            this.imgSlide2.Image = global::SchoolProject.Properties.Resources.MyOwnCreate7;
            this.imgSlide2.Location = new System.Drawing.Point(153, 171);
            this.imgSlide2.Name = "imgSlide2";
            this.imgSlide2.Size = new System.Drawing.Size(27, 65);
            this.imgSlide2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgSlide2.TabIndex = 7;
            this.imgSlide2.TabStop = false;
            this.imgSlide2.Visible = false;
            // 
            // gunaBtnMessage
            // 
            this.gunaBtnMessage.BackColor = System.Drawing.Color.Transparent;
            this.gunaBtnMessage.BorderRadius = 10;
            this.gunaBtnMessage.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gunaBtnMessage.CheckedState.FillColor = System.Drawing.Color.White;
            this.gunaBtnMessage.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.gunaBtnMessage.CheckedState.Image = global::SchoolProject.Properties.Resources.icons8_message_50;
            this.gunaBtnMessage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnMessage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gunaBtnMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gunaBtnMessage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.gunaBtnMessage.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaBtnMessage.ForeColor = System.Drawing.Color.White;
            this.gunaBtnMessage.Image = global::SchoolProject.Properties.Resources.icons8_message_50__3_;
            this.gunaBtnMessage.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunaBtnMessage.ImageOffset = new System.Drawing.Point(10, 0);
            this.gunaBtnMessage.Location = new System.Drawing.Point(9, 370);
            this.gunaBtnMessage.Name = "gunaBtnMessage";
            this.gunaBtnMessage.Size = new System.Drawing.Size(163, 43);
            this.gunaBtnMessage.TabIndex = 6;
            this.gunaBtnMessage.Text = "Message";
            this.gunaBtnMessage.UseTransparentBackground = true;
            this.gunaBtnMessage.CheckedChanged += new System.EventHandler(this.gunaBtnGrade_CheckedChanged);
            this.gunaBtnMessage.Click += new System.EventHandler(this.gunaBtnMessage_Click);
            // 
            // gunaBtnInfo
            // 
            this.gunaBtnInfo.BackColor = System.Drawing.Color.Transparent;
            this.gunaBtnInfo.BorderRadius = 10;
            this.gunaBtnInfo.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gunaBtnInfo.CheckedState.FillColor = System.Drawing.Color.White;
            this.gunaBtnInfo.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.gunaBtnInfo.CheckedState.Image = global::SchoolProject.Properties.Resources.icons8_info_50__2_;
            this.gunaBtnInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gunaBtnInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gunaBtnInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.gunaBtnInfo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaBtnInfo.ForeColor = System.Drawing.Color.White;
            this.gunaBtnInfo.Image = global::SchoolProject.Properties.Resources.icons8_info_50__3_;
            this.gunaBtnInfo.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunaBtnInfo.ImageOffset = new System.Drawing.Point(10, 0);
            this.gunaBtnInfo.Location = new System.Drawing.Point(9, 268);
            this.gunaBtnInfo.Name = "gunaBtnInfo";
            this.gunaBtnInfo.Size = new System.Drawing.Size(163, 43);
            this.gunaBtnInfo.TabIndex = 5;
            this.gunaBtnInfo.Text = "Info";
            this.gunaBtnInfo.UseTransparentBackground = true;
            this.gunaBtnInfo.CheckedChanged += new System.EventHandler(this.gunaBtnGrade_CheckedChanged);
            this.gunaBtnInfo.Click += new System.EventHandler(this.gunaBtnInfo_Click);
            // 
            // gunaBtnSubject
            // 
            this.gunaBtnSubject.BackColor = System.Drawing.Color.Transparent;
            this.gunaBtnSubject.BorderRadius = 10;
            this.gunaBtnSubject.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gunaBtnSubject.CheckedState.FillColor = System.Drawing.Color.White;
            this.gunaBtnSubject.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.gunaBtnSubject.CheckedState.Image = global::SchoolProject.Properties.Resources.icons8_books_50__1_;
            this.gunaBtnSubject.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnSubject.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gunaBtnSubject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gunaBtnSubject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gunaBtnSubject.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.gunaBtnSubject.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaBtnSubject.ForeColor = System.Drawing.Color.White;
            this.gunaBtnSubject.Image = global::SchoolProject.Properties.Resources.icons8_books_50__3_;
            this.gunaBtnSubject.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunaBtnSubject.ImageOffset = new System.Drawing.Point(10, 0);
            this.gunaBtnSubject.Location = new System.Drawing.Point(9, 182);
            this.gunaBtnSubject.Name = "gunaBtnSubject";
            this.gunaBtnSubject.Size = new System.Drawing.Size(163, 43);
            this.gunaBtnSubject.TabIndex = 4;
            this.gunaBtnSubject.Text = "Subject";
            this.gunaBtnSubject.UseTransparentBackground = true;
            this.gunaBtnSubject.CheckedChanged += new System.EventHandler(this.gunaBtnGrade_CheckedChanged);
            this.gunaBtnSubject.Click += new System.EventHandler(this.gunaBtnSubject_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SchoolProject.Properties.Resources.icons8_books_48__1_;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmStudentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(933, 566);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStudentInfo";
            this.Text = "frmStudentInfo";
            this.Load += new System.EventHandler(this.frmStudentInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button gunaBtnMessage;
        private Guna.UI2.WinForms.Guna2Button gunaBtnInfo;
        private Guna.UI2.WinForms.Guna2Button gunaBtnSubject;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox imgSlide2;
        private System.Windows.Forms.PictureBox imgSlide4;
        private System.Windows.Forms.PictureBox imgSlide3;
        private Guna.UI2.WinForms.Guna2Button gunaBtnGrade;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.PictureBox imgSlide1;
        private Guna.UI2.WinForms.Guna2Button gunaBtnLogout;
    }
}