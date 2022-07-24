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
    public class SinhVien_MonHocConfiguaration : IEntityTypeConfiguration<SinhVien_MonHoc>
    {
        public void Configure(EntityTypeBuilder<SinhVien_MonHoc> builder)
        {
            builder.HasKey(t => new { t.StudenId, t.MaMonHoc });

            builder.ToTable("SinhVienInMonHocs");

            builder.HasOne(t => t.Students).WithMany(pc => pc.sinhVien_MonHocs)
                .HasForeignKey(pc => pc.StudenId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Monhocs).WithMany(pc => pc.sinhVien_MonHocs)
              .HasForeignKey(pc => pc.MaMonHoc).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
