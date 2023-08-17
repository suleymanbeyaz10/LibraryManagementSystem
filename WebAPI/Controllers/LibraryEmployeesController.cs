using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryEmployeesController : ControllerBase
    {
        private ILibraryEmployeeService _libraryEmployeeService;

        public LibraryEmployeesController(ILibraryEmployeeService libraryEmployeeService)
        {
            _libraryEmployeeService = libraryEmployeeService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _libraryEmployeeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add(LibraryEmployee libraryEmployee)
        {
            var result = _libraryEmployeeService.Add(libraryEmployee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]

        public IActionResult Delete(LibraryEmployee libraryEmployee)
        {
            var result = _libraryEmployeeService.Delete(libraryEmployee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]

        public IActionResult Edit(LibraryEmployee libraryEmployee)
        {
            var result = _libraryEmployeeService.Update(libraryEmployee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int employeeId)
        {
            var result = _libraryEmployeeService.GetById(employeeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
