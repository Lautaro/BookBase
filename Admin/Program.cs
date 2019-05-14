using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Book search");
                Console.WriteLine("2. Fibonacci test");
                Console.WriteLine("3. Calculate easter date");
                var input = Console.ReadKey();

                switch (input.KeyChar)
                {
                    case '1':
                        BookSearchMenu();
                        break;
                    case '2':
                        FibonacciTestMenu();
                        break;
                    case '3':
                        EasterDaySearchMenu();
                        break;
                    default:
                        break;
                }
            }
        }

        static void BookSearchMenu()
        {
            Console.Clear();

            Console.WriteLine("Input search string or just enter for all books...");
            var search = Console.ReadLine();
            var searchResult = new Librarian.Librarian().GetBooksBySearchstring(search);

            foreach (var bookResult in searchResult.BookResults)
            {
                var book = bookResult.Book;
                Console.WriteLine($"({bookResult.Score})Title: {book.Title} - {book.Id.StringId} - ${book.Price}");
                Console.WriteLine($"Genre:({book.Genre})");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine("");
            }
            Console.ReadKey();
        }

        static void FibonacciTestMenu()
        {
            Console.Clear();

            Console.WriteLine("Input a nr...");
            var input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                var isFibonacci = ExtraFunctions.API.IsFibonacci(number);
                string result = isFibonacci ? "is a Fibonaccci number" : "is NOT a Fibonaccci number";
                Console.WriteLine($"The number {number} " + result);
                            }
            else
            {
                Console.WriteLine($"Thats not a nr...");
            }

            Console.ReadKey();
        }

        static void EasterDaySearchMenu()
        {
            Console.Clear();

            Console.WriteLine("Input a year...");
            var input = Console.ReadLine();

            if (int.TryParse(input, out int year))
            {
                var date = ExtraFunctions.API.EasterDateSearch(year);
                Console.WriteLine($"Year {year} easter falls on {date.ToString("MMM")} the {date.Day.ToString()} ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Not a valid year ");
                Console.ReadKey();
            }
        }
    }
}
