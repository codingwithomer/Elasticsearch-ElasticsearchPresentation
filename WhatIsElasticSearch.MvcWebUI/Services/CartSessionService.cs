﻿using Microsoft.AspNetCore.Http;
using System;
using WhatIsElasticSearch.Entities;
using WhatIsElasticSearch.MvcWebUI.Extensions;

namespace WhatIsElasticSearch.MvcWebUI.Services
{
    public class CartSessionService : ICartSessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Cart GetCart()
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");

            if (cartToCheck == null)
            { 
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }

            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
