namespace SchoolProject.Classes
{
    partial class frmAllClasses
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
            this.btnClass1 = new System.Windows.Forms.Button();
            this.btnClass3 = new System.Windows.Forms.Button();
            this.btnClass2 = new System.Windows.Forms.Button();
            this.btnClass4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClass1
            // 
            this.btnClass1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnClass1.Location = new System.Drawing.Point(161, 145);
            this.btnClass1.Name = "btnClass1";
            this.btnClass1.Size = new System.Drawing.Size(136, 81);
            this.btnClass1.TabIndex = 3;
            this.btnClass1.Text = "Class1";
            this.btnClass1.UseVisualStyleBackColor = true;
            this.btnClass1.Click += new System.EventHandler(this.btnClass1_Click);
            // 
            // btnClass3
            // 
            this.btnClass3.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnClass3.Location = new System.Drawing.Point(161, 300);
            this.btnClass3.Name = "btnClass3";
            this.btnClass3.Size = new System.Drawing.Size(136, 81);
            this.btnClass3.TabIndex = 4;
            this.btnClass3.Text = "Class3";
            this.btnClass3.UseVisualStyleBackColor = true;
            this.btnClass3.Click += new System.EventHandler(this.btnClass3_Click);
            // 
            // btnClass2
            // 
            this.btnClass2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnClass2.Location = new System.Drawing.Point(357, 145);
            this.btnClass2.Name = "btnClass2";
            this.btnClass2.Size = new System.Drawing.Size(136, 81);
            this.btnClass2.TabIndex = 5;
            this.btnClass2.Text = "Class2";
            this.btnClass2.UseVisualStyleBackColor = true;
            this.btnClass2.Click += new System.EventHandler(this.btnClass2_Click);
            // 
            // btnClass4
            // 
            this.btnClass4.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnClass4.Location = new System.Drawing.Point(357, 300);
            this.btnClass4.Name = "btnClass4";
            this.btnClass4.Size = new System.Drawing.Size(136, 81);
            this.btnClass4.TabIndex = 6;
            this.btnClass4.Text = "Class4";
            this.btnClass4.UseVisualStyleBackColor = true;
            this.btnClass4.Click += new System.EventHandler(this.btnClass4_Click);
            // 
            // frmAllClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 608);
            this.Controls.Add(this.btnClass2);
            this.Controls.Add(this.btnClass4);
            this.Controls.Add(this.btnClass3);
            this.Controls.Add(this.btnClass1);
            this.Name = "frmAllClasses";
            this.Text = "frmAllClasses";
            this.Load += new System.EventHandler(this.frmAllClasses_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClass1;
        private System.Windows.Forms.Button btnClass3;
        private System.Windows.Forms.Button btnClass2;
        private System.Windows.Forms.Button btnClass4;
    }
}