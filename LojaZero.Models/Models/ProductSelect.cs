using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class ProductSelect
    {
        public int Qtd { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public double TotalValue() => Qtd * Product.Value; 
        
    }
}
