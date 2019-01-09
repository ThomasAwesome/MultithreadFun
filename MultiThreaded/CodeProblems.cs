//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Threading.Tasks;
//using NUnit.Framework;

//namespace MultiThreaded
//{
//    [TestFixture]
//    public class CodeProblems
//    {
//        [Test]
//        public void WriteThisFileUsingAsyncMethod()
//        {
//            //do not use .Wait() or .Result()
//            var fileName = "AsyncWrite.txt";
//            var fileContents = "you will write this text file out asynchronously. Hint Stream Writer suppports Async operations";

//        }

//        [Test]
//        public void FixThreadingProblem()
//        {
//            int maxValue = 20000;
//            var exampleClass = new ExampleClass();
//            Parallel.For(0, maxValue, t =>
//              {
//                  exampleClass.Value++;
//              });

//            Assert.That(exampleClass.Value, Is.EqualTo(maxValue));
//        }

//        [Test]
//        public void MoreLockingIssues()
//        {
//            //how to protect the data and stop an exception from being raised
//            var collection = new NotThreadSafeCollection();
//            for (int i = 0; i < 100; i++)
//            {
//                collection.Add(i);
//            }
//            Task.Run(() =>
//              {
//                  for (int i = 0; i < 100; i++)
//                  {
//                      collection.Add(i);
//                  }
//              });
//            foreach (var value in collection.Values)
//            {
//                Console.WriteLine(value);
//            }
//        }

//        [Test]
//        public async Task CreateMethodThatReturnsATaskWithValue()
//        {
//            //Create a method that a returns a Task<int> or whatever value you want. call the method
//            //and retrieve the value with async
//            //do not use .Wait() or .Result()

//        }

//        [Test]
//        public async Task GetThisToRunOnAnotherThread()
//        {
//            await GenerateValue();
//        }

//        [Test]
//        public void GetDataFromMultiplePlacesAndBlock()
//        {
//            HttpClient httpClient = new HttpClient();
//            List<Uri> uris = new List<Uri>
//      {
//        new Uri("https://www.google.com"),
//        new Uri("https://www.bing.com/"),
//        new Uri("https://www.yahoo.com/"),
//        new Uri("https://duckduckgo.com/")
//      };
//            //make requests to all these websites in Parallel. hint think Parallel.Foreach
//        }

//        [Test]
//        public void GetDataFromMultiplePlacesAndNonBlocking()
//        {
//            //this time do not block and create tasks for them all and process their data when they finish.
//            HttpClient httpClient = new HttpClient();
//            List<Uri> uris = new List<Uri>
//      {
//        new Uri("https://www.google.com"),
//        new Uri("https://www.bing.com/"),
//        new Uri("https://www.yahoo.com/"),
//        new Uri("https://duckduckgo.com/")
//      };
//        }


//        public Task<int> GenerateValue()
//        {
//            int value = 0;
//            for (int i = 0; i < 100; i++)
//            {
//                ++value;
//            }
//            Assert.That(Task.CurrentId.GetValueOrDefault(), Is.Not.Zero);
//            return Task.FromResult(value);
//        }
//    }

//    public class ExampleClass
//    {
//        public int Value { get; set; }
//    }
//}
