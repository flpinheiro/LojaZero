using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public double Weight { get; set; }
        public uint Stock { get; set; }

        public ICollection<ProductSelect> Sold { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
        public ICollection<ProductPromotion> Promotions { get; set; }
        public ICollection<ProductPhoto> Photos { get; set; }

        public Product()
        {
            Sold = new List<ProductSelect>();
            ProductTags = new List<ProductTag>();
            Promotions = new List<ProductPromotion>();
            Photos = new List<ProductPhoto>();
        }

    }
}
