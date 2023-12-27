using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;
using Entity.Entities;

namespace Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
           
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Announcement { get; set; }

    }
}