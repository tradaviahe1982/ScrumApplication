using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScrumApplicationData;
using ScrumApplicationData.Models;
using ScrumApplicationServices;
using ScrumApplicationServices.Core;
using ScrumApplication.Utilities;
using ScrumApplication.Services;
using ReflectionIT.Mvc.Paging;
using Hangfire;
using Hangfire.AspNetCore;
using Hangfire.SqlServer;
namespace ScrumApplication
{
    //
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddPaging(options => {
                options.ViewName = "Bootstrap4";
                options.HtmlIndicatorDown = " <span>&darr;</span>";
                options.HtmlIndicatorUp = " <span>&uarr;</span>";
            });
            services.AddSingleton(Configuration);

            services.AddScoped<IApplicationUserService, ApplicationUserManager>();
            services.AddScoped<IProjectService, ProjectManager>();
            services.AddScoped<ISprintService, SprintManager>();
            services.AddScoped<IStoryService, StoryManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IStoredProcedureService, StoredProcedureManager>();
            services.AddDbContext<ScrumApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ScrumappDbConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ScrumApplicationDbContext>()
                .AddDefaultTokenProviders();
            //
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("ScrumappDbConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
    //
}
