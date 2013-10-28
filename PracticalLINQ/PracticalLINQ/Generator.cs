using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalLINQ
{
    public class Generator : IDisposable
    {
        private bool isDisposed;
       public Generator(int startAt = 0, int size = 20)
        {
            StartAt = startAt;
            Size = size;
        }

        public IEnumerable<int> Generate()
        {
            int index = 0;
            while (index < Size)
            {
                if (isDisposed)
                    throw new ObjectDisposedException("Generator");
                yield return StartAt + index++;
            }
        }
        public int StartAt { get; set; }

        public int Size { get; set; }

        public void Dispose()
        {
            isDisposed = true;
        }
    }
}
