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

namespace SchoolProject.Techer.UserContrles
{
    public partial class US_StudentInfo : UserControl
    {
        public US_StudentInfo()
        {
            InitializeComponent();
        }

        public void LoadStudentInfo(int TeacherID)
        {
            // Assuming you have a method to get grades by student ID
            DataTable StudentInfo = clsStudent.GetStudentsGradesByTeacherID(TeacherID);

            // Bind the DataTable to DataGridView
            dgvStudentInformation.DataSource = StudentInfo;
        }
    }
}
