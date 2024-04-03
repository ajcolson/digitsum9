/*
 * This program attempts to answer two questions:
 *  1) What is the digitsum d for each multiple of 9 from the expression d = 9n, where 0 < n < UserInputedNumber
 *  2) For each digitsum in the range, how many iterations of the digitsum can be calcutated until we reach a digitsum of 9
 * This program assumes the number n is an Unsigned 64-bit Integer.
 *  
 * I recommend you pipe the output from this program into a file if you want to save all the iteration data. A word of caution however, the size of the output file will tend to be be quite large if you select a large range to test with the program.
 * 
 * Also, this may not be the best looking code and may not be the most optimal either, but I really didn't want to put too much time into writing this.
 * 
 */

using System.Formats.Asn1;

namespace digitsum9
{
    internal class Program
    {
        static ulong digitsum(ulong n)
        {
            // All n less than ten are their own digitsum
            if (n < 10)
                return n;
            
            // All n greater than 9 requires calcuation
            ulong sum = 0;
            string digits = n.ToString();
            foreach (var digit in digits)
                sum += ulong.Parse(digit.ToString());
            return sum;
        }

        static void Main(string[] args)
        {
            // Default calculation lmits.
            ulong minLimit = 0;
            ulong maxLimit = 1000;

            // Because this is a computer and it has finite limits for representing whole numbers, we have to cap the max limit value.
            // Attempting to calculate any number greater than 2,049,638,230,412,172,401 (1/9 of the maximum value of an Unsigned 64-bit Integer),
            // will result in messy floating point numbers that we'd rather not deal with.
            // Hopefully the user won't be too disappointed by hard ceiling of the value
            ulong maxCalcLimitValue = ulong.MaxValue / 9;

            // If the user passes 1 argument, we will use the argument to set maxLimit
            if (args.Length == 1)
            {                
                // Let's sanity check that the value they input meets a few conditions.
                try {
                    // Check if the input can be be converted into a ulong variable (Unsigned 64-bit Integer)
                    ulong testLimit = ulong.Parse(args[0]);

                    if (testLimit > maxCalcLimitValue) {
                        maxLimit = maxCalcLimitValue;
                    } else maxLimit = testLimit;
                }
                catch { } // If any of the sanity checking causes an error, we will silently catch it and leave limit at the default
            }

            // If the user passes 2 arguments, we will use the 1st argument to set minLimit, the 2nd for maxLimit
            if (args.Length == 2)
            {
                // Let's sanity check that the value they input meets a few conditions.
                try
                {

                    // Min Limit
                    // Check if the input can be be converted into a ulong variable (Unsigned 64-bit Integer)
                    ulong testLimit = ulong.Parse(args[0]);
                    if (testLimit > maxCalcLimitValue)
                        minLimit = maxCalcLimitValue-1;
                    else minLimit = testLimit;

                    //Max limit
                    // Check if the input can be be converted into a ulong variable (Unsigned 64-bit Integer)
                    testLimit = ulong.Parse(args[1]);
                    if (testLimit < minLimit)
                    {
                        testLimit = minLimit+1;
                    }
                    if (testLimit > maxCalcLimitValue)
                        maxLimit = maxCalcLimitValue;
                    else maxLimit = testLimit;

                }
                catch { } // If any of the sanity checking causes an error, we will silently catch it and leave limit at the default
            }

            // Let's now calculate the digitsums and the iteration for all n between the user defined limits
            for (ulong n = minLimit; n < maxLimit; n++)
            {
                int iterations = 0;
                ulong initialProduct = n * 9;
                string outputTextPerIteration = initialProduct.ToString();
                ulong calcDigitSum = 0;

                //Until we get a digitsum of 9, calcuate an intermediate digitsum and then calculate its digitsum, making note of those itermediate values and the total number of iterations
                while (calcDigitSum != 9)
                {
                    // At n=0, the digitsum of 9*0 equals 0, which is not equal to 9.
                    // This means that we will loop endlessly continously trying to find the digitsum of 0.
                    // For completeness in our output values, we simply break out of the calculating the digitsum for n=0 and then continue to n=1
                    if (initialProduct == 0)
                        break;
                    
                    if (iterations == 0)
                        calcDigitSum = digitsum(initialProduct);
                    else calcDigitSum = digitsum(calcDigitSum);
                    iterations++;
                    outputTextPerIteration += " -> " + calcDigitSum.ToString();
                }

                Console.WriteLine("For n = " + n.ToString() + ", Total Iterations = " + iterations.ToString() + " :  " + outputTextPerIteration);
            }
        }
    }
}
