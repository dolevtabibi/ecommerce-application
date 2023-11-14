using EcommerceApp.Data.Services;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            this._service = service;
        }
        public async Task<IActionResult> Index()
        {
           var data = await _service.GetAllAsync();
           return View(data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null)
            {
                return View("NotFound");
            }
            return View(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, productName, Price, IsAvailable")] Product product, IFormFile productPictureFile)
        {
            var customerDetails = await _service.GetByIdAsync(id);

            if (customerDetails.productPictureFile != null) // יש תמונה בדטאהבייס
            {
                if (productPictureFile != null) // והכנסתי חדשה
                {
                    ModelState.Remove("productPictureFile");
                    if (!ModelState.IsValid) // בדיקה שכל שאר הערכים הוכנסו
                    {
                        return View(product);
                    }

                    using (var memoryStream = new MemoryStream())
                    {
                        await productPictureFile.CopyToAsync(memoryStream);
                        product.productPictureFile = memoryStream.ToArray();
                    }
                }
                else // לא הכנסתי תמונה חדשה
                {
                    // שומר על התמונה הקיימת
                    ModelState.Remove("productPictureFile");
                    if (!ModelState.IsValid)
                    {
                        return View(product);
                    }
                    product.productPictureFile = customerDetails.productPictureFile;
                }
            }
            else // אין תמונה בדטאהבייס
            {
                if (productPictureFile != null) // והכנסתי חדשה
                {
                    ModelState.Remove("productPictureFile");
                    if (!ModelState.IsValid) // בדיקה שכל שאר הערכים הוכנסו
                    {
                        return View(product);
                    }

                    using (var memoryStream = new MemoryStream())
                    {
                        await productPictureFile.CopyToAsync(memoryStream);
                        customerDetails.productPictureFile = memoryStream.ToArray();
                    }
                    product.productPictureFile = customerDetails.productPictureFile;
                }
            }
            // Update the product
            await _service.UpdateAsync(id, product);
            return RedirectToAction(nameof(Index));
        }
    }
}
