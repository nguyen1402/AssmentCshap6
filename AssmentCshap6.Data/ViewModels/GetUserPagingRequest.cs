using AssmentCshap6.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.ViewModels
{
    public class GetUserPagingRequest : PadingRequestBase
    {
        public string Keyword { get; set; }
    }
}
