using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MultiThreaded
{
  [TestFixture]
  public class ThreadingConcept
  {
    public void DoSomeWork(int threadNumber)
    {
      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine($"Thread {threadNumber}: Iteration loop {i}");
      }
    }

    [Test]
    public void RunSomeThreads()
    {
      Task[] tasks = new Task[10];
      for (int i = 0; i < 10; i++)
      {
        var i1 = i;
        tasks[i] = Task.Run(() =>DoSomeWork(i1));
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
      Assert.That(value, Is.Not.Zero);
    }

    public Task<int?> TaskThatHasResultWithOutAsync()
    {
      return Task.Run(() => Task.CurrentId);
    }


    [Test]
    public async Task GetResultFromTask()
    {
      var value = await TaskThatHasResult();
      Console.WriteLine(value);
      Assert.That(value, Is.Not.Zero);
    }

    public async Task<int> TaskThatHasResult()
    {
      var value = await Task.Run(() => Task.CurrentId);
      return value.GetValueOrDefault();
    }

    [Test]
    public async Task DontDoThis()
    {
      //this will not wait for 5 seconds. Why?
      await Task.Run(() => PartOfBad());
    }

    public async Task PartOfBad()
    {
      await Task.Run(async () => await Task.Delay(5000));
    }
  }
}
