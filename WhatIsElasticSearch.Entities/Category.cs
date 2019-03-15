using WhatIsElasticSearch.Core.Entities;

namespace WhatIsElasticSearch.Entities
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
