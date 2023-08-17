using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class BookCopyManager : IBookCopyService
    {
        private IBookCopyDal _bookCopyDal;

        public BookCopyManager(IBookCopyDal bookCopyDal)
        {
            _bookCopyDal = bookCopyDal;
        }

        public IResult Add(BookCopy bookCopy)
        {
            _bookCopyDal.Add(bookCopy);
            return new SuccessResult();
        }

        public IResult Delete(BookCopy bookCopy)
        {
            _bookCopyDal.Delete(bookCopy);
            return new SuccessResult();
        }

        public IResult Update(BookCopy bookCopy)
        {
            _bookCopyDal.Update(bookCopy);
            return new SuccessResult();
        }

        public IDataResult<List<BookCopy>> GetAll()
        {
            return new SuccessDataResult<List<BookCopy>>(_bookCopyDal.GetAll());
        }

        public IDataResult<BookCopy> GetBookById(int bookId)
        {
            return new SuccessDataResult<BookCopy>(_bookCopyDal.Get(p => p.BookId == bookId));
        }

    }
}
