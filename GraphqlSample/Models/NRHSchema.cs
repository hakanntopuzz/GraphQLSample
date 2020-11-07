using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace GraphqlSample.Models
{
    public class NRHSchema : Schema
    {
        public NRHSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<NHRQuery>();
            //Mutation = resolver.Resolve<NHLStatsMutation>();
        }
    }
}
