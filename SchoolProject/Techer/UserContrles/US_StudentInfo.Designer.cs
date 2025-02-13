namespace SchoolProject.Techer.UserContrles
{
    partial class US_StudentInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvStudentInformation = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudentInformation
            // 
            this.dgvStudentInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentInformation.Location = new System.Drawing.Point(59, 242);
            this.dgvStudentInformation.Name = "dgvStudentInformation";
            this.dgvStudentInformation.RowHeadersWidth = 51;
            this.dgvStudentInformation.RowTemplate.Height = 26;
            this.dgvStudentInformation.Size = new System.Drawing.Size(739, 257);
            this.dgvStudentInformation.TabIndex = 0;
            // 
            // US_StudentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvStudentInformation);
            this.Name = "US_StudentInfo";
            this.Size = new System.Drawing.Size(842, 597);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentInformation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudentInformation;
    }
}
