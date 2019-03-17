using Microsoft.AspNetCore.Mvc;
using WhatIsElasticSearch.BLL.Interfaces;
using WhatIsElasticSearch.Entities;
using WhatIsElasticSearch.MvcWebUI.Models;
using WhatIsElasticSearch.MvcWebUI.Services;

namespace WhatIsElasticSearch.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartSessionService _cartSessionService;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CartController(ICartSessionService cartSessionService,
                              ICartService cartService,
                              IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }

        public ActionResult AddToCart(int productId)
        {
            Product productToBeAdded = _productService.GetById(productId);

            Cart cart = _cartSessionService.GetCart();

            _cartService.AddToCart(cart, productToBeAdded);

            _cartSessionService.SetCart(cart);

            if (!TempData.ContainsKey("message"))
            {
                TempData.Add("message", string.Format("Your product, {0}, was successfully added to the cart.", productToBeAdded.product_name));
            }

            return RedirectToAction("Index", "Product");
        }

        public ActionResult List()
        {
            Cart cart = _cartSessionService.GetCart();

            CartSummaryViewModel cartSummaryViewModel = new CartSummaryViewModel
            {
                Cart = cart
            };

            return View(cartSummaryViewModel);
        }

        public ActionResult Remove(int productId)
        {
            Cart cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);

            if (!TempData.ContainsKey("message"))
            {
                TempData.Add("message", "Your product was successfully removed from the cart!");
            }

            return RedirectToAction("List", "Cart");
        }

        public ActionResult Complete()
        {
            ShippingDetailsViewModel shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };

            return View(shippingDetailsViewModel);
        }

        [HttpPost]
        public ActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            TempData.Add("message", string.Format("Thank you {0}, your order is in process", shippingDetails.FirstName));

            return View();
        }
    }
}
