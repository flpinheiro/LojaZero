using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }


        public int UserId { get; set; }
        public UserCompany User { get; set; }

        public ICollection<Phone> Phones { get; set; }
        public ICollection<Address> Addresses { get; set; }

        public Company()
        {
            Phones = new List<Phone>();
            Addresses = new List<Address>();
        }
    }
}
