using System;
using System.Collections.Generic;

namespace ClothingStoreApp.Web.Models
{
    public partial class OrderNumber
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
