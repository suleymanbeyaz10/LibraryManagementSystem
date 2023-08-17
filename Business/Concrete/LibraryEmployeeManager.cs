using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class LibraryEmployeeManager : ILibraryEmployeeService
    {
        ILibraryEmployeeDal _libraryEmployeeDal;

        public LibraryEmployeeManager(ILibraryEmployeeDal libraryEmployeeDal)
        {
            _libraryEmployeeDal = libraryEmployeeDal;
        }
        public IResult Add(LibraryEmployee libraryEmployee)
        {
            _libraryEmployeeDal.Add(libraryEmployee);
            return new SuccessResult();
        }

        public IResult Delete(LibraryEmployee libraryEmployee)
        {
            _libraryEmployeeDal.Delete(libraryEmployee);
            return new SuccessResult();
        }

        public IResult Update(LibraryEmployee libraryEmployee)
        {
            _libraryEmployeeDal.Update(libraryEmployee);
            return new SuccessResult();
        }

        public IDataResult<List<LibraryEmployee>> GetAll()
        {
            return new SuccessDataResult<List<LibraryEmployee>>(_libraryEmployeeDal.GetAll());
        }

        public IDataResult<LibraryEmployee> GetById(int employeeId)
        {
            return new SuccessDataResult<LibraryEmployee>(_libraryEmployeeDal.Get(e => e.Id == employeeId));
        }
    }
}
