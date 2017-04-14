using System;
using System.Collections.Generic;

namespace ClothingStoreApp.Web.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Address = new HashSet<Address>();
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTimeOffset SignupDate { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
