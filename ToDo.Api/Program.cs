using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ToDo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseKestrel() można pobawić się Kestrelem, ale polecam najpierw nieco o nim poczytać :)
                .UseStartup<Startup>()
                .Build();
    }
}
