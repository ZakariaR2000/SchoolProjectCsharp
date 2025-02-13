using SchoolProject.People;
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

namespace SchoolProject.Techer
{
    public partial class frmTechersList : Form
    {
        private int TecherID = -1;

        private DataTable _dtTecherList;
        public frmTechersList()
        {
            InitializeComponent();
        }

        private void frmTechersList_Load(object sender, EventArgs e)
        {
            _dtTecherList = clsTeacher.GetAllTeachers();

            dgvTechersList.DataSource = _dtTecherList;


            dgvTechersList.Columns[1].Width = 200;

            lblNumberOfRecords.Text = dgvTechersList.Rows.Count.ToString();


        }

        

        

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            /*      None
                    Techer ID
                    Person ID
                    Full Name
                    Country Name
                    National No
                    Gendor Caption*/

            string FilterColumn = "";

            switch(cbFilterBy.Text)
            {
                case "TecherID":
                    FilterColumn = "TecherID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Country Name":
                    FilterColumn = "CountryName";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Gendor Caption":
                    FilterColumn = "GendorCaption";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if(txtFilterValue.Text.Trim() =="" || FilterColumn=="None")
            {
                _dtTecherList.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvTechersList.Rows.Count.ToString();
                return;
            }

            if(FilterColumn=="PersonID" || FilterColumn=="TecherID")
                _dtTecherList.DefaultView.RowFilter =
                    string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtTecherList.DefaultView.RowFilter =
                    string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblNumberOfRecords.Text = dgvTechersList.Rows.Count.ToString();
        }

        private void cmsTecher_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var teacherIDValue = dgvTechersList.CurrentRow.Cells[0].Value;

            if (teacherIDValue == null)
            {
                MessageBox.Show("No TeacherID found in the selected row.");
                return;
            }

            int teacherID = (int)teacherIDValue;
            var teacher = clsTeacher.FindByTeacherID(teacherID);

            if (teacher != null)
            {
                int PersonID = teacher.PersonID;

                if ((bool)dgvTechersList.CurrentRow.Cells[6].Value)
                {
                    frmShowPersonInfo frm1 = new frmShowPersonInfo(PersonID);
                    frm1.ShowDialog();
                }
                else
                {
                    frmShowPersonInfo frm2 = new frmShowPersonInfo(PersonID, false);
                    frm2.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Teacher not found for the given TeacherID.");
            }


        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
    }
}
