using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Migrations;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false) // changed to false
                .AddRoles<IdentityRole>() // Adding roles
                .AddEntityFrameworkStores<AppDbContext>();



            builder.Services.AddSingleton<IEmailSender, EmailSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();

            // Configure the route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");




            /*services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Configure identity options if needed
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders(); ;*/

            using (var scope = app.Services.CreateScope())
            {

                var RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "User" };

                foreach (var role in roles)
                {
                    if (!await RoleManager.RoleExistsAsync(role))
                        await RoleManager.CreateAsync(new IdentityRole(role));
                }


            }

            using (var scope = app.Services.CreateScope())
            {

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string email = "admin@gmail.com";
                string password = "Admin123!";
                

                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new IdentityUser();
                    user.UserName = email;
                    user.Email = email;
                    

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Admin");

                }



            }
            app.Run();
        }
    }
}

