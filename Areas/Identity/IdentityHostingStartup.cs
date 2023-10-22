using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pp.Data;

[assembly: HostingStartup(typeof(pp.Areas.Identity.IdentityHostingStartup))]
namespace pp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            _ = builder.ConfigureServices((context, services) =>
            {
                _ = services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

                _ = services.AddDefaultIdentity<IdentityUser>(options =>
                    options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ApplicationDbContext>();

                // Add Razor Pages
                _ = services.AddRazorPages();

                // Add the three different pages
                _ = services.ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = "/Identity/Account/Login";
                    options.LogoutPath = "/Identity/Account/Logout";
                    options.AccessDeniedPath = "/Identity/Account/AccessDenied";

                    options.LoginPath = "/Identity/Account/Register";
                    options.LogoutPath = "/Identity/Account/ResetPassword";
                    options.AccessDeniedPath = "/Identity/Account/ResetPassword";


                    options.AccessDeniedPath = "/Identity/Account/Manage/PersonalData";
                    options.AccessDeniedPath = "/Identity/Account/Manage/DownloadPersonalData";
                    options.AccessDeniedPath = "/Identity/Account/Manage/DeletePersonalData";
                    options.AccessDeniedPath = "/Identity/Account/Manage/ChangePassword";
                });
            }
            );
        }
    }
}