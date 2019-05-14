using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IBookRepository
    {
        List<Book> GetBooks(int maxQuantity);
    }
}
