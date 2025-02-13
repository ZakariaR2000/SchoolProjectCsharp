using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SchoolProjectDataAccess
{
    public class clsTeacherSubjectsData
    {
        // Get teacher info with ClassID
        public static bool GetTeacherInfoByID(int teacherID, ref int subjectID, ref int classID, ref int createdByUserID,
            ref DateTime createdDate, ref bool status)
        {
            subjectID = -1;
            classID = -1;
            createdByUserID = -1;
            createdDate = DateTime.MinValue;
            status = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT SubjectID, ClassID, CreatedByUserID, CreatedDate, Status FROM TeacherSubjects WHERE TeacherID = @TeacherID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@TeacherID", SqlDbType.Int).Value = teacherID;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                subjectID = reader.GetInt32(reader.GetOrdinal("SubjectID"));
                                classID = reader.GetInt32(reader.GetOrdinal("ClassID"));
                                createdByUserID = reader.GetInt32(reader.GetOrdinal("CreatedByUserID"));
                                createdDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                                status = reader.GetBoolean(reader.GetOrdinal("Status"));

                                return true; // Record found
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception (log it or display it)
                        return false;
                    }
                }
            }

            return false; // Record not found
        }

        // Get teacher info with SubjectID and ClassID
        public static bool GetTeacherInfoByIDandSubjectID(int teacherID, int subjectID, int classID, ref int createdByUserID,
            ref DateTime createdDate, ref bool status)
        {
            createdByUserID = -1;
            createdDate = DateTime.MinValue;
            status = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT CreatedByUserID, CreatedDate, Status FROM TeacherSubjects WHERE TeacherID = @TeacherID AND SubjectID = @SubjectID AND ClassID = @ClassID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@TeacherID", SqlDbType.Int).Value = teacherID;
                    command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
                    command.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                createdByUserID = reader.GetInt32(reader.GetOrdinal("CreatedByUserID"));
                                createdDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                                status = reader.GetBoolean(reader.GetOrdinal("Status"));

                                return true; // Record found
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception
                        return false;
                    }
                }
            }

            return false; // Record not found
        }

        // Add teacher with SubjectID and ClassID
        public static bool AddTeacherSubject(int teacherID, int subjectID, int classID)
        {
            bool isSuccess = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "INSERT INTO TeacherSubjects (TeacherID, SubjectID, ClassID) VALUES (@TeacherID, @SubjectID, @ClassID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherID", teacherID);
                    command.Parameters.AddWithValue("@SubjectID", subjectID);
                    command.Parameters.AddWithValue("@ClassID", classID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isSuccess = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Handle the error
                    }
                }
            }

            return isSuccess;
        }

        // Update teacher with SubjectID and ClassID
        public static bool UpdateTeacherSubject(int teacherID, int subjectID, int classID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE TeacherSubjects SET SubjectID = @SubjectID, ClassID = @ClassID WHERE TeacherID = @TeacherID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherID", teacherID);
                    command.Parameters.AddWithValue("@SubjectID", subjectID);
                    command.Parameters.AddWithValue("@ClassID", classID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception if necessary
                    }
                }
            }

            return (rowsAffected > 0);
        }

        // Get subjects by TeacherID and ClassID
        public static DataTable GetSubjectsByTeacherID(int teacherID, int classID)
        {
            DataTable subjectsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                SELECT s.SubjectName 
                FROM TeacherSubjects ts
                INNER JOIN Subjects s ON ts.SubjectID = s.SubjectID
                WHERE ts.TeacherID = @TeacherID AND ts.ClassID = @ClassID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherID", teacherID);
                    command.Parameters.AddWithValue("@ClassID", classID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            subjectsTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the error
                    }
                }
            }

            return subjectsTable;
        }

        // Get teachers by SubjectID and ClassID
        public static DataTable GetTeachersBySubjectID(int subjectID, int classID)
        {
            DataTable teachersTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                SELECT t.PersonID, t.TeacherID 
                FROM TeacherSubjects ts
                INNER JOIN Teachers t ON ts.TeacherID = t.TeacherID
                WHERE ts.SubjectID = @SubjectID AND ts.ClassID = @ClassID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SubjectID", subjectID);
                    command.Parameters.AddWithValue("@ClassID", classID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            teachersTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the error
                    }
                }
            }

            return teachersTable;
        }

        // Check if relationship exists (TeacherID, SubjectID, ClassID)
        public static bool CheckIfRelationshipExists(int teacherID, int subjectID, int classID)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM TeacherSubjects WHERE TeacherID = @TeacherID AND SubjectID = @SubjectID AND ClassID = @ClassID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherID", teacherID);
                    command.Parameters.AddWithValue("@SubjectID", subjectID);
                    command.Parameters.AddWithValue("@ClassID", classID);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        exists = (count > 0);
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception if necessary
                    }
                }
            }

            return exists;
        }

        // Get all teacher subjects with ClassID
        public static DataTable GetAllTeacherSubjects()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                SELECT t.TeacherID, t.PersonID, p.FirstName + ' ' + p.LastName AS FullName, 
                       s.SubjectName, ts.Status, ts.ClassID
                FROM TeacherSubjects ts
                INNER JOIN Teachers t ON ts.TeacherID = t.TeacherID
                INNER JOIN Subjects s ON ts.SubjectID = s.SubjectID
                INNER JOIN People p ON t.PersonID = p.PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception if necessary
                    }
                }
            }

            return dt;
        }

        // Delete teacher subject with ClassID
        public static bool RemoveTeacherSubject(int teacherID, int subjectID, int classID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM TeacherSubjects WHERE TeacherID = @TeacherID AND SubjectID = @SubjectID AND ClassID = @ClassID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherID", teacherID);
                    command.Parameters.AddWithValue("@SubjectID", subjectID);
                    command.Parameters.AddWithValue("@ClassID", classID);

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception
                        return false;
                    }
                }
            }
        }

        public static DataTable GetTeachersByClassID(int classID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT DISTINCT t.TeacherID, p.FirstName + ' ' + p.LastName AS TeacherName 
            FROM TeacherSubjects ts
            INNER JOIN Teachers t ON ts.TeacherID = t.TeacherID
            INNER JOIN People p ON t.PersonID = p.PersonID
            WHERE ts.ClassID = @ClassID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassID", classID);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static int GetSubjectIDByName(string subjectName)
        {
            int subjectID = -1;
            string query = "SELECT SubjectID FROM Subjects WHERE SubjectName = @SubjectName";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SubjectName", subjectName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out subjectID))
                    {
                        return subjectID;
                    }
                }
                catch (Exception ex)
                {
                    // التعامل مع الاستثناءات
                }
            }

            return subjectID;
        }


    }
}
