using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class PopularityService : IPopularityService
    {
        public BooksSQLiteContext db;
        public PopularityService(BooksSQLiteContext context)
        {
            db = context;
        }
        public List<Author_popularity> FoundAuthorPopularity(List<Book> foundBooks) {
            //Author Popularity:
            //-----------------------------------
            //get authors of selected works:
            List<String> FoundAuthors = foundBooks.ToList().Select(book => book.AuthorName).ToList();
            //foreach author:
            foreach (var author in FoundAuthors)
            {
                //Author_popularityTable Table from db:
                List<Author_popularity> popularAuthors = db.Author_popularityTable.ToList();
                Boolean authorExists = false;
                foreach (var TableAuthor in popularAuthors)
                {
                    if (TableAuthor.AuthorName == author)
                    {
                        //update author:
                        Author_popularity alteredAuthor = (from x in db.Author_popularityTable
                                                           where x.AuthorName == author
                                                           select x).First();
                        alteredAuthor.Popularity += 1;
                        db.SaveChanges();
                        //Set the flag if the author exists
                        authorExists = true;
                    }
                }
                //if the author isn't exists 
                if (!authorExists)
                {
                    //create author:
                    Author_popularity createdAuthor = new Author_popularity(author, 1);
                    db.Author_popularityTable.Add(createdAuthor);
                    db.SaveChanges();
                }
                //if db.Author_popularityTable is empty:
                if (db.Author_popularityTable.ToList().Count == 0)
                {
                    //create author:
                    Author_popularity createdAuthor = new Author_popularity(author, 1);
                    db.Author_popularityTable.Add(createdAuthor);
                    db.SaveChanges();
                }

            }
            //-----------------------------------
            //Author_popularityTable Table from db:
            List<Author_popularity> resultPopularAuthors = db.Author_popularityTable.ToList();
            return resultPopularAuthors;
        }
        public List<Book_popularity> FoundBookPopularity(List<Book> foundBooks)
        {

            //Book Popularity:
            //-----------------------------------
            //get book's names of selected books:
            List<String> FoundTitles = foundBooks.ToList().Select(book => book.Title).ToList();
            //foreach book:
            foreach (var title in FoundTitles)
            {
                //Book_popularityTable Table from db:
                List<Book_popularity> popularBooks = db.Book_popularityTable.ToList();
                Boolean bookExists = false;
                foreach (var TableBook in popularBooks)
                {
                    if (TableBook.BookName == title)
                    {
                        //update book:
                        Book_popularity alteredBook = (from x in db.Book_popularityTable
                                                         where x.BookName == title
                                                         select x).First();
                        alteredBook.Popularity += 1;
                        db.SaveChanges();
                        //Set the flag if the book exists
                        bookExists = true;
                    }
                }
                //if the book isn't exists 
                if (!bookExists)
                {
                    //create book:
                    Book_popularity createdBook = new Book_popularity(title, 1);
                    db.Book_popularityTable.Add(createdBook);
                    db.SaveChanges();
                }
                //if db.Book_popularityTable is empty:
                if (db.Author_popularityTable.ToList().Count == 0)
                {
                    //create book:
                    Book_popularity createdBook = new Book_popularity(title, 1);
                    db.Book_popularityTable.Add(createdBook);
                    db.SaveChanges();
                }

            }
            //-----------------------------------
            //Book_popularityTable Table from db:
            List<Book_popularity> resultPopularBooks = db.Book_popularityTable.ToList();
            return resultPopularBooks;
        }
    }
}
