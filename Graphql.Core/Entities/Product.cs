using System;
using System.Collections.Generic;
using System.Text;

namespace Graphql.Core.Entities
{
    public class Product
    {
        public  int ProductID { get; set; }
        public  int CategoryID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public Category Category { get; set; }
    }
}
