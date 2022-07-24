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
    public class Sinhvien_SchoolConfiguaration : IEntityTypeConfiguration<SinhVien_School>
    {
        public void Configure(EntityTypeBuilder<SinhVien_School> builder)
        {
            builder.HasKey(t => new { t.StudenId, t.IdSchools });

            builder.ToTable("SinhVienInSchools");

            builder.HasOne(t => t.Students).WithMany(pc => pc.sinhVien_Schools)
                .HasForeignKey(pc => pc.StudenId);

            builder.HasOne(t => t.Schools).WithMany(pc => pc.sinhVien_Schools)
              .HasForeignKey(pc => pc.IdSchools);
        }
    }
}
