using System.Collections.Generic;
using WhatIsElasticSearch.Entities.DTOs;

namespace WhatIsElasticSearch.DAL.Interfaces
{
    public interface IElasticContext
    {
        IndexResponseDTO CreateIndex<T>(string indexName, string aliasName) where T : class;
        IndexResponseDTO Index<T>(string indexName, T document) where T : class;
        bool CheckDocumentExist<T>(string indexName) where T : class;
        IndexResponseDTO IndexMany<T>(List<T> documents,string indexName) where T : class; 
    }
}
