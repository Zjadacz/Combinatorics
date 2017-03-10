using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.Combinatorics.Tests
{
    public static class Any
    {
        public static int Int()
        {
            var r = new Random();
            return r.Next(int.MinValue, int.MaxValue);
        }

        public static int IntLessThan(int maxValue)
        {
            var r = new Random();
            return r.Next(int.MinValue, maxValue);
        }
    }
}
