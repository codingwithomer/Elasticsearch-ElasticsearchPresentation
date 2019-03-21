using WhatIsElasticSearch.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WhatIsElasticSearch.Entities
{
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Unit Price")]
        public float UnitPrice { get; set; }
        [Required]
        [DisplayName("Units In Stock")]
        public short UnitsInStock { get; set; }
    }
}
