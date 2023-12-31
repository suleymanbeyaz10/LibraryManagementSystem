﻿using Business.Abstract;
using Entities.Concrete;
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

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _bookService.GetAllBookDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]

        public IActionResult Add(Book book)
        {
            var result = _bookService.Add(book);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("delete")]

        public IActionResult Delete(Book book)
        {
            var result = _bookService.Delete(book);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("update")]

        public IActionResult Update(Book book)
        {
            var result = _bookService.Update(book);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbookdetails")]
        public ActionResult GetBookDetails(string searchText = "")
        {
            var result = _bookService.GetBookDetails(searchText);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
