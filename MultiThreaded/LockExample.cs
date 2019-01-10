using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiThreaded
{
    [TestFixture]
    public class LockExample
    {
        private readonly object collectionLock = new object();
        private List<int> numbers;

        [SetUp]
        public void Setup()
        {
            numbers = new List<int>();
        }

        [Test]
        public void Locking()
        {
            var timesToIterate = 5000000;
            Parallel.For(0, timesToIterate, (iteration) =>
            {
                lock (collectionLock)
                {
                    numbers.Add(iteration);
                }
            });

            Console.WriteLine($"collection count equals {numbers.Count}");
            Assert.That(numbers.Count, Is.EqualTo(timesToIterate));
        }

        [Test]
        public void NonLocking()
        {
            var timesToIterate = 5000000;
            Parallel.For(0, timesToIterate, (iteration) =>
            {
                numbers.Add(iteration);
            });

            Console.WriteLine($"collection count equals {numbers.Count}");
            Assert.That(numbers.Count, Is.EqualTo(timesToIterate));
        }
    }
}
