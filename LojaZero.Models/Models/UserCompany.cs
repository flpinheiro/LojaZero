using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class UserCompany : User
    {
        public Company Company { get; set; }
    }
}
