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

namespace SchoolProject.People
{
    public partial class frmListPeople : Form
    {
        DataTable _dtPeople = clsPerson.GetAllPeople();
        

        private void _RefreshPeopleList()
        {
            _dtPeople = clsPerson.GetAllPeople();

            dgvPeople.DataSource = _dtPeople;

            lblNumberOfRecords.Text = dgvPeople.Rows.Count.ToString();
        }

        public frmListPeople()
        {
            InitializeComponent();
        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {
            dgvPeople.DataSource = _dtPeople;
            cbFilterBy.SelectedIndex = 0;
            lblNumberOfRecords.Text = dgvPeople.Rows.Count.ToString();

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
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";//int
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";//string
                    break;

                case "First Name":
                    FilterColumn = "FirstName";//string
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";//string
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";//string
                    break;

                case "Last Name":
                    FilterColumn = "LastName";//string
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";//string
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";//string
                    break;

                case "Phone":
                    FilterColumn = "Phone";//string
                    break;

                case "Email":
                    FilterColumn = "Email";//string
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter =
                    string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter =
                    string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAddPerson frm = new frmEditAddPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshPeopleList();

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmEditAddPerson frm = new frmEditAddPerson();
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmEditAddPerson frm = new frmEditAddPerson();
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" +
                dgvPeople.CurrentRow.Cells[0].Value + "]",
                "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }
                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }
    }
}
