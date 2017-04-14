using System;
using System.Collections.Generic;

namespace ClothingStoreApp.Web.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
    }
}
