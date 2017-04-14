using System;
using System.Collections.Generic;

namespace ClothingStoreApp.Web.Models
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public DateTime ImageCreated { get; set; }
        public bool ImageIsMain { get; set; }
        public string ImageName { get; set; }
        public string ImageTitle { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
