using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer{ Name = "Customer 1" },
                new Customer{ Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Customers = customers,
                Movie = movie
            };

            return View(viewModel);
            // return Content("hello world");
            // return HttpNotFound();
            // return new EmptyResult();
            // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        // movies/edit

        public ActionResult Edit(int id)
        {
            //return Content(String.Format("Now editing id: {0}", id));

            //foreach (var movie  in movies)
            //{
            //    if (movie.Id == id)
            //        return View(movie);
            //}

            return View(new Movie());
        }


        // movies/Index
        public ActionResult Index(int? pageIndex, string sortby)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortby))
                sortby = "Name";
            // return Content(String.Format("first {0} and second {1}", pageIndex, sortby));

            var viewModel = new MoviesIndexViewModel
            {
                Movies = _context.Movies.Include(m => m.Genre).ToList()
            };

            return View(viewModel);
        }

        //movies/details
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // movies/released/{year}/{month}
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($" year is : {year} and month is: {month}");
        }
    }
}