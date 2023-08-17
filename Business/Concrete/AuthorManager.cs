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
    public class AuthorManager : IAuthorService
    {
        private IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public IResult Add(Author author)
        {
            _authorDal.Add(author);
            return new SuccessResult();
        }

        public IResult Delete(Author author)
        {
            _authorDal.Delete(author);
            return new SuccessResult();
        }

        public IResult Update(Author author)
        {
            _authorDal.Update(author);
            return new SuccessResult();
        }

        public IDataResult<List<Author>> GetAll()
        {
            return new SuccessDataResult<List<Author>>(_authorDal.GetAll());
        }

        public IDataResult<Author> GetAuthorById(int authorId)
        {
            return new SuccessDataResult<Author>(_authorDal.Get(p => p.Id == authorId));
        }
    }
}
