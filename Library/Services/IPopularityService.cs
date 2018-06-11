using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
   public interface IPopularityService
    {
        List<Author_popularity> FoundAuthorPopularity(List<Book> foundBooks);
        List<Book_popularity> FoundBookPopularity(List<Book> foundBooks);

    }
}
