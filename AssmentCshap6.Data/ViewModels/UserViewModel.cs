using AssmentCshap6.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Họ và Tên Đệm")]
        public string HovaTen { get; set; }
        [Display(Name = "Tên")]
        public string Ten { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime DBO { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        [Display(Name = "Giới tính")]
        public Sex Sexs { get; set; }
        [Display(Name = "Trường học")]
        public int IdSchool { get; set; }
        [Display(Name = "Ngành")]
        public int IdNganh { get; set; }

        [Display(Name = "Hòm thư")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

    }
}
