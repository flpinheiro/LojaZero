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

            Assert.AreEqual(sc.TotalWeight(), 3 * 3 + 4 * 4);
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

            Assert.AreEqual(sc.Totalvalue(), 3 * 12 + 4 * 16 + 10);
        }
    }
}
