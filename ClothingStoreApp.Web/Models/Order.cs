using System;
using System.Collections.Generic;

namespace ClothingStoreApp.Web.Models
{
    public partial class Order
    {
        public Order()
        {
            Address = new HashSet<Address>();
            OrderItem = new HashSet<OrderItem>();
            OrderNumber = new HashSet<OrderNumber>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int CustomerId { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual ICollection<OrderNumber> OrderNumber { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
