using EcommerceApp.Data.Services;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersService _service;

        public CustomersController(ICustomersService service)
        {
            this._service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await this._service.GetAllAsync();
            return View(data);
        }

        //Get: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("fullName, Email, phoneNumber, Gender")] Customer customer, IFormFile profilePictureFile)
        {
            if(profilePictureFile == null)
            {
                ModelState.Remove("profilePictureFile");
                if (!ModelState.IsValid)
                {
                    return View(customer);
                }
            }

            if (profilePictureFile != null && profilePictureFile.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await profilePictureFile.CopyToAsync(stream);
                    customer.profilePictureFile = stream.ToArray();
                }
            }

            await _service.AddAsync(customer);
            return RedirectToAction(nameof(Index));
        }


        //Get: Customers/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var customerDetails = await _service.GetByIdAsync(id);
            if(customerDetails == null) 
            {
                return View("NotFound");
            }
            return View(customerDetails);
        }

        //Get: Customers/Edit{id}
        public async Task<IActionResult> Edit(int id)
        {
            var customerDetails = await _service.GetByIdAsync(id);
            if (customerDetails == null)
            {
                return View("NotFound");
            }
            return View(customerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, fullName, Email, phoneNumber, Gender")] Customer customer, IFormFile profilePictureFile, bool removeImageFlag)
        {
            var customerDetails = await _service.GetByIdAsync(id);

            if (customerDetails.profilePictureFile != null) //יש תמונה בדטאהבייס
            {
                if (profilePictureFile != null) // והכנסתי חדשה
                {
                    ModelState.Remove("profilePictureFile");
                    if (!ModelState.IsValid) // בדיקה שכל שאר הערכים הוכנסו
                    {
                        return View(customer);
                    }

                    using (var memoryStream = new MemoryStream())
                    {
                        await profilePictureFile.CopyToAsync(memoryStream);
                        customer.profilePictureFile = memoryStream.ToArray();
                    }
                }
                else // לא הכנסתי תמונה חדשה
                {
                    if (removeImageFlag == false) //לא ביקשתי למחוק את התמונה הדטאבייס
                    {
                        // שומר על התמונה הקיימת
                        ModelState.Remove("profilePictureFile");
                        if (!ModelState.IsValid)
                        {
                            return View(customer);
                        }
                        customer.profilePictureFile = customerDetails.profilePictureFile;
                    }
                }
            }
            else // אין תמונה בדטאהבייס
            {
                if (profilePictureFile != null) // והכנסתי חדשה
                {
                    ModelState.Remove("profilePictureFile");
                    if (!ModelState.IsValid) // בדיקה שכל שאר הערכים הוכנסו
                    {
                        return View(customer);
                    }

                    using (var memoryStream = new MemoryStream())
                    {
                        await profilePictureFile.CopyToAsync(memoryStream);
                        customerDetails.profilePictureFile = memoryStream.ToArray();
                    }
                    customer.profilePictureFile = customerDetails.profilePictureFile;
                }
            }
            // Update the customer
            await _service.UpdateAsync(id, customer);
            return RedirectToAction(nameof(Index));
        }


        //Get: Customers/Delete{id}
        public async Task<IActionResult> Delete(int id)
        {
            var customerDetails = await _service.GetByIdAsync(id);
            if (customerDetails == null)
            {
                return View("NotFound");
            }
            return View(customerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerDetails = await _service.GetByIdAsync(id);
            if (customerDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        private string GetDefaultImageFileNameBasedOnGender(string gender)
        {
            switch (gender)
            {
                case "Male":
                    return "male.svg";
                case "Female":
                    return "female.svg";
                default:
                    return "neithermalenorfemale.svg";
            }
        }
    }
}
