using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        public IResult Add(Author author)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Author author)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Author author)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Author>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Author> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
