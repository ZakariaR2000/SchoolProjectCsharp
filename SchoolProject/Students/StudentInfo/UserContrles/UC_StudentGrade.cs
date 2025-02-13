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
    public partial class UC_StudentGrade : UserControl
    {

        public UC_StudentGrade()
        {
            InitializeComponent();
        }

        public void LoadStudentGrades(int studentID)
        {
            // Assuming you have a method to get grades by student ID
            DataTable grades = clsGrade.GetGradesByStudentID(studentID);

            // Bind the DataTable to DataGridView
            dgvStudentGrade.DataSource = grades;
        }
    }
}
