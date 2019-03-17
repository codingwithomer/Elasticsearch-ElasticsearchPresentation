using System.Collections.Generic;
using System.Linq;

namespace WhatIsElasticSearch.Entities
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }

        public List<CartLine> CartLines { get; set; }

        public float Total
        {
            get { return CartLines.Sum(cl => 1.0F * cl.quantity); }
        }
    }
}
