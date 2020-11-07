using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Graphql.Core.Entities;

namespace Graphql.Data.Repositories.Interfaces
{
    public  interface ICustomerRepository
    {
        Task<Customer> Get(string id);
        Task<Customer> GetRandom();
        Task<List<Customer>> GetAll();
    }
}
