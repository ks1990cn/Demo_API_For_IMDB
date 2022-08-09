using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program : ClientBaseClass
    {
        static async Task Main(string[] args)
        {
            try
            {
                await NotificationSystem.KeepCheckingRequests();
            }
            catch (Exception)
            {

            }
        }
    }
}
