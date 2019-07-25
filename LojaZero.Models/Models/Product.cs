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
        public double Value { get; set; }
        public double Weight { get; set; }

        public ICollection<ProductSelect> Sold { get; set; }

        public Product()
        {
            Sold = new List<ProductSelect>();
        }

    }
}
