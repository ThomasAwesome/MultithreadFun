//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using NUnit.Framework;

//namespace MultiThreaded
//{
//  [TestFixture]
//  public class DeadLockExample
//  {
//    //don't lock on strings
//    public const string Lock1 = "hello";

//    public const string Lock2 = "hello2";

//    [Test]
//    public async Task ItIsEasyToHappen()
//    {
//      var task1 = Task.Run(() => DoWorkBar());
//      var task2 = Task.Run(() => DoWorkFoo());
//      await Task.WhenAll(task1, task2);
//    }

//    public void DoWorkFoo()
//    {
//      lock (Lock2)
//      {
//        Thread.Sleep(1000);
//        for (int i = 0; i < 5000; i++)
//        {
//          lock (Lock1)
//          {
//            Console.WriteLine(i);
//          }
//        }
//      }
//    }

//    public void DoWorkBar()
//    {
//      lock (Lock1)
//      {
//        Thread.Sleep(1000);
//        for (int i = 0; i < 5000; i++)
//        {
//          lock (Lock2)
//          {
//            Console.WriteLine(i);
//          }
//        }
//      }
//    }
//  }
//}
