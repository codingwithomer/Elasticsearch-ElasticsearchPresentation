using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WhatIsElasticSearch.BLL.Interfaces;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            List<Product> products = _productService.GetAll();

            return View(products);
        }
    }
}
