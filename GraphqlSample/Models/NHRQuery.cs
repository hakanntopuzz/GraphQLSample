using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Graphql.Core.Entities;
using Graphql.Data.Repositories.Interfaces;
using GraphQL.Types;

namespace GraphqlSample.Models
{
    public class NHRQuery : ObjectGraphType
    {
        public NHRQuery(ICustomerRepository customerRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            Field<CustomerType>(
                "customer",
                arguments: new QueryArguments(new QueryArgument<GraphType> { Name = "CustomerID" }),
                resolve: context => customerRepository.Get(context.GetArgument<string>("CustomerID")));

            Field<CustomerType>(
                "randomCustomer",
                resolve: context => customerRepository.GetRandom());

            Field<ListGraphType<CustomerType>>(
                "customers",
                resolve: context => customerRepository.GetAll());

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "productID" }),
                resolve: context => productRepository.Get(context.GetArgument<int>("productID")));

            Field<ProductType>(
                "randomProduct",
                resolve: context => productRepository.GetRandom());

            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetAll());

            Field<CategoryType>(
                "category",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryID" }),
                resolve: context => categoryRepository.Get(context.GetArgument<int>("categoryID")));
        }
    }
}
