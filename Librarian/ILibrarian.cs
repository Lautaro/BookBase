using Models;

namespace Librarian
{
    public interface ILibrarian
    {
        SearchResult GetBooksBySearchstring(string searchString);
    }
}