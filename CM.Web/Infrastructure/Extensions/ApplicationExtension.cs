using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CM.Data;

namespace RVC.Web.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RCVDBContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RCVDBContext>();

            //if (context.Database.GetPendingMigrations().Any())
            //{
            //    context.Database.Migrate();
            //}
        }

        public static void ConfigureLocalization(this WebApplication app)
        {


            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                InitializeAsync(userManager, roleManager).Wait();
            }

                app.UseRequestLocalization(options =>
                {
                    options.AddSupportedCultures("tr-TR")
                        .AddSupportedUICultures("tr-TR")
                        .SetDefaultCulture("tr-TR");
                });
          
        }

        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";

            // UserManager
            UserManager<IdentityUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            // RoleManager
            RoleManager<IdentityRole> roleManager = app
                .ApplicationServices
                .CreateAsyncScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new IdentityUser()
                {
                    Email = "karani@gmail.com",
                    PhoneNumber = "5059715871",
                    UserName = adminUser,
                };

                var result = await userManager.CreateAsync(user, adminPassword);

                if (!result.Succeeded)
                    throw new Exception("Admin user could not been created.");

                var roleResult = await userManager.AddToRolesAsync(user,
                    roleManager
                        .Roles
                        .Select(r => r.Name)
                        .ToList()
                );

                if (!roleResult.Succeeded)
                    throw new Exception("System have problems with role defination for admin.");
            }
        }



        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminRole = "Admin";
            string adminUsername = "root@root.com";
            string adminPassword = "Admin123!";

            string userRole = "User";
            string userUsername = "user@example.com";
            string userPassword = "User123!";

            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if (await roleManager.FindByNameAsync(userRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(userRole));
            }

            if (await userManager.FindByNameAsync(adminUsername) == null)
            {
                var adminUser = new IdentityUser { UserName = adminUsername, Email = adminUsername };
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }
            }

            if (await userManager.FindByNameAsync(userUsername) == null)
            {
                var user = new IdentityUser { UserName = userUsername, Email = userUsername };
                var result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, userRole);
                }
            }
        }
   
    
    
    
    }

}
