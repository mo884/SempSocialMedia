using Hangfire;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SempSocialMedia.BLL.Mapping;
using SempSocialMedia.BLL.Service.Abstraction;
using SempSocialMedia.BLL.Service.Impelementation;
using SempSocialMedia.DAL.DataBase;
using SempSocialMedia.DAL.Entities;
using SempSocialMedia.DAL.Repo.Abstraction;
using SempSocialMedia.DAL.Repo.Impelementation;
using System.Net.NetworkInformation;

namespace SempSocialMedia.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //Enhance ConnectionString
            var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
            builder.Services.AddDbContext<SempSocialMediaDbContext>(options =>
            options.UseSqlServer(connectionString));

            //Identity
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                });



            builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                            .AddEntityFrameworkStores<SempSocialMediaDbContext>()
                            .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);



                    builder.Services.AddIdentity<User, IdentityRole>(options =>
                    {
                        // Default Password settings.   
                        options.Password.RequireDigit = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequiredLength = 8;
                        options.Password.RequiredUniqueChars = 0;
                    }).AddEntityFrameworkStores<SempSocialMediaDbContext>();

            //AutoMapper
            builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            //Dependancy Injection Service Life Time Repo
            builder.Services.AddTransient<IPostRepo, PostRepo>();
            builder.Services.AddTransient<IUserRepo, UserRepo>();


            //Dependancy Injection Service Life Time Service
            builder.Services.AddTransient<IPostService,PostService>();
            builder.Services.AddTransient<IUserService,UserServices>();



            //Use Hang Fire
            builder.Services.AddHangfire(x => x.UseSqlServerStorage(connectionString));
            builder.Services.AddHangfireServer();

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
            app.UseHangfireDashboard("/HangFire");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
