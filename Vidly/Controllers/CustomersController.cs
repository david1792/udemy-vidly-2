using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        List<Customer> customers = new List<Customer>()
        {
            new Customer{ Name = "Customer 1", Id = 1},
            new Customer{Name = "Customer 2", Id = 2}
        };
        // GET: Customers
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
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }
        [HttpPost]
        /*
         *mvc framework automatically map request data to the párameter object
         * this is what we call model binding, so nvc framework binds this model to request data
         * So if we view the request of the view(f12 -> network), mvc frameworkwill use the properties send to
         * initialize the model binding in parameter, in this case we used a model view object but if we change to Customer
         * nvc framework is it smart enough to bind this object to form data becouse all the keys in the form data are prefixed but customer
         * this is how model binding works  
         */
        public ActionResult Create(NewCustomerViewModel viewModel)
        {
            return View(viewModel);
        }
        public ActionResult Index() 
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult ShowDetails(int id)
        {
            return View(_context.Customers.Include(c => c.MembershipType).SingleOrDefault(i => i.Id == id));
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Name = "Customer 1", Id = 1},
                new Customer {Name = "Customer 2", Id = 2}
            };
        }

    }
}