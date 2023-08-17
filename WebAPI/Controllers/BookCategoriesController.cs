using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoriesController : ControllerBase
    {
        IBookCategoriesService _bookCategoriesService;

        public BookCategoriesController(IBookCategoriesService bookCategoriesService)
        {
            _bookCategoriesService = bookCategoriesService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _bookCategoriesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add(BookCategories bookCategories)

        {
            var result = _bookCategoriesService.Add(bookCategories);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]

        public IActionResult Delete(BookCategories bookCategories)
        {
            var result = _bookCategoriesService.Delete(bookCategories);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]

        public IActionResult Update(BookCategories bookCategories)
        {
            var result = _bookCategoriesService.Update(bookCategories);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
