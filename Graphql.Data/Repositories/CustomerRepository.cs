using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphql.Core.Entities;
using Graphql.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graphql.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NHRContext _db;

        public CustomerRepository(NHRContext db)
        {
            _db = db;
        }

        public async Task<Customer> Get(string id)
        {
            return await _db.Customers.FirstOrDefaultAsync(p => p.CustomerID == id);
        }

        public async Task<Customer> GetRandom()
        {
            return await _db.Customers.OrderBy(o => Guid.NewGuid()).FirstOrDefaultAsync();
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _db.Customers.ToListAsync();
        }
    }
}
