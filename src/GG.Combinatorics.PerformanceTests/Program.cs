using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GG.Combinatorics.PerformanceTests
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0.0;
            for (int i = 0; i < 10; i++)
            {
                var time = GetTimeForCustomLenghtSetPermutation(10);
                sum += time.TotalMilliseconds;
                Console.WriteLine((i + 1) + ": Try time - " + time.TotalMilliseconds.ToString("0") + "ms");
            }

            Console.WriteLine("Avg time - " + (sum/10).ToString("0") + "ms");
            Console.ReadKey();
        }

        public static TimeSpan GetTimeForCustomLenghtSetPermutation(int n)
        {
            var list = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                list.Add(i);
            }

            var counter = PermutationGenerator.CountAll(list);
            var stopwatch = Stopwatch.StartNew();
            while (PermutationGenerator.Next(list))
            {
                counter--;
            }

            stopwatch.Stop();

            if (counter != 1)
            {
                throw new ApplicationException("Something is wrong...");
            }

            return stopwatch.Elapsed;
        }
    }
}
