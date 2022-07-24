using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.Entities
{
    public class SinhVien_Nganh
    {
        public Guid StudenId { get; set; }
        public virtual Student Students { get; set; }

        public int IdNganh { get; set; }
        public virtual Nganh Nganhs { get; set; }

        public string Desctions { get; set; }
    }
}
