using Microsoft.AspNetCore.Mvc;

namespace WhatIsElasticSearch.MvcWebUI.Controllers
{
    public class HomeController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
