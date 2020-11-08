using Graphql.Core.Entities;
using Graphql.Data.Repositories.Interfaces;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlSample.Models
{
    public class NHRMutation : ObjectGraphType
    {
        public NHRMutation(ICategoryRepository repository)
        {
            Field<CategoryType>(
           "createCategory",
           arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CategoryInputType>> { Name = "category" }),
           resolve: context =>
           {
               var owner = context.GetArgument<Category>("category");
               return repository.CreateCategory(owner);
           }
       );
        }
    }
}
