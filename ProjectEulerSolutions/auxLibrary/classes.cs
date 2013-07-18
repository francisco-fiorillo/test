using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auxLibrary
{
    public class primeFactor
    {
        public primeFactor(ulong primeNumber, ulong multiplier)
        {
            this.primeNumber = primeNumber;
            this.multiplier = multiplier;
        }

        public ulong primeNumber { get; set; }
        public ulong multiplier { get; set; }
    }
}
