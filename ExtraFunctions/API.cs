using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraFunctions
{
    public class API
    {
        public static bool IsFibonacci(int number)
        {
            double fi = (1 + Math.Sqrt(5)) / 2.0; //Golden ratio
            int n = (int)Math.Floor(Math.Log(number * Math.Sqrt(5) + 0.5, fi)); //Find's the index (n) of the given number in the fibonacci sequence

            int actualFibonacciNumber = (int)Math.Floor(Math.Pow(fi, n) / Math.Sqrt(5) + 0.5); //Finds the actual number corresponding to given index (n)

            return actualFibonacciNumber == number;
        }

        public static DateTime EasterDateSearch(int year)
        {
            return ExtraFunctions.EasterDateFinder.FindEasterDate(year);
        }

        public static void Main(string[] args)
        { }

    }
}
