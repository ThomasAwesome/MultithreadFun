using System.Collections.Generic;

namespace MultiThreaded
{
    public class NotThreadSafeCollection
    {
        public NotThreadSafeCollection()
        {
            Values = new List<int>();
        }

        public List<int> Values { get; }

        public void Add(int value)
        {
            Values.Add(value);
        }

        public void Remove(int value) { Values.Remove(value); }
    }
}
