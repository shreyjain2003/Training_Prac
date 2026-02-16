using Microsoft.Data.SqlClient;
using System;
using System.Data;

class EmployeeManager
{
    static string cs =
        "Server=localhost,1433;" +
        "Database=TrainingDB;" +
        "User Id=sa;" +
        "Password=****" +
        "TrustServerCertificate=True;" +
        "Encrypt=False;";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Employee Manager ===");
            Console.WriteLine("1) List employees");
            Console.WriteLine("2) Add employee (Stored Procedure)");
            Console.WriteLine("3) Count employees (Output)");
            Console.WriteLine("4) Insert employee (Direct SQL)");
            Console.WriteLine("5) Update employee");
            Console.WriteLine("6) Delete employee");
            Console.WriteLine("0) Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1": ListEmployees(); break;
                    case "2": AddEmployeeSp(); break;
                    case "3": CountEmployeesSp(); break;
                    case "4": InsertEmployee(); break;
                    case "5": UpdateEmployee(); break;
                    case "6": DeleteEmployee(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }
    }

    // 🔹 SELECT
    static void ListEmployees()
    {
        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees ORDER BY EmployeeId";

        using var con = new SqlConnection(cs);
        using var cmd = new SqlCommand(sql, con);

        con.Open();
        using var reader = cmd.ExecuteReader();

        Console.WriteLine("\nID | Name | Dept | Salary");
        Console.WriteLine("----------------------------------");

        while (reader.Read())
        {
            Console.WriteLine($"{reader["EmployeeId"]} | {reader["FullName"]} | {reader["Department"]} | {reader["Salary"]}");
        }
    }

    // 🔹 INSERT (Direct SQL)
    static void InsertEmployee()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Dept: ");
        string dept = Console.ReadLine() ?? "";

        Console.Write("Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine() ?? "0");

        string sql = @"INSERT INTO dbo.Employees (FullName, Department, Salary)
                       VALUES (@FullName, @Department, @Salary)";

        using var con = new SqlConnection(cs);
        using var cmd = new SqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@FullName", name);
        cmd.Parameters.AddWithValue("@Department", dept);
        cmd.Parameters.AddWithValue("@Salary", salary);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine($"✅ Inserted {rows} row(s).");
    }

    // 🔹 INSERT (Stored Procedure with OUTPUT)
    static void AddEmployeeSp()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Dept: ");
        string dept = Console.ReadLine() ?? "";

        Console.Write("Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine() ?? "0");

        using var con = new SqlConnection(cs);
        using var cmd = new SqlCommand("dbo.sp_AddEmployee", con);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@FullName", name);
        cmd.Parameters.AddWithValue("@Department", dept);
        cmd.Parameters.AddWithValue("@Salary", salary);

        var outputParam = new SqlParameter("@NewEmployeeId", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };
        cmd.Parameters.Add(outputParam);

        con.Open();
        cmd.ExecuteNonQuery();

        int newId = (int)cmd.Parameters["@NewEmployeeId"].Value;
        Console.WriteLine($"✅ Added employee. New ID = {newId}");
    }

    // 🔹 UPDATE
    static void UpdateEmployee()
    {
        Console.Write("Employee ID to update: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("New Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("New Dept: ");
        string dept = Console.ReadLine() ?? "";

        Console.Write("New Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine() ?? "0");

        string sql = @"UPDATE dbo.Employees
                       SET FullName = @FullName,
                           Department = @Department,
                           Salary = @Salary
                       WHERE EmployeeId = @EmployeeId";

        using var con = new SqlConnection(cs);
        using var cmd = new SqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@EmployeeId", id);
        cmd.Parameters.AddWithValue("@FullName", name);
        cmd.Parameters.AddWithValue("@Department", dept);
        cmd.Parameters.AddWithValue("@Salary", salary);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        if (rows > 0)
            Console.WriteLine("✅ Employee updated successfully.");
        else
            Console.WriteLine("❌ Employee not found.");
    }

    // 🔹 DELETE
    static void DeleteEmployee()
    {
        Console.Write("Employee ID to delete: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        string sql = "DELETE FROM dbo.Employees WHERE EmployeeId = @EmployeeId";

        using var con = new SqlConnection(cs);
        using var cmd = new SqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@EmployeeId", id);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        if (rows > 0)
            Console.WriteLine("✅ Employee deleted successfully.");
        else
            Console.WriteLine("❌ Employee not found.");
    }

    // 🔹 COUNT (Stored Procedure OUTPUT)
    static void CountEmployeesSp()
    {
        using var con = new SqlConnection(cs);
        using var cmd = new SqlCommand("dbo.sp_CountEmployees", con);

        cmd.CommandType = CommandType.StoredProcedure;

        var totalParam = new SqlParameter("@Total", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };
        cmd.Parameters.Add(totalParam);

        con.Open();
        cmd.ExecuteNonQuery();

        int total = (int)cmd.Parameters["@Total"].Value;
        Console.WriteLine($"📊 Total employees = {total}");
    }
}
