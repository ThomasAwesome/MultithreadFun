using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContextExamples
{
    public class GoogleApiWrapperContextFree
    {
        private HttpClient httpClient = new HttpClient();

        public async Task<string> MakeRequest()
        {
            Console.WriteLine(Task.CurrentId);

            await Task.Delay(TimeSpan.FromSeconds(3)).ConfigureAwait(false);

            Console.WriteLine(Task.CurrentId);

            var response = await httpClient.GetAsync("https://www.google.com").ConfigureAwait(false);

            Console.WriteLine(Task.CurrentId);

            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}
