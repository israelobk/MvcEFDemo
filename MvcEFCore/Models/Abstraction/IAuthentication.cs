using HotelWebApplication.Models.Poco_Class;

namespace MvcEFCore.Models.Abstraction
{
    public interface IAuthentication
    {
        Customer Login(string email, string password);

        void Signup(Customer customer);
        Customer? GetUser(string email);
        IEnumerable<Customer> Users { get; }
    }
}
