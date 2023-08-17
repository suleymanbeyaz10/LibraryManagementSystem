using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedBooksController : ControllerBase
    {
        IBorrowedBookService _borrowedBooksService;

        public BorrowedBooksController(IBorrowedBookService borrowedBooksService)
        {
            _borrowedBooksService = borrowedBooksService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _borrowedBooksService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add(BookCopy bookCopy)
        {
            var result = _borrowedBooksService.Add(bookCopy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]

        public IActionResult Delete(BookCopy bookCopy)
        {
            var result = _borrowedBooksService.Delete(bookCopy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]

        public IActionResult Update(BookCopy bookCopy)
        {
            var result = _borrowedBooksService.Update(bookCopy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
