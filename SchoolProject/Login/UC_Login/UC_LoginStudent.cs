using SchoolProject.Global_Classes;
using SchoolProject.Students.StudentInfo;
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

namespace SchoolProject.Login.UC_Login
{
    public partial class UC_LoginStudent : UserControl
    {
        public UC_LoginStudent()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            clsStudent student = clsStudent.FindByStudentNumberAndPassword(txtStudentNumber.Text.Trim(),
                txtPassword.Text.Trim());

            if (student != null)
            {
                if (chkRememberMe.Checked)
                {
                    clsGlobal.RememberStudentNumberAndPassword(txtStudentNumber.Text.Trim(),
                        txtPassword.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberStudentNumberAndPassword("", "");
                }

                if (!student.IsActive)
                {
                    txtStudentNumber.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.",
                        "In Active Account",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clsGlobal.CurrentStudent = student;
                this.Hide();
                frmStudentInfo frm = new frmStudentInfo();
                frm.StudentID = student.StudentID;
                frm.FormClosed += (s, args) => Application.Exit();

                frm.ShowDialog();

            }

            else
            {
                txtStudentNumber.Focus();
                MessageBox.Show("Invalid StudentNumber/Password.", "Wrong Credintials",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
