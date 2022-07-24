using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.Entities
{
    public class SinhVien_School
    {
        public Guid StudenId { get; set; }
        public virtual Student Students { get; set; }

        public int IdSchools { get; set; }
        public virtual School Schools { get; set; }

        public string Desctions { get; set; }
    }
}
