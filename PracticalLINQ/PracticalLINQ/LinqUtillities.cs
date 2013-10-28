using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalLINQ
{
    public static class LinqUtillities
    {
        public static void ForAll<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (T item in sequence)
                action(item);
        }
        public static IEnumerable<T> Log<T>(this IEnumerable<T> sequence, string after)
        {
            foreach (T item in sequence)
            {
                Console.WriteLine("{0}: After {1}", item.ToString(), after);
                yield return item;
            }
        }
        public static IEnumerable<T> LogSequence<T>(this IEnumerable<T> sequence, string after)
        {
            var eagerSequence = sequence.ToArray();
            Console.WriteLine("Sequence after {0}", after);
            eagerSequence.ForAll(item =>
                Console.WriteLine("\t{0}", item.ToString()));
            return sequence;
        }
        public static IEnumerable<T> LogSequenceEager<T>(this IEnumerable<T> sequence, string after)
        {
            var eagerSequence = sequence.ToArray();
            Console.WriteLine("Sequence after {0}", after);
            eagerSequence.ForAll(item => Console.WriteLine("\t{0}", item.ToString()));
            return eagerSequence;
        }

    }
}
