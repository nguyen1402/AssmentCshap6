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
    public class NganhConfiguarations : IEntityTypeConfiguration<Nganh>
    {
        public void Configure(EntityTypeBuilder<Nganh> builder)
        {
            builder.ToTable("Nganhs");
            builder.HasKey(c => c.IdNganh);
            builder.Property(c => c.TenNganh).HasMaxLength(200).IsRequired();
            
        }
    }
}
