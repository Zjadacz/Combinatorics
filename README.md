Combinatorics
============
## Summary
This is simple .NET library for creating various permutations, combinations, partitions and other. Those are main implementation and functional features of the library:
- fast and simple
- implementation is data-independent

## Permutations

By permutation we understand different order of the elements of the list/array. For example here are all permutations of number 123:
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

### Implementation

We have implemented permutations to only contain information about possible positions in collection of data of  any type. Let's imagine that we have array of three string, we don't have to operate on those strings directly, but only on its positions:

```c#
// We are creating permutation of three elementes collection 
// (we don't really care here about collection data type - just length)
var permutation = new Permutation(3);

// Permutation was created with first possible permutation so positions collection will be equal
// permutation.Positions[0] == 0;
// permutation.Positions[1] == 1;
// permutation.Positions[2] == 2;

// Here we can iterate to next permutation (if possible, null otherwise)
var nextPermutation = permutation.Next();

// Now Permutation was iterated to next smallest possible permutation, so positions will be equal
// nextPermutation.Positions[0] == 0;
// nextPermutation.Positions[1] == 2;
// nextPermutation.Positions[2] == 1;

// At any time we can apply this permutation to any IList<T> based collection, 
// lets try to use nextPermutation for that

// String
var strings = new [] { "this", "is", "test" };
var stringsPermutation = nextPermutation.Apply(string);
// stringsPermutation == { "this", "test", "is" }

// Ints
var integers = new List<int> { 1, 2, 3 };
var integersPermutation = nextPermutation.Apply(integers);
// integersPermutation == { 1, 3, 2 }
```

## Combinations

Combination is a unique subset of K elementes from set of length N. For example here is the list of combinations of length 2, of set { a, b, c, d }:
- { a, b }
- { a, c }
- { a, d }
- { b, c }
- { b, d }
- { c, d }

So in this example by all combination we can understan collection of all possible pairs of letters from a to d (mind that combination doesn't care of positions, so pair ab is equal to pair ba).

For more information look at:
https://en.wikipedia.org/wiki/Combination

### Implementation

Like in permutations we have implemented combinations only to contain information about possible positions in collection of data of any type. Additionally our implementaiton of combinations will always order positions in ascending order like in example above) because combinations { a, b } and { b, a } are equal and represent the same combination.

Let's imagine that we have array of three string, we don't have to operate on those strings directly, but only on its positions:

```c#
// We are creating combination of length two using three elementes collection 
// (we don't really care here about collection data type - just length of data, and length of combination)
var combination = new Combination(3, 2);

// Combination was created with first possible combination so positions collection will be equal
// combination.Positions[0] == 0;
// combination.Positions[1] == 1;

// Here we can iterate to next combination (if possible, null otherwise)
var nextCombination = combination.Next();

// Now Permutation was iterated to next smallest possible permutation, so positions will be equal
// nextCombination.Positions[0] == 0;
// nextCombination.Positions[1] == 2;

// At any time we can apply this combination to any IList<T> based collection, 
// lets try to use nextPermutation for that

// String
var strings = new [] { "this", "is", "test" };
var stringsCombination = nextCombination.Apply(string);
// stringsCombination == { "this", "test" }

// Ints
var integers = new List<int> { 1, 2, 3 };
var integersCombination = nextCombination.Apply(integers);
// integersCombination == { 1, 3 }
```

## Integer Partitions

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

### Implementation

GG.Combinatorics namespace contains class IntegerPartitionGenerator, that implements method called Next. This method updates list given as a parameter to next partition (see example above). If next partition is available it return true, false otherwise.

```c#
bool IntegerPartitionGenerator.Next(List<int> input)
```

Example of usage:

```c#
var list = new List<int> { 5 };
new IntegerPartitionGenerator().Next(list);
// will update list to  { 1, 4 } and return true
```

## SetPartition

Similarly to integer partition set partition is used to create different division (subsets) of given set. For example when we try to create partitions for set {a,b,c,d}, we will end up with:
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

### Implementation

GG.Combinatorics namespace contains class SetPartitionGenerator, that implements method called Next. This method update lists of lists given as a parameter to next set partition. If next partition is available it return true, false otherwise.

```c#
var list = new List<int> { 
  new List<int> { 1, 2, 3, 4} 
};

new SetPartitionGenerator().Next(list);
// will update list to  {{1}, {2,3,4}} and return true
```
