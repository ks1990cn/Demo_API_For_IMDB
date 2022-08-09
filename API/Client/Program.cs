using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new();
            try
            {

                HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44337/GetMovie");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);

            }
            catch (Exception)
            {

            }
        }
    }
}
