using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GG.Combinatorics.Partitions;

namespace GG.Combinatorics.Tests.Partitions
{
    [TestClass]
    public class IntegerPartitionGeneratorTests
    {
        [TestMethod]
        public void NextPartitionOfEmptyListReturnsFalse()
        {
            // Given
            var list = new List<int>();

            // When
            var result = NextPartition(list);

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NextPartitionOfEmptyListDoesntUpdateInput()
        {
            // Given
            var list = new List<int>();

            // When
            NextPartition(list);

            // Then
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void NextPartitionOn1ReturnsFalse()
        {
            // Given
            var list = new List<int> { 1 };

            // When
            var result = NextPartition(list);

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NextPartitionOn1DoesntUpdateList()
        {
            // Given
            var list = new List<int>{ 1 };
            var expectedList = new List<int> { 1 };

            // When
            NextPartition(list);

            // Then
            CollectionAssert.AreEqual(expectedList, list);
        }

        [TestMethod]
        public void NextPartitionOn2UpdatesListTo11()
        {
            // Given
            var list = new List<int> { 2 };
            var expectedList = new List<int> { 1, 1 };

            // When
            NextPartition(list);

            // Then
            CollectionAssert.AreEqual(expectedList, list);
        }

        public void NextPartitionOn2ReturnsTrue()
        {
            // Given
            var list = new List<int> { 2 };

            // When
            var result = NextPartition(list);

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NextPartitionOn12UpdatesListTo111()
        {
            // Given
            var list = new List<int> { 1, 2 };
            var expectedList = new List<int> { 1, 1, 1 };

            // When
            NextPartition(list);

            // Then
            CollectionAssert.AreEqual(expectedList, list);
        }
        
        [TestMethod]
        public void NextPartitionOn14UpdatesListTo23()
        {
            // Given
            var list = new List<int> { 1, 4 };
            var expectedList = new List<int> { 2, 3 };

            // When
            NextPartition(list);

            // Then
            CollectionAssert.AreEqual(expectedList, list);
        }

        [TestMethod]
        public void NextParititionOn1113UpdatesListTo222()
        {
            // Given
            var list = new List<int> { 1, 1, 1, 3 };
            var expectedList = new List<int> { 2, 2, 2 };

            // When
            NextPartition(list);

            // Then
            CollectionAssert.AreEqual(expectedList, list);
        }

        public bool NextPartition(List<int> input)
        {
            return new IntegerPartitionGenerator().Next(input);
        }
    }
}
