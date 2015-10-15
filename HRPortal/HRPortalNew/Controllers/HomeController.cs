using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models;
using HRPortal.Data;
using HRPortal.WebModels;


namespace HRPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            return View("Index");
            //return View();
        }

        public ActionResult Form()
        {
            Application application = new Application();

            return View(application);
        }

        [HttpPost]
        public ActionResult Form(Application application)
        {
            if (ModelState.IsValid)
            {

                var repo = new ApplicantDatabase();
                repo.Add(application);

               // string name = application.Name;

                return RedirectToAction("ThankYou", application);
            }

            return View(application);
        }

        public ActionResult EditForm(int id)
        {
            Application application = new Application();
            ApplicantDatabase ad = new ApplicantDatabase();

            application = ad.GetById(id);

            return View(application);
        }

        [HttpPost]
        public ActionResult EditForm(Application application)
        {
            if (ModelState.IsValid)
            {

                var repo = new ApplicantDatabase();
                repo.Edit(application);

                return RedirectToAction("ViewApplicant");
            }

            return View(application);
        }

        public ActionResult ThankYou(Application application)
        {
            return View(application);
        }

        [HttpGet]
        public ActionResult ViewApplicant()
        {
            var repo = new ApplicantDatabase();
            var applicants = repo.GetAll();

            return View(applicants);
        }

        ////not use
        //public JsonResult ViewApplicantJ()
        //{
        //    var repo = new ApplicantDatabase();
        //    IEnumerable<Application> applicants = repo.GetAll();

        //    return Json(applicants, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult ViewDetailsJ(int id)
        {
            return View(id);
        }

        public JsonResult ViewDetailsJH(string id)
        {
            var repo = new ApplicantDatabase();
            var applicant = repo.GetById(int.Parse(id));

            return Json(applicant, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult ViewDetails(int id)
        {
            var repo = new ApplicantDatabase();
            var applicant = repo.GetById(id);

            return View(applicant);
        }

        
        public ActionResult RemoveApplication(int id)
        {
            var repo = new ApplicantDatabase();
            repo.Delete(id);

            return RedirectToAction("ViewApplicant");
        }
    }
}