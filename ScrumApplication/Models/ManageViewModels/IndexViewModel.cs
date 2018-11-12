using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScrumApplicationData.Models;

namespace ScrumApplication.Models.ManageViewModels
{
    public class IndexViewModel
    {
        //public bool IsAdmin { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Họ của bạn tối đa 50 kí tự.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Tên của bạn tối đa 50 kí tự.")]
        public string LastName { get; set; }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Số điện thoại của bạn")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
