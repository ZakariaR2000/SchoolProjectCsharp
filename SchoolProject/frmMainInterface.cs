using Guna.UI2.WinForms;
using SchoolProject.Global_Classes;
using SchoolProject.Login;
using SchoolProject.Login.UC_Login;
using SchoolProject.LoginStudent;
using SchoolProject.Students.StudentInfo.UserContrles;
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

namespace SchoolProject
{
    public partial class frmMainInterface : Form
    {
        public frmMainInterface()
        {
            InitializeComponent();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmLoginAdmin frm = new frmLoginAdmin();
            frm.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLoginStudent frm = new frmLoginStudent();
            frm.Show();
            this.Hide();

            // إعادة إظهار النافذة الرئيسية عند إغلاق frmLoginStudent
            frm.FormClosed += (s, args) => this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmLoginTeacher frm = new frmLoginTeacher();
            frm.ShowDialog();
        }

        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;

            //// إخفاء جميع الصور أولاً
            imgSlide1.Visible = false;
            imgSlide2.Visible = false;
            imgSlide3.Visible = false;

            // تحديد الصورة المناسبة بناءً على الزر
            switch (b.Name)
            {
                case "gunaBtnStudent":
                    imgSlide1.Visible = true; // إظهار الصورة الأولى
                    break;

                case "gunaBtnTeacher":
                    imgSlide2.Visible = true; // إظهار الصورة الثانية
                    break;

                case "gunaBtnAdmin":
                    imgSlide3.Visible = true; // إظهار الصورة الثالثة
                    break;


            }

        }


        private void gunaBtnStudent_Click(object sender, EventArgs e)
        {
            // Create a new instance of UC_StudentSubject
            UC_LoginStudent LoginStudentControl = new UC_LoginStudent();

            // Load the student's subjects into the UserControl
            //subjectControl.LoadStudentSubjects(clsGlobal.CurrentStudent.StudentID);

            // Clear any existing controls in the Panel
            panel2.Controls.Clear();

            // Add the UC_StudentSubject UserControl to the Panel
            LoginStudentControl.Dock = DockStyle.Fill;  // Optional: make it fill the panel
            panel2.Controls.Add(LoginStudentControl);

        }

        private void gunaBtnStudent_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void gunaBtnTeacher_Click(object sender, EventArgs e)
        {

            // Create a new instance of UC_StudentSubject
            UC_LoginTeacher LoginTeacherControl = new UC_LoginTeacher();

            // Load the student's subjects into the UserControl
            //subjectControl.LoadStudentSubjects(clsGlobal.CurrentStudent.StudentID);

            // Clear any existing controls in the Panel
            panel2.Controls.Clear();

            // Add the UC_StudentSubject UserControl to the Panel
            LoginTeacherControl.Dock = DockStyle.Fill;  // Optional: make it fill the panel
            panel2.Controls.Add(LoginTeacherControl);
        }

        private void frmMainInterface_Load(object sender, EventArgs e)
        {
            imgSlide1.Visible = true;
            imgSlide2.Visible = false;
            imgSlide3.Visible = false;

            gunaBtnStudent_Click(null, null);

        }
    }
}
