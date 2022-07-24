using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.Entities
{
    public class School
    {
        public int IdSchool { get; set; }
        public string TenTruong { get; set; }
        public List<SinhVien_School> sinhVien_Schools { get; set; }
    }
}
