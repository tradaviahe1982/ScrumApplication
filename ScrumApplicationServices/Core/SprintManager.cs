using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ScrumApplicationData;
using ScrumApplicationData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
//
namespace ScrumApplicationServices.Core
{
    public class SprintManager : ISprintService
    {
        //
        private readonly ScrumApplicationDbContext _context;
        public SprintManager(ScrumApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SprintStatus> GetAllSprintStatus()
        {
            return _context.SprintStatus.ToList();
        }
        public async Task<Sprint> GetByIdAsync(int id)
        {
            return await _context.Sprints.FindAsync(id);
        }
        public async Task<SprintStatus> GetSprintStatusId(int id)
        {
            return await _context.SprintStatus.FindAsync(id);
        }
        public IEnumerable<Sprint> GetAll()
        {
            return _context.Sprints.ToList();
        }

        public IEnumerable<Story> GetStories(int sprintId)
        {
            return _context.Stories.Include(x => x.Sprint)
                                   .Where(x => x.Sprint.Id == sprintId);
        }
        public async Task Add(Sprint sprint)
        {
            await _context.AddAsync(sprint);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Sprint sprint)
        {
            _context.Update(sprint);
            await _context.SaveChangesAsync();
        }
        public bool IsExistSprintNumber(int SprintNumner)
        {
            var result = _context.Sprints.Where(x => x.Number == SprintNumner).FirstOrDefault();
            return (result.Number == SprintNumner);
        }
    }
}
