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
    public class Sinhvien_LopConfiguaration : IEntityTypeConfiguration<Sinhvien_Lop>
    {
        public void Configure(EntityTypeBuilder<Sinhvien_Lop> builder)
        {
            builder.HasKey(t => new { t.StudenId, t.Malop });

            builder.ToTable("SinhVienInLops");

            builder.HasOne(t => t.Students).WithMany(pc => pc.sinhvien_Lops)
                .HasForeignKey(pc => pc.StudenId);

            builder.HasOne(t => t.Cnasss).WithMany(pc => pc.sinhvien_Lops)
              .HasForeignKey(pc => pc.Malop);
        }
    }
}