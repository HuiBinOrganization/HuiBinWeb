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
    /// 分段预约
    /// </summary>
    public class SegmentationOrderApp
    {
        private ISegmentationOrderRepository service = new SegmentationOrderRepository();

        public IQueryable<SegmentationOrderEntity> GetList(Expression<Func<SegmentationOrderEntity, bool>> predicate)
        {
            return service.IQueryable(predicate);
        }
    }
}
