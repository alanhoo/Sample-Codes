using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HRPortal.Models;

namespace HRPortal.Data
{
    public class EmployeeDataBase
    {
        private static List<Employee> _employees;

        public EmployeeDataBase()
        {
            if (_employees == null)
            {
                _employees = new List<Employee>();
                _employees = getAllDefaultEmployees();
            }
        }

        private List<Employee> getAllDefaultEmployees()
        {
            return new List<Employee>
            {
                new Employee { Name = "Balzer, David", EmpID = "111"},
                new Employee { Name = "Wise, Eric", EmpID = "112"},
                new Employee { Name = "Ward, Eric", EmpID = "113"},
                new Employee { Name = "Pudelski, Victor", EmpID = "114"},
                new Employee { Name = "Dutkiewicz, Sarah", EmpID = "115"},
                new Employee { Name = "Clapper, Randall", EmpID = "116"}
            };
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public string getEmployeeName(string employeeID)
        {
            if (employeeID == null)
            {
                return employeeID;
            }
            return _employees.Find(i => i.EmpID == employeeID).Name;
        }

        //public string getEmployeeId(string employeeName)
        //{
        //    var employee = _employees.Find(i => i.Name == employeeName);
        //    return employee.EmpID;
        //}

        //public List<SelectListItem> CreateEmployeeList()
        //{
        //    List<SelectListItem> employeeList = new List<SelectListItem>();

        //    foreach (var employee in _employees)
        //    {
        //        employeeList.Add(new SelectListItem
        //        {
        //            Text = employee.Name,
        //            Value = employee.EmpID
        //        });
        //    }

        //    return employeeList;
        //} 
    }
}
