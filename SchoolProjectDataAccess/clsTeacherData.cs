using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SchoolProjectDataAccess
{
    public class clsTeacherData
    {
        public static bool GetTeahcerInfoByID(int TeacherID, ref int PersonID,
            ref int CreatedByAdminID, ref DateTime CreatedDate ,ref int UserID)
        {
            bool isFound = false;
            string query = "SELECT PersonID, CreatedByAdminID, CreatedDate,UserID FROM Teachers WHERE TeacherID = @TeacherID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TeacherID", TeacherID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            PersonID = (int)reader["PersonID"];
                            CreatedByAdminID = (int)reader["CreatedByAdminID"];
                            CreatedDate = (DateTime)reader["CreatedDate"];
                            UserID = (int)reader["UserID"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    isFound = false;
                }
            }

            return isFound;
        }


        public static bool GetTeacherInfoByPersonID(int PersonID, ref int TeacherID,
            ref int CreatedByUserID, ref DateTime CreatedDate,ref int UserID)
        {
            bool isFound = false;
            string query = "SELECT TeacherID, CreatedByUserID, CreatedDate , UserID FROM Teachers WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            TeacherID = (int)reader["TeacherID"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                            CreatedDate = (DateTime)reader["CreatedDate"];
                            UserID = (int)reader["UserID"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    isFound = false;
                }
            }

            return isFound;
        }

        public static int AddNewTeacher(int PersonID, int CreatedByAdminID,int UserID)
        {
            int TeacherID = -1;
            string query = @"
        INSERT INTO Teachers (PersonID, CreatedByAdminID, CreatedDate,UserID)
        VALUES (@PersonID, @CreatedByAdminID, @CreatedDate , @UserID);
        SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@CreatedByAdminID", CreatedByAdminID);
                command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        TeacherID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                }
            }

            return TeacherID;
        }


        public static bool UpdateTeacher(int TeacherID, int PersonID, int CreatedByAdminID ,int UserID)
        {
            bool success = false;
            string query = @"
        UPDATE Teachers 
        SET PersonID = @PersonID, 
            CreatedByUserID = @CreatedByUserID, 
            CreatedDate = @CreatedDate,
            UserID = @UserID
        WHERE TeacherID = @TeacherID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TeacherID", TeacherID);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByAdminID);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                try
                {
                    connection.Open();
                    success = command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    // Handle exception
                }
            }

            return success;
        }


        // Method 5: GetAllTeachers - No ClassID needed
        public static DataTable GetAllTeachers()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Techer_View";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
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
                catch (Exception ex)
                {
                    // Handle exception (log it, rethrow it, etc.)
                }
            }

            return dt;
        }

        public static bool GetTeacherInfoByUserNameAndPassword(string UserName, string Password,
            ref int TeacherID, ref int PersonID, ref int CreatedByAdminID,
            ref DateTime CreatedDate, ref bool IsActive , ref int UserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT 
            Teachers.TeacherID, 
            Teachers.PersonID, 
            Teachers.CreatedDate, 
            Teachers.CreatedByAdminID, 
            Teachers.UserID,
            Users.IsActive
        FROM 
            Teachers 
        INNER JOIN 
            Users 
        ON 
            Teachers.UserID = Users.UserID
        WHERE 
            Users.UserName = @UserName AND Users.Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // السجل موجود
                    isFound = true;

                    TeacherID = (int)reader["TeacherID"];
                    PersonID = (int)reader["PersonID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    CreatedByAdminID = (int)reader["CreatedByAdminID"];
                    IsActive = (bool)reader["IsActive"];
                    UserID = (int)reader["UserID"];
                }
                else
                {
                    // السجل غير موجود
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


        public static DataTable GetSubjectsAndClassesByTeacherID(int teacherID)
        {
            DataTable resultTable = new DataTable();

            string connectionString = clsDataAccessSettings.ConnectionString;
            string query = @"
                            SELECT DISTINCT 
                                TS.SubjectID, 
                                Sub.SubjectName, 
                                TS.ClassID
                            FROM TeacherSubjects TS
                            INNER JOIN Subjects Sub ON TS.SubjectID = Sub.SubjectID
                            WHERE TS.TeacherID = @TeacherID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TeacherID", teacherID);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(resultTable);
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    throw new Exception("Error fetching subjects and classes: " + ex.Message);
                }
            }

            return resultTable;
        }

        public static int AuthenticateTeacher(string username, string password)
        {
            string query = @"SELECT TeacherID FROM Teachers
                             inner join Users u on U.UserID = Teachers.UserID
                             WHERE u.UserName = @UserName AND u.Password = @Password";
            int teacherID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        teacherID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error authenticating teacher: " + ex.Message);
                }
            }

            return teacherID; // Return -1 if authentication failed
        }

        public static DataTable GetClassesByTeacher(int teacherID)
        {
            DataTable resultTable = new DataTable();
            string query = @"
        SELECT DISTINCT TS.ClassID
FROM TeacherSubjects TS
inner join Teachers on Teachers.TeacherID = TS.TeacherID
inner join Users on Teachers.UserID = Users.UserID
WHERE Users.UserID = @TeacherID";

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TeacherID", teacherID);

                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(resultTable);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching classes: " + ex.Message);
                }
            }

            return resultTable;
        }

        public static DataTable GetSubjectsByTeacherAndClass(int userID, int classID)
        {
            DataTable resultTable = new DataTable();
            string query = @"
        SELECT DISTINCT TS.SubjectID, S.SubjectName
FROM TeacherSubjects TS
INNER JOIN Subjects S ON TS.SubjectID = S.SubjectID
Inner join Teachers T on t.TeacherID = TS.TeacherID
inner join Users U on U.UserID = T.UserID
WHERE U.UserID = @UserID AND TS.ClassID = @ClassID";

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@ClassID", classID);

                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(resultTable);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching subjects: " + ex.Message);
                }
            }

            return resultTable;
        }



        public static DataTable GetStudentsWithGrades(int classID, int subjectID)
        {
            DataTable resultTable = new DataTable();
            string query = @"
        SELECT 
            P.FirstName + ' ' + P.LastName AS StudentName, 
            G.WorkGrade, 
            G.MidtermGrade, 
            G.FinalGrade
        FROM Students S
        INNER JOIN People P ON S.PersonID = P.PersonID
        INNER JOIN Grades G ON S.StudentID = G.StudentID
        WHERE S.ClassID = @ClassID AND G.SubjectID = @SubjectID";

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClassID", classID);
                cmd.Parameters.AddWithValue("@SubjectID", subjectID);

                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(resultTable);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching student grades: " + ex.Message);
                }
            }

            return resultTable;
        }


    }
}
