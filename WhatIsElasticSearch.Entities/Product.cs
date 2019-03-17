using WhatIsElasticSearch.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace WhatIsElasticSearch.Entities
{
    public class Product : IEntity
    {
        [Key]
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int category_id { get; set; }
        //public float unit_price { get; set; }
        public short units_in_stock { get; set; }
    }
}
