using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WhatIsElasticSearch.BLL.Interfaces;
using WhatIsElasticSearch.Entities;
using WhatIsElasticSearch.MvcWebUI.Models;

namespace WhatIsElasticSearch.MvcWebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private const int pageSize = 10;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            List<Product> products = _productService.GetAll();

            ProductListViewModel model = new ProductListViewModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentPage = page
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ProductAddViewModel model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductAddViewModel productAddViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productAddViewModel.Product);
            }

            _productService.Add(productAddViewModel.Product);

            TempData.Add("message", "Product was successfully added.");

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int productId)
        {
            ProductUpdateViewModel model = new ProductUpdateViewModel
            {
                Product = _productService.GetById(productId),
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductUpdateViewModel productUpdateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productUpdateViewModel.Product);
            }

            _productService.Update(productUpdateViewModel.Product);

            TempData.Add("message", "Product was successfully updated.");

            return RedirectToAction("Index", "Admin");
        }

        public IActionResult RemoveProduct(int productId)
        {
            _productService.Delete(productId);

            TempData.Add("message", "Product was successfully deleted.");

            return RedirectToAction("Index", "Admin");
        }
    }
}
