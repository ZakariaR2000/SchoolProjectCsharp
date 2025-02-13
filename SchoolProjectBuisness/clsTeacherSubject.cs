using SchoolProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectBuisness
{
    public class clsTeacherSubject
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int TeacherID { get; set; }
        public int SubjectID { get; set; }
        public int ClassID { get; set; } // إضافة ClassID
        public bool Status { get; set; }

        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRelationshipExists { get; set; }

        public clsTeacherSubject()
        {
            this.TeacherID = -1;
            this.SubjectID = -1;
            this.ClassID = -1; // تعيين قيمة ابتدائية لـ ClassID
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            this.Status = false;

            Mode = enMode.AddNew;
        }

        private clsTeacherSubject(int TeacherID, int SubjectID, int ClassID, int CreatedByUserID, DateTime CreatedDate, bool Status)
        {
            this.TeacherID = TeacherID;
            this.SubjectID = SubjectID;
            this.ClassID = ClassID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.Status = Status;

            Mode = enMode.Update;
        }

        public static clsTeacherSubject FindByTeacherID(int TeacherID)
        {
            int SubjectID = -1, ClassID = -1, CreatedUserID = -1;
            DateTime CreatedDate = DateTime.Now;
            bool Status = false;

            if (clsTeacherSubjectsData.GetTeacherInfoByID(TeacherID, ref SubjectID, ref ClassID, ref CreatedUserID, ref CreatedDate, ref Status))
                return new clsTeacherSubject(TeacherID, SubjectID, ClassID, CreatedUserID, CreatedDate, Status);
            else
                return null;
        }

        public static clsTeacherSubject FindByTeacherIDAndSubjectID(int TeacherID, int SubjectID, int ClassID)
        {
            int CreatedUserID = -1;
            DateTime CreatedDate = DateTime.Now;
            bool Status = false;

            if (clsTeacherSubjectsData.GetTeacherInfoByIDandSubjectID(TeacherID, SubjectID, ClassID, ref CreatedUserID, ref CreatedDate, ref Status))
                return new clsTeacherSubject(TeacherID, SubjectID, ClassID, CreatedUserID, CreatedDate, Status);
            else
                return null;
        }

        private bool _AddTeacherSubject()
        {
            if (CheckIfRelationshipExists(this.TeacherID, this.SubjectID, this.ClassID))
            {
                return false;
            }

            return clsTeacherSubjectsData.AddTeacherSubject(this.TeacherID, this.SubjectID, this.ClassID);
        }

        private bool _UpdateTeacherSubject()
        {
            // يمكنك إضافة أي منطق تحقق إضافي إذا لزم الأمر

            return clsTeacherSubjectsData.UpdateTeacherSubject(this.TeacherID, this.SubjectID, this.ClassID);
        }

        private bool _RemoveTeacherSubject(int teacherID, int subjectID, int classID)
        {
            if (!CheckIfRelationshipExists(teacherID, subjectID, classID))
            {
                return false;
            }

            return clsTeacherSubjectsData.RemoveTeacherSubject(teacherID, subjectID, classID);
        }

        public bool CheckIfRelationshipExists(int teacherID, int subjectID, int classID)
        {
            IsRelationshipExists = clsTeacherSubjectsData.CheckIfRelationshipExists(teacherID, subjectID, classID);
            return IsRelationshipExists;
        }

        public static DataTable GetSubjectsByTeacherID(int teacherID, int classID)
        {
            return clsTeacherSubjectsData.GetSubjectsByTeacherID(teacherID, classID);
        }

        public static DataTable GetTeachersBySubjectID(int subjectID, int classID)
        {
            return clsTeacherSubjectsData.GetTeachersBySubjectID(subjectID, classID);
        }

        public static DataTable GetTeachersByClassID(int classID)
        {
            return clsTeacherSubjectsData.GetTeachersByClassID(classID);
        }

        public static DataTable GetAllTeacherSubjects()
        {
            // استدعاء الـ Method من Data Access Layer لجلب البيانات
            return clsTeacherSubjectsData.GetAllTeacherSubjects();
        }

        public static bool Delete(int TeacherID, int SubjectID, int ClassID)
        {
            return clsTeacherSubjectsData.RemoveTeacherSubject(TeacherID, SubjectID, ClassID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddTeacherSubject())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateTeacherSubject();
            }
            return false;
        }

        public static int GetSubjectIDByName(string subjectName)
        {
            return clsTeacherSubjectsData.GetSubjectIDByName(subjectName);
        }

    }
}
