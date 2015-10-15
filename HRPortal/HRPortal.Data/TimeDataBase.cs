using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data
{
    public class TimeDataBase
    {
        private static List<Time> _timeSheet = new List<Time>();
        private static int _timeSheetID;

        public List<Time> getTimeSheets()
        {
            return _timeSheet;
        }

        [DataType(DataType.Date)]
        public void AddTime(Time time)
        {
            if (!_timeSheet.Any())
            {
                _timeSheetID = 1;
                time.Id = _timeSheetID;
            }
            else
            {
                _timeSheetID ++;
                time.Id = _timeSheetID;
            }
            _timeSheet.Add(time);
        }

        public void RemoveTime(string id)
        {
            int idToRemove = int.Parse(id);
            var timeToRemove = _timeSheet.Find(i => i.Id == idToRemove);

            _timeSheet.Remove(timeToRemove);
        }

        public List<Time> GetEmployeeTimeSheet(string employee)
        {
           // List<Time> timesheet = new List<Time>();
            var timesheet = _timeSheet.FindAll(i => i.EmpID == employee).OrderByDescending(j => j.Date);
     
            return timesheet.ToList();
        } 



    }
}
