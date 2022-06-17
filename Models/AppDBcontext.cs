using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Pathology.ViewModels;

namespace Pathology.Models
{
    public class AppDBcontext:IdentityDbContext<User, Role, Guid>
    {
        public AppDBcontext(DbContextOptions<AppDBcontext>options):base(options)
        {

        }

        
    }
}