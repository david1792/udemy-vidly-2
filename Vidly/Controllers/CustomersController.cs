using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace UdemyCourse.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer>()
        {
            new Customer{ Name = "Customer 1", Id = 1},
            new Customer{Name = "Customer 2", Id = 2}
        };
        // GET: Customers
        public ActionResult Index()
        {
            int random = new Random().Next(2);
            System.Diagnostics.Debug.WriteLine(random);
            if (random == 0)
            {
               customers.Clear();
            }
            return View(customers);
        }
        public ActionResult ShowDetails(int id)
        {
            return View(customers.Where(i => i.Id == id).FirstOrDefault());
        }
    }
}