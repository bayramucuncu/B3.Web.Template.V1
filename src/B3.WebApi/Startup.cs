using B3.Infrastructure.DependencyInjection;
using B3.Infrastructure.Reflection;
using B3.WebApi.ApiConsistency;
using B3.WebApi.ApiFilters;
using B3.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;

namespace B3.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            LoadDependencyModules(services);

            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("DevPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllers(options =>
            {
                options.Filters.Add<ApiResponseWrapperAttribute>();
                options.Filters.Add<ApiExceptionHandleWrapperFilter>();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDevelopmentUser();
                app.UseCors("DevPolicy");
            }
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void LoadDependencyModules(IEnumerable services)
        {
            AppDomain.CurrentDomain.FromAssembliesMatching<IDependencyModule>("*.dll")
                .ForEach(t => ((IDependencyModule)Activator.CreateInstance(t, services)).LoadDependencies());
        }
    }
}
