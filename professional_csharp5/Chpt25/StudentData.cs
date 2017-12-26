using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Chpt25
{
    public class StudentData
    {
        public async Task<int> AddStudentAsync(Student student)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chpt25_DB"].ConnectionString);
            await connection.OpenAsync();
            try
            {


                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Students " +
                                      "(FirstName, LastName, Company) VALUES " +
                                      "(@FirstName, @LastName, @Company)";
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@Company", student.Company);

                Task<int> t = command.ExecuteNonQueryAsync();


                return await t;
            }
            
            finally
            {
                connection.Close();
            }
            
        }

        public async Task AddStudentAsync(Student student, Transaction tx)
        {
            //Contract.Requires<ArgumentNullException>(student!=null);
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chpt25_DB"].ConnectionString);
            await connection.OpenAsync();

            try
            {
                if (tx != null)
                    connection.EnlistTransaction(tx);


                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Students " +
                                      "(FirstName, LastName, Company) VALUES " +
                                      "(@FirstName, @LastName, @Company)";
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@Company", student.Company);

                await command.ExecuteNonQueryAsync();
            }
            finally
            {
                connection.Close();
            }
        }


        public void AddStudent(Student student, Transaction tx)
        {
            //Contract.Requires<ArgumentNullException>(student!=null);
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chpt25_DB"].ConnectionString);
            connection.Open();

            try
            {
                if (tx != null)
                    connection.EnlistTransaction(tx);


                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Students " +
                                      "(FirstName, LastName, Company) VALUES " +
                                      "(@FirstName, @LastName, @Company)";
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@Company", student.Company);

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
