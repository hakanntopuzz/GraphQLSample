using System;
using System.Collections.Generic;
using System.Text;
using Graphql.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Graphql.Data
{
    public class NHRContext : DbContext
    {
        public NHRContext()
        {
        }
        public NHRContext(DbContextOptions options)
            : base(options)
        {
            // these are mutually exclusive, migrations cannot be used with EnsureCreated()
            // Database.EnsureCreated();
            // Database.Migrate();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
