using AdminDashboard.HttpHandler;
using AdminDashboard.Services;
using AdminDashboard.SwaggerClient;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
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
            string AuthorityUrl = Configuration.GetValue<string>("Urls:Authority");
            string tmsUrl = Configuration.GetValue<string>("Urls:TMS");
            string sofUrl = Configuration.GetValue<string>("Urls:SOF");

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IRolesApi>(x => new RolesApi(AuthorityUrl));
            services.AddScoped<IAccountApi>(x => new AccountApi(AuthorityUrl));
            services.AddScoped<IFeesApi>(x => new FeesApi(tmsUrl));
            services.AddScoped<ITaxApi>(x => new TaxApi(tmsUrl));
            services.AddScoped<IAccountFeesApi>(x => new AccountFeesApi(tmsUrl));
            services.AddScoped<IDenominationApi>(x => new DenominationApi(tmsUrl));
            services.AddScoped<IAdminServiceApi>(x => new AdminServiceApi(tmsUrl));
            services.AddScoped<ICommissionApi>(x => new CommissionApi(tmsUrl));
            services.AddScoped<IAccountCommissionApi>(x => new AccountCommissionApi(tmsUrl));
            services.AddScoped<IRegionApi>(x => new RegionApi(AuthorityUrl));
            services.AddScoped<IActivityApi>(x => new ActivityApi(AuthorityUrl));
            services.AddScoped<IEntityApi>(x => new EntityApi(AuthorityUrl));
            services.AddScoped<IAccountTypeProfileApi>(x => new AccountTypeProfileApi(AuthorityUrl));
            services.AddScoped<IAccountChannelApi>(x => new AccountChannelApi(AuthorityUrl));
            services.AddScoped<IChannelApi>(x => new ChannelApi(AuthorityUrl));
            services.AddScoped<IAccountChannelTypeApi>(x => new AccountChannelTypeApi(AuthorityUrl));
            services.AddScoped<IChannelTypeApi>(x => new ChannelTypeApi(AuthorityUrl));
            services.AddScoped<IUsersApi>(x => new UsersApi(AuthorityUrl));
            services.AddScoped<IChannelOwnerApi>(x => new ChannelOwnerApi(AuthorityUrl));
            services.AddScoped<IChannelPaymentMethodApi>(x => new ChannelPaymentMethodApi(AuthorityUrl));
            services.AddScoped<IAccountTypeApi>(x => new AccountTypeApi(AuthorityUrl));
            services.AddScoped<IAccountTypeProfileCommissionApi>(x => new AccountTypeProfileCommissionApi(tmsUrl));
            services.AddScoped<IAccountTypeProfileDenominationApi>(x => new AccountTypeProfileDenominationApi(tmsUrl));
            services.AddScoped<IAccountTypeProfileFeeApi>(x => new AccountTypeProfileFeeApi(tmsUrl));
            services.AddScoped<IChannelCategoryApi>(x => new ChannelCategoryApi(AuthorityUrl));
            services.AddScoped<IDenominationCommissionApi>(x => new DenominationCommissionApi(tmsUrl));
            services.AddScoped<IDenominationFeesApi>(x => new DenominationFeesApi(tmsUrl));
            services.AddScoped<IDenominationTaxesApi>(x => new DenominationTaxesApi(tmsUrl));
            services.AddScoped<IServiceProviderApi>(x => new ServiceProviderApi(tmsUrl));
            services.AddScoped<IServiceConfigurationApi>(x => new ServiceConfigurationApi(tmsUrl));
            services.AddScoped<IDenominationParamApi>(x => new DenominationParamApi(tmsUrl));
            services.AddScoped<IParameterApi>(x => new ParameterApi(tmsUrl));
            services.AddScoped<IAuthenticationApi>(x => new AuthenticationApi(AuthorityUrl));
            services.AddScoped<ILookupTypeApi>(x => new LookupTypeApi(tmsUrl));
            services.AddScoped<IAccountsApi>(x => new AccountsApi(sofUrl));
            services.AddScoped<IIntegrations, Integrations>();

            //services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; 
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.Authority = Configuration["Urls:Authority"];
                options.RequireHttpsMetadata = true;

                options.ClientId = "admin_dashboard_123";// Configuration["ISConfig:ClientId"];
                options.ClientSecret = "d5a9b78e-a694-4026-af7f-6d559d8a3949"; // Configuration["ISConfig:Secret"];
                options.ResponseType = "code";
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                //options.Scope.Add("account_id");
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("SOF");
                options.Scope.Add("Auth");
                options.Scope.Add("TMS");
                //options.Scope.Add("offline_access");
                //options.ClaimActions.MapJsonKey("account_id", "account_id", "account_id");
                options.ClaimActions.MapJsonKey("roles", "roles", "roles");
                options.SignedOutCallbackPath = "/Home/Index";
                options.Events.OnRedirectToIdentityProvider = async n =>
                {
                    n.ProtocolMessage.RedirectUri = $"{Configuration["Urls:DashboardRedirectUrl"]}/signin-oidc";
                    await Task.FromResult(0);
                };
            });
            services.AddHttpContextAccessor();

            services.AddControllersWithViews();

            services.AddTransient<AuthenticationDelegatingHandler>();
            services.AddHttpClient("Accounts", client =>
            {
                client.BaseAddress = new System.Uri(Configuration["Urls:Authority"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            }).AddHttpMessageHandler<AuthenticationDelegatingHandler>();

            services.AddHttpClient("TMS", client =>
            {
                client.BaseAddress = new System.Uri(Configuration["Urls:TMS"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            }).AddHttpMessageHandler<AuthenticationDelegatingHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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
                //endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
