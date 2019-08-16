using LojaZero.Context;
using LojaZero.DAL;
using LojaZero.Models;
using System;
using System.Collections.Generic;

namespace LojaZero
{
    class Program
    {
        static void Main()
        {
            var context = new LojaZeroDbContextFactory().CreateDbContext();
            
            var pro = new ProductDAL(context);

            var cli = new ClientDAL(context);

            var product = new Product()
            {
                Name = "sorvete",
                Description = "sorvete muito bom",
                Stock = 10,
                Value = 1.3m,
                Weight = 1,
                ProductTags = new List<ProductTag>()
                {
                    new ProductTag()
                    {
                        Tag = new Tag()
                        {
                            Name = "Comida"
                        }
                    },
                    new ProductTag()
                    {
                        Tag = new Tag()
                        {
                            Name = "delicia"
                        }
                    }
                }
            };

            var client = new Client()
            {
                FirstName = "Felipe",
                LastName = "pinheiro", 
                CPF = "012.109.651-35", 
                DtBirthDay = new DateTime(1985,5,1), 
                Gender = Gender.Male,
                User = new UserPerson()
                {
                    Email = "flpinheiro@gmail.com",
                    Password = "12345678"
                },
                Phones = new List<Phone>()
                {
                    new Phone()
                    {
                        AreaCode = 61,
                        CountryCode =55,
                        Number = 995599415
                    }
                },
                Addresses =  new List<Address>()
                {
                    new Address()
                    {
                        Country ="brasil",
                        State = "DF",
                        City = "Brasilia",
                        District = "taguatiga",
                        Number=25,
                        Street = "qnb 03",
                        ZipCode = 72115030
                    }
                }
            

            };

            pro.Create(product);
            cli.Create(client);

            Console.WriteLine(pro.Exist(1)); 
        }
    }
}
