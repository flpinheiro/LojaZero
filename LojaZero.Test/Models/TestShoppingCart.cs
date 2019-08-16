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

            Assert.AreEqual(3m * 12m + 4m * 16m + 10m, sc.TotalValue());
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
            Assert.AreEqual((decimal)3m * 12m * (1m - 10m / 100m) + 4m * 16m * (1m - 20m / 100m) + 10m, sc.TotalValueWithDiscount());
        }


        [TestMethod]
        public void TestApplyPromotion()
        {
            var prod1 = new Product()
            {
                Id = 1,
                Value = 10
            };
            var prod2 = new Product()
            {
                Id = 2,
                Value = 5
            };

            var promo = new Promotion()
            {
                Products = new List<ProductPromotion>()
                {
                    new ProductPromotion(){Product = prod1, Discount = 20},
                    new ProductPromotion(){Product = prod2 , Discount = 10}
                }
            };

            var cart = new ShoppingCart()
            {
                ProductSelects = new List<ProductSelect>()
                {
                    new ProductSelect(){Product = prod1, Qtd=1 },
                    new ProductSelect(){Product = prod2, Qtd=1 }
                },
                Promotion = promo
            };
            cart.ApplyPromotion();
            Assert.AreEqual(10 * 0.8m + 5 * 0.9m, cart.TotalValueWithDiscount());
        }

        [TestMethod]
        public void TestApplyPromotion2()
        {
            var prod1 = new Product()
            {
                Id = 1,
                Value = 10
            };
            var prod2 = new Product()
            {
                Id = 2,
                Value = 5
            };

            var promo = new Promotion()
            {
                Products = new List<ProductPromotion>()
                {
                    new ProductPromotion() { Product = prod1, Discount = 20 },
                    new ProductPromotion() { Product = prod2, Discount = 10 }
                },
                DtEnd = DateTime.Today.AddDays(-1)
            };

            var cart = new ShoppingCart()
            {
                ProductSelects = new List<ProductSelect>()
                {
                    new ProductSelect(){Product = prod1, Qtd=1 },
                    new ProductSelect(){Product = prod2, Qtd=1 }
                },
                Promotion = promo,
                DtShop = DateTime.Today
            };
            cart.ApplyPromotion();
            Assert.AreEqual(cart.TotalValue(), cart.TotalValueWithDiscount());
        }

        [TestMethod]
        public void TestApplyPromotion3()
        {
            var prod1 = new Product()
            {
                Id = 1,
                Value = 10
            };
            var prod2 = new Product()
            {
                Id = 2,
                Value = 5
            };

            var promo = new Promotion()
            {
                Products = new List<ProductPromotion>()
                {
                    new ProductPromotion() { Product = prod1, Discount = 20 },
                    new ProductPromotion() { Product = prod2, Discount = 10 }
                },
                DtEnd = DateTime.Today
            };

            var cart = new ShoppingCart()
            {
                ProductSelects = new List<ProductSelect>()
                {
                    new ProductSelect(){Product = prod1, Qtd=1 },
                    new ProductSelect(){Product = prod2, Qtd=1 }
                },
                Promotion = promo,
                DtShop = DateTime.Today
            };
            cart.ApplyPromotion();
            Assert.AreEqual(10 * 0.8m + 5 * 0.9m, cart.TotalValueWithDiscount());
        }

        [TestMethod]
        public void TestCheckout()
        {
            var prod = new Product()
            {
                Id = 1,
                Name = "sorvete",
                Stock = 10
            };

            var cart = new ShoppingCart()
            {
                ProductSelects = new List<ProductSelect>()
                {
                    new ProductSelect()
                    {
                        Product = prod, Qtd = 5
                    }
                }
            };
            cart.Checkout();
            Assert.AreEqual((uint)5, prod.Stock);
        }


        [TestMethod]
        public void TestCheckout2()
        {
            var prod = new Product()
            {
                Id = 1,
                Name = "sorvete",
                Stock = 10
            };

            var cart = new ShoppingCart()
            {
                ProductSelects = new List<ProductSelect>()
                {
                    new ProductSelect()
                    {
                        Product = prod, Qtd = 15
                    }
                }
            };
            cart.Checkout();
            Assert.AreEqual((uint)0, prod.Stock);
        }

        [TestMethod]
        public void TestCancel()
        {
            var prod = new Product()
            {
                Id = 1,
                Name = "sorvete",
                Stock = 10
            };

            var cart = new ShoppingCart()
            {
                ProductSelects = new List<ProductSelect>()
                {
                    new ProductSelect()
                    {
                        Product = prod, Qtd = 5
                    }
                }
            };
            cart.Cancel();
            Assert.AreEqual((uint)15, prod.Stock);
        }

    }
}
