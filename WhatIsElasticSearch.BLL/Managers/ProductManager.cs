using System.Collections.Generic;
using WhatIsElasticSearch.BLL.Interfaces;
using WhatIsElasticSearch.DAL.Interfaces;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.BLL.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _productDAL;

        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public void Add(Product product)
        {
            _productDAL.Add(product);
        }

        public void Delete(int productId)
        {
            Product product = _productDAL.Get(p => p.ProductId == productId);
            _productDAL.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDAL.GetList();
        }

        public List<Product> GetByCategoryId(int categoryId)
        {
            return _productDAL.GetList(p => p.CategoryId == categoryId);
        }

        public void Update(Product product)
        {
            _productDAL.Update(product);
        }
    }
}
