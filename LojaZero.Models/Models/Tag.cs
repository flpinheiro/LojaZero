using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductTag> ProductTags { get; set; }
        public Tag()
        {
            ProductTags = new List<ProductTag>();
        }
    }
}
