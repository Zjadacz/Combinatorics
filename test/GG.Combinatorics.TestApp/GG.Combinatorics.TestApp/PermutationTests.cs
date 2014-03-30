using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG.Combinatorics.TestApp
{
    public static class PermutationTests
    {
        public static void TestPermutationsGenerationOnTenElementsIntSet()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Testing int permutations generation on ten element int set");
            Console.ForegroundColor = color;

            var input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var permutationsGenerator = new PermutationGenerator();
            var stopwatch = Stopwatch.StartNew();

            int counter = 1;
            while(permutationsGenerator.Next<int>(input))
            {
                counter++;
            }

            stopwatch.Stop();

            Console.WriteLine("Generated {0} permutations in {1} miliseconds.", counter, stopwatch.ElapsedMilliseconds);
            Console.WriteLine("CountAll returned {0}.", permutationsGenerator.CountAll(input));
            Console.WriteLine();
        }

        public static void TestPermutationsGenerationOnTenLettersString()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Testing int permutations generation on ten element string");
            Console.ForegroundColor = color;

            var input = "abcdefghij";
            var permutationsGenerator = new PermutationGenerator();
            var stopwatch = Stopwatch.StartNew();

            int counter = 1;
            while (permutationsGenerator.Next(ref input))
            {
                counter++;
            }

            stopwatch.Stop();

            Console.WriteLine("Generated {0} permutations in {1} miliseconds.", counter, stopwatch.ElapsedMilliseconds);
            //Console.WriteLine("CountAll returned {0}.", permutationsGenerator.CountAll(input));
            Console.WriteLine();
        }

        public static void TestPermutationsGenerationOnTwelveElementsIntSet()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Testing int permutations generation on twelve element int set");
            Console.ForegroundColor = color;

            var input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var permutationsGenerator = new PermutationGenerator();
            var stopwatch = Stopwatch.StartNew();

            int counter = 1;
            while (permutationsGenerator.Next<int>(input))
            {
                counter++;
            }

            stopwatch.Stop();

            Console.WriteLine("Generated {0} permutations in {1} miliseconds.", counter, stopwatch.ElapsedMilliseconds);
            Console.WriteLine("CountAll returned {0}.", permutationsGenerator.CountAll(input));
            Console.WriteLine();
        }

        public static void TestPermutationsGenerationOnTwelveLettersString()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Testing int permutations generation on twelve element string");
            Console.ForegroundColor = color;

            var input = "abcdefghijkl";
            var permutationsGenerator = new PermutationGenerator();
            var stopwatch = Stopwatch.StartNew();

            int counter = 1;
            while (permutationsGenerator.Next(ref input))
            {
                counter++;
            }

            stopwatch.Stop();

            Console.WriteLine("Generated {0} permutations in {1} miliseconds.", counter, stopwatch.ElapsedMilliseconds);
            //Console.WriteLine("CountAll returned {0}.", permutationsGenerator.CountAll(input));
            Console.WriteLine();
        }
    }
}
