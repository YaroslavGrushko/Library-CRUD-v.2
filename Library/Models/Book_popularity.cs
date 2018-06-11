using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book_popularity
    {
        //default constructor:
        public Book_popularity()
        {
        }
        public Book_popularity(string bookName, int popularity)
        {
            BookName = bookName;
            Popularity = popularity;
        }
    public int Id { get; set; }
    public string BookName { get; set; }
    public int Popularity { get; set; }   

    }
}
