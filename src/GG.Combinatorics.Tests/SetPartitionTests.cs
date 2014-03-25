using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG.Combinatorics.Tests
{
    [TestClass]
    public class SetPartitionTests
    {
        [TestMethod]
        public void NextSetPartitionFrom2ElementsSetUpdatesCollectionToTwoOneElementSets()
        {
            // Given
            var list = Any.CharIList("a,b");
            var listOfLists = new List<IList<char>> { list };

            // When
            NextSetPartition<char>(listOfLists);

            // Then
            Assert.AreEqual(2, listOfLists.Count);
            Assert.AreEqual('a', listOfLists[0][0]);
            Assert.AreEqual('b', listOfLists[1][0]);
        }

        [TestMethod]
        public void NextSetPartitionFrom2ElementsSetReturnsTrue()
        {
            // Given
            var list = Any.CharIList("a,b");
            var listOfLists = new List<IList<char>> { list };

            // When
            var result = NextSetPartition<char>(listOfLists);

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateIntPartitionFromTwoThreeElementSetsReturns33()
        {
            // Given
            var list1 = Any.CharIList("a,b,c");
            var list2 = Any.CharIList("d,e,f");
            var listOfLists = new List<IList<char>> { list1, list2 };
            var expectedIntPartition = new List<int> { 3, 3 };

            // When
            var result = CreateIntPartition<char>(listOfLists);

            // Then 
            CollectionAssert.AreEqual(expectedIntPartition, result);
        }

        public bool NextSetPartition<T>(IList<IList<T>> collectionOfSets)
        {
            return new SetPartition().Next<T>(collectionOfSets);
        }

        public List<int> CreateIntPartition<T>(IList<IList<T>> collectionOfSets)
        {
            return new SetPartition().CreateIntPartition<T>(collectionOfSets);
        }
    }
}
