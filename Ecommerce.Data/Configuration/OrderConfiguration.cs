using Ecommerce.Data.Entities;
using Ecommerce.Data.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OrderDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ShipAddress).IsRequired(true).HasMaxLength(200);
            builder.Property(x => x.ShipName).IsRequired(true).HasMaxLength(80);
            builder.Property(x => x.ShipEmail).IsRequired(true).IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.ShipPhoneNumber).IsRequired(true).HasMaxLength(20);
        }
    }
}
