using MicroServiceMongoDB.Core;
using MicroServiceMongoDB.Core.ContextMongoDB;
using MicroServiceMongoDB.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MicroServiceMongoDB
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
            services.Configure<MongoSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoDb:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoDb:Database").Value;
            });

            services.AddSingleton<MongoSettings>();

            services.AddTransient<IAutorContext, AutorContext>();

            services.AddTransient<IAutorRepository, AutorRepository>();

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroServiceMongoDB", Version = "v1" });
            });

            services.AddCors(option =>
            {
                var frontendURL = Configuration.GetValue<string>("frontendUrl");
                option.AddPolicy("CorsRule", rule =>
                {
                    rule.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(frontendURL); // * for any clients
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MicroServiceMongoDB v1"));
            }

            app.UseRouting();

            app.UseCors("CorsRule");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
