using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class ShoppingCartStatus
    {
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public string TrackCod { get; set; }

        public bool Paid { get; set; }
        public bool Selected { get; set; }
        public int? SelectEmployeeId { get; set; }
        public Employee SelectEmployee { get; set; }
        public bool Dispatch { get; set; }
        public int? DispatchEmployeeId { get; set; }
        public Employee DispatchEmployee { get; set; }

        public ShoppingCartStatus()
        {
            Paid = false;
            Selected = false;
            Dispatch = false;
        }
    }
}
