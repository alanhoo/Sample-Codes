using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using StockAjaxMVC.BLL;
using StockAjaxMvc.Model;
using Newtonsoft.Json.Linq;


namespace StockAjaxMvc.Controllers
{
    public class StockController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("IndexJson");
        }

        public ActionResult IndexJson()
        {
            return View();
        }

        public JsonResult GetQuoteJson(string symbol)
        {
            StockAjaxMVCflow flow = new StockAjaxMVCflow();
            IEnumerable<Quote> quotes = flow.ExecuteQuote(symbol);

            return Json(quotes, JsonRequestBehavior.AllowGet);
        }

    }
}