using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCopiesController : ControllerBase
    {
        IBookCopyService _bookCopyService;

        public BookCopiesController(IBookCopyService bookCopyService)
        {
            _bookCopyService = bookCopyService;
        }

        [HttpGet("getall")]

        public ActionResult GetAll()
        {
            var result = _bookCopyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public ActionResult Add(BookCopy bookCopy)
        {
            var result = _bookCopyService.Add(bookCopy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public ActionResult Delete(BookCopy bookCopy)
        {
            var result = _bookCopyService.Delete(bookCopy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public ActionResult Update(BookCopy bookCopy)
        {
            var result = _bookCopyService.Update(bookCopy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbookbyid")]

        public ActionResult GetBookById(int bookId)
        {
            var result = _bookCopyService.GetBookById(bookId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
