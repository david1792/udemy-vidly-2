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
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
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
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id != 0)
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                /*
                 * to update we have to aproach to update a model:
                 * 1. microsoft .net mvc tutorials used a method in Controller class call TryUpdateModel(<model here>)
                 * but its going to open up a number of issues, that aproach open up a security holes in your application
                 * because update all value pairs in our model, a malicius user can modify your request data and add aditional keys
                 * value pairs in form data and this method will succesfully update all properties. recomend method is set mannualy the properties what we wish update
                 */
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSuscribedToNewsletter = customer.IsSuscribedToNewsletter;
                //other aproach is use a library that maps automaticaly the properties like automaper library
                //and the code may look like this: Mapper.map(customer, customerInId);
                //other way is create a helper model with the properties what we can update only, helper model like UpdateCustomerDTO 
                _context.SaveChanges();
            }
            else
            {
                _context.Customers.Add(customer); // in this point, the entity is save in memory
                _context.SaveChanges(); // in this point, the entity is save in DB and generates all the sql statements
                //all these statements are wrapped in a transaction, so all changes are persisted or nothing get persisted  

            }
            return RedirectToAction("Index", "Customers");
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

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);

            }

        }
    }
}