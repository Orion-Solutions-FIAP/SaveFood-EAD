using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SaveFood.Models;
using SaveFood.Repositories;
using System;
using System.Security.Claims;

namespace SaveFood.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IStorageRepository _storageRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, IStorageRepository storageRepository, ICategoryRepository categoryRepository)
        {
            _storageRepository = storageRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_productRepository.SearchByUserIdAndStatus(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadingOptions();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product.ExpirationDate <= DateTime.Now.Date)
                ModelState.AddModelError(nameof(product.ExpirationDate), "A data de vencimento deve ser uma data futura.");

            if (!ModelState.IsValid)
            {
                LoadingOptions();
                return View();
            }

            product.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _productRepository.Create(product);
            _productRepository.Save();

            TempData["msg"] = "Produto cadastrado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExpiredProducts()
        {
            return View(_productRepository.SearchByUserIdAndStatus(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)), Status.Expired));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            LoadingOptions();
            return View(_productRepository.SearchById(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var currentProduct = _productRepository.SearchById(product.Id);
            if (currentProduct.ExpirationDate != product.ExpirationDate && product.ExpirationDate <= DateTime.Now.Date)
                ModelState.AddModelError(nameof(product.ExpirationDate), "A data de vencimento deve ser uma data futura.");

            if (!ModelState.IsValid)
            {
                LoadingOptions();
                return View();
            }

            _productRepository.Update(product);
            _productRepository.Save();

            TempData["msg"] = "Produto atualizado com sucesso! :D";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();
            TempData["msg"] = "Produto removido com sucesso! :D";
            return RedirectToAction("Index");
        }

        private void LoadingOptions()
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.Storages = new SelectList(_storageRepository.SearchByUserId(userId), "Id", "Name");
            ViewBag.Categories = new SelectList(_categoryRepository.SearchByUserId(userId), "Id", "Name");
        }
    }
}
