using System;
using System.Collections.Generic;
using System.Text;

namespace Graphql.Core.Entities
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }
        public  int CategoryID { get; set; } 
        public  string CategoryName { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
