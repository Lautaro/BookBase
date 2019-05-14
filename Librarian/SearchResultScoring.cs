using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian
{
    class SearchResultScoring : ISearchResultScoring
    {
        public List<SearchResultBook> ScoreBooks(List<Book> books, string searchString)
        {
            var result =
             (from b in books
              let score = Score(b, searchString)
              where score > 0
              orderby score descending
              select new SearchResultBook()
              {
                  Book = b,
                  Score = score
              }).Take(10).ToList();

            return result;
        }

        private int Score(Book b, string searchString)
        {
            var score = 0;

            score += ScoreBookId(b.Id, searchString);
            score += ScoreMultiWordString(b.Author, searchString, 30, 7);
            score += ScoreMultiWordString(b.Title, searchString, 100, 5);
            score += ScoreString(b.Genre, searchString, 7, 4);
            score += ScoreMultiWordString(b.Description, searchString, 100, 3);
            score += ScoreDate(b.PublishDate, searchString, 10);

            return score;
        }

        private int ScoreDate(DateTime publishDate, string searchString, int scoreIfPerfectMatch)
        {
            if (DateTime.TryParse(searchString, out DateTime parsedDate))
            {
                if (publishDate == parsedDate)
                {
                    return scoreIfPerfectMatch;
                }
            }

            return 0;
        }

        private int ScoreString(string bookInfo, string searchString, int scoreIfPerfectMatch, int scoreIfUnperfectMatch)
        {
            bookInfo = bookInfo.ToLower().Trim();
            searchString = searchString.ToLower().Trim();


            if (bookInfo == searchString)
            {
                return scoreIfPerfectMatch;
            }

            if (bookInfo.Contains(searchString) || searchString.Contains(bookInfo))
            {
                return scoreIfUnperfectMatch;
            }

            return 0;
        }

        private int ScoreMultiWordString(string bookInfoString, string searchStringInput, int scoreIfPerfectMatch, int scoreIfMatch)
        {
            if (bookInfoString.ToLower().Trim() == searchStringInput.ToLower().Trim())
            {
                return scoreIfPerfectMatch;
            }

            var score = 0;
            var delimiters = new char[] { ' ', ',', '-', '.' };
            var words = bookInfoString.ToLower().Split(delimiters).Select(s => s.Trim());
            var searchStrings = searchStringInput.ToLower().Split(delimiters).Select(s => s.Trim());

            foreach (var searchString in searchStrings)
            {
                if (words.Contains(searchString))
                {
                    score += scoreIfMatch;
                }
            }

            return score;
        }

        private int ScoreBookId(BookId id, string searchString)
        {
            var idString = id.StringId.ToLower();
            searchString = searchString.ToLower();

            if (idString == searchString)
            {
                return 100;
            }

            if (idString.Contains(searchString))
            {
                return 10;
            }

            if (searchString.Contains(idString))
            {
                return 50;
            }

            return 0;
        }
    }
}
