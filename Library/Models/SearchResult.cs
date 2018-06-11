using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class SearchResult
    {
        public SearchResult(List<Book> foundBooks, List<Author_popularity> resultPopularAuthors, List<Book_popularity> resultPopularBooks) {
            this.foundBooks = foundBooks;
            this.resultPopularAuthors = resultPopularAuthors;
            this.resultPopularBooks = resultPopularBooks;

        }

        public List<Book> foundBooks { get; set; }
        public List<Author_popularity> resultPopularAuthors { get; set; }
        public List<Book_popularity> resultPopularBooks { get; set; }

    }
}
