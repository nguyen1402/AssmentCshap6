using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsmentCShap6.ViewModels.SinhVienInMonHocs
{
    public class SinhVienINMonHocViewModel
    {
        public Guid IdSrudent { get; set; }
        public int IdMonhoc { get; set; }
        public string? TenSV { get; set; }
        public string? TenMonHoc { get; set; }
        public string? Email { get; set; }
        public decimal Diem { get; set; }

    }
}
