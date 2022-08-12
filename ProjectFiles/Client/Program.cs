using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program : ClientBaseClass
    {
        static void Main(string[] args)
        {
            try
            {
                Host.CreateDefaultBuilder()
                    .ConfigureServices((context, services) => {
                        services.AddHostedService<BackgroundService>();
                    })
                    .Build()
                    .Run();
            }
            catch (Exception)
            {

            }
        }
    }
}
