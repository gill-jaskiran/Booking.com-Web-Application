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

                app.UseHsts();
            }
            else
            {
                // Development environment settings
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //custome error pages for 404 and 500
            app.UseStatusCodePagesWithRedirects("/Home/NotFound?statusCode={0}");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // Logging unhandled exceptions
            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (Exception ex)
                {
                    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An unhandled exception occurred.");
                    context.Response.Redirect("/Home/Error"); // Redirect to custom error page
                }
                finally
                {
                    // Log the response status after the request has been processed
                    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
                    logger.LogInformation($"Response Status: {context.Response.StatusCode}");
                }
            });

            app.MapRazorPages();

            // Configure the route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            using (var scope = app.Services.CreateScope())
            {
                var RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "User" };
                // Implementing Try-Catch Blocks
                foreach (var role in roles)
                {
                    try
                    {
                        if (!await RoleManager.RoleExistsAsync(role))
                            await RoleManager.CreateAsync(new IdentityRole(role));
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception locally and provide feedback
                        Console.WriteLine($"An error occurred while creating role '{role}': {ex.Message}");
                    }
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string email = "admin@gmail.com";
                string password = "Admin123!";
                // Implementing Try-Catch Blocks
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new IdentityUser();
                    user.UserName = email;
                    user.Email = email;

                    try
                    {
                        await userManager.CreateAsync(user, password);
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception locally and provide feedback
                        Console.WriteLine($"An error occurred while creating admin user: {ex.Message}");
                    }
                }
            }

            app.Run();
        }
    }
}
