using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LojaZero.Models;

namespace LojaZero.Test.Models
{
    [TestClass]
    public class TestProductSelect
    {
        [TestMethod]
        public void TestTotalValue()
        {
            var p = new Product()
            {
                Name = "Refrigerante",
                Value = 3m,
                Description = "refrigerente de cola"
            };
            var ps = new ProductSelect()
            {
                Qtd = 3,
                Product = p
            };
            Assert.AreEqual(3m * 3m, ps.TotalValue());
        }

        [TestMethod]
        public void TestTotalValueWithDiscount()
        {
            var p = new Product()
            {
                Name = "Refrigerante",
                Value = 12m,
                Description = "refrigerente de cola"
            };
            var ps = new ProductSelect()
            {
                Qtd = 3,
                Product = p,
                Discount = 10
            };
            Assert.AreEqual(32.4m, ps.TotalValueWithDiscount());
        }
        [TestMethod]
        public void TestTotalValueWithDiscount2()
        {
            var p = new Product()
            {
                Name = "Refrigerante",
                Value = 16m,
                Description = "refrigerente de cola"
            };
            var ps = new ProductSelect()
            {
                Qtd = 4,
                Product = p,
                Discount = 20
            };
            Assert.AreEqual(51.2m, ps.TotalValueWithDiscount());
        }

        [TestMethod]
        public void TestUnitValue()
        {
            var p = new Product()
            {
                Value = 3m
            };
            var ps = new ProductSelect
            {
                Product = p
            };
            Assert.AreEqual(3m, ps.UnitValue);
        }

        [TestMethod]
        public void TestUnitValue2()
        {
            var p = new Product()
            {
                Value = 3m
            };
            var p2 = new Product()
            {
                Value = 5m
            };
            var ps = new ProductSelect
            {
                Product = p
            };
            ps.Product = p2;
            Assert.AreEqual(3m, ps.UnitValue);
        }
    }
}
