using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Graphql.Core.Entities;
using Graphql.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graphql.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NHRContext _context;
        public CategoryRepository(NHRContext context)
        {
            _context = context;
        }

        public Category Get(int id)
        {
            return _context.Categories.Include(q=> q.Products).AsNoTracking().FirstOrDefault(q => q.CategoryID == id);
        }

        public Category CreateCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();

            return category;
        }
    }
}
