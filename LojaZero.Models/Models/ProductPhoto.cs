using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaZero.Models
{
    public class ProductPhoto
    {
        [Required,MaxLength(1<<10)]
        public byte[] File { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
