using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Domain.ViewModel;
using System.Collections.Generic;

namespace NFine.IRepository.SystemManage
{
    /// <summary>
    /// 会员表
    /// </summary>
    public interface IMemberRepository : IRepositoryBase<MemberEntity>
    {
        /// <summary>
        /// 获取医生列表信息
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        List<MemberEntity> GetOrderList(GetOrderListRequest model);
    }
}