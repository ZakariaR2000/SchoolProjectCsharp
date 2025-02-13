using SchoolProject.Classes;
using SchoolProject.Login;
using SchoolProject.People;
using SchoolProject.Students;
using SchoolProject.TeacherSubject;
using SchoolProject.Techer;
using SchoolProject.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolProject
{
    public partial class frmMain : Form
    {
        frmLoginAdmin _frmLogin;


        public frmMain(frmLoginAdmin frm)
        {
            InitializeComponent();

            _frmLogin = frm;


        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            frmTechersList frm = new frmTechersList();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmStudentsList frm = new frmStudentsList();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.ShowDialog();
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            frmListTeacherSubject frm = new frmListTeacherSubject();
            frm.ShowDialog();
        }



        private void btnClasses_Click_1(object sender, EventArgs e)
        {
            frmAllClasses frm = new frmAllClasses();
            frm.ShowDialog(); 

        }

        private void btnClassesInfo_Click(object sender, EventArgs e)
        {
            
            frmListClassInfo frm = new frmListClassInfo();
            frm.ShowDialog();

        }

       
    }
}
