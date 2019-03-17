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
            Product product = new Product() { product_id = productId };
            _productDAL.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDAL.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDAL.GetList(p => p.category_id == categoryId || categoryId == 0);
        }

        public void Update(Product product)
        {
            _productDAL.Update(product);
        }

        public Product GetById(int productId)
        {
            return _productDAL.Get(p => p.product_id == productId);
        }
    }
}
