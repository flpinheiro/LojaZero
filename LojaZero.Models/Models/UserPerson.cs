using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class UserPerson : User
    {
        public Person Person { get; set; }
    }
}
