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

namespace SchoolProject.Classes.Subjects
{
    public partial class frmSubjectsInClass : Form
    {
        private int _ClassID;
        public frmSubjectsInClass(int ClassID)
        {
            InitializeComponent();

            _ClassID = ClassID;
        }

        private void frmSubjectsInClass_Load(object sender, EventArgs e)
        {
            DataTable dtSubjects = clsSubject.GetSubjectsByClassID(_ClassID);
            dgvSubjects.DataSource= dtSubjects;

            lblNumberOfRecords.Text = dgvSubjects.Rows.Count.ToString();

        }
    }
}
