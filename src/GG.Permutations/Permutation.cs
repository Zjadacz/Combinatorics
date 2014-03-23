using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG.Permutations
{
    public class Permutation
    {
        /// <summary>
        /// Generic implementation of Knuth's permutation algorithm
        /// 1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
        /// 2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
        /// 3. Swap a[j] with a[l].
        /// 4. Reverse the sequence from a[j + 1] up to and including the final element a[n].
        /// </summary>
        /// <typeparam name="T">Generic type of list elements</typeparam>
        /// <param name="input">IList collection of element to permutate</param>
        /// <returns>True if permutation was done, false otherwise</returns>
        public bool NextPermutation<T>(IList<T> input) where T: IComparable<T>
        {
            var largestIndex = -1;
            for (var i = input.Count - 2; i >= 0; i--)
            {
                if (input[i].CompareTo(input[i + 1]) < 0)
                {
                    largestIndex = i;
                    break;
                }
            }

            if (largestIndex < 0)
            {
                return false;
            }

            var largestIndex2 = -1;
            for (var i = input.Count - 1; i >= 0; i--)
            {
                if (input[largestIndex].CompareTo(input[i]) < 0)
                {
                    largestIndex2 = i;
                    break;
                }
            }

            var tmp = input[largestIndex];
            input[largestIndex] = input[largestIndex2];
            input[largestIndex2] = tmp;

            for (int i = largestIndex + 1, j = input.Count - 1; i < j; i++, j--)
            {
                tmp = input[i];
                input[i] = input[j];
                input[j] = tmp;
            }

            return true; 
        }
    }
}
