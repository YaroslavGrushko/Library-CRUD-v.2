using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Services;

namespace Library.Controllers
{
    [Produces("application/json")]
    [Route("api/Search")]
    public class SearchController : Controller
    {

        ////////////////////constructor->///////////////
        
        public ISearchService _searchService;
        public SearchController(ISearchService serv)
        {
            _searchService = serv;
        }
        ////////////////////<-constructor///////////////      

        //Post the text to search for books:
        // POST: api/Search
        [HttpPost]
        public IActionResult Post([FromBody]Text text)
        {
            //Get all the books matching the search:
            SearchResult searchResult = _searchService.Search(text.text);
            //Validation:
            if (searchResult == null) return BadRequest();

            return new ObjectResult(searchResult);
        }

       
    }
}
