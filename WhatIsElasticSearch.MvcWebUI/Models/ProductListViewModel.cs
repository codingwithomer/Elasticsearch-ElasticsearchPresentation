using System.Collections.Generic;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public int CurrentPage { get; internal set; }
        public int CurrentCategory { get;  set; }
        public int PageSize { get;  set; }
        public int PageCount { get;  set; }
    }
}
