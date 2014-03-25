Combinatorics
============
##Summary
This is simple .NET library for creating various permutations, combinations, and other. Those are main implementation and functional features of the library:
- implemented using BDD
- implemented to use generic types
- use extension methods to IList
- use custom elements comparisson method

##Permutations

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
bool Permutaiton.Next<T>(IList<T> input, IComparer<T> comparer = null)
bool Permutation.Next(string text, IComparer<char> comparer = null)
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

##Integer Partitions

Partition is a way of writing number as a sum of positive integers. Two sums that differ only in the order of their summands are consider the same parition. For example here is a list of all subsequent partitions of number 6:
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

For more information look at:
http://en.wikipedia.org/wiki/Partition_(number_theory)

###Implementation

GG.Combinatorics namespace contains class IntegerPartition, that implements method called Next. This method updates list given as a parameter to next partition (see example above). If next partition is available it return true, false otherwise.

```c#
bool IntegerPartition.Next(List<int> input)
```

Example of usage:

```c#
var list = new List<int> { 5 };
new IntegerPartition().Next(list);
// will update list to  { 1, 4 } and return true
```

##SetPartition

Simillary to integer partition set partition is used to create different division (subsets) of given set. For example when we try to create partitions for set {a,b,c,d}, we will end up with:
- {a}, {b,c,d}
- {b}, {a,c,d}
- {c}, {a,b,d}
- {d}, {a,b,c}
- {a,b}, {c,d}
- {a,c}, {b,d}
- {a,d}, {b,c}
- {a}, {b}, {c,d}
- {a}, {c}, {b,d}
- {a}, {d}, {b,c}
- {b}, {c}, {a,d}
- {b}, {d}, {a,c}
- {c}, {d}, {a,b}
- {a}, {b}, {c}, {d}

###Implementation

GG.Combinatorics namespace contains class SetPartition, that implements method called Next. This method update lists of lists given as a parameter to next set partition. If next partition is available it return true, false otherwise.

```c#
var list = new List<int> { 
  new List<int> { 1, 2, 3, 4} 
};
new SetPartition().Next(list);
// will update list to  {{1}, {2,3,4}} and return true
```
