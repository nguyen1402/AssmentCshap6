using AssmentCshap6.Data.EF;
using AssmentCshap6.Data.ViewModels;
using AssmentsCshap6.Application.Nganh;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentsCshap6.Application.nganh
{
    public class nganh : INganh
    {
        private readonly AsmentCshap6Context _context;

        public nganh(AsmentCshap6Context context)
        {
            _context = context;
        }
        public async Task<List<NganhVM>> GetAll()
        {
            var schools = await _context.Nganhs
                .Select(x => new NganhVM()
                {
                    MaNganh = x.MaNganh,
                    TenNganh = x.TenNganh
                }).ToListAsync();
            return schools;
        }
    }
}
