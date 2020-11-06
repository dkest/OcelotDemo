using BookApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api")]
    [ApiExplorerSettings(GroupName = "Book")]
    public class BookController : ControllerBase
    {
        [HttpGet, Route("Book")]
        public List<Book> GetAll()
        {
            return BookDataRepository.GetAll();
        }

        [HttpGet,Route("Book/{number}")]
        public Book Get(string number)
        {
            return BookDataRepository.GetBookingByNumber(number);
        }
    }
}
