using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Models;
using Newtonsoft.Json;

namespace DataLayer
{
    class BookRepository : IBookRepository
    {
        IXMLReader xmlReader;

        public BookRepository()
        {
            xmlReader = DataAccess._dependecyContainer.GetInstance<IXMLReader>();

        }

        public List<Book> GetBooks(int maxQuantity)
        {
            var doc = xmlReader.GetXMLDocument();
            var rawBooks = XMLToDynamic(doc);
            var books = DynamicToBooks(rawBooks);
            return books;
        }

        private dynamic XMLToDynamic(XDocument xml)
        {
            string jsonText = JsonConvert.SerializeXNode(xml);
            dynamic dyn = JsonConvert.DeserializeObject<ExpandoObject>(jsonText);
            var catalog = dyn.catalog;
            return catalog;
        }

        private List<Book> DynamicToBooks(dynamic rawBooks)
        {
            var books = new List<Book>();

            foreach (dynamic rawBook in rawBooks.book)
            {
                var book = new Book()
                {
                    Id = new BookId() { StringId = ((IDictionary<string, object>)rawBook)["@id"].ToString() },
                    Author = rawBook.author,
                    Title = rawBook.title,
                    Price = Decimal.Parse(rawBook.price, CultureInfo.InvariantCulture),
                    Genre = rawBook.genre,
                    PublishDate = DateTime.ParseExact(rawBook.publish_date, "yyyy-MM-dd", null),
                    Description = rawBook.description
                };
                books.Add(book);
            }
            return books;
        }
    }
}
