using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Graphql.Core.Entities;
using GraphQL.Types;

namespace GraphqlSample.Models
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(x => x.CustomerID);
            Field(x => x.Address);
            Field(x => x.City);
            Field(x => x.CompanyName);
            Field(x => x.ContactName);
            Field(x => x.ContactTitle);
            Field(x => x.Country);
            Field(x => x.PostalCode);
            Field(x => x.Region);
        }
    }
}
