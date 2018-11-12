using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ScrumApplication.Models.SprintViewModels;
using ScrumApplication.Models.ProjectViewModels;
namespace ScrumApplication.Models.StoryViewModels
{
    public class StoryDetailViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Reporter { get; set; }
        public string Description { get; set; }
        public int Point { get; set; }
        [Required]
        [Display(Name = "Bạn phải chọn trạng thái dự án")]
        public int ProjectId { get; set; }
        [Required]
        [Display(Name = "Bạn phải chọn trạng thái Sprint")]
        public int SprintId { get; set; }
        [Required]
        [Display(Name = "Bạn phải chọn trạng thái Story")]
        public int StoryStatusId { get; set; }
        [Required]
        [Display(Name = "Bạn phải chọn kiểu Story")]
        public int StoryTypeId { get; set; }

        public string StatusMessage { get; set; }
    }
}
