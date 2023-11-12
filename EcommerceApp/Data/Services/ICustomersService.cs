using EcommerceApp.Models;

namespace EcommerceApp.Data.Services
{
    public interface ICustomersService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        Customer Update(int id, Customer newCustomer);
        void Delete(int id);
    }
}
