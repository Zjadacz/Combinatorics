using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG.Combinatorics
{
    public class SetPartition
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionOfSets"></param>
        /// <returns></returns>
        public bool Next<T>(IList<IList<T>> collectionOfSets)
        {
            var intPartition = CreateIntPartition<T>(collectionOfSets);
            var flatCollection = collectionOfSets.SelectMany(s => s).ToList();

            var updatePartitionResult = new IntegerPartition().Next(intPartition);
            if(updatePartitionResult)
            {
                int counter = 0;
                collectionOfSets.Clear();
                foreach(int count in intPartition)
                {
                    collectionOfSets.Add(flatCollection.Skip(counter).Take(count).ToList());
                    counter++;
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
