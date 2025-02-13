using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SchoolProjectDataAccess
{
    public class clsGradeData
    {
        public static bool GetGradeByStudentAndSubjectID(int StudentID, int SubjectID, ref decimal Grade)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Grade FROM StudentGrades WHERE StudentID = @StudentID AND SubjectID = @SubjectID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", StudentID);
            command.Parameters.AddWithValue("@SubjectID", SubjectID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The grade record was found
                    isFound = true;

                    Grade = (decimal)reader["Grade"];
                }
                else
                {
                    // No grade record found
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow, etc.)
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool InsertOrUpdateGrade(int StudentID, int SubjectID, decimal Grade)
        {
            bool isSuccess = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                IF EXISTS (SELECT 1 FROM StudentGrades WHERE StudentID = @StudentID AND SubjectID = @SubjectID)
                BEGIN
                    UPDATE StudentGrades 
                    SET Grade = @Grade 
                    WHERE StudentID = @StudentID AND SubjectID = @SubjectID
                END
                ELSE
                BEGIN
                    INSERT INTO StudentGrades (StudentID, SubjectID, Grade) 
                    VALUES (@StudentID, @SubjectID, @Grade)
                END";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", StudentID);
            command.Parameters.AddWithValue("@SubjectID", SubjectID);
            command.Parameters.AddWithValue("@Grade", Grade);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow, etc.)
                isSuccess = false;
            }
            finally
            {
                connection.Close();
            }

            return isSuccess;
        }

        public static DataTable GetGradesByClassID(int ClassID)
        {
            string query = @"
                SELECT 
                    S.StudentID,
                    P.FirstName + ' ' + P.LastName AS StudentName,
                    Sub.SubjectName,
                    G.Grade
                FROM 
                    StudentGrades G
                INNER JOIN 
                    Students S ON G.StudentID = S.StudentID
                INNER JOIN 
                    People P ON S.PersonID = P.PersonID
                INNER JOIN 
                    Subjects Sub ON G.SubjectID = Sub.SubjectID
                WHERE 
                    S.ClassID = @ClassID";

            SqlParameter[] parameters = { new SqlParameter("@ClassID", ClassID) };

            return clsDataAccess.ExecuteParamerizedQuery(query, parameters);
        }

        public static DataTable GetAllGrades()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM StudentGrades";

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
                // Handle the exception (log it, rethrow, etc.)
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static DataTable GetGradesByStudentID(int StudentID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT 
    Sub.SubjectName,
    G.WorkGrade,
    G.MidtermGrade,
    G.FinalGrade,
    CASE 
        WHEN G.WorkGrade IS NULL OR G.MidtermGrade IS NULL OR G.FinalGrade IS NULL 
            THEN 'NotYet'
        ELSE CAST((G.WorkGrade + G.MidtermGrade + G.FinalGrade) AS NVARCHAR)
    END AS TotalGrade
FROM 
    Grades G
INNER JOIN 
    Subjects Sub ON G.SubjectID = Sub.SubjectID
WHERE 
    G.StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", StudentID);

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
                // Handle the exception (log it, rethrow, etc.)
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

    }
}
