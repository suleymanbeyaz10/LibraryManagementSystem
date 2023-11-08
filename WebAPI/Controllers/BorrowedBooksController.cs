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

        public IActionResult Add(BorrowedBook borrowedBook)
        {
            var result = _borrowedBooksService.Add(borrowedBook);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]

        public IActionResult Delete(BorrowedBook borrowedBook)
        {
            var result = _borrowedBooksService.Delete(borrowedBook);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]

        public IActionResult Update(BorrowedBook borrowedBook)
        {
            var result = _borrowedBooksService.Update(borrowedBook);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
