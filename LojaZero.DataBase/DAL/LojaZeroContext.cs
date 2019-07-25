using LojaZero.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.DataBase.DAL
{
    class LojaZeroContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        //public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(p => 
            {
                p.HasKey(ps => ps.Id);
            });

            modelBuilder.Entity<Product>(p => 
            {
                p.HasKey(ps => ps.Id);
            });

            modelBuilder.Entity<ProductSelect>(p => 
            {
                p.HasKey(ps => new {ps.ProductId, ps.ShoppingCartId });
            });
            modelBuilder.Entity<ShoppingCart>(p => 
            {
                p.HasKey(ps => ps.Id);
            });
        }

    }
}
