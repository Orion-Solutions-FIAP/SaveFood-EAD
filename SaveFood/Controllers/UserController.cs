using Microsoft.AspNetCore.Mvc;
using SaveFood.Models;
using SaveFood.Repositories;

namespace SaveFood.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
                return View();

            if (_userRepository.SearchByEmail(user.Email) != null)
                ModelState.AddModelError(nameof(user.Email), "Já existe uma conta com este e-mail");

            if (!ModelState.IsValid)
                return View();

            _userRepository.Create(user);
            _userRepository.Save();
            TempData["msg"] = "Cadastro efetuado com sucesso! Agora é só logar :D";

            return RedirectToAction("Index", "Login");
        }
    }
}
