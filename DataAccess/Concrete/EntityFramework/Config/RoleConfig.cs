using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Config
{
    public class RoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole
                {
                    Id = 1,
                    Name = "User",
                    NormalizedName = "USER"
                },
                new AppRole
                {
                    Id = 2,
                    Name = "Editor",
                    NormalizedName = "EDITOR"
                },
                new AppRole
                {
                    Id=3,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );
        }
    }
}
