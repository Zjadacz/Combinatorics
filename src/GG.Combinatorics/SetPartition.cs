﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG.Combinatorics
{
    public class SetPartition
    {
        /// <summary>
        /// Simillary to integer partition set partition is used to create different division (subsets) of given set. 
        /// For example when we try to create partitions for set {a,b,c,d}, we will end up with:
        /// {a}, {b,c,d}
        /// {b}, {a,c,d}
        /// {c}, {a,b,d}
        /// {d}, {a,b,c}
        /// {a,b}, {c,d}
        /// {a,c}, {b,d}
        /// {a,d}, {b,c}
        /// {a}, {b}, {c,d}
        /// {a}, {c}, {b,d}
        /// {a}, {d}, {b,c}
        /// {b}, {c}, {a,d}
        /// {b}, {d}, {a,c}
        /// {c}, {d}, {a,b}
        /// {a}, {b}, {c}, {d}
        /// </summary>
        /// <typeparam name="T">Type of sets' element</typeparam>
        /// <param name="collectionOfSets">Collection of sets to partition</param>
        /// <returns>True if partition was successful, false otherwise.</returns>
        public bool Next<T>(IList<IList<T>> collectionOfSets) where T: IComparable<T>
        {
            if (collectionOfSets.Count > 1)
            {
                for (int i = 0; i < collectionOfSets.Count; i++)
                {
                    collectionOfSets[i] = collectionOfSets[i].OrderByDescending(k => k).ToList();
                }
            }

            var intPartition = CreateIntPartition<T>(collectionOfSets);
            var flatCollection = collectionOfSets.SelectMany(s => s).ToArray();
            var permutationGenerator = new Permutation();

            bool wasChange = false;

            if (collectionOfSets.Count > 1)
            {
                wasChange = permutationGenerator.Next<T>(flatCollection);
            }

            if (!wasChange)
            {
                flatCollection = flatCollection.OrderBy(k => k).ToArray();
                wasChange = new IntegerPartition().Next(intPartition);
            }

            if (wasChange)
            {
                int counter = 0;
                collectionOfSets.Clear();
                foreach(int count in intPartition)
                {
                    collectionOfSets.Add(flatCollection.Skip(counter).Take(count).OrderBy(k => k).ToList());
                    counter += count;
                }

                return true;
            }

            return false;
        }

        public List<int> CreateIntPartition<T>(IList<IList<T>> collectionOfSets)
        {
            return collectionOfSets.Select(l => l.Count).ToList();
        }
    }
}
