using Microsoft.AspNetCore.Mvc;

namespace WhatIsElasticSearch.MvcWebUI.Controllers
{
    public class PresentationController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
