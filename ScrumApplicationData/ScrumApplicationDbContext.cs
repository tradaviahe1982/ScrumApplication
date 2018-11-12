using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScrumApplicationData.Models;

namespace ScrumApplicationData
{
    public class ScrumApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        //
        public ScrumApplicationDbContext(DbContextOptions<ScrumApplicationDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Story> Stories { get; set; }


        public DbSet<Tasks> Tasks { get; set; }
       
        public DbSet<StoryStatus> StoryStatus { get; set; }
        public DbSet<ProjectStatus> ProjectStatus { get; set; }

        public DbSet<SprintStatus> SprintStatus { get; set; }
        public DbSet<StoryType> StoryType { get; set; }

        public DbSet<TaskStatus> TaskStatus { get; set; }
    }
}
