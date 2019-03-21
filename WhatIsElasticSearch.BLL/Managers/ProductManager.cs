using System;
using System.Collections.Generic;
using WhatIsElasticSearch.BLL.Interfaces;
using WhatIsElasticSearch.DAL.Interfaces;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.BLL.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _productDAL;
        private readonly IElasticContext _elasticContext;

        public ProductManager(IProductDAL productDAL, IElasticContext elasticContext)
        {
            _productDAL = productDAL;
            _elasticContext = elasticContext;
        }

        public void Add(Product product)
        {
            _productDAL.Add(product);
            //TODO: Elasticsearch'e ekle ve indeksle.
        }

        public void Delete(int productId)
        {
            Product product = new Product() { Id = productId };
            _productDAL.Delete(product);
        }

        public List<Product> GetAll()
        {
            List<Product> products = _productDAL.GetList();

            string indexName = $"product-{DateTime.Now.ToString("yyyy.MM.dd")}";

            if (!_elasticContext.CheckDocumentExist<Product>(indexName))
            {
                _elasticContext.CreateIndex<Product>(indexName, "product");

                _elasticContext.IndexMany(products, indexName);
            }

            return products;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDAL.GetList(p => p.CategoryId == categoryId || categoryId == 0);
        }

        public void Update(Product product)
        {
            _productDAL.Update(product);
        }

        public Product GetById(int productId)
        {
            return _productDAL.Get(p => p.Id == productId);
        }
    }
}
