using System;

namespace ECommerce.Model
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
