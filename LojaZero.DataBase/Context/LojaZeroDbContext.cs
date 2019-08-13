using JetBrains.Annotations;
using LojaZero.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Context
{
    public class LojaZeroDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        public LojaZeroDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {

                //"Data Source=(localdb)/MSSQLLocalDB;Initial Catalog=LojaZero;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("LojaZero");

            modelBuilder.Entity<Address>(a =>
            {
                a.HasKey(ad => ad.Id);
            });

            modelBuilder.Entity<Client>(c =>
            {
                c.HasBaseType<Person>();
                c.HasMany(cs => cs.ShoppingCarts)
                .WithOne(s => s.Client)
                .HasForeignKey(s => s.ClientId);
            });

            modelBuilder.Entity<Company>(c =>
            {
                c.HasKey(cs => cs.Id);
                c.HasOne(cs => cs.User).WithOne(u => u.Company).HasForeignKey<Company>(cs => cs.UserId);
                c.HasMany(cs => cs.Phones).WithOne(p => p.Company).HasForeignKey(p => p.CompanyId);
                c.HasMany(cs => cs.Addresses).WithOne(a => a.Company).HasForeignKey(a => a.CompanyId);
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.HasBaseType<Person>();
                e.HasMany(es => es.ShoppingCartSelect)
                .WithOne(st => st.SelectEmployee)
                .HasForeignKey(st => st.SelectEmployeeId);
                e.HasMany(es => es.ShoppingCartDispatch)
                .WithOne(st => st.DispatchEmployee)
                .HasForeignKey(st => st.DispatchEmployeeId);
            });

            modelBuilder.Entity<Person>(p =>
            {
                p.HasKey(ps => ps.Id);
                p.HasOne(ps => ps.User)
                .WithOne(u => u.Person)
                .HasForeignKey<Person>(ps => ps.UserId);
                p.HasMany(ps => ps.Phones)
                .WithOne(ph => ph.Person)
                .HasForeignKey(ph => ph.PersonId);
                p.HasMany(ps => ps.Addresses)
                .WithOne(ad => ad.Person)
                .HasForeignKey(ad => ad.PersonId);
            });

            modelBuilder.Entity<Phone>(p =>
            {
                p.HasKey(ph => ph.Id);
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(pr => pr.Id);
                p.HasMany(pr => pr.Sold)
                .WithOne(ps => ps.Product)
                .HasForeignKey(ps => ps.ProductId);
                p.HasMany(pr => pr.ProductTags)
                .WithOne(pt => pt.Product)
                .HasForeignKey(pt => pt.ProductId);
                p.HasMany(pr => pr.Promotions)
                .WithOne(pm => pm.Product)
                .HasForeignKey(pm => pm.ProductId);
            });

            modelBuilder.Entity<ProductPromotion>(p =>
            {
                p.HasKey(pm => new { pm.ProductId, pm.PromotionId });
            });

            modelBuilder.Entity<ProductSelect>(p =>
            {
                p.HasKey(ps => new { ps.ProductId, ps.ShoppingCartId });
            });

            modelBuilder.Entity<ProductTag>(p =>
            {
                p.HasKey(pt => new { pt.ProductId, pt.TagId });
            });

            modelBuilder.Entity<Promotion>(p =>
            {
                p.HasKey(pm => pm.Id);
                p.HasMany(pm => pm.Products)
                .WithOne(pm => pm.Promotion)
                .HasForeignKey(pm => pm.PromotionId);
            });

            modelBuilder.Entity<ShoppingCart>(s =>
            {
                s.HasKey(ps => ps.Id);
                s.HasOne(sc => sc.ShoppingCartStatus)
                .WithOne(st => st.ShoppingCart)
                .HasForeignKey<ShoppingCartStatus>(st => st.ShoppingCartId);
                s.HasMany(sc => sc.ProductSelects)
                .WithOne(ps => ps.ShoppingCart)
                .HasForeignKey(ps => ps.ShoppingCartId);
            });

            modelBuilder.Entity<ShoppingCartStatus>(s =>
            {
                s.HasKey(st => st.ShoppingCartId);
            });

            modelBuilder.Entity<Tag>(t =>
            {
                t.HasKey(ts => ts.Id);
                t.HasMany(ts => ts.ProductTags)
                .WithOne(pt => pt.Tag)
                .HasForeignKey(pt => pt.TagId);
            });

            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(us => us.Id);
            });

            modelBuilder.Entity<UserPerson>(u => 
            {
                u.HasBaseType<User>();
            });

            modelBuilder.Entity<UserCompany>(u =>
            {
                u.HasBaseType<User>();
            });
        }
    }
}
