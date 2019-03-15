using WhatIsElasticSearch.Core.DAL.EntityFramework;
using WhatIsElasticSearch.DAL.Interfaces;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.DAL.EntityFramework
{
    public class EFCategoryDAL : EntityFrameworkRepositoryBase<Category, EFDbContext>, ICategoryDAL
    {

    }
}
