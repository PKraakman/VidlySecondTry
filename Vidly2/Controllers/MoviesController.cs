using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Shrek!" };

             return View(movie);
            // return Content("hello world");
            // return HttpNotFound();
            // return new EmptyResult();
            // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        // movies/edit
        public ActionResult Edit(int id)
        {
            return Content(String.Format("Now editing id: {0}", id));
        }

        // movies
        public ActionResult Index(int? pageIndex, string sortby)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortby))
                sortby = "Name";

            return Content(String.Format("first {0} and second {1}", pageIndex, sortby));

        }
    }
}