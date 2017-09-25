using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Domain.ViewModel;

namespace NFine.IRepository.SystemManage
{
    /// <summary>
    /// 预约表
    /// </summary>
    public interface IOrderRepository : IRepositoryBase<OrderEntity>
    {

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="entity">entity</param>
        /// <param name="keyValue">key</param>
        AddOrderResponse AddOrder(OrderViewModel model);
    }
}