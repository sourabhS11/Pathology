using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Pathology.ViewModels;
using Pathology.Models;

namespace Pathology.Models
{
    public class AppDBcontext:IdentityDbContext<User, Role, Guid>
    {
        public AppDBcontext(DbContextOptions<AppDBcontext>options):base(options)
        {

        }

        public DbSet<Package> Packages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<TestCategory> TestCategory { get; set; }

        public DbSet<Patient> Patient { get; set; }

        public DbSet<TestMgmt> TestMgmt { get; set; }
    }
}