using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.ViewModels
{
    public class Loginrequest
    {
        [Display(Name = "Tài Khoản")]
        [Required(ErrorMessage = "Không được bỏ trống Tài Khoản")]
        public string UserName { get; set; }
        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Không được bỏ trống mật khẩu")]
        public string Password { get; set; }

    }
}
