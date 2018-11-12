using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ScrumApplication.Models.ProjectViewModels;

namespace ScrumApplication.Models.ScrumViewModels
{
    public class BoardAddTaskViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int Day { get; set; }
    
        [Required]
        public int TaskStatusId { get; set; }
        [Required]
        public string StoryId { get; set; }
        [Required]
        public string UserId { get; set; }

        public IList<ProjectUserDetailViewModel> Users { get; set; }

        public IList<TaskStatusViewModel> TaskStatus { get; set; }

    }
}
