using WhatIsElasticSearch.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace WhatIsElasticSearch.Entities
{
    public class Category : IEntity
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set; }
    }
}
