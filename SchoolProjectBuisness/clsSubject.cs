using SchoolProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectBuisness
{
    public class clsSubject
    {
        public int ID { set; get; }
        public string SubjectName { set; get; }

        public clsSubject()

        {
            this.ID = -1;
            this.SubjectName = "";

        }

        private clsSubject(int ID, string SubjectName)

        {
            this.ID = ID;
            this.SubjectName = SubjectName;
        }

        public static clsSubject Find(int ID)
        {
            string SubjectName = "";

            if (clsCountryData.GetCountryInfoByID(ID, ref SubjectName))

                return new clsSubject(ID, SubjectName);
            else
                return null;

        }

        public static clsSubject Find(string SubjectName)
        {

            int ID = -1;

            if (clsSubjectData.GetSubjectInfoByName(SubjectName, ref ID))

                return new clsSubject(ID, SubjectName);
            else
                return null;

        }

        public static DataTable GetAllSubjects()
        {
            return clsSubjectData.GetAllSubjects();

        }

        public static DataTable GetSubjectsByClassID(int ClassID)
        {
            return clsSubjectData.GetSubjectsByClassID(ClassID);
        }

        public static async Task<int> GetSubjectID(string subjectName)
        {
            int? subjectID = await clsSubjectData.GetSubjectIDByNameAsync(subjectName);
            return subjectID ?? throw new Exception("Subject not found"); // أو إرجاع قيمة افتراضية
        }

    }
}
