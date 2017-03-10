using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.Combinatorics.Tests.Partitions
{
    [TestClass]
    public class SetPartitionGeneratorTests
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
        public void NextSetPartitionFromSetThatAlowsPermutationWillPermutateNumberButTheCountOfSetsStaysTheSame()
        {
            // Given
            var list1 = Any.CharIList("a");
            var list2 = Any.CharIList("b,c,d");
            var listOfLists = new List<IList<char>> { list1, list2 };
            var expectedList1 = Any.CharIList("b");
            var expectedList2 = Any.CharIList("a,c,d");

            // When
            NextSetPartition<char>(listOfLists);

            // Then
            Assert.AreEqual(2, listOfLists.Count);
            CollectionAssert.AreEqual(expectedList1.ToList(), listOfLists[0].ToList());
            CollectionAssert.AreEqual(expectedList2.ToList(), listOfLists[1].ToList());
        }

        [TestMethod]
        public void NextSetPartitionFromDandABCWillPermutateToABandCD()
        {
            // Given
            var list1 = Any.CharIList("d");
            var list2 = Any.CharIList("a,b,c");
            var listOfLists = new List<IList<char>> { list1, list2 };
            var expectedList1 = Any.CharIList("a,b");
            var expectedList2 = Any.CharIList("c,d");

            // When
            NextSetPartition<char>(listOfLists);

            // Then
            Assert.AreEqual(2, listOfLists.Count);
            CollectionAssert.AreEqual(expectedList1.ToList(), listOfLists[0].ToList());
            CollectionAssert.AreEqual(expectedList2.ToList(), listOfLists[1].ToList());
        }

        [TestMethod]
        public void NextSetPartitionFromABandCDWillPermutateToACandBD()
        {
            // Given
            var list1 = Any.CharIList("a,b");
            var list2 = Any.CharIList("c,d");
            var listOfLists = new List<IList<char>> { list1, list2 };
            var expectedList1 = Any.CharIList("a,c");
            var expectedList2 = Any.CharIList("b,d");

            // When
            NextSetPartition<char>(listOfLists);

            // Then
            Assert.AreEqual(2, listOfLists.Count);
            CollectionAssert.AreEqual(expectedList1.ToList(), listOfLists[0].ToList());
            CollectionAssert.AreEqual(expectedList2.ToList(), listOfLists[1].ToList());
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

        public bool NextSetPartition<T>(IList<IList<T>> collectionOfSets) where T: IComparable<T>
        {
            return new SetPartitionGenerator().Next<T>(collectionOfSets);
        }

        public List<int> CreateIntPartition<T>(IList<IList<T>> collectionOfSets)
        {
            return new SetPartitionGenerator().CreateIntPartition<T>(collectionOfSets);
        }
    }
}
