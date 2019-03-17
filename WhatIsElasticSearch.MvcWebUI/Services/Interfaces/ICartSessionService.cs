using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.MvcWebUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
