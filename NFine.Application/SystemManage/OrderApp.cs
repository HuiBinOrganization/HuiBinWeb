using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.ViewModel;
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
    /// 预约处理
    /// </summary>
    public class OrderApp
    {
        private IOrderRepository service = new OrderRepository();

        public IQueryable<OrderEntity> GetList(Expression<Func<OrderEntity, bool>> predicate)
        {
            return service.IQueryable(predicate);
        }

        /// <summary>
        /// 预约
        /// </summary>
        /// <param name="model">参数</param>
        public AddOrderResponse AddOrder(OrderViewModel model)
        {
            return service.AddOrder(model);
        }

        /// <summary>
        /// 获取预约列表信息
        /// </summary>
        /// <param name="model">参数</param>
        public List<OrderEntity> GetOrderList(GetOrderListRequest model)
        {
            return service.IQueryable(item => item.MemberId == model.MemberId).ToList();
        }
    }
}
