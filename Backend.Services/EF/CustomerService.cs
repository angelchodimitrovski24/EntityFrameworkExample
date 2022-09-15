using Backend.Shared.Enums;
using BackEnd.DDD;
using BackEnd.DDD.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Backend.Services.EF
{
    public class CustomerService
    {
        private AccessDbContext _context;

        public CustomerService(AccessDbContext context)
        {
            _context = context;
        }

        //C
        public Customers NewCustomer(Customers customers)
        {
            _context.Customers.Add(customers);
            _context.SaveChanges();

            return customers;
        }

        //R all Customers
        public List<Customers> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //R Customer by Id
        public Customers GetCustomerById(Guid Id)
        {
            var customer = _context.Customers.Find(Id);

            if (customer == null)
            {
                throw new NullReferenceException("Customer is empty");
            }

            return customer;
        }

        public List<Customers> GetCustomerId(Guid? Id)
        {
            var customer = _context.Customers.Where(x => x.Id == Id).ToList();

            if (customer == null)
            {
                throw new NullReferenceException("Customer is empty");
            }

            return customer;
        }

        //U
        public Customers UpdateCustomer(Guid id, Customers customers)
        {
            var customersToUpdate = _context.Customers.Find(id);

            if (customersToUpdate == null)
            {
                throw new NullReferenceException("No such customer for update");
            }

            customersToUpdate.CustomerName = customers.CustomerName;
            customersToUpdate.City = customers.City;

            _context.Customers.Update(customersToUpdate);
            _context.SaveChanges();

            return customers;
        }

        //D
        public void DeleteCustomer(Guid Id)
        {
            var customers = _context.Customers.Where(x => x.Id == Id).SingleOrDefault();

            if (customers == null)
            {
                throw new NullReferenceException("Nothing to Delete.");
            }

            _context.Customers.Remove(customers);
            _context.SaveChanges();
        }

    }
}