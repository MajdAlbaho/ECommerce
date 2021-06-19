using System;
using System.Collections.Generic;

namespace ECommerce.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string ImageSource { get; set; }
        public string EnDescription { get; set; }
        public string ArDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
