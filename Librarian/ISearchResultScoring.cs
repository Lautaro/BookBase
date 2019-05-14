using Models;
using System.Collections.Generic;

namespace Librarian
{
    internal interface ISearchResultScoring
    {
        List<SearchResultBook> ScoreBooks(List<Book> books, string searchString);
    }
}