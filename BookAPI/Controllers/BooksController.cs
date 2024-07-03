using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BooksController:ControllerBase
    {

        private readonly Book[] _books =  [ 
        
         new() { Id=1,Author="Author one", Title="Book One" },
         new() { Id=1,Author="Author two", Title="Book two" },
         new() { Id=1,Author="Author three", Title="Book three" },
         new() { Id=1,Author="Author four", Title="Book four" }
        ];


        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(this._books);

        }

    }
}
