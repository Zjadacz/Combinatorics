using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GG.Combinatorics.Tests
{
    [TestClass]
    public class CombinationGeneratorTests
    {
        /// <summary>
        /// {a, b, c, d} => {a, b}, {a, c}, {a, d}, {b, c}, {b, d}, {c, d}
        /// </summary>
        [TestMethod]
        public void CountAll_ForFourNumberOfInputSetAndLengthEqualTwo_ReturnsSix()
        {
            // Given
            var input = new [] { 'a', 'b', 'c', 'd' };
            int length = 2;

            // When
            var count = CombinationGenerator.CountAll(input, length);

            // Then
            Assert.AreEqual(6, count);
        }

        /// <summary>
        /// {a, b, c, d} => {a, b}, {a, c}, {a, d}, {b, c}, {b, d}, {c, d}
        /// </summary>
        [TestMethod]
        public void CountAll_ForFixeNumberOfInputSetButWithRepetitionAndLengthEqualTwo_ReturnsSix()
        {
            // Given
            var input = new [] { 'a', 'a', 'b', 'c', 'd' };
            int length = 2;

            // When
            var count = CombinationGenerator.CountAll(input, length);

            // Then
            Assert.AreEqual(6, count);
        }

        [TestMethod]
        public void Next_IterateAllCombinations()
        {
            // Given
            var input = new[] { 'a', 'b', 'c', 'd', 'e' };
            var combination = new[] { 'a', 'b', 'c' };

            // When
            var next = CombinationGenerator.Next(input, combination);

            // Then
            Assert.IsTrue(next);
            Assert.AreEqual(combination[0], 'a');
            Assert.AreEqual(combination[1], 'b');
            Assert.AreEqual(combination[2], 'd');

            // When
            next = CombinationGenerator.Next(input, combination);

            // Then
            Assert.IsTrue(next);
            Assert.AreEqual(combination[0], 'a');
            Assert.AreEqual(combination[1], 'b');
            Assert.AreEqual(combination[2], 'e');

            // When
            next = CombinationGenerator.Next(input, combination);

            // Then
            Assert.IsTrue(next);
            Assert.AreEqual(combination[0], 'a');
            Assert.AreEqual(combination[1], 'c');
            Assert.AreEqual(combination[2], 'd');

            // When
            next = CombinationGenerator.Next(input, combination);

            // Then
            Assert.IsTrue(next);
            Assert.AreEqual(combination[0], 'a');
            Assert.AreEqual(combination[1], 'c');
            Assert.AreEqual(combination[2], 'e');

            // When
            next = CombinationGenerator.Next(input, combination);

            // Then
            Assert.IsTrue(next);
            Assert.AreEqual(combination[0], 'a');
            Assert.AreEqual(combination[1], 'd');
            Assert.AreEqual(combination[2], 'e');

            // When
            next = CombinationGenerator.Next(input, combination);

            // Then
            Assert.IsTrue(next);
            Assert.AreEqual(combination[0], 'b');
            Assert.AreEqual(combination[1], 'c');
            Assert.AreEqual(combination[2], 'd');

            // When
            next = CombinationGenerator.Next(input, combination);

            // Then
            Assert.IsTrue(next);
            Assert.AreEqual(combination[0], 'b');
            Assert.AreEqual(combination[1], 'c');
            Assert.AreEqual(combination[2], 'e');

            // When
            next = CombinationGenerator.Next(input, combination);

            // Then
            Assert.IsTrue(next);
            Assert.AreEqual(combination[0], 'b');
            Assert.AreEqual(combination[1], 'd');
            Assert.AreEqual(combination[2], 'e');

            // When
            next = CombinationGenerator.Next(input, combination);

            // Then
            Assert.IsTrue(next);
            Assert.AreEqual(combination[0], 'c');
            Assert.AreEqual(combination[1], 'd');
            Assert.AreEqual(combination[2], 'e');

            // When
            next = CombinationGenerator.Next(input, combination);

            // Then
            Assert.IsFalse(next);
        }
    }
}
