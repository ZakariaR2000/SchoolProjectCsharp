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

namespace SchoolProject.Classes.Teacher
{
    public partial class frmTeachersInClass : Form
    {
        private int _ClassID;
        public frmTeachersInClass(int ClassID)
        {
            InitializeComponent();

            _ClassID = ClassID;
        }

        private void frmTeachersInClass_Load(object sender, EventArgs e)
        {
            DataTable dtTeachers = clsTeacherSubject.GetTeachersByClassID(_ClassID);
            dgvTeachers.DataSource = dtTeachers;
            lblNumberOfRecords.Text = dgvTeachers.Rows.Count.ToString();
        }
    }
}
