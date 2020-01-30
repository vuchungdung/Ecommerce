using Ecommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.Configuration
{
    public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            builder.ToTable("CategoryTranslations");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.LanguageId).IsUnicode(false).IsRequired(true).HasMaxLength(5);

            builder.Property(x => x.SeoDescription).HasMaxLength(250);

            builder.Property(x => x.SeoAlias).IsUnicode(false).HasMaxLength(50);

            builder.Property(x => x.Name).IsRequired(true);

            builder.HasOne(x => x.Category).WithMany(s => s.CategoryTranslations).HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Language).WithMany(s => s.CategoryTranslations).HasForeignKey(x => x.LanguageId);
        }
    }
}
