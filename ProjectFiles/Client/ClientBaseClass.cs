using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public abstract class ClientBaseClass
    {
        private static HttpClient client;
        public static HttpClient Client
        {
            get { 

                if (client == null)
                {
                    client = new();
                }
                return client;
            }
        }
    }
}
