using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program : ClientBaseClass
    {
        static async Task Input()
        {
            var bakwas = await Console.In.ReadLineAsync();
        }
        static async Task Main(string[] args)
        {
            try
            {
                await NotificationSystem.KeepCheckingRequests();
                
                //By below manner one can take input and parallely fetch output
                
                //Parallel.Invoke(async () =>
                //{
                //await NotificationSystem.KeepCheckingRequests();

                //}, async () => { await Input(); });
            }
            catch (Exception)
            {

            }
        }
    }
}
