using EcommerceApp.Data.Base;
using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        public ProductsService(AppDbContext context) : base(context)
        {

        }
    }
}
