using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class Program
{
    public static void ShowTable(SqlConnection connection)
    {
        string query = "SELECT id, name, age, grade FROM dbo.student";

        using SqlCommand command = new(query, connection);
        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine(
                $"Id: {reader["id"]}, Name: {reader["name"]}, Age: {reader["age"]}, Grade: {reader["grade"]}");
        }

        Console.WriteLine();
    }

    public static void DeleteRow(SqlConnection connection)
    {
        Console.Write("Enter ID to delete: ");
        int id = int.Parse(Console.ReadLine()!);

        string query = "DELETE FROM student WHERE id = @id";

        using SqlCommand command = new(query, connection);
        command.Parameters.AddWithValue("@id", id);

        int result = command.ExecuteNonQuery();

        Console.WriteLine(result > 0 ? "Deleted Successfully" : "Delete Failed");
    }

    public static void InsertRow(SqlConnection connection)
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine()!);

        Console.Write("Enter Name: ");
        string? name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine()!);

        Console.Write("Enter Grade: ");
        string? grade = Console.ReadLine();

        string query = "INSERT INTO student (id, name, age, grade) VALUES (@id, @name, @age, @grade)";

        using SqlCommand command = new(query, connection);

        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@age", age);
        command.Parameters.AddWithValue("@grade", grade); // fixed casing

        int result = command.ExecuteNonQuery();

        Console.WriteLine(result > 0 ? "Inserted Successfully" : "Insert Failed");
    }

    public static void UpdateGrade(SqlConnection connection)
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine()!);

        Console.Write("Enter New Grade: ");
        string? grade = Console.ReadLine();

        string query = "UPDATE student SET grade = @grade WHERE id = @id";

        using SqlCommand command = new(query, connection);

        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@grade", grade);

        int result = command.ExecuteNonQuery();

        Console.WriteLine(result > 0 ? "Updated Successfully" : "Update Failed");
    }

    public static void Main(string[] args)
    {
        try
        {
            DotNetEnv.Env.Load();

            string? connectionString = Environment.GetEnvironmentVariable("ConnectionString");

            // Debug check
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.WriteLine("Connection string is missing. Check your .env file.");
                return;
            }

            Console.WriteLine("Connection string loaded successfully.");

            using SqlConnection connection = new(connectionString);
            connection.Open();

            if (connection.State == ConnectionState.Open)
                Console.WriteLine("✅ Database Connected Successfully!\n");

            int choice = 0;

            while (choice != 5)
            {
                Console.WriteLine("1 -> Show Table");
                Console.WriteLine("2 -> Delete Row");
                Console.WriteLine("3 -> Insert Row");
                Console.WriteLine("4 -> Update Grade");
                Console.WriteLine("5 -> Exit");
                Console.Write("Enter Choice: ");

                choice = int.Parse(Console.ReadLine()!);

                switch (choice)
                {
                    case 1:
                        ShowTable(connection);
                        break;

                    case 2:
                        DeleteRow(connection);
                        break;

                    case 3:
                        InsertRow(connection);
                        break;

                    case 4:
                        UpdateGrade(connection);
                        break;

                    case 5:
                        Console.WriteLine("Thank You!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
