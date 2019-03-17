using System;
using System.Collections.Generic;
using System.Text;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.BLL.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
        Product GetById(int productId);
    }
}
