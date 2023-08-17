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
    public class MemberManager : IMemberService
    {
        private IMemberDal _memberDal;

        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        public IResult Add(Member member)
        {
            _memberDal.Add(member);
            return new SuccessResult();
        }

        public IResult Delete(Member member)
        {
            _memberDal.Delete(member);
            return new SuccessResult();
        }

        public IResult Update(Member member)
        {
            _memberDal.Update(member);
            return new SuccessResult();
        }

        public IDataResult<List<Member>> GetAll()
        {
            return new SuccessDataResult<List<Member>>(_memberDal.GetAll());
        }

        public IDataResult<Member> GetById(int memberId)
        {
            return new SuccessDataResult<Member>(_memberDal.Get(m => m.Id == memberId));
        }
    }
}
