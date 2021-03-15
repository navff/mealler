using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tests.SimpleTestClasses;
using web.api.App.Recipes;
using web.api.DataAccess;

namespace Tests.ToolsTests
{
    public static class TestDiMapper
    {
        public static void Map(IServiceCollection services)
        {
            // SERVICES
            // Test services
            services.AddTransient<TestService>();
            services.AddTransient<InlineService>();

            var configuration = ConfigHelper.GetIConfigurationRoot(Directory.GetCurrentDirectory());
            services.AddSingleton<IConfiguration>(configuration);
            // services.AddTransient<DivisionService>();

            // CONTROLLERS
            services.AddTransient<RecipeController>();

            // OTHERS
            AppDbContext.Register(services);
        }
    }
}