using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Castle.Facilities.Logging;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using MediHub.Touchee.Authentication.JwtBearer;
using MediHub.Touchee.Configuration;
using MediHub.Touchee.Identity;
using MediHub.Touchee.Web.Resources;
using Abp.AspNetCore.SignalR.Hubs;
using System.Threading.Tasks;

namespace MediHub.Touchee.Web.Startup
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddMvc(
                options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
            );

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddScoped<IWebResourceManager, WebResourceManager>();

            services.AddSignalR();

services.ConfigureApplicationCookie(options => {
                //options.LoginPath = "/Account/Deny";
                //options.AccessDeniedPath = "/Account/Deny";

                options.Events.OnRedirectToLogin = context =>
                {
                    if (context.HttpContext?.User?.Identity?.IsAuthenticated == false)
                    {
                        //The user is not authenticated... Use the "oidc" challenge scheme 
                        //and send them to identity server.
                        //var task = context.HttpContext.ChallengeAsync("oidc");
                        //task.WaitAndUnwrapException();
                        context.Response.Redirect("/Account/Login");
//                        var uri = new Uri("/Account/Login");
//                        context.Response.Redirect(uri.AbsoluteUri);
//                        context.Response.StatusCode = 403;
                        return Task.CompletedTask;
                    }

                    //var accessDeniedPath = BuildRedirectUri(context.HttpContext, options.AccessDeniedPath);

                    context.Response.Redirect("/Account/Deny");
                    context.Response.StatusCode = 302;

                    return Task.CompletedTask;
                };

            });

            // Configure Abp and Dependency Injection
            return services.AddAbp<ToucheeWebMvcModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); // Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseJwtTokenMiddleware();

            app.UseSignalR(routes =>
            {
                routes.MapHub<AbpCommonHub>("/signalr");
            });
            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
