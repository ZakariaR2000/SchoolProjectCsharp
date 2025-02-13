using SchoolProject.Classes.Students;
using SchoolProject.Classes.Subjects;
using SchoolProject.Classes.Teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolProject.Classes
{
    public partial class frmClassInfo : Form
    {

        private int _ClassID;

        public frmClassInfo(int ClassID)
        {
            InitializeComponent();
            _ClassID = ClassID;
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            frmSubjectsInClass frm = new frmSubjectsInClass(_ClassID);
            frm.ShowDialog();
        }

        private void btnStudnets_Click(object sender, EventArgs e)
        {
            frmStudentsInClass frm = new frmStudentsInClass(_ClassID);
            frm.ShowDialog();
        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            frmTeachersInClass frm = new frmTeachersInClass(_ClassID);
            frm.ShowDialog();
        }
    }
}
