using SchoolProject.Classes.Teacher;
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

namespace SchoolProject.Classes
{
    public partial class frmAllClasses : Form
    {

        

        public frmAllClasses()
        {
            InitializeComponent();
            
        }

         

        private void btnClass1_Click(object sender, EventArgs e)
        {
            frmClassInfo frm = new frmClassInfo(1);
            frm.ShowDialog();
        }

        private void btnClass2_Click(object sender, EventArgs e)
        {
            frmClassInfo frm = new frmClassInfo(2);
            frm.ShowDialog();
        }

        private void btnClass3_Click(object sender, EventArgs e)
        {
            frmClassInfo frm = new frmClassInfo(3);
            frm.ShowDialog();
        }

        private void btnClass4_Click(object sender, EventArgs e)
        {
            frmClassInfo frm = new frmClassInfo(4);
            frm.ShowDialog();
        }

        public void LoadClassButtons()
        {
            DataTable allClasses = clsClass.GetAllClasses();

            if (allClasses.Rows.Count > 0)
            {
               
                btnClass1.Text = allClasses.Rows[0]["ClassName"].ToString();
            }
            if (allClasses.Rows.Count > 1)
            {
                
                btnClass2.Text = allClasses.Rows[1]["ClassName"].ToString();
            }
            if (allClasses.Rows.Count > 2)
            {
                
                btnClass3.Text = allClasses.Rows[2]["ClassName"].ToString();
            }
            if (allClasses.Rows.Count > 3)
            {
                
                btnClass4.Text = allClasses.Rows[3]["ClassName"].ToString();
            }
        }

        private void frmAllClasses_Load(object sender, EventArgs e)
        {
            LoadClassButtons();
        }
    }
}
