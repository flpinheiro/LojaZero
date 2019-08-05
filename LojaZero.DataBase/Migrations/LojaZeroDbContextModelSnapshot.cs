﻿// <auto-generated />
using System;
using LojaZero.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LojaZero.Migrations
{
    [DbContext(typeof(LojaZeroDbContext))]
    partial class LojaZeroDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("LojaZero")
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LojaZero.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Country");

                    b.Property<string>("District");

                    b.Property<int>("Number");

                    b.Property<int?>("PersonId");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<int>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PersonId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("LojaZero.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ");

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("LojaZero.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("DtBirthDay");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("LastName");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("LojaZero.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaCode");

                    b.Property<int?>("CompanyId");

                    b.Property<int>("CountryCode");

                    b.Property<int>("Number");

                    b.Property<int?>("PersonId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PersonId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("LojaZero.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Stock");

                    b.Property<decimal>("Value");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("LojaZero.Models.ProductPromotion", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("PromotionId");

                    b.Property<decimal>("Discount");

                    b.HasKey("ProductId", "PromotionId");

                    b.HasIndex("PromotionId");

                    b.ToTable("ProductPromotion");
                });

            modelBuilder.Entity("LojaZero.Models.ProductSelect", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("ShoppingCartId");

                    b.Property<decimal>("Discount");

                    b.Property<int>("Qtd");

                    b.Property<decimal>("UnitValue");

                    b.HasKey("ProductId", "ShoppingCartId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ProductSelect");
                });

            modelBuilder.Entity("LojaZero.Models.ProductTag", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("TagId");

                    b.HasKey("ProductId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ProductTag");
                });

            modelBuilder.Entity("LojaZero.Models.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cod");

                    b.Property<DateTime>("DtEnd");

                    b.Property<DateTime>("DtStart");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("LojaZero.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<int>("DeliveryAddressId");

                    b.Property<DateTime>("DtSend");

                    b.Property<DateTime>("DtShop");

                    b.Property<decimal>("ShippingTax");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DeliveryAddressId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("LojaZero.Models.ShoppingCartStatus", b =>
                {
                    b.Property<int>("ShoppingCartId");

                    b.Property<bool>("Dispatch");

                    b.Property<int?>("DispatchEmployeeId");

                    b.Property<bool>("Paid");

                    b.Property<int?>("SelectEmployeeId");

                    b.Property<bool>("Selected");

                    b.Property<string>("TrackCod");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("DispatchEmployeeId");

                    b.HasIndex("SelectEmployeeId");

                    b.ToTable("ShoppingCartStatus");
                });

            modelBuilder.Entity("LojaZero.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("LojaZero.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LojaZero.Models.Client", b =>
                {
                    b.HasBaseType("LojaZero.Models.Person");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("LojaZero.Models.Employee", b =>
                {
                    b.HasBaseType("LojaZero.Models.Person");

                    b.Property<bool>("Status");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("LojaZero.Models.Address", b =>
                {
                    b.HasOne("LojaZero.Models.Company", "Company")
                        .WithMany("Addresses")
                        .HasForeignKey("CompanyId");

                    b.HasOne("LojaZero.Models.Person", "Person")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("LojaZero.Models.Company", b =>
                {
                    b.HasOne("LojaZero.Models.User", "User")
                        .WithOne("Company")
                        .HasForeignKey("LojaZero.Models.Company", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaZero.Models.Person", b =>
                {
                    b.HasOne("LojaZero.Models.User", "User")
                        .WithOne("Person")
                        .HasForeignKey("LojaZero.Models.Person", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaZero.Models.Phone", b =>
                {
                    b.HasOne("LojaZero.Models.Company", "Company")
                        .WithMany("Phones")
                        .HasForeignKey("CompanyId");

                    b.HasOne("LojaZero.Models.Person", "Person")
                        .WithMany("Phones")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("LojaZero.Models.ProductPromotion", b =>
                {
                    b.HasOne("LojaZero.Models.Product", "Product")
                        .WithMany("Promotions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LojaZero.Models.Promotion", "Promotion")
                        .WithMany("Products")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaZero.Models.ProductSelect", b =>
                {
                    b.HasOne("LojaZero.Models.Product", "Product")
                        .WithMany("Sold")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LojaZero.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("ProductSelects")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaZero.Models.ProductTag", b =>
                {
                    b.HasOne("LojaZero.Models.Product", "Product")
                        .WithMany("ProductTags")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LojaZero.Models.Tag", "Tag")
                        .WithMany("ProductTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaZero.Models.ShoppingCart", b =>
                {
                    b.HasOne("LojaZero.Models.Client", "Client")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LojaZero.Models.Address", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaZero.Models.ShoppingCartStatus", b =>
                {
                    b.HasOne("LojaZero.Models.Employee", "DispatchEmployee")
                        .WithMany("ShoppingCartDispatch")
                        .HasForeignKey("DispatchEmployeeId");

                    b.HasOne("LojaZero.Models.Employee", "SelectEmployee")
                        .WithMany("ShoppingCartSelect")
                        .HasForeignKey("SelectEmployeeId");

                    b.HasOne("LojaZero.Models.ShoppingCart", "ShoppingCart")
                        .WithOne("ShoppingCartStatus")
                        .HasForeignKey("LojaZero.Models.ShoppingCartStatus", "ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}