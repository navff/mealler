using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Tests.ToolsTests
{
    public class DIServiceBuilder
    {
        public DIServiceBuilder()
        {
            var args = new string[0];
            var host = CreateHostBuilder(args).Build();
            ServiceProvider = host.Services;
        }

        private IServiceProvider ServiceProvider { get; }

        public T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }


        private IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services => { TestDiMapper.Map(services); });
        }
    }
}