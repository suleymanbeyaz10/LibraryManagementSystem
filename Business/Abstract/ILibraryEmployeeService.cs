using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILibraryEmployeeService
    {
        IResult Add(LibraryEmployee libraryEmployee);
        IResult Delete(LibraryEmployee libraryEmployee);
        IResult Update(LibraryEmployee libraryEmployee);
        IDataResult<List<LibraryEmployee>> GetAll();
        IDataResult<LibraryEmployee> GetById(int employeeId);
    }
}
