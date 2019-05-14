using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookBase.ViewModels 
{
    public class BookSearchViewModel
    {
        public SearchResult SearchResult { get; set; }
        public int FibonacciQuestion { get; set; }
        public bool FibonacciAnswer { get; set; }
        public int EasterQuestion { get; set; }
        public string EasterAnswer { get; set; }

        public static BookSearchViewModel  MockData()
        {
            var model = new BookSearchViewModel()
            {
                SearchResult = new SearchResult()
                {
                    BookResults = new List<SearchResultBook>()
                    {
                        new SearchResultBook()
                        {

                            Score = 100,
                            Book = new Book(){
                                Id = new BookId(){StringId = "bk101"},
                            Title = "XML Developer's Guide",
                            Genre = "Computer",
                            Author = "Gambardella, Matthew",
                            Price = (decimal)44.95,
                            PublishDate = DateTime.Now,
                            Description = "A former architect battles corporate zombies, an evil sorceress, and her own childhood to become queen of the world."
                            }
                        },
                         new SearchResultBook()
                        {

                            Score = 100,
                            Book = new Book(){
                                Id = new BookId(){StringId = "bk101"},
                            Title = "XML Developer's Guide",
                            Genre = "Computer",
                            Author = "Gambardella, Matthew",
                            Price = (decimal)44.95,
                            PublishDate = DateTime.Now,
                            Description = "A former architect battles corporate zombies, an evil sorceress, and her own childhood to become queen of the world."
                            }
                        },
                            new SearchResultBook()
                        {

                            Score = 100,
                            Book = new Book(){
                                Id = new BookId(){StringId = "bk101"},
                            Title = "XML Developer's Guide",
                            Genre = "Computer",
                            Author = "Gambardella, Matthew",
                            Price = (decimal)44.95,
                            PublishDate = DateTime.Now,
                            Description = "A former architect battles corporate zombies, an evil sorceress, and her own childhood to become queen of the world."
                            }
                        }
                    }
                }
            };

            return model; 
        }
    }
}