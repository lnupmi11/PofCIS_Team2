using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=NORTHWND;"
            + "Integrated Security=true";

            var task_1_queryString = "SELECT * FROM Employees WHERE EmployeeID = 8";
            var task_3_queryString = "SELECT FirstName, LastName FROM Employees WHERE FirstName Like \'A%\'";
            var task_13_queryString = "SELECT DISTINCT FirstName, LastName FROM Employees " +
                "INNER JOIN Orders ON Employees.EmployeeID = Orders.EmployeeID " +
                "WHERE ShipCity='Madrid'";
            var task_17_queryString = "SELECT  ContactName, COUNT(Orders.CustomerID) FROM Customers " +
                "INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID " +
                "WHERE Customers.Country= 'France' GROUP BY ContactName";
            var task_22_queryString = "SELECT DISTINCT ContactName FROM Customers " +
                "INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID " +
                "WHERE  Orders.ShipCountry <> 'France'";
            var task_29_queryString = "SELECT Employees.FirstName, Employees.LastName, Chiefs.FirstName, Chiefs.LastName FROM Employees " +
                "LEFT JOIN Employees AS Chiefs ON Employees.ReportsTo = Chiefs.EmployeeID";
            var task_31_queryString = "INSERT INTO Employees (FirstName, LastName, BirthDate, HireDate, Address, City, Country, Notes) " +
                $"VALUES('Steve', 'Spencer','1988-01-01 12:00','2010-01-01 12:00', 'Street 9', 'Lviv', 'Ukraine', 'Andriana')";
            var task_34_queryString = "UPDATE Employees " +
                $"Set HireDate = @Date WHERE Notes LIKE 'Andriana'";

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var query_1 = new Query(task_1_queryString, "Task 1",connection);
                    query_1.PrintResult(new int[]{0,1,2,3,4,5,6,7,8,9});
                    query_1.CloseReader();

                    var query_3 = new Query(task_3_queryString, "Task 3", connection);
                    query_3.PrintResult(new int[] { 0, 1});
                    query_3.CloseReader();

                    var query_13 = new Query(task_13_queryString, "Task 13", connection);
                    query_13.PrintResult(new int[] { 0, 1 });
                    query_13.CloseReader();

                    var query_17 = new Query(task_17_queryString, "Task 17", connection);
                    query_17.PrintResult(new int[] { 0, 1 });
                    query_17.CloseReader();

                    var query_22 = new Query(task_22_queryString, "Task 22", connection);
                    query_22.PrintResult(new int[] { 0 });
                    query_22.CloseReader();

                    var query_29 = new Query(task_29_queryString, "Task 29", connection);
                    query_29.PrintResult(new int[] { 0,1 ,2 ,3 });
                    query_29.CloseReader();
                    for (var i = 0; i < 5; ++i)
                    {
                        var query_31 = new Query(task_31_queryString, "Task 31", connection);
                        //query_31.PrintResult(new int[] { 0, 1, 2, 3 });
                        query_31.CloseReader();
                    }
                    var query_34 = new Query(task_34_queryString, "Task 34", connection, "@Date", DateTime.Now.ToString("yyyy-MM-dd hh:mm"));
                    query_34.PrintResult(new int[] { 0, 1, 2, 3 });
                    query_34.CloseReader();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}

