using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectDataAccess
{
    public class clsSubjectData
    {
        public static bool GetSubjectInfoByID(int ID, ref string SubjectName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries WHERE SubjectID = @SubjectID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SubjectID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    SubjectName = (string)reader["SubjectName"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetSubjectInfoByName(string SubjectName, ref int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries WHERE SubjectName = @SubjectName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SubjectName", SubjectName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ID = (int)reader["SubjectID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllSubjects()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Subjects";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable GetSubjectsByClassID(int ClassID)
        {
            string query = @"
                            SELECT Subjects.SubjectName, 
                                   P.FirstName + ' ' + P.LastName + ' ' + ISNULL(P.ThirdName, '') + ' ' + P.LastName AS Teacher, 
                                   TS.CreatedDate
                            FROM TeacherSubjects TS
                            INNER JOIN Subjects ON Subjects.SubjectID = TS.SubjectID
                            INNER JOIN Teachers T ON T.TeacherID = TS.TeacherID
                            INNER JOIN People P ON T.PersonID = P.PersonID
                            WHERE TS.ClassID = @ClassID;";
            SqlParameter[] parameters = { new SqlParameter("@ClassID", ClassID) };
            return clsDataAccess.ExecuteParamerizedQuery(query, parameters);
        }


        public static async Task<int?> GetSubjectIDByNameAsync(string subjectName)
        {
            // التحقق من صحة الاسم المدخل
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                Console.WriteLine("⚠️ الاسم المدخل للمادة فارغ أو يحتوي على مسافات فقط.");
                return null;
            }

            // تنظيف الاسم لتجنب الإدخال غير الصحيح
            subjectName = subjectName.Trim();

            const string query = "SELECT TOP 1 SubjectID FROM Subjects WHERE SubjectName = @SubjectName";

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // إضافة المعامل وضبط نوعه
                    cmd.Parameters.Add("@SubjectName", SqlDbType.NVarChar, 100).Value = subjectName;

                    await conn.OpenAsync();
                    object result = await cmd.ExecuteScalarAsync();

                    // إرجاع النتيجة إذا كانت صحيحة
                    return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : (int?)null;
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"❌ خطأ في قاعدة البيانات: {sqlEx.Message}");
                // يمكن هنا تسجيل الخطأ في ملف Log أو قاعدة بيانات للأخطاء
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ خطأ غير متوقع: {ex.Message}");
            }

            return null; // في حالة الخطأ أو عدم العثور على المادة
        }

    }
}
