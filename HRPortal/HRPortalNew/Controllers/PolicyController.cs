using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Data;
using HRPortal.Models;
using HRPortal.WebModels;

namespace HRPortalNew.Controllers
{
    public class PolicyController : Controller
    {
        // GET: Policy
        public ActionResult Index()
        {
            return RedirectToAction("ManagePolicy");
        }

        public ActionResult ManagePolicy()
        {
            var cb = new CategoryDataBase();

            return View(cb.CreateCategoryList());
        }

        public ActionResult ManageCategory()
        {
            var cb = new CategoryDataBase();

            return View(cb.GetAllCategoriess());
        }

        public ActionResult ManageCategoryJ()
        {
            return View();
        }

        public JsonResult ManageCategoryJH()
        {
            CategoryDataBase cd = new CategoryDataBase();
            IEnumerable<Category> categories = cd.GetAllCategoriess();

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddCategoryJ(string Category)
        {
            var cd = new CategoryDataBase();
            cd.AddNewCategory(Category);

            IEnumerable<Category> categories = cd.GetAllCategoriess();

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PolicyForm()
        {
            PolicyToAddVM vm = new PolicyToAddVM();

            return View(vm);
        }

        [HttpPost]
        public ActionResult PolicyForm(PolicyToAddVM vm)
        {
            if (ModelState.IsValid)
            {
                PolicyDatabase pd = new PolicyDatabase();
             
                pd.AddPolicy(vm.PolicyToAdd);
           
                return RedirectToAction("ManagePolicy");
            }

            return View(vm);
        }

        public ActionResult GetPolicyFromCategory(string Category)
        {
            PolicyDatabase pd = new PolicyDatabase();
            List<Policy> policies = new List<Policy>();

            policies = pd.GetPolicyByCategory(Category);

            return View(policies);
        }

        public ActionResult RemovePolicy(string title)
        {
            PolicyDatabase pd = new PolicyDatabase(); 

            pd.DeletePolicy(title);

            return RedirectToAction("ManagePolicy");
        }

        [HttpPost]
        public ActionResult AddCategory(string Category)
        {
            var repo = new CategoryDataBase();
            repo.AddNewCategory(Category);

            return RedirectToAction("ManageCategory");
        }

        public ActionResult ViewPolicy()
        {
            var cd = new CategoryDataBase();
            var categories = cd.CreateCategoryList();

            return View(categories);
        }

        public ActionResult ViewPolicyDetails(string title)
        {
            var repo = new PolicyDatabase();
            var policy = repo.GetByTitle(title);

            return View(policy);
        }
    }
}