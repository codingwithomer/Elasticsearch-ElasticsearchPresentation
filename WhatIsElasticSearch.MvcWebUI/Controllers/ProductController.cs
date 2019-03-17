using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WhatIsElasticSearch.BLL.Interfaces;
using WhatIsElasticSearch.Entities;
using WhatIsElasticSearch.MvcWebUI.Models;

namespace WhatIsElasticSearch.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index(int page = 1, int category = 1)
        {
            int pageSize = 10;

            category = 1;
            List<Product> products = _productService.GetByCategory(category);

            ProductListViewModel productList = new ProductListViewModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory = category,
                CurrentPage = page
            };

            return View(productList);
        }
    }
}
