using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Autofac;

using DevProfile.Infrastructure.CrossCutting.IOC;
using DevProfile.Infrastructure.DataBase.DevProfileDB;
using Swashbuckle.AspNetCore.Swagger;

namespace DevProfile.WebAPI
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
            var connection = this.Configuration.GetConnectionString("DevProfile");
            services.AddDbContext<DevProfileContext>(options =>
            options.UseSqlServer(connection, x => x.MigrationsAssembly("DevProfile.WebAPI")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "DevProfile API", Version = "v1" });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvcCore().AddApiExplorer();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DevProfileIOC());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevProfile V1");
            });
        }
    }
}
