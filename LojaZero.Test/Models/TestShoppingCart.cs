using LojaZero.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Test.Models
{
    [TestClass]
    public class TestShoppingCart
    {
        [TestMethod]
        public void TestTotalWeight()
        {
            var ps1 = new ProductSelect()
            {
                Product = new Product()
                {
                    Weight = 3
                },
                Qtd = 3
            };
            var ps2 = new ProductSelect()
            {
                Product = new Product()
                {
                    Weight = 4
                },
                Qtd = 4
            };
            var sc = new ShoppingCart();
            sc.ProductSelects.Add(ps1);
            sc.ProductSelects.Add(ps2);

            Assert.AreEqual(3 * 3 + 4 * 4, sc.TotalWeight());
        }

        [TestMethod]
        public void TestTotalValue()
        {
            var ps1 = new ProductSelect()
            {
                Product = new Product()
                {
                    Value = 12
                },
                Qtd = 3
            };
            var ps2 = new ProductSelect()
            {
                Product = new Product()
                {
                    Value = 16
                },
                Qtd = 4
            };
            var sc = new ShoppingCart()
            {
                ShippingTax = 10
            };
            sc.ProductSelects.Add(ps2);
            sc.ProductSelects.Add(ps1);

            Assert.AreEqual(3m * 12m + 4m * 16m + 10m, sc.TotalValue() );
        }

        [TestMethod]
        public void TestTotalValueWithDiscount()
        {
            var ps1 = new ProductSelect()
            {
                Product = new Product()
                {
                    Value = 12m
                },
                Qtd = 3, 
                Discount = 10
            };
            var ps2 = new ProductSelect()
            {
                Product = new Product()
                {
                    Value = 16m
                },
                Qtd = 4,
                Discount = 20
            };
            var sc = new ShoppingCart()
            {
                ShippingTax = 10
            };
            sc.ProductSelects.Add(ps2);
            sc.ProductSelects.Add(ps1);

            Assert.AreEqual((decimal)3m * 12m * (1m - 10m / 100m) + 4m * 16m * (1m - 20m / 100m) + 10m,sc.TotalValueWithDiscount());
        }

        [TestMethod]
        public void TestApplyDiscount()
        {
            var product = new Product()
            {
                Name = "sorvete",
                Id = 1,
                Value = 10,
                Promotions = new List<ProductPromotion>()
                {
                    new ProductPromotion()
                    {
                        ProductId = 1,
                        Discount = 10
                    }
                }
            };
            var productSelection = new ProductSelect()
            {
                Product = product,
                Qtd = 1
            };
            var shoppingCart = new ShoppingCart()
            {
                ProductSelects = new List<ProductSelect>()
                {
                    productSelection
                }
            };
            Assert.AreEqual(9, shoppingCart.TotalValueWithDiscount() );
        }
    }
}
