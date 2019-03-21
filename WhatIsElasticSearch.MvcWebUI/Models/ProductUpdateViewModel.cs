using System.Collections.Generic;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.MvcWebUI.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
