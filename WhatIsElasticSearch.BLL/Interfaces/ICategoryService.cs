using System;
using System.Collections.Generic;
using System.Text;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.BLL.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
