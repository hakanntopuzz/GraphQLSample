using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Graphql.Core.Entities;

namespace Graphql.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product Get(int productID);
        Product GetRandom();
        List<Product> GetAll();

        List<Product> GetByCategoryId(int categoryId);
    }
}
