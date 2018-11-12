using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ScrumApplication.Models.RoleViewModels;
using ScrumApplication.Models.UserViewModels;

namespace ScrumApplication.Models.ProjectViewModels
{
    public class ProjectDetailViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StatusMessage { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn trạng thái dự án")]
        public int ProjectStatusID { get; set; }
        public IList<ProjectUserDetailViewModel> ProjectUsers { get; set; }
        public IEnumerable<UserDetailViewModel> Users { get; set; }
        public IEnumerable<ApplicationRoleDetailViewModel> Roles { get; set; }
    }
}
