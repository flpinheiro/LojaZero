using LojaZero.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LojaZero.Context;

namespace LojaZero.DAL
{
    public class ProductDAL : DAL<Product>
    {
        public ProductDAL(LojaZeroDbContext context) : base(context)
        {
        }

        public override void Create(Product t)
        {
            _context.Products.Add(t);
            _context.SaveChanges();
        }

        public override void Delete(Product t)
        {
            _context.Products.Remove(t);
            _context.SaveChanges();
        }

        public override Product Read(int i)
        {            
            return _context.Products.Find(i);
        }

        public override ICollection<Product> ReadAll()
        {
            return _context.Products.ToList();
        }

        public override void Update(Product t)
        {
            _context.Products.Update(t);
            _context.SaveChanges();
        }
    }
}
