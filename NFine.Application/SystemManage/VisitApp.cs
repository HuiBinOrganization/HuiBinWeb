using NFine.Code;
using NFine.Domain;
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
    /// 坐诊处理
    /// </summary>
    public class VisitApp
    {
        private IVisitRepository service = new VisitRepository();
      
        public IQueryable<VisitEntity> GetList(Expression<Func<VisitEntity, bool>> predicate)
        {
            return service.IQueryable(predicate);
        }
    }
}
