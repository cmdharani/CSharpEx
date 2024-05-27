using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BooksController:ControllerBase
    {

        private Book[] _books = new Book[] { 
        
         new Book{ Id=1,Author="Author one", Title="Book One" },
         new Book{ Id=1,Author="Author two", Title="Book two" },
         new Book{ Id=1,Author="Author three", Title="Book three" },
         new Book{ Id=1,Author="Author four", Title="Book four" }
        };


        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(this._books);

        }

    }
}
