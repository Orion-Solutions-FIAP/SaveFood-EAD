using Microsoft.AspNetCore.Mvc;
using SaveFood.Models;
using SaveFood.Services;
using SaveFood.Services.Enums;

namespace SaveFood.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login) 
        {
            if (!ModelState.IsValid)
                return View("Index", login);

            var result = _authService.ValidateUser(new User(login));
            if (result == AuthStatus.UserNotFound)
                ModelState.AddModelError(nameof(login.Email), "Opa! não localizamos o usuário, verifique se digitou corretamente.");

            if(result == AuthStatus.WrongPassword)
                ModelState.AddModelError(nameof(login.Password), "Senha incorreta, verifique se digitou corretamente.");

            return RedirectToAction("Index", "Product");
        }
    }
}
