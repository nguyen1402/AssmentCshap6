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
        public int Manganh { get; set; }
        public int IdSchools { get; set; }
        public string HovsTenDem { get; set; }
        public string Ten { get; set; }
        public DateTime DBO { get; set; }
        public string Diachi { get; set; }
        public Sex Sexs { get; set; }
        public List<Sinhvien_Lop> sinhvien_Lops { get; set; }
        public List<SinhVien_MonHoc> sinhVien_MonHocs { get; set; }
        public Nganh Nganhs { get; set; }
        public School Schools { get; set; }
    }
}
