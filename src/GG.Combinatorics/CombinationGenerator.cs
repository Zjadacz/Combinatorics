using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace GG.Combinatorics
{
    public class CombinationGenerator
    {
        public static bool Next<T>(IList<T> input, IList<T> combination) where T : IComparable<T>
        {
            if (combination == null || combination.Count == 0)
                return false;

            var positions = new List<int>();
            var index = 0;
            for (int i = 0; i < input.Count && index < combination.Count; i++)
            {
                if (input[i].CompareTo(combination[index]) == 0)
                {
                    positions.Add(i);
                    index++;
                }
            }

            if (positions.Last() < input.Count - 1)
            {
                positions[positions.Count - 1]++;
            }
            else
            {
                bool result = false;
                for (int i = positions.Count - 2; i >= 0; i--)
                {
                    if (positions[i] + 1 != positions[i + 1])
                    {
                        positions[i]++;
                        for (int j = i + 1; j < positions.Count; j++)
                        {
                            positions[j] = positions[j - 1] + 1;
                        }

                        result = true;
                        break;
                    }
                }

                if (!result)
                    return false;
            }

            for (int i = 0; i < combination.Count; i++)
            {
                combination[i] = input[positions[i]];
            }

            return true;
        }

        public static long CountAll<T>(IList<T> input, int length) where T : IComparable<T>
        {
            var distinctElementsCount = 1;
            for (var i = 1; i < input.Count; i++)
            {
                if (input[i - 1].CompareTo(input[i]) != 0)
                {
                    distinctElementsCount++;
                }
            }

            return MathHelper.BinomialCoefficient(distinctElementsCount, length);
        }
    }
}
