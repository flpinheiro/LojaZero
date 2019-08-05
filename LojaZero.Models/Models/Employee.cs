using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class Employee : Person
    {
        public bool Status { get; set; }
        public ICollection<ShoppingCartStatus> ShoppingCartSelect { get; set; }
        public ICollection<ShoppingCartStatus> ShoppingCartDispatch { get; set; }
    }
}
