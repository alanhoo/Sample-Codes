using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models;
using HRPortal.Data;

namespace HRPortalNew.Controllers
{
    public class ApplyController : Controller
    {
        // GET: Apply
        public ActionResult Index()
        {
            Application application = new Application();

            return View(application);
        }

        public ActionResult Viiiew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Application application)
        {
            if (ModelState.IsValid)
            {

                var repo = new ApplicantDatabase();
                repo.Add(application);

                return RedirectToAction("ThankYou");
            }

            return View(application);
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}