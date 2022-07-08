using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
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

            services.AddTransient<ICategoryService, CategoryManager>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IBlogService, BlogManager>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<ICommentService, CommentManager>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IWriterService, WriterManager>();
            services.AddTransient<IWriterRepository, WriterRepository>();
            services.AddTransient<INewsLetterService, NewsLetterManager>();
            services.AddTransient<INewsLetterRepository, NewsLetterRepository>();
            services.AddTransient<IAboutService, AboutManager>();
            services.AddTransient<IAboutRepository, AboutRepository>();
            services.AddTransient<IContactService, ContactManager>();
            services.AddTransient<IContactRepository, ContactRepository>();
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

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
