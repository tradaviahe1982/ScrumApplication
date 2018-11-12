using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ScrumApplication.Models.RoleViewModels
{
    public class ApplicationRoleDetailViewModel
    {
       
        public string Id { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tên quyền")]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string UserRoleName { get; set; }
        public string StatusMessage { get; set; }
    }
}
