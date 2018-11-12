using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ScrumApplicationData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace ScrumApplicationServices
{
    public interface IProjectService
    {

        IEnumerable<ProjectStatus> GetAllProjectStatus();
        Task<Project> GetByIdAsync(int id);
        IEnumerable<Project> GetAll();
        IEnumerable<Sprint> GetSprints(int projectId);
        Task Add(Project project);
        Task Update(Project project);
        //
        IEnumerable<ApplicationUserRole> GetProjectUserRoles(string projectId);
        IEnumerable<ApplicationUserRole> GetUserRolesAtRoleId(string RoleId);
        Task AddUser(ApplicationUserRole userRole);
        Task DeleteUser(ApplicationUserRole userRole);
    }
}
