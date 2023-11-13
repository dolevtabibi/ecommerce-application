using EcommerceApp.Data.Base;
using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data.Services
{
    public class CustomersService : EntityBaseRepository<Customer>, ICustomersService
    {
        public CustomersService(AppDbContext context) : base(context)
        {

        }
    }
}
