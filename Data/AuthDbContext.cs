using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bloggie.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Seed Roles (User, Admin, SuperAdmin)

            var adminRoleId = "53381092-2caf-4722-89cb-2a6cd1ff3a63";
            var superAdminRoleId = "95f1196f-08c3-47ca-8fe3-3732a18a329f";
            var userRoleId = "799565e1-0aae-44e4-816c-049c260f0f48";
            
            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Name="Admin",
                    NormalizedName="Admin",
                    Id= adminRoleId,
                    ConcurrencyStamp=adminRoleId
                },
                new IdentityRole
                {
                    Name="SuperAdmin",
                    NormalizedName="SuperAdmin",
                    Id=superAdminRoleId,
                    ConcurrencyStamp=superAdminRoleId
                },
                new IdentityRole
                {
                    Name="User",
                    NormalizedName="User",
                    Id=userRoleId,
                    ConcurrencyStamp=userRoleId
                }
            };
            
            builder.Entity<IdentityRole>().HasData(roles);
            //Seed SuperAdminUser
            var superAdminId = "1be42ab8-7fd1-468a-975f-04435f1cdfaa";
            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@bloggie.com",
                Email = "superadmin@bloggie.com",
                NormalizedEmail = "superadmin@bloggie.com".ToUpper(),
                NormalizedUserName = "superadmin@bloggie.com".ToUpper(),
                Id = superAdminId
            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
            .HashPassword(superAdminUser, "Superadmin@123");
            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //Add all roles to SuperAdminUser
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId= adminRoleId,
                    UserId=superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId=superAdminRoleId,
                    UserId=superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId=userRoleId,
                    UserId=superAdminId
                }
            };
            builder.Entity<IdentityUserRole<string> >().HasData(superAdminRoles);
        }
    }
}

