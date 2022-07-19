using AssmentCshap6.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentsCshap6.Application.Schools
{
    public interface Ischool
    {
        Task<List<SchoolVM>> GetAll();
    }
}
