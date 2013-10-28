using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            AnyVsCount();

        }

        private static void AnyVsCount()
        {
            var stopwatch = new Stopwatch();

            var oddNumberSequence = (from value in GenerateLongRandomSequence()
                                     where value % 2 == 1
                                     select value);

            stopwatch.Start();
            var hasOdds = oddNumberSequence.Any();
            stopwatch.Stop();
            Console.WriteLine("Elapsed time for Any: {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            hasOdds = oddNumberSequence.Count() > 0;
            stopwatch.Stop();

            Console.WriteLine("Elapsed time for Any: {0}", stopwatch.Elapsed);
        }

        public static IEnumerable<int> GenerateLongRandomSequence()
        {
            var generator = new Random();

            return from n in Enumerable.Range(0, 5000000)
                   select generator.Next(0, 1500);
        }

    }
}
