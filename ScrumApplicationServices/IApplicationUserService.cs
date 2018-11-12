using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ScrumApplicationData.Models;
namespace ScrumApplicationServices
{
    public interface IApplicationUserService
    {
        void Add(ApplicationUser applicationUser);
    }
}
