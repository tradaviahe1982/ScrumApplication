using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumApplication.Models.ProjectViewModels
{
    public class ProjectUserDetailViewModel
    {
        [Required(ErrorMessage = "Bạn phải chọn trạng thái dự án")]
        public string ProjectId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn người dùng")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn quyền")]
        public string RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string UserRoleName { get; set; }

    }
}
