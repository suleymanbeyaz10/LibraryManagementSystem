using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using GeneratedDataAccess.Models2;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<object> Get()
        {


            //throw new NotImplementedException();
            LibraryManagementContext context = new LibraryManagementContext();
            //var b1 = context.Books.Include(b => b.BookCategories);
            ////var y = context.Books.Include(b => b.BookCategories).ThenInclude(b => b).ToList();


            var books = context.Books
                    .Include(b => b.BookCategories) // Include the BookCategories collection within Books
                    .ThenInclude(bc => bc.Category)
                    .Include(b=>b.Author)
                    .ToList();


            List<BookDetailDto> bookDetailDtos = new List<BookDetailDto>();
            
            foreach (var book in books)
            {

                BookDetailDto bookDetailDto = new BookDetailDto();
                bookDetailDto.BookName = book.Title;
                bookDetailDto.Author = $"{book.Author.FirstName} {book.Author.LastName}";
                bookDetailDtos.Add(bookDetailDto);

            }



            //var books = context.Books.ToList();

            return bookDetailDtos;
        }
    }
}