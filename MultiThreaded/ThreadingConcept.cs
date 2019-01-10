using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MultiThreaded
{
    [TestFixture]
    public class ThreadingConcept
    {
        public void DoSomeWork()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thread {Task.CurrentId}: Iteration loop {i}");
            }
        }

        [Test]
        public async Task RunSomeThreads()
        {
            var threadCount = 30;
            Task[] tasks = new Task[threadCount];
            for (int i = 0; i < threadCount; i++)
            {
                tasks[i] = Task.Run(() => DoSomeWork());
            }
            await Task.WhenAll(tasks);
        }
        
        [Test]
        public void GetResultFromTaskWithoutAsync()
        {
            var task = TaskThatReturnsTheTaskId();
            var value = task.Result;
            Console.WriteLine(value);
            Assert.That(value, Is.Not.EqualTo(Task.CurrentId));
        }

        public Task<int?> TaskThatReturnsTheTaskId()
        {
            return Task.Run(() => Task.CurrentId);
        }

        [Test]
        public async Task GetResultFromTask()
        {
            int? value = await TaskThatReturnsTheTaskId();
            Console.WriteLine(value);
            Assert.That(value, Is.Not.EqualTo(Task.CurrentId));
        }

        [Test]
        public async Task BesureToAwaitAll()
        {
            //this will not wait for 5 seconds. Why?
            //what do we do to fix this?
            await Task.Run(async() =>
            {
                DelayForFiveSeconds();
                return 1;
            });
        }

        public Task DelayForFiveSeconds()
        {
            return Task.Delay(5000);
        }
    }
}