using System;
using System.Data.Entity;  // to use Include() for eager loading
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;  // for getting data from the database

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();  // get all customer from the db Customers table
                                                // Entity Framework will not execute the query when _context.Customer is executed,
                                                // instead, it will called when the customers object is iterated (e.g. in the View(customers), or _context.Customers.ToList()). 

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList(); // because this uses db reference data, so need to retrieve from db and use a viewmodel.
            var viewModel = new CustomerEditViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer/*NewCustomerViewModel viewmodel*/)  //model can bind to the customer in viewmodel
        {
            if(customer.Id == 0) { // a new customer
                // save form inputs into db
                _context.Customers.Add(customer);  // cache the object into the memory
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DOB = customer.DOB;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();  // save to db
            return RedirectToAction("Index", "Customers");  // back to the Customers/Index page.
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerEditViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

    }
}