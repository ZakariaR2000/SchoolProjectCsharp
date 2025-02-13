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
    public class clsStudentData
    {
        public static bool GetStudentInfoByID(int ID,ref string StudentNumber, ref int PersonID,
            ref int CreatedAdminID,ref DateTime CreatedDate, ref int ClassID , ref string Password)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * from Students where StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    CreatedAdminID = (int)reader["CreatedByAdminID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    ClassID = (int)reader["ClassID"];
                    StudentNumber = (string)reader["StudentNumber"];
                    Password = (string)reader["Password"];


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

        public static bool GetStudentInfoByPersonID(int PersonID, ref int StudentID, ref int CreatedByAdminID,
            ref DateTime CreatedDate, ref int ClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * from Students where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    StudentID = (int)reader["StudentID"];
                    CreatedByAdminID = (int)reader["CreatedByAdminID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    ClassID = (int)reader["ClassID"];


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

        public static int AddNewStudent(int PersonID, int CreatedByAdminID, int ClassID)
        {
            int StudentID = -1;

            string connectionString = clsDataAccessSettings.ConnectionString;

            string query = @"INSERT INTO Students (PersonID, CreatedByAdminID, CreatedDate, ClassID)
                     VALUES (@PersonID, @CreatedByAdminID, @CreatedDate, @ClassID);
                     SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@CreatedByAdminID", CreatedByAdminID);
                        command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        command.Parameters.AddWithValue("@ClassID", ClassID);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            StudentID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // سجل الخطأ أو اعرض رسالة توضيحية
                MessageBox.Show("Error: " + ex.Message);
            }

            return StudentID;
        }

        public static bool UpdateStudent(int StudentID, int CreatedByAdminID, int ClassID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Students  
                         SET 
                             CreatedByAdminID = @CreatedByAdminID,
                             CreatedDate = @CreatedDate,
                             ClassID = @ClassID
                         WHERE StudentID = @StudentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", StudentID);
                    command.Parameters.AddWithValue("@ClassID", ClassID);
                    command.Parameters.AddWithValue("@CreatedByAdminID", CreatedByAdminID);
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            Console.WriteLine("No rows were updated.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("SQL Error: " + ex.Message);
                        return false;
                    }
                }
            }

            return rowsAffected > 0;
        }

        public static DataTable GetAllStudents()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Students_View";

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

        public static bool DeleteStudent(int studentID)
        {
            int rowsAffected = 0;
            string query = @"DELETE FROM Students WHERE StudentID = @StudentID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                // هنا يمكنك تسجيل الخطأ أو عرضه كرسالة إذا أردت
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // معالجة أي أخطاء أخرى غير متعلقة بقاعدة البيانات
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return rowsAffected > 0;
        }

        public static bool IsStudentExists(int PersonID)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COUNT(1) FROM Students WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        exists = Convert.ToInt32(command.ExecuteScalar()) > 0;
                    }
                    catch (Exception ex)
                    {
                        // التعامل مع الأخطاء (يمكن عرض رسالة توضيحية)
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            return exists;
        }

        public static DataTable GetStudentsByClassID(int ClassID)
        {
            string query = @"
                            SELECT S.StudentID, P.FirstName+' '+ P.SecondName+' '+isnull(P.ThirdName,'')+' '+P.LastName as FullName, S.CreatedDate
                            FROM Students S
                            INNER JOIN People P ON S.PersonID = P.PersonID
                            WHERE S.ClassID = @ClassID";
            SqlParameter[] parameters = { new SqlParameter("@ClassID", ClassID) };
            return clsDataAccess.ExecuteParamerizedQuery(query, parameters);
        }

        public static bool GetStudentInfoByStudentNumberAndPassword(string StudentNumber, string Password,
            ref int StudentID, ref int PersonID, ref int CreatedByAdminID, 
            ref DateTime CreatedDate, ref int ClassID , ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * from Students where StudentNumber = @StudentNumber and Password =@Password ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentNumber", StudentNumber);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    StudentID = (int)reader["StudentID"];
                    PersonID = (int)reader["PersonID"];
                    CreatedByAdminID = (int)reader["CreatedByAdminID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    ClassID = (int)reader["ClassID"];
                    StudentNumber = (string)reader["StudentNumber"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];


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


        public static DataTable GetStudentsGradesByTeacherID(int TeacherID)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT 
    S.StudentID,
    P.FirstName + ' ' + P.LastName AS StudentName,
    G.WorkGrade,
    G.MidtermGrade,
    G.FinalGrade,
    G.Semester,
    Sub.SubjectName,
    T.TeacherID,
    T.UserID
FROM Grades G
INNER JOIN Students S ON G.StudentID = S.StudentID
INNER JOIN People P ON S.PersonID = P.PersonID
INNER JOIN Subjects Sub ON G.SubjectID = Sub.SubjectID
INNER JOIN TeacherSubjects TS ON Sub.SubjectID = TS.SubjectID
INNER JOIN Teachers T ON TS.TeacherID = T.TeacherID
WHERE T.TeacherID = @TeacherID
  AND TS.ClassID = @ClassID; -- يمكن إضافة شرط الفصل إذا لزم الأمر
";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherID", TeacherID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return dataTable;
        }
 



    }
}
