using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolProjectDataAccess
{
    public class clsClassData
    {
        public static bool GetClassInfoByID(int classID, ref string className, ref float classFees)
        {
            bool isFound = false;
            className = string.Empty;
            classFees = 0.0f;

            string query = "SELECT ClassName, ClassFees FROM Classes WHERE ClassID = @ClassID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassID", classID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            className = reader["ClassName"].ToString();

                            // حاول تحويل قيمة ClassFees إلى float بشكل آمن
                            if (!float.TryParse(reader["ClassFees"].ToString(), out classFees))
                            {
                                classFees = 0.0f; // تعيين قيمة افتراضية إذا كان التحويل غير ناجح
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الخطأ أو التعامل معه بطريقة أخرى
                // Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }

            return isFound;
        }

        public static bool GetClassInfoByClassName(string className, ref int id, ref float classFees)
        {
            bool isFound = false;
            id = -1;
            classFees = 0.0f;

            string query = "SELECT ClassID, ClassFees FROM Classes WHERE ClassName = @ClassName";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassName", className);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            id = Convert.ToInt32(reader["ClassID"]);
                            classFees = Convert.ToSingle(reader["ClassFees"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الأخطاء هنا
                isFound = false;
            }

            return isFound;
        }


        public static bool GetClassNameByID(int classID, ref string className)
        {
            bool isFound = false;
            className = string.Empty;

            string query = "SELECT ClassName FROM Classes WHERE ClassID = @ClassID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassID", classID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            className = reader["ClassName"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الأخطاء هنا
                isFound = false;
            }

            return isFound;
        }


        public static string GetClassNameByClassID(int classID)
        {
            string className = string.Empty;

            string query = "SELECT ClassName FROM Classes WHERE ClassID = @ClassID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassID", classID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            className = reader["ClassName"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الأخطاء هنا
            }

            return className;
        }



        public static DataTable GetAllClasses()
        {
            DataTable dt = new DataTable();

            string query = "SELECT * FROM Classes ORDER BY ClassID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الأخطاء هنا
            }

            return dt;
        }


        public static int AddNewClass(string className, float classFees)
        {
            int classID = -1;

            string query = @"INSERT INTO Classes (ClassName, ClassFees) 
                     VALUES (@ClassName, @ClassFees); 
                     SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassName", className);
                    command.Parameters.AddWithValue("@ClassFees", classFees);

                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        classID = insertedID;
                    }
                }
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الأخطاء هنا
            }

            return classID;
        }

        public static bool UpdateClass(int classID, string className, float classFees)
        {
            int rowsAffected = 0;

            string query = @"UPDATE Classes 
                     SET ClassName = @ClassName, ClassFees = @ClassFees 
                     WHERE ClassID = @ClassID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassID", classID);
                    command.Parameters.AddWithValue("@ClassName", className);
                    command.Parameters.AddWithValue("@ClassFees", classFees);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الأخطاء هنا
            }

            return rowsAffected > 0;
        }


        public static bool DoesClassNameExist(string className)
        {
            bool exists = false;

            string query = "SELECT COUNT(1) FROM Classes WHERE ClassName = @ClassName";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassName", className);
                    connection.Open();

                    // ExecuteScalar returns the first column of the first row in the result set
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    exists = (count > 0);
                }
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الأخطاء هنا
                exists = false;
            }

            return exists;
        }

        public static int GetClassIDByName(string className)
        {
            int classID = -1; // قيمة افتراضية في حالة عدم العثور على الصف

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT ClassID FROM Classes WHERE ClassName = @ClassName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClassName", className);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        classID = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    // يمكن تسجيل الخطأ هنا
                    Console.WriteLine(ex.Message);
                }
            }

            return classID;
        }


    }
}
