using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Server
{
    public class RoleInitializer
    {
        const string UserName = "Nikita";
        const string FullName = "Kislov";
        const string Password = "jnvfkfdlkf44";
        const string Email = "nikitakislov368rwr@gmail.com";
        const string PhoneNumber = "+37544562877241";
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await userManager.FindByNameAsync(UserName) == null)
            {
                User admin = new User { UserName = UserName, Email = Email, FullName = FullName, PhoneNumber = PhoneNumber };
                var result = await userManager.CreateAsync(admin, Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

        }
    }
}
