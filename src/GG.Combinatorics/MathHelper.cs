using System;

namespace GG.Combinatorics
{
    public class MathHelper
    {
        /// <summary>
        /// Returns Factoral of given natural number, when number is not from natural numbers domain throws exception
        /// </summary>
        public static long Factorial(int n)
        {
            if(n < 0)
                throw new ArgumentException("Fractoral can only operate of natural numbers domain.");

            if(n == 0 || n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        /// <summary>
        /// Returns Binomial Coefficient for given natural number n and given length k, 
        /// when numbers do not solve ineqasion n ≥ k ≥ 0 argument exception is thrown.
        /// </summary>
        public static long BinomialCoefficient(int n, int k)
        {
            if (k < 0 || n < k)
                throw new ArgumentException("BinomialCoefficient arguments must solve inequasion n ≥ k ≥ 0.");

            if (n == 1 || k == 0 || n == k)
            {
                return 1;
            }

            return BinomialCoefficient(n - 1, k - 1) + BinomialCoefficient(n - 1, k);
        }
    }
}
