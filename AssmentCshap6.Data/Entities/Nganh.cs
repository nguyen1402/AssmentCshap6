using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.Entities
{
    public class Nganh
    {
        public int IdNganh { get; set; }
        public string TenNganh { get; set; }
        public List<SinhVien_Nganh> sinhVien_Nganhs { get; set; }
    }
}
