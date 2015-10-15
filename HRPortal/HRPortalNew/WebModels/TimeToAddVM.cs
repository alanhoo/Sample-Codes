using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Data;
using HRPortal.Models;

namespace HRPortalNew.WebModels
{
    public class TimeToAddVM
    {
        public Time TimeToAdd { get; set; }
        public List<SelectListItem> EmployeeList { get; set; }

        public TimeToAddVM()
        {
            TimeToAdd = new Time();
            EmployeeList = new List<SelectListItem>();
            CreateEmployeeList();
        }

        public void CreateEmployeeList()
        {
            EmployeeDataBase ed = new EmployeeDataBase();
            List<Employee> employees = ed.GetAllEmployees();

            foreach (var employee in employees)
            {
                EmployeeList.Add(new SelectListItem
                {
                    Text = employee.Name,
                    Value = employee.EmpID
                });
            }
        }
    }
    
}