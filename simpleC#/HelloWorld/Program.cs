using System;
using System.Data.SqlClient;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=testdb;Trusted_Connection=True;";
            
            Console.WriteLine("Opening connection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 1. Create the table
                string createTableQuery = @"
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'test_table')
                    BEGIN
                        CREATE TABLE test_table (
                            test_field NVARCHAR(255)
                        );
                    END";

                Console.WriteLine("Creating table");
                using (SqlCommand createCommand = new SqlCommand(createTableQuery, connection))
                {
                    createCommand.ExecuteNonQuery();
                    Console.WriteLine("Table created successfully.");
                }

                // 2. Insert a row
                string insertQuery = "INSERT INTO test_table (test_field) VALUES (@value)";
                Console.WriteLine("Inserting data");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@value", "Rain in Spain falls mainly on the plain");
                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine("Row inserted successfully.");
                }
            }

        }
    }
}
