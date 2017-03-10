using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using GG.Combinatorics.Partitions;

namespace GG.Combinatorics.Tests.Partitions
{
    [TestClass]
    public class SetPartitionGeneratorTests
    {
        [TestMethod]
        public void NextSetPartitionFrom2ElementsSetUpdatesCollectionToTwoOneElementSets()
        {
            // Given
            var list = new List<char> { 'a', 'b' };
            var listOfLists = new List<IList<char>> { list };

            // When
            NextSetPartition(listOfLists);

            // Then
            Assert.AreEqual(2, listOfLists.Count);
            Assert.AreEqual('a', listOfLists[0][0]);
            Assert.AreEqual('b', listOfLists[1][0]);
        }

        [TestMethod]
        public void NextSetPartitionFrom2ElementsSetReturnsTrue()
        {
            // Given
            var list = new List<char> { 'a', 'b' };
            var listOfLists = new List<IList<char>> { list };
        
            // When
            var result = NextSetPartition(listOfLists);

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NextSetPartitionFromSetThatAlowsPermutationWillPermutateNumberButTheCountOfSetsStaysTheSame()
        {
            // Given
            var list1 = new List<char> { 'a' };
            var list2 = new List<char> { 'b', 'c', 'd' };
            var listOfLists = new List<IList<char>> { list1, list2 };
            var expectedList1 = new List<char> { 'b' };
            var expectedList2 = new List<char> { 'a', 'c', 'd' };

            // When
            NextSetPartition(listOfLists);

            // Then
            Assert.AreEqual(2, listOfLists.Count);
            CollectionAssert.AreEqual(expectedList1.ToList(), listOfLists[0].ToList());
            CollectionAssert.AreEqual(expectedList2.ToList(), listOfLists[1].ToList());
        }

        [TestMethod]
        public void NextSetPartitionFromDandAbcWillPermutateToAbAndCd()
        {
            // Given
            var list1 = new List<char> { 'd' };
            var list2 = new List<char> { 'a', 'b', 'c' };
            var listOfLists = new List<IList<char>> { list1, list2 };
            var expectedList1 = new List<char> { 'a', 'b' };
            var expectedList2 = new List<char> { 'c', 'd' };

            // When
            NextSetPartition(listOfLists);

            // Then
            Assert.AreEqual(2, listOfLists.Count);
            CollectionAssert.AreEqual(expectedList1.ToList(), listOfLists[0].ToList());
            CollectionAssert.AreEqual(expectedList2.ToList(), listOfLists[1].ToList());
        }

        [TestMethod]
        public void NextSetPartitionFromABandCcWillPermutateToAcandBd()
        {
            // Given
            var list1 = new List<char> { 'a', 'b' };
            var list2 = new List<char> { 'c', 'd' };
            var listOfLists = new List<IList<char>> { list1, list2 };
            var expectedList1 = new List<char> { 'a', 'c' };
            var expectedList2 = new List<char> { 'b', 'd' };

            // When
            NextSetPartition(listOfLists);

            // Then
            Assert.AreEqual(2, listOfLists.Count);
            CollectionAssert.AreEqual(expectedList1.ToList(), listOfLists[0].ToList());
            CollectionAssert.AreEqual(expectedList2.ToList(), listOfLists[1].ToList());
        }

        [TestMethod]
        public void CreateIntPartitionFromTwoThreeElementSetsReturns33()
        {
            // Given
            var list1 = new List<char> { 'a', 'b', 'c' };
            var list2 = new List<char> { 'd', 'e', 'f' };
            var listOfLists = new List<IList<char>> { list1, list2 };
            var expectedIntPartition = new List<int> { 3, 3 };

            // When
            var result = CreateIntPartition(listOfLists);

            // Then 
            CollectionAssert.AreEqual(expectedIntPartition, result);
        }

        public bool NextSetPartition<T>(IList<IList<T>> collectionOfSets) where T: IComparable<T>
        {
            return new SetPartitionGenerator().Next(collectionOfSets);
        }

        public List<int> CreateIntPartition<T>(IList<IList<T>> collectionOfSets)
        {
            return new SetPartitionGenerator().CreateIntPartition(collectionOfSets);
        }
    }
}
