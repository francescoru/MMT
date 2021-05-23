using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
