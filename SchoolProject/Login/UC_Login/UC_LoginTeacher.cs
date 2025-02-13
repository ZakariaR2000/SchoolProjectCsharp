using SchoolProject.Global_Classes;
using SchoolProject.Students.StudentInfo;
using SchoolProject.Techer.TeacherWindow;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SchoolProject.Login.UC_Login
{
    public partial class UC_LoginTeacher : UserControl
    {
        public UC_LoginTeacher()
        {
            InitializeComponent();
        }

        private void btnGunaLogin_Click(object sender, EventArgs e)
        {
            clsTeacher teacher = clsTeacher.FindByUserNameAndPassword(txtTeacherNumber.Text.Trim(),
               txtPassword.Text.Trim());

            if (teacher != null)
            {
                if (chkRememberMe.Checked)
                {
                    clsGlobal.RememberStudentNumberAndPassword(txtTeacherNumber.Text.Trim(),
                        txtPassword.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberStudentNumberAndPassword("", "");
                }

                if (!teacher.UserInfo.IsActive)
                {
                    txtTeacherNumber.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.",
                        "In Active Account",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int teacherID = clsTeacher.LoginTeacher(txtTeacherNumber.Text.Trim(),
                    txtPassword.Text.Trim());

                clsGlobal.CurrentUser = teacher.UserInfo;
                this.Hide();
                frmTeacherControlPanel frm = new frmTeacherControlPanel(teacherID);
               // frm.StudentID = teacher.StudentID;
                frm.FormClosed += (s, args) => Application.Exit();

                frm.ShowDialog();

            }

            else
            {
                txtTeacherNumber.Focus();
                MessageBox.Show("Invalid StudentNumber/Password.", "Wrong Credintials",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
