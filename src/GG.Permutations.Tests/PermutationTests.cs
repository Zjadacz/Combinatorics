using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace GG.Permutations.Tests
{
    [TestClass]
    public class PermutationTests
    {
        [TestMethod]
        public void PermutatingEmptyCollectionDoesNothingToCollection()
        {
            // Given
            IList<int> list = Any.IntIList("");

            // When
            NextPermutation(list);

            // Then
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void PermutatingEmptyCollectionReturnsFalse()
        {
            // Given
            IList<int> list = Any.IntIList("");

            // When
            var result = NextPermutation(list);

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PermutatingOneElementCollectionDoesNothingToCollection()
        {
            // Given
            var element = Any.Int();
            var list = Any.IntIList(element.ToString());
     
            // When
            NextPermutation(list);

            // Then
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(element, list[0]);
        }

        [TestMethod]
        public void PermutatingOneElementCollectionReturnsFalse()
        {
            // Given
            var element = Any.Int();
            var list = Any.IntIList(element.ToString());

            // When
            var result = NextPermutation(list);

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Permutating12UpdatesCollectionTo21()
        {
            // Given 
            var list = Any.IntIList("1,2");

            // When
            NextPermutation(list);

            // Then
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(1, list[1]);
        }

        [TestMethod]
        public void Permutating12ReturnsTrue()
        {
            // Given 
            var list = Any.IntIList("1,2");

            // When
            var result = NextPermutation(list);

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PermutatingAnyThreeNumbersCreatesLargerNumber()
        {
            // Given 
            var number3 = Any.Int();
            var number2 = Any.IntLessThan(number3);
            var number1 = Any.IntLessThan(number3);
            var list = Any.IntIList(string.Format("{0},{1},{2}", number1, number2, number3));

            // When
            NextPermutation(list);

            // Then
            Assert.IsTrue(list[0] > number1 || (list[0] == number1 && list[1] > number1));
        }

        public bool NextPermutation<T>(IList<T> collection) where T : IComparable<T>
        {
            return new Permutation().NextPermutation<T>(collection);
        }
    }
}
