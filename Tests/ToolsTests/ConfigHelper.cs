using Microsoft.Extensions.Configuration;

namespace Tests.ToolsTests
{
    /// <summary>
    ///     https://weblog.west-wind.com/posts/2018/Feb/18/Accessing-Configuration-in-NET-Core-Test-Projects
    /// </summary>
    public static class ConfigHelper
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", true)
                .AddUserSecrets("2cd58c05-a34e-4e7e-9fd1-b36fbc0e2fde")
                .AddEnvironmentVariables()
                .Build();
        }
    }
}