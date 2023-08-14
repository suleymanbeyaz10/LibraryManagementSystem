using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        IResult Add(Author  author);
        IResult Delete(Author author);
        IResult Update(Author author);
        IDataResult<List<Author>> GetAll();
        IDataResult<Author> GetById(int id);
    }
}
