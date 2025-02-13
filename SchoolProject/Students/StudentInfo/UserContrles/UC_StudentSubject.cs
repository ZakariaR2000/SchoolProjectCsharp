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

namespace SchoolProject.Students.StudentInfo.UserContrles
{
    public partial class UC_StudentSubject : UserControl
    {
        public UC_StudentSubject()
        {
            InitializeComponent();
        }

        public void LoadStudentSubjects(int studentID)
        {
            // Assuming you have a method to get grades by student ID

            int ClassID = clsStudent.FindByStudentID(studentID).ClassID;

            DataTable Subject = clsSubject.GetSubjectsByClassID(ClassID);

            // Bind the DataTable to DataGridView
            dgvStudentSubject.DataSource = Subject;
        }
    }
}
