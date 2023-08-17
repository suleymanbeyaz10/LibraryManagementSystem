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
    public class BorrowedBookManager : IBorrowedBookService
    {
        IBorrowedBookDal _borrowedBookDal;

        public BorrowedBookManager(IBorrowedBookDal borrowedBookDal)
        {
            _borrowedBookDal = borrowedBookDal;
        }
        public IResult Add(BorrowedBook borrowedBook)
        {
            _borrowedBookDal.Add(borrowedBook);
            return new SuccessResult();
        }

        public IResult Delete(BorrowedBook borrowedBook)
        {
            _borrowedBookDal.Delete(borrowedBook);
            return new SuccessResult();
        }

        public IResult Update(BorrowedBook borrowedBook)
        {
            _borrowedBookDal.Update(borrowedBook);
            return new SuccessResult();
        }

        public IDataResult<List<BorrowedBook>> GetAll()
        {
            return new SuccessDataResult<List<BorrowedBook>>(_borrowedBookDal.GetAll());
        }

    }
}
