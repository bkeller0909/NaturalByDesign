using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Created by Brandon

namespace NBDv2.Data
{
    public static class ApplicationSeedData
    {
        public static async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            //Create Roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "Designer", "Design Manager", "Work Manager", "Worker", "Security"};
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            //Create Users
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            if (userManager.FindByEmailAsync("admin1@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin1@outlook.com",
                    Email = "admin1@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    userManager.AddToRoleAsync(user, "Security").Wait();
                }
            }
            if (userManager.FindByEmailAsync("security1@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "security1@outlook.com",
                    Email = "security1@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Security").Wait();
                }
            }
            if (userManager.FindByEmailAsync("designer1@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "designer1@outlook.com",
                    Email = "designer1@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Designer").Wait();
                }
            }
            if (userManager.FindByEmailAsync("worker1@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "worker1@outlook.com",
                    Email = "worker1@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Worker").Wait();
                }
            }
            if (userManager.FindByEmailAsync("user1@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "user1@outlook.com",
                    Email = "user1@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;
                //Not in any role
                // Do not add the user to any role
            }
        }
    }
}
