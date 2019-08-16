using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LojaZero.Models
{
    public class ProductSelect
    {
        public uint Qtd {get;set;}
        public decimal UnitValue { get; set; }

        private decimal _dicount;
        public decimal Discount
        {
            get => _dicount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Impossible to give negative discount value");
                }
                if (value >= 100)
                {
                    throw new ArgumentOutOfRangeException("Impossible to give more than 100% discount");
                }
                _dicount = value;
            }
        }

        public int ProductId { get; set; }
        public Product Product
        {
            get => _product;
            set
            {
                if (UnitValue == 0) UnitValue = value.Value;
                _product = value;
            }
        }
        private Product _product;

        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public decimal TotalValue() => Qtd * UnitValue;

        public decimal TotalValueWithDiscount() => TotalValue() * (1 - Discount / 100);

    }
}
