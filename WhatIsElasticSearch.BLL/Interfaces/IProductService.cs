using System;
using System.Collections.Generic;
using System.Text;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.BLL.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategoryId(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
    }
}
