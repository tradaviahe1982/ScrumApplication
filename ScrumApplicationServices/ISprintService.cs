using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ScrumApplicationData.Models;
namespace ScrumApplicationServices
{
    public interface ISprintService
    {
        Task<SprintStatus> GetSprintStatusId(int id);
        //
        IEnumerable<SprintStatus> GetAllSprintStatus();
        Task<Sprint> GetByIdAsync(int id);
        IEnumerable<Sprint> GetAll();
        IEnumerable<Story> GetStories(int sprintId);
        Task Add(Sprint sprint);
        Task Update(Sprint sprint);
        bool IsExistSprintNumber(int SprintNumner);
    }
}
