using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class ProductTag
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
