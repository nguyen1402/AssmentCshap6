using AssmentCshap6.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AssmentCshap6.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.Configuarations
{
    public class StudentsConfiguaration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.Property(c => c.HovsTenDem).HasMaxLength(200).IsRequired();
            builder.Property(c => c.Ten).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Sexs).HasDefaultValue(Sex.female);
            builder.Property(c => c.DBO);
        }
    }
}
