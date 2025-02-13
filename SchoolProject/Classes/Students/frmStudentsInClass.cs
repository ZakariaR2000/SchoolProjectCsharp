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

namespace SchoolProject.Classes.Students
{
    public partial class frmStudentsInClass : Form
    {
        private int _ClassID;
        public frmStudentsInClass(int ClassID)
        {
            InitializeComponent();
            _ClassID = ClassID;
        }

        private void frmStudentsInClass_Load(object sender, EventArgs e)
        {
            DataTable _dtStudents = clsStudent.GetStudentsByClassID(_ClassID);
            dgvStudents.DataSource = _dtStudents;

            lblNumberOfRecords.Text = dgvStudents.Rows.Count.ToString();
        }
    }
}
