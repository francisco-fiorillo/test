using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auxLibrary
{
    public class PrimeFactor
    {
        public ulong primeNumber { get; set; }
        public ulong multiplier { get; set; }

        public PrimeFactor(ulong primeNumber, ulong multiplier)
        {
            this.primeNumber = primeNumber;
            this.multiplier = multiplier;
        }        
    }

    public class NumberWithName
    {
        public int number { get; set; }
        public string name { get; set; }

        public NumberWithName(int number, string name)
        {
            this.number = number;
            this.name = name;
        }
    }
}
