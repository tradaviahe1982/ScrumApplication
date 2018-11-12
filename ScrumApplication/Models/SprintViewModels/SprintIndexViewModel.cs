using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumApplication.Models.SprintViewModels
{
    public class SprintIndexViewModel
    {
        public IEnumerable<SprintDetailViewModel> Sprints { get; set; }
    }
}
