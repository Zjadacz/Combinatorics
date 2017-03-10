using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG.Combinatorics.Partitions
{
    /// <summary>
    /// Partition is a way of writing number as a sum of positive integers. Two sums that differ only 
    /// in the order of their summands are consider the same parition.
    /// </summary>
    public class IntegerPartitionGenerator
    {
        /// <summary>
        /// Transforms permutation into next "lower" partition if possible. For example:
        /// {6} => {1,5} => {2,4} => {1,1,4} => {1,2,3} => {1,1,1,3} => {2,2,2} => {1,1,2,2} => {1,1,1,1,2} => {1,1,1,1,1,1}
        /// Algorithm:
        /// a) if first number is greather than 1, subtract one from it insert 1 at the beginning
        /// b) look up for number greather than 1 and 
        /// b1) if number is equal two subtract one from it and add insert one as predecessor
        /// b2) if number is more than two subtract one from it and add one to predecessor, aggregate to left
        /// </summary>
        /// <param name="input">Input partition</param>
        /// <returns></returns>
        public bool Next(List<int> input)
        {
            if (input.Count == 0 || input.Last() == 1)
            {
                return false;
            }

            if (input[0] > 1)
            {
                input[0]--;
                input.Insert(0, 1);
                return true;
            }

            int i = 1;
            while (i < input.Count)
            {
                if (input[i] > 1)
                {
                    input[i]--;
                    if (input[i] == 1)
                    {
                        input.Insert(i, 1);
                    }
                    else
                    {
                        input[i - 1]++;
                        AggregateLeft(input, i);
                    }
                    return true;
                }
                i++;
            }

            return true;
        }

        /// <summary>
        /// For given position in list aggregates all values before the position 
        /// to the greatest possible combination, for example (position indicated with quotation marks):
        /// {1,1,"3"}=>{2,3}
        /// {1,1,1,"3"}=>{3,3}
        /// {1,1,1,1,"2",5}=>{2,2,2,5}
        /// </summary>
        /// <param name="input">Input list to aggregate values before given index</param>
        /// <param name="index">Position to which aggregation should take place</param>
        private void AggregateLeft(List<int> input, int index)
        {
            int value = input[index];
            int sum = input.Take(index).Sum();
            int division = sum / value;
            int rest = sum % value;

            for (int i = 0; i < index; i++)
            {
                input.RemoveAt(0);
            }

            for (int i = 0; i < division; i++)
            {
                input.Insert(0, value);
            }

            if (rest > 0)
            {
                input.Insert(0, rest);
            }
        }
    }
}
