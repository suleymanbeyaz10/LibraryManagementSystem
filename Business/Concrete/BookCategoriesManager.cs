using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BookCategoriesManager : IBookCategoriesService
    {
        IBookCategoriesDal _bookCategoriesDal;

        public BookCategoriesManager(IBookCategoriesDal bookCategoriesDal)
        {
            _bookCategoriesDal = bookCategoriesDal;
        }

        public IResult Add(BookCategories bookCategories)
        {
            _bookCategoriesDal.Add(bookCategories);
            return new SuccessResult();
        }

        public IResult Delete(BookCategories bookCategories)
        {
            _bookCategoriesDal.Delete(bookCategories);
            return new SuccessResult();
        }

        public IResult Update(BookCategories bookCategories)
        {
            _bookCategoriesDal.Update(bookCategories);
            return new SuccessResult();
        }

        public IDataResult<List<BookCategories>> GetAll()
        {
            return new SuccessDataResult<List<BookCategories>>(_bookCategoriesDal.GetAll());
        }
    }
}
