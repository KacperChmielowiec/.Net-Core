
using Microsoft.AspNetCore.Identity;
namespace Store.Models
{
    public static class IdentitySeed
    {
        private const string AdminUser = "Admin";
        private const string AdminPassword = "Secret123$";

        public static async void EnsurePopulateUser(this IApplicationBuilder app)
        {
            IdentityDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityDbContext>();
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate(); 
            }
            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.
                GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByIdAsync(AdminUser);

            if(user == null)
            {
                user = new IdentityUser("Admin");
                user.Email = "admin@gmail.com";
                user.PhoneNumber = "+48 101 100 233";
                await userManager.CreateAsync(user, AdminPassword);
                
            }
            context.SaveChanges();
        }
    }
}
