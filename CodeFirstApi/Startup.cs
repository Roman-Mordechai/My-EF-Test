using CodeFirstApi.Data;
using CodeFirstApi.Domain.DataServices;
using CodeFirstApi.Data.DataServicies;
using CodeFirstApi.Domain.Servicies;
using CodeFirstApi.Servicies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CodeFirstApi
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
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IDcManagerDataService, DcManagerDataService>();
            services.AddTransient<IDcManagerService, DcManagerService>();
            services.AddTransient<IDcFrameDataService, DcFrameDataService>();
            services.AddTransient<IDcFrameService, DcFrameService>();
            services.AddTransient<IDcClassDataService, DcClassDataService>();
            services.AddTransient<IDcClassService, DcClassService>();

            services.AddControllers();
            //services.AddControllers().AddJsonOptions(x =>
            //    {
            //        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            //        x.JsonSerializerOptions.WriteIndented = true;
            //        x.JsonSerializerOptions.IgnoreReadOnlyFields = true;
            //    }
            //);
            services.AddControllers().AddNewtonsoftJson(x =>
             x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CodeFirstApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeFirstApi v1"));
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
