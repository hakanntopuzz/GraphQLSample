using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Graphql.Core.Entities;
using Graphql.Data.Repositories.Interfaces;
using GraphQL.Types;

namespace GraphqlSample.Models
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IProductRepository productRepository)
        {
            Field(x => x.CategoryID);
            Field(x => x.CategoryName);
            Field(x => x.Description);

            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetByCategoryId(context.Source.CategoryID).ToList()
            );
        }
    }
}
