using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard
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
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = "Cookies";
                options.Authority = Configuration["Urls:Authority"];
                options.RequireHttpsMetadata = false;

                options.ClientId = "admin_dashboard_123";// Configuration["ISConfig:ClientId"];
                options.ClientSecret = "d5a9b78e-a694-4026-af7f-6d559d8a3949"; // Configuration["ISConfig:Secret"];
                options.ResponseType = "code";
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                //options.Scope.Add("account_id");
                options.Scope.Add("SOF");
                options.Scope.Add("Auth");
                //options.Scope.Add("offline_access");
                //options.ClaimActions.MapJsonKey("account_id", "account_id", "account_id");
                options.ClaimActions.MapJsonKey("roles", "roles", "roles");
              
            });

            //services.AddScoped<ISwaggerClient>(obj => new SwaggerClient("http://localhost:44303/", new System.Net.Http.HttpClient { Timeout = TimeSpan.FromMinutes(30) }));

            //.AddOpenIdConnect("oidc", config =>
            //{
            //    config.Authority = "https://localhost:44303/";
            //    config.ClientId = "admin_dashboard_123";
            //    config.ClientSecret = "d5a9b78e-a694-4026-af7f-6d559d8a3949";
            //    config.SaveTokens = true;
            //    config.ResponseType = "code";
            //    //config.RequireHttpsMetadata = false;

            //    //config.Scope.Add("SOF");
            //    //config.Scope.Add("Auth");
            //});

            //services.AddHttpClient();
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseExceptionHandler(errorApp =>
            //{
            //    var sss = errorApp;
            //});
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //     name: "areaRoute",
                //     pattern: "{area:exists}/{controller=Home}/{action=Index}");
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
