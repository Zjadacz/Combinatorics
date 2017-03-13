using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GG.Combinatorics.Tests
{
    [TestClass]
    public class MathHelperTests
    {
        [TestMethod]
        public void FactorialFromZeroReturnsOne()
        {
            // Given
            var argument = 0;

            // When
            var result = MathHelper.Factorial(argument);

            // Then
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void FactorialFromOneReturnsOne()
        {
            // Given
            var argument = 1;

            // When
            var result = MathHelper.Factorial(argument);

            // Then
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void FactorialFromSixReturns720()
        {
            // Given
            var argument = 6;

            // When
            var result = MathHelper.Factorial(argument);

            // Then
            Assert.AreEqual(result, 720);
        }

        [TestMethod]
        public void BinomialCoefficientFromZeroLengthReturnsOne()
        {
            // Given
            var length = 0;

            // When
            var result = MathHelper.BinomialCoefficient(10, length);

            // Then
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void BinomialCoefficientFromNOneReturnsOne()
        {
            // Given
            var argument = 1;

            // When
            var result = MathHelper.BinomialCoefficient(argument, 1);

            // Then
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void BinomialCoefficientFromEqualParametersReturnsOne()
        {
            // Given
            var argument = 10;

            // When
            var result = MathHelper.BinomialCoefficient(argument, argument);

            // Then
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void BinomialCoefficientFromSixAndThreeReturns20()
        {
            // Given
            var n = 6;
            var k = 3;

            // When
            var result = MathHelper.BinomialCoefficient(n, k);

            // Then
            Assert.AreEqual(result, 20);
        }
    }
}
