using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Common.Config;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using web.api.App.Recipes;
using web.api.DataAccess;

namespace web.api.Helpings
{
    [ExcludeFromCodeCoverage]
    public static class DiMapper
    {
        public static void Map(IServiceCollection services, bool testing = false)
        {
            // SERVICES
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "web.api", Version = "v1"});
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.DescribeAllParametersInCamelCase();
            });
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            // CONFIGURATION
            var configuration = ConfigHelper.GetIConfigurationRoot(Directory.GetCurrentDirectory());
            services.AddSingleton<IConfiguration>(configuration);
            // Register DbContext
            AppDbContext.Register(services);

            // BUSINESS SERVICES
            services.AddTransient<RecipeService>();

            // CONTROLLERS
            services.AddTransient<RecipeController>();
        }
    }
}