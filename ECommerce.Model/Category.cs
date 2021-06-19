using System;
using System.Collections.Generic;

namespace ECommerce.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public List<Product> Products { get; set; }
    }
}
