using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ecommerce.Data.EF
{
    public class EcommerceContextFactory : IDesignTimeDbContextFactory<EcommerceDbContext>
    {
        public EcommerceDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectString = configuration.GetConnectionString("EcommerceDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<EcommerceDbContext>();


            optionsBuilder.UseSqlServer(connectString);

            return new EcommerceDbContext(optionsBuilder.Options);
        }
    }
}
