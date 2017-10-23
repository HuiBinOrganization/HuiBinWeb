using NFine.Code;
using NFine.Domain.Entity.Enums;
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
    /// 停诊
    /// </summary>
    public class StopApp
    {
        private ICloseOrderRepository service = new CloseOrderRepository();
        private IOrderRepository orderService = new OrderRepository();

        public void DoctorStop(StopDoctorViewModel model)
        {
            var closeData = Convert.ToDateTime(model.CloseDate.ToString("yyyy-MM-dd"));
            var orderTimeType = 1;
            //上午
            if (model.Morning)
            {
                 orderTimeType = 1;
              
                var isExist = service.IQueryable(item => item.DoctorId == model.DoctorId
                                                 && item.OrderTimeType == orderTimeType
                                                 && item.CloseDate >= closeData && item.CloseDate <= closeData).Count() > 0;
                //不存在则进行添加
                if (!isExist)
                {
                    CloseOrderEntity closeOrderEntity = new CloseOrderEntity();
                    closeOrderEntity.DoctorId = model.DoctorId;
                    closeOrderEntity.CloseDate = model.CloseDate;
                    closeOrderEntity.OrderTimeType = orderTimeType;
                    service.Insert(closeOrderEntity);
                }
            }

            //下午
            if (model.Afternoon)
            {
                orderTimeType = 2;
                var isExist = service.IQueryable(item => item.DoctorId == model.DoctorId
                                                 && item.OrderTimeType == orderTimeType
                                                 && item.CloseDate >= closeData && item.CloseDate <= closeData).Count() > 0;
                //不存在则进行添加
                if (!isExist)
                {
                    CloseOrderEntity closeOrderEntity = new CloseOrderEntity();
                    closeOrderEntity.DoctorId = model.DoctorId;
                    closeOrderEntity.CloseDate = model.CloseDate;
                    closeOrderEntity.OrderTimeType = orderTimeType;
                    service.Insert(closeOrderEntity);
                }
            }

            //晚上
            if (model.Night)
            {
                 orderTimeType = 3;
                var isExist = service.IQueryable(item => item.DoctorId == model.DoctorId
                                                 && item.OrderTimeType == orderTimeType
                                                 && item.CloseDate >= closeData && item.CloseDate <= closeData).Count() > 0;
                //不存在则进行添加
                if (!isExist)
                {
                    CloseOrderEntity closeOrderEntity = new CloseOrderEntity();
                    closeOrderEntity.DoctorId = model.DoctorId;
                    closeOrderEntity.CloseDate = model.CloseDate;
                    closeOrderEntity.OrderTimeType = orderTimeType;
                    service.Insert(closeOrderEntity);
                }
            }

            //修改预约信息
            var orderList = orderService.IQueryable(item => item.OrderDoctorId == model.DoctorId
                                                    && item.OrderDate >= closeData && item.OrderDate <= closeData
                                                    && item.OrderType == orderTimeType).ToList();
            if (orderList != null && orderList.Any())
            {
                foreach (var order in orderList)
                {
                    order.OrderStatus = OrderStatusEnum.Stop;
                    orderService.Update(order);
                }
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        public IQueryable<CloseOrderEntity> GetList(Expression<Func<CloseOrderEntity, bool>> predicate)
        {
            return service.IQueryable(predicate);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<CloseOrderEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<CloseOrderEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                int doctorId = 0;
                int.TryParse(keyword, out doctorId);
                expression = expression.And(t => t.DoctorId== doctorId);
            }
            return service.FindList(expression, pagination);
        }


    }
}
