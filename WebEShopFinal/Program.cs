using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebEShopFinal.Data;
using WebEShopFinal.API;
using WebEShopFinal.Data.Repositories;

namespace WebEShopFinal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection2") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddRazorPages();
            builder.Services.AddMvc();
            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer();

            //add singleton??
            //builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();

            //builder.Services.AddSingleton<CategoryRepository>(ApplicationDbContext db);
            //services.AddSingleton<ICategoryRepository>(new CategoryRepository(db));

            //public void ConfigureServices(IServiceCollection services)
            //{
            //services.AddSingleton<ICategoryRepository, CategoryRepository>();
            //services.AddSingleton<ICategoryRepository>(new CategoryRepository()); // custom LoginService
            //}

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            };

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting(); // general routing

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages(); // razor pages' routing
            app.MapDefaultControllerRoute(); // controllers' routing
            app.MapGet("/api/koukou", () => { return "This is Koukou!!!"; }); // minimal web api

            app.MapCategoryEndpoints();
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

    //public void ConfigureServices(IServiceCollection services)
    //{
    //    services.AddAuthentication();
    //    services.AddRazorPages(options =>
    //    {
    //        options.Conventions.AddPageRoute("/Dashboard", "Authorize");
    //        //options.Conventions.AuthorizePage("/Dashboard");
    //        options.Conventions.AllowAnonymousToPage("/Login");
    //    }
    //        );
    //    services.AddSingleton<ILoginService>(new LoginService()); // custom LoginService
    //}






}