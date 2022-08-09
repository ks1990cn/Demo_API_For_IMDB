using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class NotificationSystem : ClientBaseClass
    {
        static string prevResponse = "";
        public static async Task KeepCheckingRequests()
        {
            label:

            var pingDuration = TimeSpan.FromSeconds(10);

            string responseBody = await Client.GetStringAsync("https://localhost:44337/GetMovie");

            if (prevResponse != responseBody)
            {
                Console.Clear();
                Console.WriteLine(responseBody);
            }
            prevResponse = responseBody;

            Thread.Sleep(TimeSpan.FromSeconds(5));

            goto label;
            
        }
    }
}
