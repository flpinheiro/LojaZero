using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DtbirthDay { get; set; }
        public string CPF { get; set; }

        public User User { get; set; }

        public ICollection<Phone> Phones { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public Person()
        {
            Addresses = new List<Address>();
            Phones = new List<Phone>();
        }
    }
}
