using SchoolProject.Techer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolProject.People
{
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo(int PersonID, bool isEnabled = true)
        {
            InitializeComponent();
            ctrlPersonCard1.LoadPersonInfo(PersonID);

            if (!isEnabled)
            {
                DisableAllControls();
            }


        }

        public frmShowPersonInfo(string NationalNo , bool isEnabled = true)
        {
            InitializeComponent();
            ctrlPersonCard1.LoadPersonInfo(NationalNo);

            if (!isEnabled)
            {
                DisableAllControls();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisableAllControls()
        {
            // تعطيل جميع مكونات الفورم

            foreach (System.Windows.Forms.Control ctrl in this.Controls)
            {
                ctrl.Enabled = false;
            }
        }

    }
}
