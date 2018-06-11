using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class SearchService : ISearchService
    {
        //public static BooksContext db;
        //public static BooksSQLiteContext db;
        public BooksSQLiteContext db;
        public IPopularityService _popularityService;


        public SearchService(BooksSQLiteContext context, IPopularityService _service)
        {
            db = context;
            _popularityService = _service;

        }
        public SearchResult Search(string text) {

            List<Book> AllBooks = db.Books.ToList();
            List<Book> FoundBooks= new List<Book>();
            string[] KeyWords = text.Split(' ');

            foreach (var book in AllBooks) {
                for(int i = 0; i < KeyWords.Length; i++)
                {
                    if (book.Title.Contains(KeyWords[i]) || book.AuthorName.Contains(KeyWords[i]))
                        FoundBooks.Add(book);
                }

                                           }
            
            //Author_popularityTable Table from db:
            List<Author_popularity> resultPopularAuthors = _popularityService.FoundAuthorPopularity(FoundBooks);
            
            //Book_popularityTable Table from db:
            List<Book_popularity> resultPopularBooks = _popularityService.FoundBookPopularity(FoundBooks);


            return new SearchResult(FoundBooks.ToList(), resultPopularAuthors, resultPopularBooks);
        }
    }
}
