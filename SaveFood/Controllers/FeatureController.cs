using Microsoft.AspNetCore.Mvc;

namespace SaveFood.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
