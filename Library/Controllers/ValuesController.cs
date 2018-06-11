using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Services;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public ICRUDService _crudService;
        ////////////////////constructor->///////////////       
        public ValuesController(ICRUDService serv)
        {

            _crudService = serv;

        }

        ////////////////////<-constructor///////////////

        // GET api/values
        [HttpGet]
        public SearchResult Get()
        {
            
            return _crudService.GetAllBooks();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_crudService.GetOne(id) == null)
                return NotFound();

            return new ObjectResult(_crudService.GetOne(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            _crudService.AddBook(book);
                            
            return Ok(book);
        }


        [HttpPut]
        public IActionResult Put([FromBody]Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            if (_crudService.UpdateBook(book) == null)
                return NotFound();

            return Ok(book);
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {                        
            return Ok(_crudService.DeleteBook(id));
        }
    }
}
