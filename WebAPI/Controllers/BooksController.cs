using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("getbookdetailsbyid")]
        public ActionResult GetBookDetailsById(int bookId)
        {
            var result = _bookService.GetBookDetails(bookId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
