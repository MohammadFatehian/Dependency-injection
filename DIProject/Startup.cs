using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DIProject.Models;
using DIProject.Services;
using Microsoft.AspNetCore.Http;

namespace DIProject
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
            services.AddControllersWithViews();
            services.AddSession();
            //services.Add(new ServiceDescriptor(typeof(Imail) , new MailGmail()));
            //services.Add(new ServiceDescriptor(typeof(Imail) , new MailYahoo()));

            //services.AddSingleton<Imail, MailGmail>();
            //services.AddTransient<Imail, MailGmail>();
            services.AddScoped<Imail, MailGmail>();
            services.AddScoped(x => new DIProjectService());
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.Use(async (httpcontext, next) => {
                MyProjectMiddleware(httpcontext);
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        public void MyProjectMiddleware( HttpContext httpContext)
        {
            if (httpContext == null || httpContext.Session == null) return;
            if (httpContext.Session.GetInt32("iscount") == 1) return;
            httpContext.Session.MyWebSessionExtensionTotalVisitors(httpContext);
        }
    }
    public static class MyWebCountVisitors
    {
        public static int countVisitors { get; set; } = 0;
    }
    public static class MyWebExtensionSession
    {
        public static void MyWebSessionExtensionTotalVisitors(this ISession session , 
            HttpContext httpContext)
        {
            if (httpContext.Session.GetInt32("iscount") == 1) return;
            MyWebCountVisitors.countVisitors++;
            httpContext.Session.SetInt32("iscount" , 1);


        }
    }
}
