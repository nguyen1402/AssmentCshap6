using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.Entities
{
    public class Sinhvien_Lop
    {
        public Guid StudenId { get; set; }
        public Student Students { get; set; }

        public int Malop { get; set; }
        public Cnass Cnasss { get; set; }

        public string Desctions { get; set; }
    }
}
