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
    public partial class frmListClassInfo : Form
    {


        DataTable _dtAllClass;


        public frmListClassInfo()
        {
            InitializeComponent();

        }


        private void clsListClass_Load(object sender, EventArgs e)
        {
            _dtAllClass = clsClass.GetAllClasses();

            dgvClasses.DataSource = _dtAllClass;

            lblNumberOfRecords.Text = dgvClasses.Rows.Count.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int classID = (int)dgvClasses.CurrentRow.Cells[0].Value;
            frmEditClassInfo frm = new frmEditClassInfo(classID);

            frm.ShowDialog();

            

            clsListClass_Load(null, null); // إعادة تحميل البيانات في DataGridView
        }


    }
}
