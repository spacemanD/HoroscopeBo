using BLL;
using Core.Options;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using HoroscopeBot.Filters.ExceptionFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


namespace HoroscopeBot
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.Configuration = configuration;
            this.Env = env;

        }

        public IWebHostEnvironment Env { get; }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            this.InstallDataAccess(services);
            this.InstallBusinessLogic(services);
            this.InstallFilters(services);
            this.InstallBot(services);
        }

        private void InstallFilters(IServiceCollection services)
        {
            services.AddScoped<AppExceptionFilterAttribute>();
        }

        private void InstallBot(IServiceCollection services)
        {
            BotOptions botOptions = new BotOptions();
            this.Configuration.GetSection(nameof(BotOptions)).Bind(botOptions);
            services.AddSingleton(botOptions);
            services.AddSingleton<AppBot>();
        }

        private void InstallBusinessLogic(IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
        }

        private void InstallDataAccess(IServiceCollection services)
        {
            string connection;
            if (!this.Env.IsDevelopment())
            {
                Console.WriteLine("Database in prod mode");
                connection = this.Configuration.GetConnectionString("DefaultConnectionProd");
            }
            else
            {
                Console.WriteLine("Database in dev mode");
                connection = this.Configuration.GetConnectionString("DefaultConnection");
            }

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            services.BuildServiceProvider().GetService<AppDbContext>().Database.Migrate();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
