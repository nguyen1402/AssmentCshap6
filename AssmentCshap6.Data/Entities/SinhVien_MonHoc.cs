using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.Entities
{
    public class SinhVien_MonHoc
    {
        public Guid StudenId { get; set; }

        public virtual Student Students { get; set; }

        public int MaMonHoc { get; set; }
        public virtual Monhoc Monhocs { get; set; }

        public decimal Diem { get; set; }
    }
}
