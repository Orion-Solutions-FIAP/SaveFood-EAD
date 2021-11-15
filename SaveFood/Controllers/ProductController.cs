using Microsoft.AspNetCore.Mvc;
using SaveFood.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace SaveFood.Controllers
{
    public class ProductController : Controller
    {
        public readonly List<Product> _productList = new List<Product>();

        public IActionResult Index()
        {
            var identity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "Test"),
                    new Claim(ClaimTypes.Role, "Common")
                }, "Custom");
            HttpContext.User = new ClaimsPrincipal(identity);
            return View(_productList);
        }

        public IActionResult Create() 
        {
            return View();
        }

        public IActionResult ExpiredProducts() 
        {
            return View(_productList);
        }
    }
}
