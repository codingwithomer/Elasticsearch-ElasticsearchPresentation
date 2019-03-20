using Microsoft.AspNetCore.Mvc;
using System;
using WhatIsElasticSearch.BLL.Interfaces;
using WhatIsElasticSearch.DAL.Interfaces;
using WhatIsElasticSearch.Entities;
using WhatIsElasticSearch.MvcWebUI.Models;

namespace WhatIsElasticSearch.MvcWebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IElasticContext _elasticContext;

        public AdminController(IProductService productService, IElasticContext elasticContext)
        {
            _productService = productService;
            _elasticContext = elasticContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };

            string indexName = $"product-{DateTime.Now.ToString("yyyy.MM.dd")}";

            if (!_elasticContext.CheckDocumentExist<Product>(indexName))
            {
                _elasticContext.CreateIndex<Product>(indexName, "product");

                _elasticContext.IndexMany<Product>(model.Products, indexName);
            }


            return View(model);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _productService.Add(product);


            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult UpdateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _productService.Update(product);

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult RemoveProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RemoveProduct(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _productService.Delete(product.Id);

            return RedirectToAction("Index", "Admin");
        }
    }
}
