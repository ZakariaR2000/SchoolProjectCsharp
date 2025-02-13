namespace SchoolProject.TeacherSubject
{
    partial class frmListTeacherSubject
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTeacherSubject = new System.Windows.Forms.DataGridView();
            this.cmsTeacherSubject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addNewTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTeahcerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacherSubject)).BeginInit();
            this.cmsTeacherSubject.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 35F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(149, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(588, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "Teachers Inforamtion";
            // 
            // dgvTeacherSubject
            // 
            this.dgvTeacherSubject.AllowUserToAddRows = false;
            this.dgvTeacherSubject.AllowUserToDeleteRows = false;
            this.dgvTeacherSubject.AllowUserToOrderColumns = true;
            this.dgvTeacherSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeacherSubject.ContextMenuStrip = this.cmsTeacherSubject;
            this.dgvTeacherSubject.Location = new System.Drawing.Point(13, 236);
            this.dgvTeacherSubject.Name = "dgvTeacherSubject";
            this.dgvTeacherSubject.ReadOnly = true;
            this.dgvTeacherSubject.RowHeadersWidth = 51;
            this.dgvTeacherSubject.RowTemplate.Height = 26;
            this.dgvTeacherSubject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeacherSubject.Size = new System.Drawing.Size(903, 375);
            this.dgvTeacherSubject.TabIndex = 1;
            // 
            // cmsTeacherSubject
            // 
            this.cmsTeacherSubject.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTeacherSubject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewTeacherToolStripMenuItem,
            this.deleteTeahcerToolStripMenuItem});
            this.cmsTeacherSubject.Name = "cmsTeacherSubject";
            this.cmsTeacherSubject.Size = new System.Drawing.Size(196, 52);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblNumberOfRecords.Location = new System.Drawing.Point(132, 630);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(37, 24);
            this.lblNumberOfRecords.TabIndex = 31;
            this.lblNumberOfRecords.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(12, 630);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 24);
            this.label2.TabIndex = 30;
            this.label2.Text = "# Records :";
            // 
            // addNewTeacherToolStripMenuItem
            // 
            this.addNewTeacherToolStripMenuItem.Name = "addNewTeacherToolStripMenuItem";
            this.addNewTeacherToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.addNewTeacherToolStripMenuItem.Text = "Add New Teacher";
            // 
            // deleteTeahcerToolStripMenuItem
            // 
            this.deleteTeahcerToolStripMenuItem.Name = "deleteTeahcerToolStripMenuItem";
            this.deleteTeahcerToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.deleteTeahcerToolStripMenuItem.Text = "Delete";
            this.deleteTeahcerToolStripMenuItem.Click += new System.EventHandler(this.deleteTeahcerToolStripMenuItem_Click);
            // 
            // frmListTeacherSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 709);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTeacherSubject);
            this.Controls.Add(this.label1);
            this.Name = "frmListTeacherSubject";
            this.Text = "frmListTeacherSubject";
            this.Load += new System.EventHandler(this.frmListTeacherSubject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacherSubject)).EndInit();
            this.cmsTeacherSubject.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTeacherSubject;
        private System.Windows.Forms.ContextMenuStrip cmsTeacherSubject;
        private System.Windows.Forms.ToolStripMenuItem addNewTeacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTeahcerToolStripMenuItem;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
    }
}