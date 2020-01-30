﻿using Ecommerce.Data.Configuration;
using Ecommerce.Data.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ecommerce.Data.EF
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartConfiguration());

            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppConfig> AppConfigs { set; get; }
        public DbSet<Cart> Carts { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<CategoryTranslation> CategoryTranslations { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<Language> Languages { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductInCategory> ProductInCategories { set; get; }
        public DbSet<ProductTranslation> ProductTranslations { set; get; }
        public DbSet<Promotion> Promotions { set; get; }
        public DbSet<Transaction> Transactions { set; get; }

    }
}
