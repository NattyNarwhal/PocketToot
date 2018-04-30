using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PocketToot
{
    public class Paginated<T> where T : IId
    {
        public IEnumerable<T> Items { get; private set; }
        public long? Before { get; private set; }
        public long? After { get; private set; }

        public Paginated(IEnumerable<T> items, long max, long since)
        {
            Items = items;
            Before = max;
            After = since;
        }

        public Paginated(IEnumerable<T> items)
        {
            Items = items;
            if (items.Count() > 0)
            {
                After = items.First().Id;
                Before = items.Last().Id;
            }
        }
    }
}
