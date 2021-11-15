using Microsoft.AspNetCore.Mvc;
using SaveFood.Models;
using System.Security.Claims;

namespace SaveFood.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login) 
        {
            return RedirectToAction("Index", "Product");
        }
    }
}
