using JetBrains.Annotations;
using LojaZero.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.DataBase.DAL
{
    public class LojaZeroContext : DbContext
    {
        public LojaZeroContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSelect> ProductSelects { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("Data Source=(localdb)/MSSQLLocalDB;Initial Catalog=LojaZero;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(p =>
            {
                p.HasKey(ps => ps.Email);
            });
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
