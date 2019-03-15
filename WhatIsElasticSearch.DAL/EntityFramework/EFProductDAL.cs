using WhatIsElasticSearch.Core.DAL.EntityFramework;
using WhatIsElasticSearch.DAL.Interfaces;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.DAL.EntityFramework
{
    public class EFProductDAL : EntityFrameworkRepositoryBase<Product,EFDbContext>, IProductDAL
    {

    }
}
