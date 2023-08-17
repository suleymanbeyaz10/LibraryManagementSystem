using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBookCopyService
    {
        IResult Add(BookCopy  bookCopy);
        IResult Delete(BookCopy bookCopy);
        IResult Update(BookCopy bookCopy);
        IDataResult<List<BookCopy>> GetAll();
        IDataResult<BookCopy> GetBookById(int bookId);
    }
}
