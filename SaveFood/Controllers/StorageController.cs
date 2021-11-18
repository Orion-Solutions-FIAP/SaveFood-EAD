using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaveFood.Models;
using SaveFood.Repositories;
using System;
using System.Security.Claims;

namespace SaveFood.Controllers
{
    [Authorize]
    public class StorageController : Controller
    {
        private readonly IStorageRepository _storageRepository;

        public StorageController(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Storage storage)
        {
            storage.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (_storageRepository.Exist(storage))
                ModelState.AddModelError(nameof(storage.Name), $"Já existe o armazenamento {storage.Name}");

            if (!ModelState.IsValid)
                return View(storage);

            _storageRepository.Create(storage);
            _storageRepository.Save();

            TempData["msg"] = "Armazenamento cadastrado com sucesso!";
            return View();
        }
    }
}
