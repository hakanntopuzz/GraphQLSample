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
    public class ProductRepository : IProductRepository
    {
        private readonly NHRContext _db;

        public ProductRepository(NHRContext db)
        {
            _db = db;
        }

        public Product Get(int productID)
        {
            try
            {
                var data = _db.Products.Include(x=> x.Category).FirstOrDefault(p => p.ProductID == productID);

                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public Product GetRandom()
        {
            return _db.Products.OrderBy(o => Guid.NewGuid()).FirstOrDefault();
        }

        public List<Product> GetAll()
        {
            List<int> categoryList = new List<int> { 1, 3, 4, 6, 7 };
            var products = _db.Products.Where(q => categoryList.Contains(q.CategoryID)).ToList();

            var productsWithJoin = _db.Products.Join(categoryList,
                p => p.CategoryID,
                c => c,
                (p, c) => new { ProductName = p, CategoryId = c }).ToList();


            return  _db.Products.ToList();
        }

        public List<Product> GetByCategoryId(int categoryId)
        {

            //for (int i = 0; i <  100; i++)
            //{
            //    var product = new Product();
            //    _db.Products.Add(product);
            //}


            //List<Product> products = new List<Product>();
            //for (int i = 0; i < 100; i++)
            //{
            //    var product = new Product();
            //    products.Add(product);
            //}

            //_db.Products.AddRange(products);
            //_db.SaveChanges();

            return _db.Products.Where(q=> q.CategoryID == categoryId).ToList();
        }
    }
}
