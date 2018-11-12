using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ScrumApplicationData.Models
{
    public class ApplicationUserClaim:IdentityUserClaim<string>
    {
    }
}
