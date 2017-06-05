using FC;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FConverters.Tests
{
    [TestClass]
    public class ObjectCloneTests
    {
        [TestMethod]
        public void CloneTest()
        {
            Employee emp = new Employee();
            emp.EmployeeId = 1000;
            emp.EmployeeName = "Jignesh";
            emp.Department = new Department { DepartmentId = 1, DepartmentName = "Examination" };



            Employee clone = ObjectCopier.Clone<Employee>(emp) as Employee;

            clone.ShouldBeEquivalentTo(emp);
        }
    
    }



    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    public class Employee 
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Department Department { get; set; }
    }

}
