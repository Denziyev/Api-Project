using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Core.Entities;

namespace WebApplication1.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired(true).HasMaxLength(30)
                .IsUnicode(true);
            builder.Property(x => x.CreadetAt)
                .IsRequired(true).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x=>x.IsDeleted).HasDefaultValue(false);
        }
    }
}
