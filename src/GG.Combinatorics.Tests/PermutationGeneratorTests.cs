using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GG.Combinatorics.Tests
{
    [TestClass]
    public class PermutationGeneratorTests
    {
        [TestMethod]
        public void PermutatingEmptyCollectionDoesNothingToCollection()
        {
            // Given
            var list = new List<int>();

            // When
            PermutationGenerator.Next(list);

            // Then
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void PermutatingEmptyCollectionReturnsFalse()
        {
            // Given
            var list = new List<int>();

            // When
            var result = PermutationGenerator.Next(list);

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PermutatingOneElementCollectionDoesNothingToCollection()
        {
            // Given
            var element = Any.Int();
            var list = new List<int> { element };

            // When
            PermutationGenerator.Next(list);

            // Then
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(element, list[0]);
        }

        [TestMethod]
        public void PermutatingOneElementCollectionReturnsFalse()
        {
            // Given
            var element = Any.Int();
            var list = new List<int> { element };

            // When
            var result = PermutationGenerator.Next(list);

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Permutating12UpdatesCollectionTo21()
        {
            // Given 
            var list = new List<int> { 1, 2 };

            // When
            PermutationGenerator.Next(list);

            // Then
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(1, list[1]);
        }

        [TestMethod]
        public void Permutating12ReturnsTrue()
        {
            // Given 
            var list = new List<int> { 1, 2 };

            // When
            var result = PermutationGenerator.Next(list);

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
            var list = new List<int> {number1, number2, number3};

            // When
            PermutationGenerator.Next(list);

            // Then
            Assert.IsTrue(list[0] > number1 || (list[0] == number1 && list[1] > number1));
        }

        [TestMethod]
        public void PermutationOfStringAbcUpdatesStringToAcb()
        {
            // Given
            var text = "ABC";
            var expectedText = "ACB";

            // When
            PermutationGenerator.Next(ref text);

            // Then
            Assert.AreEqual(expectedText, text);
        }

        [TestMethod]
        public void PermutationOfStringAbcReturnTrue()
        {
            // Given
            var text = "ABC";

            // When
            var result = PermutationGenerator.Next(ref text);

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PermutationOfStringCbaReturnsFalse()
        {
            // Given
            var text = "CBA";

            // When
            var result = PermutationGenerator.Next(ref text);

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CountAllFrom1ElementSetReturn1()
        {
            // Given
            var element = Any.Int();
            var list = new List<int> {element};

            // When
            var result = PermutationGenerator.CountAll(list);

            // Then
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CountAllFrom2DistinctElementSetReturn2()
        {
            // Given
            var element1 = Any.Int();
            var element2 = Any.IntLessThan(element1);
            var list = new [] { element1, element2 };

            // When
            var result = PermutationGenerator.CountAll(list);

            // Then
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CountAllFrom3DistinctElementSetReturn6()
        {
            // Given
            var element1 = Any.Int();
            var element2 = Any.IntLessThan(element1);
            var element3 = Any.IntLessThan(element2);
            var list = new [] { element1, element2, element3 };

            // When
            var result = PermutationGenerator.CountAll(list);

            // Then
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void CountAllFrom3ElementSetWhereTwoAreTheSameReturn2()
        {
            // Given
            var element1 = Any.Int();
            var element2 = Any.IntLessThan(element1);
            var list = new [] { element1, element2, element1 };

            // When
            var result = PermutationGenerator.CountAll(list);

            // Then
            Assert.AreEqual(2, result);
        }
    }
}
