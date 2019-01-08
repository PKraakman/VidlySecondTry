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


        // movies/new
        public ActionResult New()
        {

            var viewModel = new MoviesFormViewModel
            {
                Movie = new Movie(),
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }


        // movies/details
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }


        // movies/edit
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == Id);
            var viewModel = new MoviesFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        // movies/save
        public ActionResult Save(Movie Movie)
        {
            if (Movie.Id == 0)
            {
                Movie.DateAdded = DateTime.Now;
                _context.Movies.Add(Movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == Movie.Id);

                movieInDb.Name = Movie.Name;
                movieInDb.ReleaseDate = Movie.ReleaseDate;
                movieInDb.GenreId = Movie.GenreId;
                movieInDb.QtyInStock = Movie.QtyInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        // movies/released/{year}/{month}
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($" year is : {year} and month is: {month}");
        }
    }
}