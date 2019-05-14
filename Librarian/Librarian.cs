using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian
{
    public class Librarian : ILibrarian
    {
        public SearchResult GetBooksBySearchstring(string searchString)
        {
            // Get data repository through static method returning interface with unspecified implementation 
            // To easily 
            var books = DataLayer.DataAccess.GetRepository().GetBooks(100);

            var bookResults = new SearchResultScoring().ScoreBooks(books, searchString);  

            var result = new SearchResult()
            {
                SearchString = searchString,
                BookResults = bookResults
            };

            return result;
        }

    }
}
