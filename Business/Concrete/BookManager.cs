using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        [ValidationAspect(typeof(BookValidator))]
        public IResult Add(Book book)
        {
            _bookDal.Add(book);
            return new SuccessResult(Messages.BookAdded);
        }

        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult(Messages.BookDeleted);
        }

        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(), Messages.BooksListed);
        }

        public IDataResult<List<BookDetailDto>> GetAllBookDetails()
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetAllBookDetails(), Messages.BooksListed);
        }

        public IDataResult<List<BookDetailDto>> GetBookDetails(string searchText)
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails(searchText), Messages.SearchedBooks);
        }


        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult(Messages.BookUpdated);
        }
    }
}
