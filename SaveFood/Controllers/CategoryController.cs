using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaveFood.Models;
using SaveFood.Repositories;
using System;
using System.Security.Claims;

namespace SaveFood.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category) 
        {
            if (!ModelState.IsValid)
                return View();

            category.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (_categoryRepository.Exist(category))
                ModelState.AddModelError(nameof(category.Name), $"Já existe a categoria {category.Name}");

            if (!ModelState.IsValid)
                return View();

            _categoryRepository.Create(category);
            _categoryRepository.Save();

            TempData["msg"] = "Categoria cadastrado com sucesso!";
            return View();
        }
    }
}
