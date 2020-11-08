using System;
using System.Collections.Generic;
using System.Text;
using Graphql.Core.Entities;

namespace Graphql.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Category Get(int id);

        Category CreateCategory(Category category);
    }
}
