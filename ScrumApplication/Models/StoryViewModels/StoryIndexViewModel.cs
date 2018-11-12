using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumApplication.Models.StoryViewModels
{
    public class StoryIndexViewModel
    {
        public IEnumerable<StoryDetailViewModel> Stories { get; set; }
    }
}
