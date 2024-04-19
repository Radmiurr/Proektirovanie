using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using console.app;


namespace ConsoleApp1
{
    public class SqlManager
    {
        private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";


            public static List<Employee> GetEmployees()
            {
                List<Employee> employees = new List<Employee>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM Employee", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(new Employee
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Position = reader.GetString(2),
                                    Salary = reader.GetDecimal(3),
                                    HoursWorked = reader.GetInt32(4),
                                    Seniority = reader.GetInt32(5)
                                });
                            }
                        }
                    }

                    connection.Close();
                }

                return employees;
            }
        
    }
}
