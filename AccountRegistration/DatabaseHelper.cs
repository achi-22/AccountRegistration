using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
 
namespace AccountRegistration
{
    public static class DatabaseHelper
    {
        private static string connectionString =
            "Data Source=ACHILLES\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True";
        // Change this to your SQL Server instance and DB name

        // 1. Open database connection
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // 2. Insert new student (StudentNo should be unique)
        public static void InsertStudent(StudentInfoClass student)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
                INSERT INTO Students(StudentNo, FirstName, LastName, MiddleName, Program, Age, ContactNo, Birthday, Gender)
                VALUES (@StudentNo, @FirstName, @LastName, @MiddleName, @Program, @Age, @ContactNo, @Birthday, @Gender)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentNo", student.StudentNoProp);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstNameProp);
                cmd.Parameters.AddWithValue("@LastName", student.LastNameProp);
                cmd.Parameters.AddWithValue("@MiddleName", student.MiddleNameProp);
                cmd.Parameters.AddWithValue("@Program", student.ProgramProp);
                cmd.Parameters.AddWithValue("@Age", student.AgeProp);
                cmd.Parameters.AddWithValue("@ContactNo", student.ContactNoProp);
                cmd.Parameters.AddWithValue("@Birthday", student.BirthdayProp);
                cmd.Parameters.AddWithValue("@Gender", student.GenderProp);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // unique key violation
                        MessageBox.Show("Student Number must be unique!", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        throw;
                }
            }
        }

        // 3. Retrieve all students
        public static List<StudentInfoClass> GetAllStudents()
        {
            List<StudentInfoClass> students = new List<StudentInfoClass>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Students";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new StudentInfoClass
                    {
                        StudentNoProp = Convert.ToInt64(reader["StudentNo"]),
                        FirstNameProp = reader["FirstName"].ToString(),
                        LastNameProp = reader["LastName"].ToString(),
                        MiddleNameProp = reader["MiddleName"].ToString(),
                        ProgramProp = reader["Program"].ToString(),
                        AgeProp = Convert.ToInt64(reader["Age"]),
                        ContactNoProp = Convert.ToInt64(reader["ContactNo"]),
                        BirthdayProp = reader["Birthday"].ToString(),
                        GenderProp = reader["Gender"].ToString()
                    });
                }
            }
            return students;
        }
    }
}
