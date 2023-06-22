using DataAccess.Concrete.EntityFramework.Config;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<News> News { get; set; }
        public DbSet<Setting> Setting { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfig());



            //builder.Entity<AppUser>()
            //    .HasMany(k => k.Roller)
            //    .WithMany(m => m.Users)
            //    .UsingEntity(j => j.ToTable("UserRoller")).
            //
            //<89
            //    ; //3. ara tablo

          

        }
    }
}
