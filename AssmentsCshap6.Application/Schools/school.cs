using AssmentCshap6.Data.EF;
using AssmentCshap6.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentsCshap6.Application.Schools
{
    public class school : Ischool
    {
        private readonly AsmentCshap6Context _context;

        public school(AsmentCshap6Context context)
        {
            _context = context;
        }
        public async Task<List<SchoolVM>> GetAll()
        {
            var schools = await _context.Schools
                .Select(x => new SchoolVM()
                {
                    IdSchool = x.IdSchool,
                    NameSchools = x.NameSchools
                }).ToListAsync();
            return schools;
        }
    }
}
