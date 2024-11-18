using System;
using Microsoft.Data.SqlClient;


class Program
{
    static void Main(string[] args)
    {
        // Define the connection string
        string connectionString = "Server=DESKTOP-M485FJE\\SQLEXPRESS;Database=QuizDB;Trusted_Connection=True;";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection established successfully!");

                // Example: Fetch Users
                string query = "SELECT * FROM Users;";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"UserID: {reader["UserID"]}, UserName: {reader["UserName"]}, UserEmail: {reader["UserEmail"]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
