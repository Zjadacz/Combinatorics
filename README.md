Combinatorics
============
##Summary
This is simple .NET library for creating various permutations, combinations, and other. Those are main implementation and functional features of the library:
- implemented using BDD
- implemented to use generic types
- use extension methods to IList
- use custom elements comparisson method

##Permutation

By permutation we understant different order of the elements of the list/array. For example here are all permutations of number 123:
- 132
- 213
- 231
- 312
- 321

Or for string "abc" it will be:
- "acb"
- "bac"
- "bca"
- "cab"
- "cba"

For more information look at:
http://en.wikipedia.org/wiki/Permutation

###Implementation

GG.Combinatorics namespace contains class called Permutation, that implements one method called Next. The method by default will return next "greather" permutation (see example above), however it can be overloaded to support custom comparer:

```c#
Permutaiton.Next<T>(IList<T> input, IComparer<T> comparer = null)
Permutation.Next(string text, IComparer<char> comparer = null)
```

When we want to create permutations in reversed order, the code should look like this:

```c#

public class ReversedOrderComparer: IComparer<int>
{
  public int Compare(int x, int y)
  {
      return y.CompareTo(x);
  }
}

new Permutation().Next({ 9, 8, 7 }, new ReversedOrderComparer());
```

##Partition

Partition represents decomposition of any positive integer to the sum of smaller integers. For example here is a list of all partitions of number 6:
- 1,5
- 2,4
- 1,1,4
- 3,3
- 1,2,3
- 1,1,1,3
- 2,2,2
- 1,1,2,2
- 1,1,1,1,2
- 1,1,1,1,1,1
