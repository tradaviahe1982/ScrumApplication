using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ScrumApplication.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Bạn phải nhập họ")]
        [StringLength(50, ErrorMessage = "Chiều dài kí tự tối đa là 50.")]
        [Display(Name = "Họ của bạn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên")]
        [StringLength(50, ErrorMessage = "Chiều dài kí tự tối đa là 50.")]
        [Display(Name = "Tên của bạn")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập thư điện tử")]
        [EmailAddress]
        [Display(Name = "Thư điện tử")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Chiều dài mật khẩu phải ít là 6 kí tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu chưa khớp nhau.")]
        public string ConfirmPassword { get; set; }
    }
}
