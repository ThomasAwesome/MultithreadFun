using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreaded
{
    [TestFixture]
    public class SemaphoreExample
    {
        private SemaphoreSlim semaphore;
        private List<string> responses;
        private List<Task> tasks;

        [SetUp]
        public void SemaphoreExampleSetup()
        {
            semaphore = new SemaphoreSlim(1, 1);
            responses = new List<string>();
            tasks = new List<Task>();
        }

        [Test]
        public async Task ShowSemaphoreUse()
        {
            var timesToIterate = 5;

            for (var i = 0; i < timesToIterate; i++)
            {
                var task = Task.Run(async () =>
                {
                    await semaphore.WaitAsync();

                    try
                    {
                        Console.WriteLine("I made it pass the semaphore block.");
                        var respnose = await new HttpClient().GetAsync("https://www.google.com");
                        responses.Add(await respnose.Content.ReadAsStringAsync());
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                });
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);


            Assert.That(responses.Count, Is.EqualTo(timesToIterate));
        }
    }
}
