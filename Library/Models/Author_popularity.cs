using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Author_popularity
    {   //default constructor:
        public Author_popularity() {
                                   }
        public Author_popularity(string authorName, int popularity) {
            AuthorName = authorName;
            Popularity = popularity;
                                                                    }

        public int Id { get; set; }
        public string AuthorName { get; set; }
        public int Popularity { get; set; }

    }
}
