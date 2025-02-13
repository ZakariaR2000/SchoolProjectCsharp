namespace SchoolProject.Classes
{
    partial class frmClassInfo
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
            this.btnSubjects = new System.Windows.Forms.Button();
            this.btnTeachers = new System.Windows.Forms.Button();
            this.btnStudnets = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSubjects
            // 
            this.btnSubjects.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnSubjects.Location = new System.Drawing.Point(89, 332);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Size = new System.Drawing.Size(136, 81);
            this.btnSubjects.TabIndex = 9;
            this.btnSubjects.Text = "Subjects";
            this.btnSubjects.UseVisualStyleBackColor = true;
            this.btnSubjects.Click += new System.EventHandler(this.btnSubjects_Click);
            // 
            // btnTeachers
            // 
            this.btnTeachers.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnTeachers.Location = new System.Drawing.Point(455, 332);
            this.btnTeachers.Name = "btnTeachers";
            this.btnTeachers.Size = new System.Drawing.Size(136, 81);
            this.btnTeachers.TabIndex = 8;
            this.btnTeachers.Text = "Teachers";
            this.btnTeachers.UseVisualStyleBackColor = true;
            this.btnTeachers.Click += new System.EventHandler(this.btnTeachers_Click);
            // 
            // btnStudnets
            // 
            this.btnStudnets.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnStudnets.Location = new System.Drawing.Point(261, 332);
            this.btnStudnets.Name = "btnStudnets";
            this.btnStudnets.Size = new System.Drawing.Size(136, 81);
            this.btnStudnets.TabIndex = 7;
            this.btnStudnets.Text = "Studnets";
            this.btnStudnets.UseVisualStyleBackColor = true;
            this.btnStudnets.Click += new System.EventHandler(this.btnStudnets_Click);
            // 
            // frmClassInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 495);
            this.Controls.Add(this.btnSubjects);
            this.Controls.Add(this.btnTeachers);
            this.Controls.Add(this.btnStudnets);
            this.Name = "frmClassInfo";
            this.Text = "frmClassInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSubjects;
        private System.Windows.Forms.Button btnTeachers;
        private System.Windows.Forms.Button btnStudnets;
    }
}