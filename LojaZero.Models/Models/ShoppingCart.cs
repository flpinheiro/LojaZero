using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public DateTime DtShop { get; set; }
        public DateTime DtSend { get; set; }
        public double ShippingTax { get; set; }
        public ICollection<ProductSelect> ProductSelects { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public ShoppingCart()
        {
            ProductSelects = new List<ProductSelect>();
        }

        public double TotalWeight()
        {
            double weight = 0;
            foreach (var p in ProductSelects)
            {
                weight += p.Product.Weight * p.Qtd;
            }

            return weight;
        }

        public double Totalvalue()
        {
            double total = 0;
            foreach (var item in ProductSelects)
            {
                total += item.TotalValue();
            }

            return total + ShippingTax;
        }
    }
}
