using SchoolProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectBuisness
{
    public class clsStudent
    {
        public enum enMode { AddNew = 0 , Update = 1}
        public enMode Mode = enMode.AddNew;
        
        public int StudentID { get; set; }
        public string StudentNumber { get; set; }
        public string Password { get; set; }
        public bool IsActive { set; get; }


        public int PersonID { get; set; }
        public int CreatedAdminID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ClassID { get; set; }

        public clsClass ClassInfo;

        public clsPerson PersonInfo;


        public clsStudent()
        {
            this.StudentID = -1;
            this.PersonID = -1;
            this.CreatedAdminID = -1;
            this.CreatedDate = DateTime.Now;
            this.ClassID = 1;
            this.StudentNumber = "";
            this.Password = "";
            this.IsActive = true;


            Mode = enMode.AddNew;

        }

        private clsStudent(int StudentID , int PersonID , int CreatedAdminID, DateTime CreatedDate , 
            int ClassID , string StudentNumber , string Password , bool IsActive)
        {
            this.StudentID = StudentID;
            this.PersonID = PersonID;
            this.CreatedAdminID = CreatedAdminID;
            this.CreatedDate = CreatedDate;
            this.ClassID = ClassID;
            this.StudentNumber = StudentNumber;
            this.IsActive = IsActive;

            this.ClassInfo = clsClass.Find(ClassID);
            this.PersonInfo = clsPerson.Find(PersonID);


            Mode = enMode.Update;
        }

        private bool _AddNewStudent()
        {
            this.StudentID = clsStudentData.AddNewStudent(this.PersonID, this.CreatedAdminID, this.ClassID);

            return this.StudentID != -1;
        }

        private bool _UpdateStudent()
        {
            bool result = clsStudentData.UpdateStudent(this.StudentID, this.CreatedAdminID, this.ClassID);
            if (!result)
            {
                Console.WriteLine("Update failed.");
            }
            return result;
        }


        public static clsStudent FindByStudentID(int StudentID)
        {
            int PersonID = -1, CreatedUserID = -1, ClassID = 0;
            DateTime CreatedDate= DateTime.Now;
            string StudentNumber = string.Empty, Password = string.Empty;
            bool IsActive = false;

            if (clsStudentData.GetStudentInfoByID(StudentID,ref StudentNumber, ref PersonID,
                ref CreatedUserID, ref CreatedDate, ref ClassID , ref Password))

                return new clsStudent(StudentID, PersonID, CreatedUserID,
                    CreatedDate, ClassID , StudentNumber , Password , IsActive);
            else
                return null;
        }

        public static clsStudent FindByPersonID(int PersonID)
        {
            int StudentID = -1, CreatedUserID = -1, ClassID = 0;
            DateTime CreatedDate = DateTime.Now;
            string StudentNumber = string.Empty, Password = string.Empty;
            bool IsActive = false;


            if (clsStudentData.GetStudentInfoByPersonID(PersonID, ref StudentID,
                ref CreatedUserID, ref CreatedDate, ref ClassID))

                return new clsStudent(StudentID, PersonID, CreatedUserID,
                                    CreatedDate, ClassID, StudentNumber, Password, IsActive);
            else
                return null;
        }

        public static DataTable GetAllStudents()
        {
            return clsStudentData.GetAllStudents();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewStudent())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateStudent();

            }

            return false;
        }

        public bool Delete()
        {
            return clsStudentData.DeleteStudent(this.StudentID);
        }

        public static bool CheckIfStudentExists(int studentID)
        {
            return clsStudentData.IsStudentExists(studentID);
        }

        public static DataTable GetStudentsByClassID(int ClassID)
        {
            return clsStudentData.GetStudentsByClassID(ClassID);
        }

       
        public static clsStudent FindByStudentNumberAndPassword(string StudentNumber , string Password)
        {
            int StudentID = -1, CreatedAdminID = -1, ClassID = 0, PersonID = -1;
            DateTime CreatedDate = DateTime.Now;
          //  string StudentNumber = string.Empty, Password = string.Empty;
            bool IsActive = false;


            if (clsStudentData.GetStudentInfoByStudentNumberAndPassword(StudentNumber, Password, ref StudentID, ref PersonID,
                ref CreatedAdminID, ref CreatedDate, ref ClassID, ref IsActive))

                return new clsStudent(StudentID, PersonID, CreatedAdminID,
                                                    CreatedDate, ClassID, StudentNumber, Password, IsActive);
            else
                return null;
        }


        public static DataTable GetStudentsGradesByTeacherID(int TeacherID)
        {
            return clsStudentData.GetStudentsGradesByTeacherID(TeacherID);
        }


    }
}
