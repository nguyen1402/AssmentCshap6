using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.Entities
{
    public class Cnass
    {
        public int MaLop { get; set; }
        public string TenLop { get; set; }

        public List<Sinhvien_Lop> sinhvien_Lops { get; set; }
    }
}
