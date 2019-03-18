using WhatIsElasticSearch.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace WhatIsElasticSearch.Entities
{
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
