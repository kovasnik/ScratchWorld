using Microsoft.AspNetCore.Identity;
using ScratchWorld.Models;

namespace ScratchWorld.Data
{
    public class AdminSeed
    {
        public static async Task SeedAdmin(IApplicationBuilder applicationBuilder)
        {
            using (var serviseScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //var roleManager = serviseScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                //if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                //    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                var userManager = serviseScope.ServiceProvider.GetRequiredService<UserManager<User>>();

                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Age = 30
                    };
                    await userManager.CreateAsync(newAdminUser, "adminishe23");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
            }
        }
    }
}
