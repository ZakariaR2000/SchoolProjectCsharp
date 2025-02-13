using SchoolProjectBuisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolProject.Students
{
    public partial class frmStudentsList : Form
    {
        private DataTable _dtAllStudents;


        public frmStudentsList()
        {
            InitializeComponent();
        }

        private void frmStudentsList_Load(object sender, EventArgs e)
        {
            _dtAllStudents = clsStudent.GetAllStudents();


            dgvStudents.DataSource = _dtAllStudents;

            dgvStudents.Columns[2].Width = 150;


            lblNumberOfRecords.Text = dgvStudents.Rows.Count.ToString();


        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmEditAddStudent frm = new frmEditAddStudent();
            frm.ShowDialog();
            frmStudentsList_Load(null, null);


        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            _dtAllStudents.DefaultView.RowFilter = "";
            lblNumberOfRecords.Text = dgvStudents.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Student ID":
                    FilterColumn = "StudentID"; //int
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";//int
                    break;

                case "Full Name":
                    FilterColumn = "FullName";//string
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";//string
                    break;


                case "Country Name":
                    FilterColumn = "CountryName";//string
                    break;

                case "User Name":
                    FilterColumn = "UserName";//string
                    break;

                case "Class Name":
                    FilterColumn = "ClassName";//string
                    break;


                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllStudents.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvStudents.Rows.Count.ToString();
                return;
            }

            if(FilterColumn== "StudentID" || FilterColumn=="PersonID")
                _dtAllStudents.DefaultView.RowFilter =
                    string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllStudents.DefaultView.RowFilter =
                    string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblNumberOfRecords.Text = dgvStudents.Rows.Count.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "StudentID" || cbFilterBy.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAddStudent frm = new frmEditAddStudent((int)dgvStudents.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void deleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this Student ?", "Confirm",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            int StudentID = (int)dgvStudents.CurrentRow.Cells[0].Value;

            clsStudent Student = clsStudent.FindByStudentID(StudentID);

            if(Student!=null)
            {
                if(Student.Delete())
                {
                    MessageBox.Show("Student Deleted Successfully.", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmStudentsList_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not Delete Student.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
