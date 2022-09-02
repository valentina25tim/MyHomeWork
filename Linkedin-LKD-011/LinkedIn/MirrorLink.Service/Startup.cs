using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MirrorLink.Application;
using MirrorLink.Persistence;
using System.Reflection;

namespace MirrorLink.Api
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
            services.AddApplicationServices();
            services.AddPersistenceServices(Configuration);
            services.AddMediatR(Assembly.GetExecutingAssembly()/*, typeof (I)*/);//??
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddCors(opts =>
            {
                opts.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(opts =>
            {
                opts.SwaggerEndpoint("v1/swagger.json", "MirrorLink.Api");
            });

            app.UseCors("Open");

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(opts =>
            {
                opts.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MirrorLink.Api"
                });
                // opts.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }
    }
}