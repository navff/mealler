using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OD_Stat.Helpings;
using web.api.DataAccess;
using AppContext = System.AppContext;

namespace web.api.Helpings
{
    [ExcludeFromCodeCoverage]
    public static class DiMapper
    {
        public static void Map(IServiceCollection services)
        {
            // SERVICES
            AutoMapperConfigBuilder.RegisterAutoMapper(services, new MappingProfile());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "web.api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.DescribeAllParametersInCamelCase();
                
            });
            
            // Register DbContext
            AppDbContext.Register(services);
            
            // BUSINESS SERVICES
             // services.AddTransient<DaDataService>();

            // CONTROLLERS
            // services.AddTransient<DivisionsController>();
        }
        
    }
}