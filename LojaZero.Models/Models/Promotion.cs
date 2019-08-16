using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaZero.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? DtStart { get; set; }
        public DateTime? DtEnd { get; set; }
        public string Cod { get; set; }
        public ICollection<ProductPromotion> Products { get; set; }
        public ICollection<Promotion> Promotions { get; set; }

        public Promotion()
        {
            Products = new List<ProductPromotion>();
        }
    }
}
