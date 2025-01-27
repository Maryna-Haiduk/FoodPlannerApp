using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FoodPlannerApp.Areas.Identity.Data;
using FoodPlannerApp.Data.RecipeRepository; // Add the namespace for RecipeRepository and IRecipeRepository

namespace FoodPlannerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Database Context
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                   ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Configure Identity
            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Register RecipeRepository with Dependency Injection
            builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

            // Add MVC controllers and views
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Enable Authentication and Authorization Middleware
            app.UseAuthentication(); // Add this to enable authentication
            app.UseAuthorization();

            // Configure routes
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
