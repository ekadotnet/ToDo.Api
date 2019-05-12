using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Alexinea.Autofac.Extensions.DependencyInjection;

namespace ToDo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>()
                .Build();
    }
}
