using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment CurrentEnvironment { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //SQL connection
            string connectionString;
            if (CurrentEnvironment.IsDevelopment())
            {
                connectionString = Configuration.GetConnectionString("Development");
            }
            else
            {
                var server = Configuration["DBServer"] ?? "host.docker.internal";
                var port = Configuration["DBPort"];
                var user = Configuration["DBUser"];
                var password = Configuration["DBPassword"];

                connectionString = $"Server={server},{port};Initial Catalog=PalitaxDB;User ID={user};Password={password};TrustServerCertificate=true";
            }

            services.AddDbContext<PalitaxDbContext>(options => options.UseSqlServer(connectionString));

            //TaxJar external WebAPI service
            services.AddHttpClient<ITaxJarService, TaxJarService>(c =>
           {
               c.BaseAddress = new Uri(Configuration.GetValue<string>("TaxJar:BaseUrl"));
               c.DefaultRequestHeaders.Add(HeaderNames.Authorization, Configuration.GetValue<string>("TaxJar:ApiKey"));
           });

            //allow CORS
            services.AddCors();

            //Swagger
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PalitaxDbContext palitaxDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            // trigger migration on startup
            palitaxDbContext.Database.Migrate();

            app.UseRouting();

            //allow CORS
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
