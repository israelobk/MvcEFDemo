using HotelWebApplication.EF_Data;
using HotelWebApplication.Models.Poco_Class;
using Microsoft.EntityFrameworkCore;
using MvcEFCore.Models.Abstraction;
using MvcEFCore.Models.PocoClass;

namespace MvcEFCore.Models.Implementation
{
    public class CustomerRepository : IAuthentication
    {
        private readonly HotelDbContext _context;

        public CustomerRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Customer? Login(string email, string password)
        {
            password = PasswordHash.HashPassword(password);

            var user = _context.Customers.FirstOrDefault(u => u.Email == email && EF.Functions.Like(u.Password, password));

            if (user == null)
            {
                return null;
            }

            return Populate(user);
        }

        public void Signup(Customer customer)
        {
            customer.Password = PasswordHash.HashPassword(customer.Password);

            var newuser = new Customer
            {
                Email = customer.Email,
                Password = customer.Password,
                ConfirmPassword = customer.ConfirmPassword,
                PhoneNumber = customer.PhoneNumber,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
            };
            _context.Customers.Add(newuser);
            _context.SaveChanges();
        }

        public Customer? GetUser(string email)
        {
            var user = _context.Customers.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return null;
            }
            return Populate(user);
        }

        public IEnumerable<Customer> Users
        {
            get
            {
                var allUsers = _context.Customers.Select(u => Populate(u)).ToList();

                return allUsers;
            }
        }


        private Customer? Populate(Customer customer)
        {
            if (customer == null)
            {
                return null;
            }

            return new Customer
            {
                Email = customer.Email,
                Password = customer.Password,
                ConfirmPassword = customer.ConfirmPassword,
                PhoneNumber = customer.PhoneNumber,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
            };
        }
    }
}
