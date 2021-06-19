using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerce.Api.DataAccess.Entities
{
    public partial class ProductCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
