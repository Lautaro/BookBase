using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Librarian;
using Models;
namespace BookBase.Services.BookSearch
{
    public class BookSearchService
    {
        public static SearchResult SearchForBooks(string searchString)
        {
            var searchResult = new Librarian.Librarian().GetBooksBySearchstring(searchString);

            return searchResult;
        }
    }
}