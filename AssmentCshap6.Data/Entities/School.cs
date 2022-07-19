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
        public string NameSchools { get; set; }

        public List<Student> Students { get; set; }
    }
}
