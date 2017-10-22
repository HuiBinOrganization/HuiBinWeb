﻿using NFine.Code;
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

        public void DoctorStop(StopDoctorViewModel model)
        {
            //上午
            if (model.Morning)
            {
                var orderTimeType = 1;
                var closeData = Convert.ToDateTime(model.CloseDate.ToString("yyyy-MM-dd"));
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
                var orderTimeType = 2;
                var closeData = Convert.ToDateTime(model.CloseDate.ToString("yyyy-MM-dd"));
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
                var orderTimeType = 3;
                var closeData = Convert.ToDateTime(model.CloseDate.ToString("yyyy-MM-dd"));
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