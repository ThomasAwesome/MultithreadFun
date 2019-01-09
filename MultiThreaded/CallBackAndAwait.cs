using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MultiThreaded
{
    public class CallBackAndAwait
    {
        public void CallBackExample()
        {
            var httpClient = new HttpClient();
            httpClient.GetAsync("www.google.com").ContinueWith(CallsThisMethod);
        }

        public void CallsThisMethod(Task<HttpResponseMessage> httpResponseTask)
        {
            var httpRepsonse = httpResponseTask.Result;
            httpRepsonse.Content.ReadAsStringAsync().ContinueWith(ThanCallThisMethod);
        }

        public void ThanCallThisMethod(Task<string> content)
        {
            var html = content.Result;
            Console.WriteLine(html);
        }

        public async Task AsyncAndAwaitS()
        {
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync("www.google.com");

            var html = await httpResponse.Content.ReadAsStringAsync();

            Console.WriteLine(html);
        }
    }
}