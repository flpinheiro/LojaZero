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
                Value = 3,
                Description = "refrigerente de cola"
            };
            var ps = new ProductSelect()
            {
                Qtd = 3,
                Product = p
            };
            Assert.AreEqual(ps.TotalValue(), 3 * 3);

        }
    }
}
