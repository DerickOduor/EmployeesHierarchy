using EmployeesHierarchy;
using System;
using System.Collections.Generic;
using Xunit;

namespace EmployeesHierarchyTest
{
    public class EmployeeTest
    {
        [Theory]
        [InlineData("1")]
        [InlineData("100")]
        public void PassTestSalary(string Value)
        {
            Employee employee=new Employee();
            int result =employee.ValidateSalary(Value);

            Assert.True(result != 0, Value+" should be an integer.");
        }
        [Theory]
        [InlineData("-1")]
        [InlineData("0")]
        public void FailTestSalary(string Value)
        {
            Employee employee=new Employee();
            int result =employee.ValidateSalary(Value);

            Assert.True(result == 0, Value+" should be greater than zero.");
        }

        //[Theory]
        ////[InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 2, 300\n12, 11, 500")]
        ////[InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11,, 300")]
        //[InlineData("1,,10002, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n10, 11, 400")]
        ////[InlineData("1,,10002, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n6, 5, 300")]
        ////[InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 12, 300\n12, 11, 500")]
        //public void PassTestValidation(string EmployeeCSV)
        //{
        //    Action testCode = () => { new Employee(EmployeeCSV); };

        //    var ex = Record.Exception(testCode);

        //    Assert.NotNull(ex);
        //    Assert.IsType<EmployeeException>(ex);
        //}

        //[Theory]
        //[InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 2, 300\n12, 11, 500")]
        //[InlineData("1,,10002, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n10, 11, 400")]
        //[InlineData("1,,10002, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n6, 5, 300")]
        //[InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 12, 300\n12, 11, 500")]
        //public void FailTestValidation(string EmployeeCSV)
        //{
        //    Action testCode = () => { new Employee(EmployeeCSV); };

        //    var ex = Record.Exception(testCode);

        //    Assert.Null(ex);
        //    Assert.IsNotType<EmployeeException>(ex);
        //}

        [Theory]
        [InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 2, 300\n12, 11, 500")]
        //[InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11,, 300")]
        public void PassTestNumberOfCEOs(string EmployeeCSV)
        {
            Employee employee=new Employee(EmployeeCSV);
            bool result = employee.ValidateNumberOfCeos(employee.Employees);

            Assert.True(result, "CEO is one.");
        }

        [Theory]
        //[InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 2, 300\n12, 11, 500")]
        [InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11,, 300")]
        public void FailTestNumberOfCEOs(string EmployeeCSV)
        {
            Employee employee=new Employee(EmployeeCSV);
            bool result = employee.ValidateNumberOfCeos(employee.Employees);

            Assert.False(result, "CEO is not one.");
        }

        [Theory]
        [InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 2, 300\n12, 11, 500")]
        //[InlineData("1,,10002, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n10, 11, 400")]
        public void PassTestManagersAreEmployees(string EmployeeCSV)
        {
            Employee employee=new Employee(EmployeeCSV);
            bool result = employee.ValidateManagersAreEmployees(employee.Employees);

            Assert.True(result, "Managers must be employees.");
        }

        [Theory]
        //[InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 2, 300\n12, 11, 500")]
        [InlineData("1,,10002, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n10, 11, 400")]
        public void FailTestManagersAreEmployees(string EmployeeCSV)
        {
            Employee employee=new Employee(EmployeeCSV);
            bool result = employee.ValidateManagersAreEmployees(employee.Employees);

            Assert.False(result, "Managers must be employees.");
        }

        [Theory]
        [InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 2, 300\n12, 11, 500")]
        //[InlineData("1,,10002, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n6, 5, 300")]
        public void PassTestNumberOfEmployeeManager(string EmployeeCSV)
        {
            Employee employee=new Employee(EmployeeCSV);
            bool result = employee.ValidateManagersAreEmployees(employee.Employees);

            Assert.True(result, "Employee must have only one manager.");
        }

        [Theory]
        //[InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 2, 300\n12, 11, 500")]
        [InlineData("1,,10002, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n6, 5, 300")]
        public void FailTestNumberOfEmployeeManager(string EmployeeCSV)
        {
            Employee employee=new Employee(EmployeeCSV);
            bool result = employee.ValidateManagersAreEmployees(employee.Employees);

            Assert.False(result, "Employee must have only one manager.");
        }

        [Theory]
        //[InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 12, 300\n12, 11, 500")]
        [InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 2, 300\n12, 11, 500")]
        public void PassTestCircularReferencing(string EmployeeCSV)
        {
            Employee employee=new Employee(EmployeeCSV);
            bool result = employee.ValidateCircularReferencing(employee.Employees);

            Assert.True(result, "There is no circular referencing.");
        }

        [Theory]
        //[InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 2, 300\n12, 11, 500")]
        [InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 12, 300\n12, 11, 500")]
        public void FailTestCircularReferencing(string EmployeeCSV)
        {
            Employee employee=new Employee(EmployeeCSV);
            bool result = employee.ValidateCircularReferencing(employee.Employees);

            Assert.False(result, "There is no circular referencing.");
        }

        //[Theory]
        //[InlineData("1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 12, 300\n12, 11, 500")]
        //public void TestCircularReferencingException(string EmployeeCSV)
        //{
        //    Action testCode = () => { new Employee(EmployeeCSV); };

        //    var ex = Record.Exception(testCode);

        //    Assert.NotNull(ex);
        //    Assert.IsType<EmployeeException>(ex);
        //}

        [Theory]
        [InlineData("1", "1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 2, 300\n12, 11, 500")]
        [InlineData("2", "1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 2, 300\n12, 11, 500")]
        [InlineData("3", "1,,1000\n2, 1, 800\n3, 1, 500\n4, 2, 500\n6, 2, 500\n5, 1, 500\n11, 2, 300\n12, 11, 500")]
        public void TestSalaryBudget(string ManagerId, string EmployeeCSV)
        {
            Employee employee = new Employee(EmployeeCSV);
            long result = employee.SalaryBudget(ManagerId);

            Assert.NotNull(result);
        }
    }
}
