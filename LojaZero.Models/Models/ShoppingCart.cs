using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LojaZero.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public DateTime DtShop { get; set; }
        public DateTime? DtSend { get; set; }
        public decimal ShippingTax { get; set; }
        public ShoppingCartStatus ShoppingCartStatus { get; set; }

        public ICollection<ProductSelect> ProductSelects { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int DeliveryAddressId { get; set; }
        public Address DeliveryAddress { get; set; }

        public int? PromotionId { get; set; }
        public Promotion Promotion { get; set; }

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

        public void ApplyPromotion()
        {
            if (Promotion == null) return;
            if (Promotion.DtEnd != null)
            {
                if (Promotion.DtEnd < DtShop)
                {
                    return;
                }
            }
            foreach (var promotion in Promotion.Products)
            {
                foreach (var select in ProductSelects)
                {
                    if (promotion.Product.Id == select.Product.Id)
                    {
                        select.Discount = promotion.Discount;
                        break;
                    }
                }
            }
        }

        public void Checkout()
        {
            foreach (var product in ProductSelects)
            {
                if (product.Product.Stock < product.Qtd)
                {
                    product.Qtd = product.Product.Stock;
                }
                product.Product.Stock -= product.Qtd;
            }
        }

        public void Cancel()
        {
            foreach (var product in ProductSelects)
            {
                product.Product.Stock += product.Qtd;
            }
        }
    }
}
