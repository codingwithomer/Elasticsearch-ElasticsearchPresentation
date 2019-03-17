using System.Collections.Generic;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get; internal set; }
    }
}
