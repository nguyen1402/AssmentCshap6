using AssmentCshap6.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.Configuarations
{
    public class MonhocConfiguaration : IEntityTypeConfiguration<Monhoc>
    {
        public void Configure(EntityTypeBuilder<Monhoc> builder)
        {
            builder.ToTable("Monhocs");
            builder.HasKey(c => c.IdMonhoc);
            builder.Property(c => c.TenMonhoc).HasMaxLength(200).IsRequired();
        }
    }
}
