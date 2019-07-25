using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class Client : Person
    {
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public Client()
        {
            ShoppingCarts = new List<ShoppingCart>();
        }
    }
}
