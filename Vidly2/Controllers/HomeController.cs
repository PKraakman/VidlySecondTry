using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Dump()
        {
            var viewResult = new ViewResult();

            viewResult.ViewData.Model = new DumpData { Title = "Title form model", Message = "message from dumpdata" };

            viewResult.ViewData["info"] = "Info from viewData";

            return viewResult;
        }
    }

    public class DumpData
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string test { get; set; }

        public DumpData()
        {
            test = "default value for test";
        }

        public DumpData(string testvalue)
        {
            test = testvalue;
        }
    }
}