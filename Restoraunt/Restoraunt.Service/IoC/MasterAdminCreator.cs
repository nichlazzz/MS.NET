using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;

public class MasterAdminCreator
{
    public static async Task CreateMasterAdminAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserModel>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
        var context = scope.ServiceProvider.GetRequiredService<RestorauntDbContext>();

        // Create the "Admin" role if it doesn't exist
        var adminRoleExists = await roleManager.RoleExistsAsync("Admin");
        if (!adminRoleExists)
        {
            await roleManager.CreateAsync(new IdentityRole<int>("Admin"));
        }


        // Check if master admin user already exists
        var masterAdmin = await userManager.FindByNameAsync("masteradmin"); // Replace with your preferred username
        if (masterAdmin == null)
        {
            // Create the master admin user
            masterAdmin = new UserModel
            {
                UserName = "masteradmin", // Replace with your preferred username
                Email = "masteradmin@yourdomain.com", // Replace with your preferred email
                EmailConfirmed = true //Optional: set to true if email verification is not needed.
            };
            var createResult = await userManager.CreateAsync(masterAdmin, "YOUR_STRONG_PASSWORD"); // Replace with a strong randomly generated password

            //Check if user creation was successful
            if (!createResult.Succeeded)
            {
                throw new Exception($"Failed to create MasterAdmin user: {string.Join(", ", createResult.Errors.Select(x => x.Description))}");
            }

            // Add the user to the "Admin" role
            await userManager.AddToRoleAsync(masterAdmin, "Admin");

            // Add other roles if needed
            //await userManager.AddToRoleAsync(masterAdmin, "AnotherRole");

        }
    }
}