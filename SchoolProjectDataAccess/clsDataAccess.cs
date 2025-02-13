using DVLD_DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;

public static class clsDataAccess
{
    // استبدل هذا الاتصال بسلسلة الاتصال الخاصة بك
    private static string _connectionString = clsDataAccessSettings.ConnectionString;

    // تنفيذ استعلام SQL مع معاملات (Parameterized Query) وإرجاع النتائج في DataTable
    public static DataTable ExecuteParamerizedQuery(string query, SqlParameter[] parameters)
    {
        DataTable dt = new DataTable();

        try
        {
            // إنشاء اتصال بقاعدة البيانات
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // فتح الاتصال
                conn.Open();

                // إنشاء أمر SQL مع الاستعلام والمعاملات
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // إضافة المعاملات إلى الأمر
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    // إنشاء SqlDataAdapter لملء DataTable بالبيانات
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt); // ملء DataTable بالنتائج
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // التعامل مع الأخطاء (يمكنك تسجيلها أو عرض رسالة)
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        return dt; // إرجاع DataTable بالبيانات
    }

    // تنفيذ استعلام SQL فقط (مثل INSERT, UPDATE, DELETE) دون إرجاع بيانات
    public static int ExecuteNonQuery(string query, SqlParameter[] parameters)
    {
        int rowsAffected = 0;

        try
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    // تنفيذ الأمر واسترجاع عدد الصفوف المتأثرة
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        return rowsAffected;
    }

    // تنفيذ استعلام وإرجاع قيمة فردية مثل COUNT أو MAX أو SUM
    public static object ExecuteScalar(string query, SqlParameter[] parameters)
    {
        object result = null;

        try
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    // تنفيذ الأمر واسترجاع القيمة الفردية
                    result = cmd.ExecuteScalar();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        return result;
    }
}
