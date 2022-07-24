using AssmentCshap6.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.ViewModels
{
   public class Registerequest
    {
        [Display(Name = "Họ Và Tên Đệm")]
        [Required(ErrorMessage = "Không được bỏ trống Họ Và Tên Đệm")]
        public string HovaTenDem { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Không được bỏ trống Tên")]
        public string Ten { get; set; }
        [Display(Name = "Ngày Sinh")]
        [Required(ErrorMessage = "Không được bỏ trống Ngày Sinh")]
        public DateTime DBO { get; set; }
        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "Không được bỏ trống Địa Chỉ")]
        public string Diachi { get; set; }
        [Display(Name = "Giới Tính")]
        [Required(ErrorMessage = "Không được bỏ trống Giới Tính")]
        public Sex Sexs { get; set; }

        [Display(Name = "Hòm thư")]
        [Required(ErrorMessage = "Không được bỏ trống Hòm thư")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Không được bỏ trống Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Không được bỏ trống Tài khoản")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Không được bỏ trống Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Nhập Lại Mật Khẩu Không Đúng")]
        public string ConfirmPassword { get; set; }
    }
}
