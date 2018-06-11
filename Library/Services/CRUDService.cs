using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Services
{
    public class CRUDService : ICRUDService
    {
        
        public BooksSQLiteContext db;
        
        
        public CRUDService(BooksSQLiteContext context)
        {
            db = context;
        }
        public SearchResult GetAllBooks()
        {
            //Author_popularityTable Table from db:
            List<Author_popularity> resultPopularAuthors = db.Author_popularityTable.ToList();
            //Book_popularityTable Table from db:
            List<Book_popularity> resultPopularBooks = db.Book_popularityTable.ToList();
            return new SearchResult(db.Books.ToList(), resultPopularAuthors, resultPopularBooks);
        }

        public Book GetOne(int id)
        {
            Book book = db.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return null;
            return book;
        }

        public void AddBook(Book book)
        {
            //book.Author.Books.Add();
            db.Books.Add(book);
            db.SaveChanges();
            
        }

        public Book UpdateBook(Book book)
        {
            if (!db.Books.Any(x => x.Id == book.Id))
            {
                return null;
            }

            db.Update(book);
            db.SaveChanges();
            return book;
        }
        public Book DeleteBook(int id)
        {

            Book book =db.Books.FirstOrDefault(x => x.Id == id);

                if (book == null)
                {
                    return null;
                }

            db.Books.Remove(book);
            db.SaveChanges();
            
            return book;
            

        }

    }
}
