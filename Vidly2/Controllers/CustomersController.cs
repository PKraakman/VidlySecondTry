using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        //private List<Customer> _customers = new List<Customer>
        //{
        //    new Customer {Name = "Pieter Kraakman", Id = 1},
        //    new Customer {Name = "Kurtis Ley", Id = 2},
        //    new Customer {Name = "Joseph Wright", Id = 3},
        //    new Customer {Name = "Lori Groger", Id = 4}
        //};

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            return View();
        }


        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new CustomerIndexViewModel
            {
                Customers = _context.Customers.Include(c => c.MembershipType).ToList()
            };
            
            return View(viewModel);
        }

        //customers/details/id

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            return View(customer);
        }

        

        // customers/edit/id
        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}