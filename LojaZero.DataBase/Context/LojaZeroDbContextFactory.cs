using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.Context
{
    public class LojaZeroDbContextFactory: IDesignTimeDbContextFactory<LojaZeroDbContext>
    {
        private static string _connectionString;

        public LojaZeroDbContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public LojaZeroDbContext CreateDbContext(string[] args)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                LoadConnectionString();
            }
            var builder = new DbContextOptionsBuilder<LojaZeroDbContext>();
            builder.UseSqlServer(_connectionString);

            return new LojaZeroDbContext(builder.Options);
        }

        private static void LoadConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            _connectionString = configuration.GetConnectionString("Default");
        }
    }
}
