using System;
using System.Collections.Generic;
using System.Linq;
using WhatIsElasticSearch.BLL.Interfaces;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.BLL.Managers
{
    public class CartService : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.Id == product.Id);

            if (cartLine != null)
                cartLine.Quantity++;

            cart.CartLines.Add(new CartLine { Product = product, Quantity = 1 });
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.Id == productId));
        }
    }
}
