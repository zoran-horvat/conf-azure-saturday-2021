using Demo.Infrastructure;
using Demo.Logging;
using Demo.Models.Images;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Demo
{
    public class Startup
    {
        private string ConnectionString => 
            this.Configuration.DatabaseConectionString(this.CurrentEnvironment);

        private IWebHostEnvironment CurrentEnvironment { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages(options =>
                options.Conventions.AuthorizePage("/Products/Index"));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login";
                    options.LogoutPath = "/Logout";
                });

            void ConfigureDbOptions(IServiceProvider svc, DbContextOptionsBuilder options) =>
                options.UseSqlServer(this.ConnectionString);

            services.AddDbContext<EntireContext>(ConfigureDbOptions);
            services.AddDbContext<AuthenticationContext>(ConfigureDbOptions);
            services.AddDbContext<ContentContext>(ConfigureDbOptions);

            services.AddHttpContextAccessor();
            services.AddSingleton<TenancyProvider>();

            services.AddScoped<AssignedContentReadingContext>();
            services.AddScoped<FullOwnershipContentContext>();

            services.AddSingleton<IImageStore, AzureStorageImages>(svc =>
                new AzureStorageImages(
                    this.Configuration.ImageStoreContainerName(this.CurrentEnvironment),
                    this.Configuration.ImageStoreConnectionString(this.CurrentEnvironment)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.CurrentEnvironment = env;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
