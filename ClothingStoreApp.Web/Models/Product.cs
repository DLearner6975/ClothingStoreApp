using System;
using System.Collections.Generic;

namespace ClothingStoreApp.Web.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
            ProductImage = new HashSet<ProductImage>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
    }
}
