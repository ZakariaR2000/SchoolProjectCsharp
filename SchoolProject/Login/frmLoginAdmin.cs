using SchoolProject.Global_Classes;
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

namespace SchoolProject.Login
{
    public partial class frmLoginAdmin : Form
    {
        public frmLoginAdmin()
        {
            InitializeComponent();



        }

       

        

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Brush brush = Brushes.White;

            Font font = new Font("Arial", 24);

            PointF location = new PointF(50, 30); // يمكن تغيير الإحداثيات حسب الحاجة

            e.Graphics.DrawString("\n\nWelcome To \nZakaria School \nGroub", font, brush, location);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Password = clsHashAlgor.ComputeHash(txtPassword.Text.Trim());
            

            clsAdmin admin = clsAdmin.FindByAdminNameAndPassword(txtAdminName.Text.Trim(),
               txtPassword.Text.Trim());

            if (admin != null)
            {
                if (chkRememberMe.Checked)
                {
                    clsGlobal.RememberAdminNameAndPassword(txtAdminName.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberAdminNameAndPassword("", "");
                }

                if (!admin.IsActive)
                {
                    txtAdminName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.",
                        "In Active Account",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentAdmin = admin;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.FormClosed += (s, args) => Application.Exit();

                frm.ShowDialog();
            }
            else
            {
                txtAdminName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string AdminName = "", Password = "";
            if (clsGlobal.GetStoredCredentialForAdmin(ref AdminName, ref Password))
            {
                txtAdminName.Text = AdminName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }
    }
}
