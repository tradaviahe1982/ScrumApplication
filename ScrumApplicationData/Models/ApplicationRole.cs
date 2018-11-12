using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ScrumApplicationData.Models
{
    public class ApplicationRole:IdentityRole
    {
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
