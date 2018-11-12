using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ScrumApplicationData.Models;

namespace ScrumApplication.Models.ScrumViewModels
{
    public class BoardViewModel
    {
        public string StoryId { get; set; }
        public string StorytName { get; set; }

        public IEnumerable<Tasks> BacklogTasks { get; set; }
        public IEnumerable<Tasks> InProgressTasks { get; set; }
        public IEnumerable<Tasks> TestTasks { get; set; }
        public IEnumerable<Tasks> CompletedTasks { get; set; }

    }
}
