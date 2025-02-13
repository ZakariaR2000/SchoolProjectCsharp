using Guna.UI2.WinForms;
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

namespace SchoolProject.Techer.TeacherWindow
{
    public partial class frmTeacherControlPanel : Form
    {
        private int LoggedInTeacherID;

        public frmTeacherControlPanel(int TeacherID)
        {
            InitializeComponent();
            LoggedInTeacherID = TeacherID;
        }


        
        private void frmTeacherControlPanel_Load_1(object sender, EventArgs e)
        {
            gunaComboBoxSubject.Enabled = false;
            // LoadSubjectsAndClasses();
            LoadClasses();
        }
        private void LoadClasses()
        {
            try
            {
                DataTable data = clsTeacher.GetTeacherClasses(clsGlobal.CurrentUser.UserID);

                gunaComboBoxClass.Items.Clear();

                foreach (DataRow row in data.Rows)
                {
                    int classID = Convert.ToInt32(row["ClassID"]);
                    gunaComboBoxClass.Items.Add(classID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadSubjectsForSelectedClass()
        {
            if (gunaComboBoxClass.SelectedItem != null)
            {
                int selectedClassID = Convert.ToInt32(gunaComboBoxClass.SelectedItem);

                try
                {
                    DataTable data = clsTeacher.GetTeacherSubjects(clsGlobal.CurrentUser.UserID, selectedClassID);

                    gunaComboBoxSubject.Items.Clear();

                    foreach (DataRow row in data.Rows)
                    {
                        string subjectName = row["SubjectName"].ToString();
                        int subjectID = Convert.ToInt32(row["SubjectID"]);
                        gunaComboBoxSubject.Items.Add(new { Text = subjectName, Value = subjectID });
                    }

                    // تعيين DisplayMember و ValueMember
                    gunaComboBoxSubject.DisplayMember = "Text"; // يعرض الاسم
                    gunaComboBoxSubject.ValueMember = "Value"; // القيمة المخزنة هي SubjectID
                    gunaComboBoxSubject.Enabled = gunaComboBoxSubject.Items.Count > 0; // تفعيل القائمة إذا كان بها عناصر
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void gunaComboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjectsForSelectedClass();
        }

        private async void LoadStudentGrades()
        {
            // التحقق من أن العناصر المحددة ليست null
            if (gunaComboBoxClass.SelectedItem == null || gunaComboBoxSubject.SelectedItem == null)
            {
                MessageBox.Show("يرجى تحديد الصف والمادة.");
                return;
            }

            // التحقق من أن SelectedValue ليس null
            if (gunaComboBoxSubject.SelectedValue is int subjectID)
            {
                try
                {
                    int classID = int.Parse(gunaComboBoxClass.SelectedItem.ToString());

                    DataTable data = clsTeacher.GetStudentGrades(classID, subjectID);
                    dgvStudentInformation.DataSource = data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("لم يتم تعيين قيمة للمادة المحددة.");
            }
        }
        private void gunaComboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudentGrades();
        }
    }
}
