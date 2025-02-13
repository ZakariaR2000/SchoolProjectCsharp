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

namespace SchoolProject.LoginStudent
{
    public partial class frmLoginStudent : Form
    {
        public frmLoginStudent()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            

            clsStudent student = clsStudent.FindByStudentNumberAndPassword(txtStudentNumber.Text.Trim(),
                txtPassword.Text.Trim());

            if (student!=null)
            {
                if(chkRememberMe.Checked)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
