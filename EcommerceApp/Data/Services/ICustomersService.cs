using EcommerceApp.Models;

namespace EcommerceApp.Data.Services
{
    public interface ICustomersService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        Task<Customer> UpdateAsync(int id, Customer newCustomer);
        Task DeleteAsync(int id);
    }
}
