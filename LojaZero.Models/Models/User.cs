using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
