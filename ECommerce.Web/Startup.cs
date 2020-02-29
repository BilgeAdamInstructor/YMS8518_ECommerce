using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Data.Interfaces;
using ECommerce.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Web
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
            services.AddSession();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                //options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<Data.Contexts.DataContext>(a => a
                .UseSqlServer("Server=localhost;Database=YMS8518_ECommerce;User Id=sa;Password=123;"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        private static readonly object MiddlewareLock = new object();

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceScopeFactory serviceScopeFactory)
        {
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.Use(async (context, next) => {
                lock (MiddlewareLock)
                {
                    if (context.Session.GetString("SessionKey") == null)
                    {
                        if (context.Request.Cookies.TryGetValue("rememberme", out string rememberMe))
                        {
                            Guid? guid = new Guid(rememberMe);

                            if (guid != null)
                            {
                                using (var scope = serviceScopeFactory.CreateScope())
                                {
                                    IUnitOfWork unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                                    var user = unitOfWork.UserRepository.GetByAutoLoginKey((Guid)guid);

                                    if (user != null)
                                    {
                                        context.Session.SetInt32("UserId", user.Id);
                                    }
                                }
                            }
                        }

                        context.Session.SetString("SessionKey", Guid.NewGuid().ToString());
                        context.Session.CommitAsync().Wait();
                    }
                }

                await next.Invoke();
            });

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
