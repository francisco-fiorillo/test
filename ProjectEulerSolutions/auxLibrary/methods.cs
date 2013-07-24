using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auxLibrary
{
    public static class auxMethods
    {
        /// <summary>
        /// Determines if a given number is prime.
        /// </summary>
        /// <param name="num">number to test</param>
        /// <returns>True if prime. False if not prime</returns>
        public static bool isPrime(ulong num)
        {
            //Even numbers are not prime
            if (num > 5 && (num % 2 == 0 || num % 3 == 0 || num % 5 == 0))
                return false;


            for (ulong i = 2; i < num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        public static bool isPrime(int num)
        {
            //Even numbers are not prime
            if (num > 5 && (num % 2 == 0 || num % 3 == 0 || num % 5 == 0))
                return false;


            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Finds the first larger prime than the given number
        /// </summary>
        /// <param name="num">number to find the first larger prime from</param>
        /// <returns></returns>
        public static int findNextPrime(int num)
        {
            num += 1;
            while (!isPrime(num))
            {
                num++;
            }

            return num;
        }

        /// <summary>
        /// Calculates the Least Common Multiple
        /// </summary>
        /// <param name="lstNumbers">List of numbers from which the LCM will be calculated</param>
        /// <returns>the LCM of the number list</returns>
        public static ulong calculateLCM(List<ulong> lstNumbers)
        {
            //System.Diagnostics.Stopwatch swLCM = System.Diagnostics.Stopwatch.StartNew();            
            ulong resultLCM = 1;

            //object that stores a list of prime factors
            List<primeFactor> lstPrimes = new List<primeFactor>();

            foreach (ulong num in lstNumbers)
            {
                ulong remainer = num;
                ulong currentPrimeCheck = 1;

                while (remainer > 1)
                {
                    currentPrimeCheck++;

                    if (isPrime(currentPrimeCheck))
                    {
                        ulong primeMultiplier = 0;
                        while (remainer % currentPrimeCheck == 0)
                        {
                            remainer = remainer / currentPrimeCheck;
                            primeMultiplier++;
                        }

                        //only add the prime number to the prime factors list if it doesnt already exist or if the multiplier is smaller than the current (and greater than 0).
                        if (!lstPrimes.Exists(x => x.primeNumber == currentPrimeCheck) && primeMultiplier > 0)
                        {
                            lstPrimes.Add(new primeFactor(currentPrimeCheck, primeMultiplier));
                        }

                        else if (lstPrimes.Exists(x => x.primeNumber == currentPrimeCheck && x.multiplier < primeMultiplier))
                        {
                            primeFactor primeFactorItem = lstPrimes.FirstOrDefault(x => x.primeNumber == currentPrimeCheck);

                            //I only need to update to the new greater multiplier.
                            primeFactorItem.multiplier = primeMultiplier;
                        }
                    }
                }
            }

            lstPrimes.ForEach(x => resultLCM *= (ulong)Math.Pow((double)x.primeNumber, (double)x.multiplier));
            //swLCM.Stop();
            //System.Diagnostics.Debug.WriteLine("Elapsed time: " + swLCM.Elapsed);
            return resultLCM;
        }

        /// <summary>
        /// Calculates the summation of a given function.
        /// </summary>
        /// <param name="initial">intial number for the summation</param>
        /// <param name="final">limit number for the summation</param>
        /// <param name="sumFunction">function to do the summation</param>
        /// <returns></returns>
        public static ulong summation(ulong initial, ulong final, Func<ulong, ulong> sumFunction)
        {
            if (initial > final)
                throw new Exception("The initial value must be smaller or equal to the final value");

            ulong result = 0;

            for (ulong i = initial; i <= final; i++)
            {
                result += sumFunction(i);
            }
            return result;
        }

        public static int summation(int initial, int final, Func<int, int> sumFunction)
        {
            if (initial > final)
                throw new Exception("The initial value must be smaller or equal to the final value");

            int result = 0;

            for (int i = initial; i <= final; i++)
            {
                result += sumFunction(i);
            }
            return result;
        }

        /// <summary>
        /// Special case of summation for "summation from 1 to final of x"
        /// </summary>
        /// <param name="final">Limit value to summate</param>
        /// <returns></returns>
        public static int summation(int final)
        {
            if (final < 1)
                throw new Exception("The final value must be bigger than 0");

            //Summation from 1 to "x"
            int result = final*(final+1)/2;
            return result;
        }

        /// <summary>
        /// Returns the power of a number
        /// </summary>
        /// <param name="baseNum">base number</param>
        /// <param name="exp">exponent</param>
        /// <returns></returns>
        public static uint power(uint baseNum, uint exp)
        {                        
            if (exp == 0)
                return 1;

            uint result = baseNum;
            
            for (uint i = 0; i < exp; i++)
            {
                result *= result;
            }

            return result;
        }
    }
}
