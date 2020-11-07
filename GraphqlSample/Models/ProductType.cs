using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Graphql.Core.Entities;
using Graphql.Data.Repositories.Interfaces;
using GraphQL.Types;

namespace GraphqlSample.Models
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ICategoryRepository _categoryRepository)
        {
            Field(x => x.ProductID);
            Field(x => x.ProductName);
            Field(x => x.UnitPrice);
            Field(x => x.CategoryID);

            Field<CategoryType>(
                "category",
                resolve: context => _categoryRepository.Get(context.Source.CategoryID)
            );
        }
    }
}
