﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SaveFood.Models;
using SaveFood.Services;
using SaveFood.Services.Enums;
using System.Threading.Tasks;

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
        public async Task<IActionResult> LoginAsync(Login login) 
        {
            if (!ModelState.IsValid)
                return View("Index", login);

            var (authStatus, user) = _authService.ValidateUser(new User(login));
            if (authStatus == AuthStatus.UserNotFound)
                ModelState.AddModelError(nameof(login.Email), "Opa! não localizamos o usuário, verifique se digitou corretamente.");

            if(authStatus == AuthStatus.WrongPassword)
                ModelState.AddModelError(nameof(login.Password), "Senha incorreta, verifique se digitou corretamente.");

            await HttpContext.SignInAsync(_authService.CreateAuth(user));
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
