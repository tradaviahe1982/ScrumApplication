using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ScrumApplicationData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace ScrumApplicationServices
{
    public interface IStoryService
    {
        IEnumerable<ScrumApplicationData.Models.TaskStatus> GetAllTaskStatus();
        IEnumerable<StoryType> GetAllStoryType();
        IEnumerable<StoryStatus> GetAllStoryStatus();
        Task<Story> GetByIdAsync(int id);
        IEnumerable<Story> GetAll();
        IEnumerable<Tasks> GetTasks(int id, int taskstatusId);
        Task<Tasks> GetTaskById(int id);
        IEnumerable<Tasks> GetTasks(int storyId);
        Task AddTask(Tasks task);
        Task StartTask(Tasks task);
        Task VerifyTask(Tasks task);
        Task CompleteTask(Tasks task);
        Task Add(Story story);
        Task Update(Story story);
        Task RemoveTask(Tasks task);
        Task GetTask(Tasks task, string userId);

    }
}
