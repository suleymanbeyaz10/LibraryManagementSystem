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
    public class MemberManager : IMemberService
    {
        public IResult Add(Member member)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Member member)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Member member)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Member>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Member> GetById(int memberId)
        {
            throw new NotImplementedException();
        }
    }
}
