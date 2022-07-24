using AssmentCshap6.Data.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.Entities
{
    public class Student : IdentityUser<Guid>
    {
        public string HovsTenDem { get; set; }
        public string Ten { get; set; }
        public DateTime DBO { get; set; }
        public string Diachi { get; set; }
        public Sex Sexs { get; set; }
        public virtual ICollection<Sinhvien_Lop> sinhvien_Lops { get; set; }
        public virtual ICollection<SinhVien_MonHoc> sinhVien_MonHocs { get; set; }
        public virtual ICollection<SinhVien_School> sinhVien_Schools { get; set; }
        public virtual ICollection<SinhVien_Nganh> sinhVien_Nganhs { get; set; }
    }
}
