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
    public class CnassConfiguaration : IEntityTypeConfiguration<Cnass>
    {
        public void Configure(EntityTypeBuilder<Cnass> builder)
        {
            builder.ToTable("Lops");
            builder.HasKey(c => c.MaLop);
            builder.Property(c => c.TenLop).HasMaxLength(200).IsRequired();
            
        }
    }
}
