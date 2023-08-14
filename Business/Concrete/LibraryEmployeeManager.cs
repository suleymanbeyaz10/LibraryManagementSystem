using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class LibraryEmployeeManager : ILibraryEmployeeService
    {
        public IResult Add(LibraryEmployee libraryEmployee)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(LibraryEmployee libraryEmployee)
        {
            throw new NotImplementedException();
        }

        public IResult Update(LibraryEmployee libraryEmployee)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<LibraryEmployee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<LibraryEmployee> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
