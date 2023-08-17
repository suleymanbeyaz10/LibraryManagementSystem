using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBorrowedBookService   
    {
        IResult Add(BorrowedBook borrowedBook);
        IResult Delete(BorrowedBook borrowedBook);
        IResult Update(BorrowedBook borrowedBook);
        IDataResult<List<BorrowedBook>> GetAll();
    }
}
