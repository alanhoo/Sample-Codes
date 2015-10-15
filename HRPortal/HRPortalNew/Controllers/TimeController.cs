using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.WebModels;
using HRPortalNew.WebModels;
using HRPortal.Data;

namespace HRPortalNew.Controllers
{
    public class TimeController : Controller
    {
        // GET: Time
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TimeForm()
        {
            TimeToAddVM vm = new TimeToAddVM();
            return View(vm);
        }

        [HttpPost]
        [DataType(DataType.Date)]
        public ActionResult TimeForm(TimeToAddVM vm)
        {
            if (ModelState.IsValid)
            {
                TimeDataBase td = new TimeDataBase();

                td.AddTime(vm.TimeToAdd);

                return RedirectToAction("ViewTimeSheet");
            }

            return View(vm);
        }

        public ActionResult ViewTimeSheet()
        {
            TimeToAddVM vm = new TimeToAddVM();
            return View(vm.EmployeeList);
        }

        public ActionResult GetTimeSheet(string employeeID)
        {
            TimeSheetDetailsVM vm = new TimeSheetDetailsVM(employeeID);

            return RedirectToAction("ViewTimeSheetDetails", vm);
        }

        public ActionResult ViewTimeSheetDetails(string EmployeeID)
        {
            TimeSheetDetailsVM vm = new TimeSheetDetailsVM(EmployeeID);
            return View(vm);
        }

        public ActionResult RemoveTime(string Id)
        {
            TimeDataBase td = new TimeDataBase();
            td.RemoveTime(Id);

            return RedirectToAction("ViewTimeSheet");
        }
    }
}