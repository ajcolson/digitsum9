# digitsum9
This program attempts to answer two questions:
  1) What is the digitsum d for each multiple of 9 from the expression d = 9n, where 0 < n < UserInputedNumber
  2) For each digitsum in the range, how many iterations of the digitsum can be calcutated until we reach a digitsum of 9   
This program assumes the number n is an Unsigned 64-bit Integer.

I recommend you pipe the output from this program into a file if you want to save all the iteration data. A word of caution however, the size of the output file will tend to be be quite large if you select a large range to test with the program.

Also, this may not be the best looking code and may not be the most optimal either, but I really didn't want to put too much time into writing this.

## Example Output
```
For n = 1, Total Iterations = 1 :  9 -> 9
For n = 2, Total Iterations = 1 :  18 -> 9
For n = 3, Total Iterations = 1 :  27 -> 9
For n = 4, Total Iterations = 1 :  36 -> 9
For n = 5, Total Iterations = 1 :  45 -> 9
For n = 6, Total Iterations = 1 :  54 -> 9
For n = 7, Total Iterations = 1 :  63 -> 9
For n = 8, Total Iterations = 1 :  72 -> 9
For n = 9, Total Iterations = 1 :  81 -> 9
For n = 10, Total Iterations = 1 :  90 -> 9
For n = 11, Total Iterations = 2 :  99 -> 18 -> 9
...
For n = 991, Total Iterations = 2 :  8919 -> 27 -> 9
For n = 992, Total Iterations = 2 :  8928 -> 27 -> 9
For n = 993, Total Iterations = 2 :  8937 -> 27 -> 9
For n = 994, Total Iterations = 2 :  8946 -> 27 -> 9
For n = 995, Total Iterations = 2 :  8955 -> 27 -> 9
For n = 996, Total Iterations = 2 :  8964 -> 27 -> 9
For n = 997, Total Iterations = 2 :  8973 -> 27 -> 9
For n = 998, Total Iterations = 2 :  8982 -> 27 -> 9
For n = 999, Total Iterations = 2 :  8991 -> 27 -> 9
For n = 1000, Total Iterations = 1 :  9000 -> 9
```
