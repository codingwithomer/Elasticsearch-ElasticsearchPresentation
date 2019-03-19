using Microsoft.AspNetCore.Mvc;
using WhatIsElasticSearch.BLL.Interfaces;

namespace WhatIsElasticSearch.MvcWebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = _productService.GetAll();

            return View(model);
        }
    }
}
