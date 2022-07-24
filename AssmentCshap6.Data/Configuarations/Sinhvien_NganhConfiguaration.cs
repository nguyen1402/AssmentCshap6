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
    public class Sinhvien_NganhConfiguaration : IEntityTypeConfiguration<SinhVien_Nganh>
    {
        public void Configure(EntityTypeBuilder<SinhVien_Nganh> builder)
        {
            builder.HasKey(t => new { t.StudenId, t.IdNganh });

            builder.ToTable("SinhVienInNganhs");

            builder.HasOne(t => t.Students).WithMany(pc => pc.sinhVien_Nganhs)
                .HasForeignKey(pc => pc.StudenId);

            builder.HasOne(t => t.Nganhs).WithMany(pc => pc.sinhVien_Nganhs)
              .HasForeignKey(pc => pc.IdNganh);
        }
    }
}
