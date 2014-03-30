using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG.Combinatorics.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PermutationTests.TestPermutationsGenerationOnTenElementsIntSet(); 
            PermutationTests.TestPermutationsGenerationOnTenLettersString();
            PermutationTests.TestPermutationsGenerationOnTwelveElementsIntSet();
            PermutationTests.TestPermutationsGenerationOnTwelveLettersString();
            Console.ReadKey();
        }

    }
}
