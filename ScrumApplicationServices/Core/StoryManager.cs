using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ScrumApplicationData;
using ScrumApplicationData.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace ScrumApplicationServices.Core
{
    public class StoryManager : IStoryService
    {
        private readonly ScrumApplicationDbContext _context;
        public StoryManager(ScrumApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ScrumApplicationData.Models.TaskStatus> GetAllTaskStatus()
        {
            return _context.TaskStatus.ToList();
        }
        public IEnumerable<StoryType> GetAllStoryType()
        {
            return _context.StoryType.ToList();
        }
        public IEnumerable<StoryStatus> GetAllStoryStatus()
        {
            return _context.StoryStatus.ToList();
        }
        public async Task<Story> GetByIdAsync(int id)
        {
            return await _context.Stories.FindAsync(id);

        }
        public IEnumerable<Story> GetAll()
        {
            return _context.Stories.ToList();
        }
        public IEnumerable<Tasks> GetTasks(int storyid, int taskstatusId)
        {
            return _context.Tasks
                .Include(x => x.ApplicationUser)
                .Include(x => x.Story)
                .Where(x => x.Story.Id == storyid && x.TaskStatusId == taskstatusId);

            

        }
        public async Task AddTask(Tasks task)
        {
            //
            var taskStatus = await _context.TaskStatus.FirstOrDefaultAsync(x => x.Id == 1);
            task.TaskStatusId = taskStatus.Id;
            await _context.AddAsync(task);
            await _context.SaveChangesAsync();
        }
        public async Task StartTask(Tasks task)
        {
            _context.Update(task);
            var taskStatus = await _context.TaskStatus.FirstOrDefaultAsync(x => x.Id == 2);
            task.TaskStatusId = taskStatus.Id;
            await _context.SaveChangesAsync();
        }
        public async Task RemoveTask(Tasks task)
        {
            _context.Remove(task);
            await _context.SaveChangesAsync();
        }
        public async Task GetTask(Tasks task, string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            task.UserId = userId;
            task.ApplicationUser = user;
            _context.Update(task);
            await _context.SaveChangesAsync();
        }
        public async Task VerifyTask(Tasks task)
        {
            _context.Update(task);
            var taskStatus = await _context.TaskStatus.FirstOrDefaultAsync(x => x.Id == 3);
            task.TaskStatusId = taskStatus.Id;
            await _context.SaveChangesAsync();
        }
        public async Task CompleteTask(Tasks task)
        {
            _context.Update(task);
            var taskStatus = await _context.TaskStatus.FirstOrDefaultAsync(x => x.Id == 4);
            task.TaskStatusId = taskStatus.Id;
            await _context.SaveChangesAsync();
        }
        //
       
        
        public async Task<Tasks> GetTaskById(int id)
        {
            return await _context.Tasks
                .Include(x => x.Story)
                .Include(x => x.ApplicationUser)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public IEnumerable<Tasks> GetTasks(int storyId)
        {
            return _context.Tasks
                .Include(x => x.ApplicationUser)
                .Include(x => x.Story)
                .Where(x => x.Story.Id == storyId);
        }
        public async Task Add(Story story)
        {
            await _context.AddAsync(story);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Story story)
        {
            _context.Update(story);
            await _context.SaveChangesAsync();
        }
       
    }
}
