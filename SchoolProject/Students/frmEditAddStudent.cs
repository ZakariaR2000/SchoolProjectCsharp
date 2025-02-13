using SchoolProject.Global_Classes;
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
    public partial class frmEditAddStudent : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        private int _StudentID = -1;

        clsStudent _Student;
        clsClass _Class;

        public frmEditAddStudent()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmEditAddStudent(int StudentID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _StudentID = StudentID;
        }

        private void _GetClassList(int classID = 1)
        {
            DataTable classTable = clsClass.GetAllClasses();

            cbClasses.Items.Clear();

            List<clsClass> classList = new List<clsClass>();

            foreach (DataRow row in classTable.Rows)
            {
                clsClass newClass = new clsClass
                {
                    ID = Convert.ToInt32(row["ClassID"]),  
                    ClassName = row["ClassName"].ToString(), 
                    ClassFees = Convert.ToSingle(row["ClassFees"]) 
                };
                classList.Add(newClass);

                cbClasses.Items.Add(newClass.ClassName);
            }

            clsClass selectedClass = classList.FirstOrDefault(c => c.ID == classID);
            if (selectedClass != null)
            {
                cbClasses.SelectedItem = selectedClass.ClassName;
            }
            else
            {
                MessageBox.Show("Class is not found");
            }
        }

        private void _ResetDefualtValues()
        {
            // _FillClassesInComboBox();

            if (_Mode == enMode.AddNew)
            {

                lblTitle.Text = "New Student";
                this.Text = "New Student";

                _Student = new clsStudent();
                tpClassInfo.Enabled = false;

                ctrlPersonCardWithFilter1.FilterFocus();
                //lblClassFees.Text = clsClass.classFess

            }
            else
            {
                lblTitle.Text = "Update Student";
                this.Text = "Update Student";

                tpClassInfo.Enabled = true;
                btnSave.Enabled = true;
            }


        }

        private void _LoadData()
        {
            _Student = clsStudent.FindByStudentID(_StudentID);

            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_Student == null)
            {
                MessageBox.Show("No Student with ID = " + _StudentID, "Student Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_Student.PersonInfo.PersonID);
            _Class = clsClass.Find(_Student.ClassID);

            //cbClasses.Text = _Student.ClassInfo.ClassName;
            _GetClassList(_Student.ClassID);

        }

        private void frmEditAddStudent_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();



            if (_Mode == enMode.Update)
                _LoadData();

        }

        private void cbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClasses.SelectedItem == null)
                return;

            string selectedClassName = cbClasses.SelectedItem.ToString().Trim();


            clsClass selectedClass = clsClass.Find(selectedClassName);

            if (selectedClass != null)
            {
                lblClassFees.Text = selectedClass.ClassFees.ToString("0.00");
            }
            else
            {
                lblClassFees.Text = "0.00";
                MessageBox.Show("Class not found.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            //string selectedClassName = cbClasses.SelectedItem.ToString().Trim();
            _Student.ClassID = clsClass.Find(cbClasses.SelectedItem.ToString().Trim()).ID;
            _Student.PersonID = ctrlPersonCardWithFilter1.SelectedPersonInfo.PersonID;
            _Student.CreatedAdminID = clsGlobal.CurrentUser.UserID;



            if (clsStudent.CheckIfStudentExists(_Student.PersonID))
            {
                MessageBox.Show("Student already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Student.Save())
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Update Student";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (ctrlPersonCardWithFilter1.SelectedPersonInfo == null ||
       ctrlPersonCardWithFilter1.SelectedPersonInfo.PersonID == -1)
            {
                MessageBox.Show("Please load the person's information before proceeding.",
                                "Information Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrlPersonCardWithFilter1.FilterFocus(); // إرجاع التركيز على اختيار الشخص
                return;
            }

            if (_Mode==enMode.Update)
            {
                btnSave.Enabled = true;
                tpClassInfo.Enabled = true;
                tcStudentInfo.SelectedTab = tcStudentInfo.TabPages["tpClassInfo"];
                return;
            }

            if (ctrlPersonCardWithFilter1.SelectedPersonInfo.PersonID != -1)
            {

                btnSave.Enabled = true;
                tpClassInfo.Enabled = true;
                tcStudentInfo.SelectedTab = tcStudentInfo.TabPages["tpClassInfo"];
                _GetClassList();

            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
            
            
            

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
