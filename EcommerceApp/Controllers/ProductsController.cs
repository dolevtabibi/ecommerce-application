using EcommerceApp.Data;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
           List<Product> data = await _context.Products.ToListAsync();
           return View(data);
        }
    }
}
