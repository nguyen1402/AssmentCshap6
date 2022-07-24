using AssmentCshap6.Data.Configuarations;
using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.EF
{
    public class AsmentCshap6Context : IdentityDbContext<Student, AppRole, Guid>
    {
        public AsmentCshap6Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Cnass> Cnasses { get; set; }
        public DbSet<Monhoc> Monhocs { get; set; }
        public DbSet<Nganh> Nganhs { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Sinhvien_Lop> Sinhvien_Lops { get; set; }
        public DbSet<SinhVien_Nganh> SinhVien_Nganhs { get; set; }
        public DbSet<SinhVien_MonHoc> SinhVien_MonHocs { get; set; }
        public DbSet<SinhVien_School> SinhVien_Schools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppRoleConfiguaration());
            modelBuilder.ApplyConfiguration(new CnassConfiguaration());
            modelBuilder.ApplyConfiguration(new MonhocConfiguaration());
            modelBuilder.ApplyConfiguration(new NganhConfiguarations());
            modelBuilder.ApplyConfiguration(new SchoolConfiguaration());
            modelBuilder.ApplyConfiguration(new StudentsConfiguaration());
            modelBuilder.ApplyConfiguration(new Sinhvien_LopConfiguaration());
            modelBuilder.ApplyConfiguration(new SinhVien_MonHocConfiguaration());
            modelBuilder.ApplyConfiguration(new Sinhvien_NganhConfiguaration());
            modelBuilder.ApplyConfiguration(new Sinhvien_SchoolConfiguaration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
        }
    }
}
