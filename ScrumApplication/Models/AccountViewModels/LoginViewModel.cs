using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumApplication.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bạn phải nhập thư điện tử")]
        [EmailAddress(ErrorMessage = "Bạn phải nhập đúng định dạng thư điện tử")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Có lưu mật khẩu?")]
        public bool RememberMe { get; set; }
    }
}
