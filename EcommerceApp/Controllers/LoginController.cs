using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
