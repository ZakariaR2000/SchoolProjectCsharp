using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolProjectDataAccess
{
    public class clsAdminData
    {
        // 1. Get Admin Info by AdminID
        public static bool GetAdminInfoByAdminID(int AdminID, ref int PersonID, ref string AdminName,
                    ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Admins WHERE AdminID = @AdminID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdminID", AdminID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    AdminName = (string)reader["AdminName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        // 2. Add New Admin
        public static int AddNewAdmin(int PersonID, string AdminName, string Password, bool IsActive)
        {
            int AdminID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Admins (PersonID, AdminName, Password, IsActive)
                             VALUES (@PersonID, @AdminName, @Password, @IsActive);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@AdminName", AdminName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    AdminID = insertedID;
                }
            }
            catch (Exception)
            {
                AdminID = -1;
            }
            finally
            {
                connection.Close();
            }

            return AdminID;
        }

        // 3. Update Admin Info
        public static bool UpdateAdmin(int AdminID, int PersonID, string AdminName, string Password, bool IsActive)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Admins
                             SET PersonID = @PersonID, AdminName = @AdminName, 
                                 Password = @Password, IsActive = @IsActive
                             WHERE AdminID = @AdminID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@AdminName", AdminName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@AdminID", AdminID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        // 4. Delete Admin
        public static bool DeleteAdmin(int AdminID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "DELETE FROM Admins WHERE AdminID = @AdminID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdminID", AdminID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        // 5. Get All Admins
        public static DataTable GetAllAdmins()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT AdminID, AdminName, IsActive, PersonID FROM Admins";

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
            catch (Exception)
            {
                // Handle exception
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        // 6. Check if Admin Exists
        public static bool IsAdminExist(int AdminID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT 1 FROM Admins WHERE AdminID = @AdminID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdminID", AdminID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetAdminInfoByPersonID(int personID, ref int adminID ,ref string adminName, ref string Password , ref bool isActive)
        {
            string query = "SELECT AdminID, IsActive FROM Admins WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", personID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            adminID = Convert.ToInt32(reader["AdminID"]);
                            isActive = Convert.ToBoolean(reader["IsActive"]);
                            adminName = (string)reader["AdminName"];
                            Password = (string)reader["Password"];
                            return true;
                        }
                        return false;
                    }
                }
            }
        }

        public static bool GetAdminInfoByAdminNameAndPassword(string AdminName, string password, ref int adminID, ref int personID, ref bool isActive)
        {
            string query = "SELECT AdminID, PersonID, IsActive FROM Admins WHERE AdminName = @AdminName AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@AdminName", AdminName);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            adminID = Convert.ToInt32(reader["AdminID"]);
                            personID = Convert.ToInt32(reader["PersonID"]);
                            isActive = Convert.ToBoolean(reader["IsActive"]);
                            return true;
                        }
                        return false;
                    }
                }
            }
        }


    }
}
