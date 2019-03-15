using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WhatIsElasticSearch.Core.Entities;

namespace WhatIsElasticSearch.Core.DAL
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {

        TEntity Get(Expression<Func<TEntity, bool>> filter = null);

        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
