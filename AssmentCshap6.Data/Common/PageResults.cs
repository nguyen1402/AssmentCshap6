using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.Common
{
    public class PageResults<T> : PagedResultBase
    {
        public List<T> Iteams { get; set; }
    }
}
