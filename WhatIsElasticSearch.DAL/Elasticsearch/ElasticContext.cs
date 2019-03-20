using Nest;
using System.Collections.Generic;
using WhatIsElasticSearch.DAL.Interfaces;
using WhatIsElasticSearch.Entities.DTOs;

namespace WhatIsElasticSearch.DAL.Elasticsearch
{
    public class ElasticContext : IElasticContext
    {
        private readonly IElasticClient _elasticClient;

        public ElasticContext(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public IndexResponseDTO CreateIndex<T>(string indexName, string aliasName) where T : class
        {
            CreateIndexDescriptor createIndexDescriptor = new CreateIndexDescriptor(indexName);

            createIndexDescriptor.Mappings(ms =>
                                     ms.Map<T>(m => m.AutoMap())
                                 )
                                 .Aliases(a => a.Alias(aliasName));

            ICreateIndexResponse result = _elasticClient.CreateIndex(createIndexDescriptor);

            return new IndexResponseDTO()
            {
                Exception = result.OriginalException,
                IsValid = result.IsValid,
                StatusMessage = result.DebugInformation
            };
        }

        public IndexResponseDTO Index<T>(string indexName, T document) where T : class
        {
            IIndexResponse result = _elasticClient.Index(document, id => id.Index(indexName)
                                                                  .Type<T>());

            return new IndexResponseDTO()
            {
                IsValid = result.IsValid,
                Exception = result.OriginalException,
                StatusMessage = result.DebugInformation
            };
        }

        public bool CheckDocumentExist<T>(string indexName) where T : class
        {
            Indices indices = Indices.Index(indexName);

            var result = _elasticClient.IndexExists(indices).Exists;

            return result;
        }

        public IndexResponseDTO IndexMany<T>(List<T> documents, string indexName) where T : class
        {
            var result = _elasticClient.IndexMany<T>(documents, indexName);

            return new IndexResponseDTO()
            {
                Exception = result.OriginalException,
                IsValid = result.IsValid,
                StatusMessage = result.DebugInformation
            };
        }
    }
}