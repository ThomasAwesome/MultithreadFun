using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreaded
{
    public class SemaphoreExample
    {
        private SemaphoreSlim semaphore;

        public SemaphoreExample()
        {
            semaphore = new SemaphoreSlim(0, 5);
        }

        public async Task<HttpResponseMessage> ShowSemaphoreUse()
        {
            await semaphore.WaitAsync();

            try
            {
                Console.WriteLine("I made it pass the semaphore block.");
                return await new HttpClient().GetAsync("https://www.google.com");
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
