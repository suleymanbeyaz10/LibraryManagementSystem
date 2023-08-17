using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBookCategoriesService
    {
        IResult Add(BookCategories bookCategories);
        IResult Delete(BookCategories bookCategories);
        IResult Update(BookCategories bookCategories);
        IDataResult<List<BookCategories>> GetAll();
    }
}
