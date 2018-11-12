using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ScrumApplicationData;
using ScrumApplicationData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace ScrumApplicationServices.Core
{
    public class ProjectManager : IProjectService
    {
       
        private readonly ScrumApplicationDbContext _context;
        public ProjectManager(ScrumApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ProjectStatus> GetAllProjectStatus()
        {
            return _context.ProjectStatus.ToList();
        }
        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);

        }
        public IEnumerable<Project> GetAll()
        {
            return _context.Projects.ToList();
        }

        public IEnumerable<Sprint> GetSprints(int projectId)
        {
            return _context.Sprints.Include(x => x.Project)
                                   .Where(x => x.Project.Id == projectId);
        }
        public async Task Add(Project project)
        {
            await _context.AddAsync(project);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Project project)
        {
            _context.Update(project);
            await _context.SaveChangesAsync();
        }
        //
        public IEnumerable<ApplicationUserRole> GetProjectUserRoles(string projectId)
        {
            return _context.UserRoles.Where(x => x.ProjectId == projectId);
        }
        //
        public IEnumerable<ApplicationUserRole> GetUserRolesAtRoleId(string RoleId)
        {
            return _context.UserRoles.Where(x => x.RoleId == RoleId);
        }
        //
        public async Task AddUser(ApplicationUserRole userRole)
        {
            await _context.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }
        //
        public async Task DeleteUser(ApplicationUserRole userRole)
        {
            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
        }
        //
    }
}
