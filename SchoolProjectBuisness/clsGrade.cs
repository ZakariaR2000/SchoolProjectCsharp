using SchoolProjectDataAccess;
using System;
using System.Data;

namespace SchoolProjectBuisness
{
    public class clsGrade
    {
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public decimal Grade { get; set; }

        public clsGrade()
        {
            this.StudentID = -1;
            this.SubjectID = -1;
            this.Grade = 0;
        }

        private clsGrade(int StudentID, int SubjectID, decimal Grade)
        {
            this.StudentID = StudentID;
            this.SubjectID = SubjectID;
            this.Grade = Grade;
        }

        public static clsGrade Find(int StudentID, int SubjectID)
        {
            decimal grade = 0;

            if (clsGradeData.GetGradeByStudentAndSubjectID(StudentID, SubjectID, ref grade))
                return new clsGrade(StudentID, SubjectID, grade);
            else
                return null;
        }

        public static bool InsertOrUpdate(int StudentID, int SubjectID, decimal Grade)
        {
            return clsGradeData.InsertOrUpdateGrade(StudentID, SubjectID, Grade);
        }

        public static DataTable GetGradesByClassID(int ClassID)
        {
            return clsGradeData.GetGradesByClassID(ClassID);
        }

        public static DataTable GetAllGrades()
        {
            return clsGradeData.GetAllGrades();
        }

        public static DataTable GetGradesByStudentID(int StudentID)
        {
            return clsGradeData.GetGradesByStudentID(StudentID);
        }
    }
}
