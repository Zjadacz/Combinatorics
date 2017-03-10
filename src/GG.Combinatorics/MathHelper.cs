using System;

namespace GG.Combinatorics
{
    public class MathHelper
    {
        /// <summary>
        /// Returns factoral of given natural number, when number is not from natural numbers domain throws exception
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
    }
}
