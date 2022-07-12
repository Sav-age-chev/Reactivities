//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Configuration;
//using AutoMapper;

using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });

            // Adding database connection as a service
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            // Setting up CORS - required when you access from different domain
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");  // Can use 'AllowAnyOrigins'
                });
            });

            // Adding mediator as a service
            services.AddMediatR(typeof(List.Handler).Assembly);

            // Adding AutoMapper as a service
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}