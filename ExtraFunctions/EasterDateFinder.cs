using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraFunctions
{
    class EasterDateFinder
    {
        public static DateTime FindEasterDate(int year)
        {
            if (year < 1583 && year > 2599)
            {
                return new DateTime(0,1,1);

            }

            var MandN = GetMandN(year);
            var M = MandN.M;
            var N = MandN.N;

            //1.Dividera årtalet med 19; kalla resten för a:2001 / 19 = 106, rest 6 a = 6
            var a = year % 19;

            //2.Dividera årtalet med 4; kalla resten för b: 2001 / 4 = 500, rest 1 b = 1
            var b = year % 4;

            //3.Dividera årtalet med 7; kalla resten för c: 2001 / 7 = 285, rest 6 c = 6
            var c = year % 7;

            //4.Dividera kvantiteten 19a + M med 30; kalla resten för d: (M fås ur tabellen) (114 + 24) / 30 = 138 / 30 = 4, rest 18 d = 18
            var d = ((19 * a) +  M) % 30;

            //5.Dividera kvantiteten 2b + 4c + 6d + N med 7; kalla resten för e: (N fås ur tabellen) (2 + 24 + 108 + 5) / 7 = 139 / 7 = 19, rest 6 e = 6
            var e = ((2 * b) + (4 * c) + (6 * d) + N) % 7;

            //6.Bilda kvantiteten 22 + d + e.Om talet är högst 31, får vi direkt påskdagens datum i mars.I annat fall dras 31 ifrån resultatet och man får påskdagens datum i april.
            
            var day = 0;
            var month = 0;
            var kvant = 22 + d + e;
            if (kvant <= 31)
            {
                day = kvant;
                month = 3;
            }
            else
            {
                day = kvant - 31;
                month = 4;
            }

            DateTime easterDate = new DateTime(year,month, day );
            return easterDate;
        }

        private static MandN GetMandN(int year)
        {
            int M=0;
            int N=0;

            if (year >= 1583 && year <= 1699) { M = 22; N = 2; }
            if (year >= 1700 && year <= 1799) { M = 23; N = 3; }
            if (year >= 1800 && year <= 1899) { M = 23; N = 4; }
            if (year >= 1900 && year <= 1999) { M = 24; N = 5; }
            if (year >= 2000 && year <= 2099) { M = 24; N = 5; }
            if (year >= 2100 && year <= 2199) { M = 24; N = 6; }
            if (year >= 2200 && year <= 2299) { M = 25; N = 0; }
            if (year >= 2300 && year <= 2399) { M = 26; N = 1; }
            if (year >= 2400 && year <= 2499) { M = 25; N = 1; }
            if (year >= 2500 && year <= 2599) { M = 26; N = 2; }

            return new MandN() { M = M, N = N };
        }


        class MandN
        {
            public int M { get; set; }
            public int N { get; set; }

        }
    }
}

