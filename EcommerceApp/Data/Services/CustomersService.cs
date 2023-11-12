using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly AppDbContext _context;

        public CustomersService(AppDbContext context)
        {
            this._context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await this._context.Customers.AddAsync(customer);
            await this._context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var result = await _context.Customers.ToListAsync();
            return result;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Customer> UpdateAsync(int id, Customer newCustomer)
        {
            _context.Update(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer;
        }
    }
}
