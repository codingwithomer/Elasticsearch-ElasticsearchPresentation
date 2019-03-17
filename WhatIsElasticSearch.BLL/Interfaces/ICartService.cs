using System.Collections.Generic;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.BLL.Interfaces
{
    public interface ICartService
    {
        void AddToCart(Cart cart, Product product);
        void RemoveFromCart(Cart cart, int productId);
        List<CartLine> List(Cart cart);
    }
}
