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
    }
}
