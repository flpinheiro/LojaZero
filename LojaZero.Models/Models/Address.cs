using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int ZipCode { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
