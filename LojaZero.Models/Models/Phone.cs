using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }

        public int? PersonId { get; set; }
        public Person Person { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
