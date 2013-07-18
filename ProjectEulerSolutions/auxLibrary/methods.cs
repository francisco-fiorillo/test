using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auxLibrary
{
    public static class auxMethods
    {
        public static bool isPrime(ulong x)
        {
            for (ulong i = 2; i < x; i++)
            {
                if (x % i == 0)
                    return false;
            }
            return true;
        }

        /* Calculates the Least Common Multiple*/
        public static ulong calculateLCM(List<ulong> lstNumbers)
        {
            System.Diagnostics.Stopwatch swLCM = System.Diagnostics.Stopwatch.StartNew();            
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
            swLCM.Stop();
            System.Diagnostics.Debug.WriteLine("Elapsed time: " + swLCM.Elapsed);
            return resultLCM;
        }
    }
}
