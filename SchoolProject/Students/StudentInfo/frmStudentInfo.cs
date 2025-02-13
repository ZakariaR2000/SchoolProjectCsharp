using Guna.UI2.WinForms;
using SchoolProject.Global_Classes;
using SchoolProject.LoginStudent;
using SchoolProject.Students.StudentInfo.UserContrles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SchoolProject.Students.StudentInfo
{
    public partial class frmStudentInfo : Form
    {
        public int StudentID { get; set; }

        public frmStudentInfo()
        {
            InitializeComponent();
        }

        private void frmStudentInfo_Load(object sender, EventArgs e)
        {
            imgSlide1.Visible = true;
            imgSlide2.Visible = false;
            imgSlide3.Visible = false;
            imgSlide4.Visible = false;

            _LoadFirtControl();
        }

        private void _LoadFirtControl()
        {
            panel2.Controls.Clear();

            // إنشاء نسخة من UC_StudentGrade
            UC_StudentGrade studentGrade = new UC_StudentGrade();
            studentGrade.LoadStudentGrades(clsGlobal.CurrentStudent.StudentID);

            // ضبط الخصائص
            studentGrade.Dock = DockStyle.Fill;

            // إضافة UC_StudentGrade إلى panel2
            panel2.Controls.Add(studentGrade);
        }


        //private void moveImageBox(object sender)
        //{
        //    Guna2Button b = (Guna2Button)sender;

        //    imgSlide.Location = new Point(b.Location.X + 104, b.Location.Y - 10);

        //    imgSlide.SendToBack();
        //}

        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;

            //// إخفاء جميع الصور أولاً
            imgSlide1.Visible = false;
            imgSlide2.Visible = false;
            imgSlide3.Visible = false;
            imgSlide4.Visible = false;

            // تحديد الصورة المناسبة بناءً على الزر
            switch (b.Name)
            {
                case "gunaBtnGrade":
                    imgSlide1.Visible = true; // إظهار الصورة الأولى
                    break;

                case "gunaBtnSubject":
                    imgSlide2.Visible = true; // إظهار الصورة الثانية
                    break;

                case "gunaBtnInfo":
                    imgSlide3.Visible = true; // إظهار الصورة الثالثة
                    break;

                case "gunaBtnMessage":
                    imgSlide4.Visible = true; // إظهار الصورة الرابعة
                    break;
            }

        }


        


        private void gunaBtnGrade_Click(object sender, EventArgs e)
        {
            //_LoadFirtControl();

            if (clsGlobal.CurrentStudent != null && clsGlobal.CurrentStudent.StudentID > 0)
            {
                // Create a new instance of UC_StudentGrade
                UC_StudentGrade gradeControl = new UC_StudentGrade();

                // Load the student's grades into the UserControl
                gradeControl.LoadStudentGrades(clsGlobal.CurrentStudent.StudentID);

                // Clear any existing controls in the Panel
                panel2.Controls.Clear();

                // Add the UC_StudentGrade UserControl to the Panel
                gradeControl.Dock = DockStyle.Fill;  // Optional: make it fill the panel
                panel2.Controls.Add(gradeControl);
            }
            else
            {
                MessageBox.Show("No student is logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gunaBtnSubject_Click(object sender, EventArgs e)
        {
            // Ensure the student is logged in and has a valid StudentID
            if (clsGlobal.CurrentStudent != null && clsGlobal.CurrentStudent.StudentID > 0)
            {
                // Create a new instance of UC_StudentSubject
                UC_StudentSubject subjectControl = new UC_StudentSubject();

                // Load the student's subjects into the UserControl
                subjectControl.LoadStudentSubjects(clsGlobal.CurrentStudent.StudentID);

                // Clear any existing controls in the Panel
                panel2.Controls.Clear();

                // Add the UC_StudentSubject UserControl to the Panel
                subjectControl.Dock = DockStyle.Fill;  // Optional: make it fill the panel
                panel2.Controls.Add(subjectControl);
            }
            else
            {
                MessageBox.Show("No student is logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaBtnGrade_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void gunaBtnMessage_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaBtnInfo_Click(object sender, EventArgs e)
        {
           // Ensure the student is logged in and has a valid StudentID
            if (clsGlobal.CurrentStudent != null && clsGlobal.CurrentStudent.StudentID > 0)
            {
                // Create a new instance of UC_StudentSubject
                UC_StudentInfo subjectControl = new UC_StudentInfo();

                // Load the student's subjects into the UserControl
                subjectControl.LoadStudentInfo(clsGlobal.CurrentStudent.StudentID);

                // Clear any existing controls in the Panel
                panel2.Controls.Clear();

                // Add the UC_StudentSubject UserControl to the Panel
                subjectControl.Dock = DockStyle.Fill;  // Optional: make it fill the panel
                panel2.Controls.Add(subjectControl);
            }
            else
            {
                MessageBox.Show("No student is logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaBtnLogout_Click(object sender, EventArgs e)
        {
            

            clsGlobal.CurrentStudent = null;

            // Show the login form
            frmLoginStudent frmLogin = new frmLoginStudent();
            frmLogin.Show();

            // Close only the current form (frmStudentInfo)
            this.Hide(); // أو يمكنك استخدام this.Close() هنا إذا لم يكن هناك أي تعارض.
        }
    }


}
