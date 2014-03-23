Permutations
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

###NextPermutation Method

By default next permutation method will return next "greather" permutation, however it will be overloaded to support custom comparer.
