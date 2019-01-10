using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace ContextExamples
{
    public class GoogleApiWrapper
    {
        private HttpClient httpClient = new HttpClient();

        public async Task<string> MakeRequest()
        {
            Console.WriteLine(Thread.CurrentContext.ContextID);

            await Task.Delay(TimeSpan.FromSeconds(3));

            Console.WriteLine(Thread.CurrentContext.ContextID);

            var response = await httpClient.GetAsync("https://www.google.com");

            Console.WriteLine(Thread.CurrentContext.ContextID);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
