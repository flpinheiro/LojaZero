using LojaZero.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LojaZero.Models
{
    [TestClass]
    public class TestContext
    {
        [TestMethod]
        public void TestProductSelect()
        {
            using (var context = new LojaZeroDbContextFactory().CreateDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var prod = new Product()
                {
                    Name = "Sorvete",
                    Description = "melhor Sorvete do mundo",
                    Value = 20,
                    Weight = 10,
                    Stock = 10
                };

                var cart = new ShoppingCart()
                {
                    ProductSelects = new List<ProductSelect>()
                    {
                        new ProductSelect()
                        {
                            Product = prod,
                            Qtd = 3
                        }
                    }
                };

                context.ShoppingCarts.Add(cart);
                context.SaveChanges();

                prod = context.Products.FirstOrDefault(a => a.Id == 1);
                prod.Value = 10;
                context.SaveChanges();

                var shopCart = context.ShoppingCarts.FirstOrDefault(a => a.Id == 1);
                decimal value = 0;
                foreach (var product in shopCart.ProductSelects)
                {
                    value = product.UnitValue;
                }
                Assert.AreEqual(20, value);
            }
        }
    }
}
