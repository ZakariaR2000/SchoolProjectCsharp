using SchoolProjectDataAccess;
using System;
using System.Data;

namespace SchoolProjectBuisness
{
    public class clsTeacher
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TeacherID { get; set; }
        public int PersonID { get; set; }
        public int UserID {  get; set; }
        public int CreatedByAdminID { get; set; }
        public DateTime CreatedDate { get; private set; }

        public clsPerson PersonInfo;
        public clsUser UserInfo;

        public clsTeacher()
        {
            this.TeacherID = -1;
            this.PersonID = -1;
            this.CreatedByAdminID = -1;
            this.CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

        public clsTeacher(int TeacherID, int PersonID, int CreatedByAdminID, DateTime CreatedDate , int UserID)
        {
            this.TeacherID = TeacherID;
            this.PersonID = PersonID;
            this.CreatedByAdminID = CreatedByAdminID;
            this.CreatedDate = CreatedDate;
            this.UserID = UserID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserInfo = clsUser.FindByUserID(UserID);

            Mode = enMode.Update;
        }

        // إضافة مدرس جديد
        private bool _AddNewTeachers()
        {
            this.TeacherID = clsTeacherData.AddNewTeacher(PersonID, CreatedByAdminID , UserID);
            return this.TeacherID != -1;
        }

        // تحديث معلومات المدرس
        private bool _UpdateTeachers()
        {
            return clsTeacherData.UpdateTeacher(this.TeacherID, this.PersonID, this.CreatedByAdminID,this.UserID);
        }

        // البحث عن مدرس باستخدام TeacherID
        public static clsTeacher FindByTeacherID(int TeacherID)
        {
            int PersonID = -1, CreatedByAdminID = -1 , UserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsTeacherData.GetTeahcerInfoByID(TeacherID, ref PersonID, ref CreatedByAdminID, ref CreatedDate ,ref UserID))
            {
                return new clsTeacher(TeacherID, PersonID, CreatedByAdminID, CreatedDate, UserID);
            }
            else
            {
                return null;
            }
        }

        // البحث عن مدرس باستخدام PersonID
        public static clsTeacher FindByPersonID(int PersonID)
        {
            int TeacherID = -1, CreatedByUserID = -1,UserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsTeacherData.GetTeacherInfoByPersonID(PersonID, ref TeacherID, ref CreatedByUserID, ref CreatedDate , ref UserID))
            {
                return new clsTeacher(TeacherID, PersonID, CreatedByUserID, CreatedDate, UserID);
            }
            else
            {
                return null;
            }
        }

        // جلب جميع المدرسين
        public static DataTable GetAllTeachers()
        {
            return clsTeacherData.GetAllTeachers();
        }

        // حفظ المدرس (إضافة أو تحديث)
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTeachers())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateTeachers();
            }

            return false;
        }

        public static clsTeacher FindByUserNameAndPassword(string UserName, string Password)
        {
            int TeacherID = -1, CreatedByAdminID = -1, PersonID = -1,UserID = -1;
            DateTime CreatedDate = DateTime.Now;
            bool IsActive = false;

            if (clsTeacherData.GetTeacherInfoByUserNameAndPassword(UserName, Password, ref TeacherID, ref PersonID,
                ref CreatedByAdminID, ref CreatedDate, ref IsActive,ref UserID))
            {
                // إنشاء كائن جديد من نوع clsTeacher عند العثور على المعلم
                return new clsTeacher(TeacherID, PersonID, CreatedByAdminID, CreatedDate, UserID);
            }
            else
            {
                // إذا لم يتم العثور على المعلم، يتم إرجاع null
                return null;
            }
        }

        public static DataTable GetTeacherSubjectsAndClasses(int teacherID)
        {
            return clsTeacherData.GetSubjectsAndClassesByTeacherID(teacherID);
        }
        public static int LoginTeacher(string username, string password)
        {
            return clsTeacherData.AuthenticateTeacher(username, password);
        }

        public static DataTable GetTeacherClasses(int teacherID)
        {
            return clsTeacherData.GetClassesByTeacher(teacherID);
        }

        public static DataTable GetTeacherSubjects(int teacherID, int classID)
        {
            return clsTeacherData.GetSubjectsByTeacherAndClass(teacherID, classID);
        }
        public static DataTable GetStudentGrades(int classID, int subjectID)
        {
            return clsTeacherData.GetStudentsWithGrades(classID, subjectID);
        }



    }
}
