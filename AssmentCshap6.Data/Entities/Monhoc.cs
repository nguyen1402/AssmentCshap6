using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.Entities
{
    public class Monhoc
    {
        public int IdMonhoc { get; set; }
        public string TenMonhoc { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<SinhVien_MonHoc> sinhVien_MonHocs { get; set; }
    }
}
