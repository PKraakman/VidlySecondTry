using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> _customers = new List<Customer>
        {
            new Customer {Name = "Pieter Kraakman", Id = 1},
            new Customer {Name = "Kurtis Somethingorother", Id = 2},
            new Customer {Name = "Joseph Wright", Id = 3},
            new Customer {Name = "Lori Groger", Id = 4}
        };

        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new CustomerIndexViewModel
            {
                Customers = _customers
            };
            
            return View(viewModel);
        }

        // customers/edit/id
        public ActionResult Edit(int Id)
        {
            foreach (var customer in _customers)
            {
                if (customer.Id == Id)
                    return View(customer);
            };

            return View(new Customer());
        }
    }
}