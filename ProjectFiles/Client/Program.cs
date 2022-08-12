using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program : ClientBaseClass
    {
        static Thread NotificationThread = new Thread(async () => { await NotificationSystem.KeepCheckingRequests(); });
        static Thread InputThread = new Thread(Input);
        static void Input()
        {
            ConsoleKeyInfo a = new();
            do
            {
                Console.WriteLine("Press Q to Exit else Print the same Key");
                Console.WriteLine(a.KeyChar);
                a = Console.ReadKey();
            } while (a.Key != ConsoleKey.Q);
            
        }
        static void Main(string[] args)
        {
            try
            {
                //Host.CreateDefaultBuilder()
                //    .ConfigureServices((context, services) => {
                //        services.AddHostedService<BackgroundService>();
                //    })
                //    .Build()
                //    .Run();
                Logger.Logger.LogInOutput("Starting Main");

                NotificationThread.Start();
                InputThread.Start();

                //When Task is done thread goes back to pool for reuse.
            }
            catch (Exception)
            {
                
            }
        }
    }
}
