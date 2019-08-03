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
        public decimal ShippingTax { get; set; }
        public ShoppingCartStatus ShoppingCartStatus { get; set; }

        public ICollection<ProductSelect> ProductSelects { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int DeliveryAddressId { get; set; }
        public Address DeliveryAddress { get; set; }

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

        public decimal TotalValue()
        {
            decimal total = 0;
            foreach (var item in ProductSelects)
            {
                total += item.TotalValue();
            }
            return total + ShippingTax;
        }
        public decimal TotalValueWithDiscount()
        {
            decimal total = 0;
            foreach (var item in ProductSelects)
            {
                total += item.TotalValueWithDiscount();
            }
            return total + ShippingTax;
        }
    }
}
