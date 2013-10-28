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
        static string[] someNicknames = new string[]
        {
            "Mad Max",
            "JV",
            "Mister Fister",
            "OnTheBall Sanchez"
        };

        static void Main(string[] args)
        {
            // AnyVsCount();
            //SingleFirstDefault();
            QueryWithSideEffects();
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

        private static void SingleFirstDefault()
        {
            var triples = from x in Enumerable.Range(1, 150)
                          let y = x + 1
                          let z = x + 2
                          select new { x, y, z };

            var perfectTriples = from point in triples
                                 where point.x * point.x + point.y * point.y == point.z * point.z
                                 select point;

            var only = perfectTriples.Single();
            Console.WriteLine("Only perfect triple: {0}", only);

            var oddSum = from point in triples
                         where (point.x + point.y + point.z) % 2 == 1
                         select point;

            var first = oddSum.First();
            Console.WriteLine("The first match of {0} is {1}", oddSum.Count(), first);

            var perfectSquares = from point in triples
                                 let product = point.x * point.y * point.z
                                 where Math.Sqrt(product) == Math.Floor(Math.Sqrt(product))
                                 select point;
            var sought = perfectSquares.FirstOrDefault();
            if (sought == null)
                Console.WriteLine("Not found");
            else
                Console.WriteLine("Found {0} matches. First match is {1}", perfectSquares.Count(), sought);

            // Use the perfect triples again for SingleOrDefault:
            var soughtSingle = perfectTriples.SingleOrDefault();
            if (soughtSingle == null)
                Console.WriteLine("Not found");
            else
                Console.WriteLine("Found {0}", soughtSingle);
        }

        private static void QueryWithSideEffects()
        {
            var index = 0;
            var items = (from item in someNicknames
                         select string.Format("The index of {0} is {1}",
                         item, index++));

            foreach (var item in items)
                Console.WriteLine(item);

            Console.WriteLine();
            foreach (var item in items)
                Console.WriteLine(item);
        }

        public static IEnumerable<int> GenerateLongRandomSequence()
        {
            var generator = new Random();

            return from n in Enumerable.Range(0, 5000000)
                   select generator.Next(0, 1500);
        }

    }
}
