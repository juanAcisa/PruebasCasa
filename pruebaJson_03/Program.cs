
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace pruebaJson_03
{
    class Program
    {
        static void Main(string[] args)
        {
            //try http GET
            var uri = @"http://api.sinersis.es/api/products?lastsync=2019-10-01%2000%3A00%3A00&access_token=ZTE5MmFiMjAyNzJlMzc1MzZmMjI0M2RjZTRlN2RlYzQwYTUwOGIzNDA4MmYxMjI4YTMwNDUyNzc2YjNjOGFiYw";

            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri);

            request.Method = HttpMethod.Get;

            var client = new HttpClient();
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tok_ty, acc_tok);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpWebResponse response = client.SendAsync(request);
            HttpResponseMessage response = client.


            Console.ReadKey();
        }
    }
}
