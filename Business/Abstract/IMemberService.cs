using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMemberService
    {
        IResult Add(Member member);
        IResult Delete(Member member);
        IResult Update(Member member);
        IDataResult<List<Member>> GetAll();
        IDataResult<Member> GetById(int memberId);
    }
}
