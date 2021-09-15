using System;
using System.IO;
using System.Reflection;

namespace EmployeesHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string path = @"D:\SourceCode\I\EmployeeData.csv";
            string EmployeeData = File.ReadAllText(path);

            new Employee(EmployeeData);

            Console.ReadLine();
        }
    }
}
