using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using The_Guild_Back.API.Models;
using The_Guild_Back.BLL;
using The_Guild_Back.DAL;

namespace The_Guild_Back.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            services.AddSingleton<IAPIMapper, APIMapper>();

            services.AddDbContext<project2theGuildContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("project2theGuild")));

            services.AddDbContext<AuthDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("AuthDb")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            { }).AddEntityFrameworkStores<AuthDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "UserServiceAuth";
                options.ExpireTimeSpan = TimeSpan.FromHours(2);
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.Headers.Remove("Location");
                        return Task.FromResult(0);
                    }
                };
            });

            services.AddAuthentication();

            services.AddMvc(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            }).AddXmlSerializerFormatters()
              .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Character API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Character API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
