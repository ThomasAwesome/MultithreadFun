using System;
using System.Threading;
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
        public void RunSomeThreads()
        {
            Task[] tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                tasks[i] = Task.Run(() => DoSomeWork());
            }
            Task.WaitAll(tasks);
        }

        [Test]
        public void GetMaxThreads()
        {
            ThreadPool.GetMaxThreads(out int maxThreads, out int completionPort);
            Console.WriteLine($"{maxThreads}");
        }

        [Test]
        public void GetResultFromTaskWithoutAsync()
        {

            var task = TaskThatHasResultWithOutAsync();
            task.Wait();
            var value = task.Result;
            Console.WriteLine(value);
            Assert.That(value, Is.Not.EqualTo(Task.CurrentId));
        }

        public Task<int?> TaskThatHasResultWithOutAsync()
        {
            return Task.Run(() => Task.CurrentId);
        }

        [Test]
        public async Task TestExample() { }


        [Test]
        public async Task GetResultFromTask()
        {
            int value = await TaskThatHasResult();
            Console.WriteLine(value);
            Assert.That(value, Is.Not.EqualTo(Task.CurrentId));
        }

        public async Task<int> TaskThatHasResult()
        {
            int? value = await Task.Run(() => Task.CurrentId);
            return value.GetValueOrDefault();
        }

        [Test]
        public async Task BesureToAwaitAll()
        {
            //this will not wait for 5 seconds. Why?
            //what do we do to fix this?
            await Task.Run(() => PartOfBad());
        }

        public Task PartOfBad()
        {
            return Task.Delay(5000);
        }
    }
}
