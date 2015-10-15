using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HRPortal.Models;
using HRPortal.Data;

namespace HRPortalNew.WebModels
{
    public class TimeSheetDetailsVM
    {
        public List<Time> TimeSheet { get; set; }

        public string EmployeeName { get; set; }

        public decimal TotalHour { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public TimeSheetDetailsVM(string employeeID)
        {
            TimeSheet = new List<Time>();
            TimeSheet = createEmployeeTimeSheet(employeeID);
            EmployeeName = getEmployeeName(employeeID);

            if (TimeSheet.Any())
            {               
                TotalHour = getTotalHour();
                StartDate = getStartDate();
               // StartDate = transformDate(StartDate);
            }
        }

        private List<Time> createEmployeeTimeSheet(string employeeID)
        {
            TimeDataBase td = new TimeDataBase();
            return td.GetEmployeeTimeSheet(employeeID);
        }

        private string getEmployeeName(string employeeID)
        {
            EmployeeDataBase ed = new EmployeeDataBase();
            return ed.getEmployeeName(employeeID);
        }

        private decimal getTotalHour()
        {
            decimal totalHour = 0;

            foreach (var time in TimeSheet)
            {
                totalHour += time.Hours;
            }

            return totalHour;
        }

        [DataType(DataType.Date)]
        private DateTime getStartDate()
        {
            return TimeSheet.Last().Date;
        }

        //[DataType(DataType.Date)]
        //private DateTime transformDate(DateTime date)
        //{
        //    DateTime dayOnlyDate = date;
        //    return dayOnlyDate;
        //}
    }
}