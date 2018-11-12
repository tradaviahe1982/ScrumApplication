using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ScrumApplicationData.Models
{
    public class ApplicationUserToken:IdentityUserToken<string>
    {
    }
}
