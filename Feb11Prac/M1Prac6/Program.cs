using System;
using System.Collections.Generic;

public class Employee
{
    public int EmployeeID { get; set; }
    public string Designation { get; set; }

    public Employee(int employeeID, string designation)
    {
        EmployeeID = employeeID;
        Designation = designation;
    }
}

public class EmployeeManagement
{
    private Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

    // Add Employee
    public void AddEmployee(int employeeID, string designation)
    {
        if (!employees.ContainsKey(employeeID))
        {
            employees[employeeID] = new Employee(employeeID, designation);
        }
    }

    // Update Designation
    public void UpdateDesignation(int employeeID, string newDesignation)
    {
        if (employees.ContainsKey(employeeID))
        {
            employees[employeeID].Designation = newDesignation;
            Console.WriteLine($"{employeeID} {newDesignation}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        EmployeeManagement manager = new EmployeeManagement();

        string input;
        
        while ((input = Console.ReadLine()) != null && input != "")
        {
            string[] parts = input.Split(' ');

            string command = parts[0];
            int employeeID = int.Parse(parts[1]);
            string designation = parts[2];

            if (command == "A")
            {
                manager.AddEmployee(employeeID, designation);
            }
            else if (command == "U")
            {
                manager.UpdateDesignation(employeeID, designation);
            }
        }
    }
}
