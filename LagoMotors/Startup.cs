using LagoMotors.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using LagoMotors.Core.Interface;
using LagoMotors.Data.Interface;
using LagoMotors.Data.MappingProfile;
using LagoMotors.Data.Repository;
using LagoMotors.Data.UnitOfWork;

namespace LagoMotors
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            var mappingConfig=new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());

            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddControllers();

            services.AddDbContext<AppDbcontext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Connection"));
            });
            services.AddScoped<IVehicleRepository,VehicleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.Json")
                    .AddJsonFile("appsettings.Development.Json", true)
                    .AddEnvironmentVariables();

                Configuration = builder.Build();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.WithOrigins("http://localhost:4200");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
