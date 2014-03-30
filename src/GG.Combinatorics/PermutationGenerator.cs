using System;
using System.Linq;
using System.Collections.Generic;

namespace GG.Combinatorics
{
    public class PermutationGenerator
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
        /// <param name="comparer">Custom T comparer</param>
        /// <returns>True if permutation was done, false otherwise</returns>
        public bool Next<T>(IList<T> input, IComparer<T> comparer = null) where T: IComparable<T>
        {
            var largestIndex = -1;
            for (var i = input.Count - 2; i >= 0; i--)
            {
                if (input[i].CompareTo(input[i + 1]) < 0 ||
                    (comparer != null && comparer.Compare(input[i], input[i + 1]) > 0))
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
                if (input[largestIndex].CompareTo(input[i]) < 0 ||
                    (comparer != null && comparer.Compare(input[largestIndex], input[i]) > 0))
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

        /// <summary>
        /// Generic implementation of Knuth's permutation algorithm
        /// 1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
        /// 2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
        /// 3. Swap a[j] with a[l].
        /// 4. Reverse the sequence from a[j + 1] up to and including the final element a[n].
        /// </summary>
        /// <param name="text">Input text to permutate</param>
        /// <returns>True if permutation was done, false otherwise</returns>
        public bool Next(ref string text, IComparer<char> comparer = null)
        {
            var listOfCharacters = text.ToCharArray();
            var result = this.Next(listOfCharacters, comparer);
            if (result)
            {
                text = new string(listOfCharacters);
            }

            return result;
        }

        public long CountAll<T>(IList<T> input, IComparer<T> comparer = null) where T: IComparable<T>
        {
            IList<T> ordered = null;

            if (comparer != null)
            {
                ordered = input.OrderBy(k => k, comparer).ToList();
            }
            else
            {
                ordered = input.OrderBy(k => k).ToList();
            }

            int distinctElementsCount = 1;
            for (int i = 1; i < ordered.Count; i++)
            {
                if(ordered[i - 1].CompareTo(ordered[i]) != 0)
                {
                    distinctElementsCount++;
                }
            }

            return MathHelper.Factorial(distinctElementsCount);
        }
    }
}
