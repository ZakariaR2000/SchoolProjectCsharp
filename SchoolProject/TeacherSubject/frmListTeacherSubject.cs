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

namespace SchoolProject.TeacherSubject
{
    public partial class frmListTeacherSubject : Form
    {

        DataTable _dtTeacherSubject;
        public frmListTeacherSubject()
        {
            InitializeComponent();
        }

        private void frmListTeacherSubject_Load(object sender, EventArgs e)
        {
            _dtTeacherSubject = clsTeacherSubject.GetAllTeacherSubjects();
            dgvTeacherSubject.DataSource = _dtTeacherSubject;

            dgvTeacherSubject.Columns[2].Width = 220;

        }

        private void deleteTeahcerToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (dgvTeacherSubject.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a teacher to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvTeacherSubject.CurrentRow;

            if (selectedRow != null)
            {
                int teacherID = (int)selectedRow.Cells["TeacherID"].Value;
                string subjectName = selectedRow.Cells["SubjectName"].Value.ToString();

                int subjectID = clsTeacherSubject.GetSubjectIDByName(subjectName);

                if (subjectID > 0)
                {
                    // إذا كان ClassID موجودًا في DataGridView، احصل عليه
                    int classID = (int)selectedRow.Cells["ClassID"].Value; // استبدل "ClassID" باسم العمود المناسب

                    if (clsTeacherSubject.Delete(teacherID, subjectID, classID)) // تأكد من تمرير ClassID
                    {
                        MessageBox.Show("Teacher deleted successfully.", "Deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmListTeacherSubject_Load(null, null); // تحديث DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Error deleting teacher.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Subject not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
