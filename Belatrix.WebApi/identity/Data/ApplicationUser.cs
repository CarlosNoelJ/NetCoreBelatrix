using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Belatrix.WebApi.identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        internal ClaimsIdentity NewGuide()
        {
            throw new NotImplementedException();
        }
    }
}
