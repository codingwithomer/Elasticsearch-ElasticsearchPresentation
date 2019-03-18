using WhatIsElasticSearch.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace WhatIsElasticSearch.Entities
{
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public float UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }
}
