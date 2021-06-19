using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerce.Api.DataAccess.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string ImageSource { get; set; }
        public string EnDescription { get; set; }
        public string ArDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
