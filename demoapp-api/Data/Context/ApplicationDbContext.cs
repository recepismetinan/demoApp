using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;
using Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUserLogin<int>>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
            });
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}