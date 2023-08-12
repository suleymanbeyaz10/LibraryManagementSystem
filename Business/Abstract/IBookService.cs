using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    { 
        IResult Add(Book book);
        IResult Update(Book book);
        IResult Delete(Book book);
        IDataResult<List<Book>> GetAll();
        IDataResult<List<BookDetailDto>> GetBookDetails();

    }
}
