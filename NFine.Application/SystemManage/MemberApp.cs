using NFine.Domain.Entity.SystemManage;
using NFine.IRepository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.SystemManage
{
    /// <summary>
    /// 会员处理类
    /// </summary>
    public class MemberApp
    {
        private IMemberRepository service = new MemberRepository();

        public IQueryable<MemberEntity> GetList(Expression<Func<MemberEntity, bool>> predicate)
        {
            return service.IQueryable(predicate);
        }
    }
}
