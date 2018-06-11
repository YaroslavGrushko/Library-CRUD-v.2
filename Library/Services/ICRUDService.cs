using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
   public interface ICRUDService
    {
        SearchResult GetAllBooks();
        Book GetOne(int id);
        void AddBook(Book book);
        Book DeleteBook(int id);
        Book UpdateBook(Book book);

    }
}
