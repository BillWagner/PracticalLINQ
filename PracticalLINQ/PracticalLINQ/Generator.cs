using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalLINQ
{
    public class Generator
    {
       public Generator(int startAt = 0, int size = 20)
        {
            StartAt = startAt;
            Size = size;
        }

        public IEnumerable<int> Generate()
        {
            return from n in Enumerable.Range(StartAt, Size)
                   select n;
        }
        public int StartAt { get; set; }

        public int Size { get; set; }
    }
}
