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
        /*
        public ApplicationDbContext()
        {
        }
        */
        protected override void OnModelCreating(ModelBuilder builder)
        {
           
        }
/*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=root;password=3522;database=proje";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
*/
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Announcement { get; set; }

    }
}