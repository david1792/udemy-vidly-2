using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //get api/customers

        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);//we delete parenthesis because we 're not going to call this method, if we calling that gets executed, but here we need a delegate, a reference to this method
        }
        //get api/customers/{id}
        public CustomerDto  GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Customer, CustomerDto>(customer);
        }
        //we can optionally use in name method the keyword Post and we save the annotation but is better implement the annotation
        //post api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return customerDto;
        }
        //in put method we can ise void or return, in thi case a customer object 
        //put /api/customers/{id}
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound); 
            Mapper.Map(customerDto, customerInDb);//the secound argument is because customerInDb is loaded in _context, so we want to db context to track changes in this object and we don't need to pass a generic param,eters becouse the compiller can infer from the objects we have to pass this method what are the source and target types
            //automapper has a good features like properties don't match, exclude properties or create custom mapping classes, please read documentation 
            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
