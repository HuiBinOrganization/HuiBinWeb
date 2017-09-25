using NFine.Data;
using NFine.Domain.Entity.Enums;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFine.IRepository.SystemManage
{
    /// <summary>
    /// 预约表
    /// </summary>
    public class OrderRepository : RepositoryBase<OrderEntity>, IOrderRepository
    {
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="keyValue">key</param>
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {

                db.Commit();
            }
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="entity">entity</param>
        /// <param name="keyValue">key</param>
        public void SubmitForm(OrderEntity entity, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Commit();
            }
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="entity">entity</param>
        /// <param name="keyValue">key</param>
        public AddOrderResponse AddOrder(OrderViewModel model)
        {
            AddOrderResponse addOrderResponse = new AddOrderResponse();
            using (var db = new RepositoryBase().BeginTrans())
            {
                //添加患者信息
                MemberEntity memberEntity = new MemberEntity();
                memberEntity.CredentialInformation = model.CredentialInformation;
                memberEntity.CredentialType = (int)model.CredentialType;
                memberEntity.FullName = model.FullName;
                memberEntity.VisitingCardNumber = model.VisitingCardNumber;
                memberEntity.Gender = (int)model.Gender;
                memberEntity.DateOfBirth = model.DateOfBirth;
                memberEntity.ContactNumber = model.ContactNumber;
                memberEntity.Email = model.Email;
                memberEntity.Nationality = model.Nationality;

                //验证用户是否存在，如果存在不进行添加
                var member = db.IQueryable<MemberEntity>(item => item.CredentialInformation == memberEntity.CredentialInformation && item.CredentialType == memberEntity.CredentialType).FirstOrDefault();
                if (member == null)
                {
                    db.Insert(memberEntity);
                }

                //添加预约信息
                OrderEntity orderEntity = new OrderEntity();
                orderEntity.OrderDoctorId = model.OrderDoctorId;
                orderEntity.OrderDate = orderEntity.OrderDate;
                orderEntity.OrderType = orderEntity.OrderType;
                orderEntity.Category = (OrderTimeTypeEnum)orderEntity.OrderType;
                orderEntity.MemberId = memberEntity.MemberId;
                orderEntity.SymptomDescription = model.SymptomDescription;

                //周几
                var week = (int)model.OrderDateTime.DayOfWeek;
                if (week == 0)
                {
                    week = 7;
                }
                //判断是否预约已经满

                //剩余预约数量
                int remainOrderCount = 0;

                //出诊信息
                var linq = db.IQueryable<VisitEntity>(item => item.DoctorId == model.OrderDoctorId && item.Week == week);

                //依次预约
                if (model.OrderType == OrderTypeEnum.Successively)
                {
                    orderEntity.NumberType = (int)OrderTypeEnum.Successively;
                    orderEntity.BeginTime = null;
                    orderEntity.EndTime = null;
                    orderEntity.OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    switch (model.OrderDateTimeType)
                    {
                        case OrderTimeTypeEnum.Morning:
                            {
                                var orderTimetype = (int)OrderTimeTypeEnum.Morning;
                                //查询已预约数量
                                var orderedCount = db.IQueryable<OrderEntity>(item => item.OrderDoctorId == model.OrderDoctorId && item.OrderType == orderTimetype && item.OrderDate == model.OrderDateTime).Sum(item => item.OrderId);

                                //坐诊信息
                                var visit = linq.FirstOrDefault();
                                if (visit != null)
                                {
                                    remainOrderCount = visit.MorningCount - orderedCount;
                                }
                            }
                            break;
                        case OrderTimeTypeEnum.Afternoon:
                            {
                                var orderTimetype = (int)OrderTimeTypeEnum.Afternoon;
                                //查询已预约数量
                                var orderedCount = db.IQueryable<OrderEntity>(item => item.OrderDoctorId == model.OrderDoctorId && item.OrderType == orderTimetype && item.OrderDate == model.OrderDateTime).Sum(item => item.OrderId);

                                //坐诊信息
                                var visit = linq.FirstOrDefault();
                                if (visit != null)
                                {
                                    remainOrderCount = visit.AfternoonCount - orderedCount;
                                }
                            }
                            break;
                        case OrderTimeTypeEnum.Night:
                            {
                                var orderTimetype = (int)OrderTimeTypeEnum.Night;
                                //查询已预约数量
                                var orderedCount = db.IQueryable<OrderEntity>(item => item.OrderDoctorId == model.OrderDoctorId && item.OrderType == orderTimetype && item.OrderDate == model.OrderDateTime).Sum(item => item.OrderId);

                                //坐诊信息
                                var visit = linq.FirstOrDefault();
                                if (visit != null)
                                {
                                    remainOrderCount = visit.NightCount - orderedCount;
                                }
                            }
                            break;
                    }
                }
                else
                {
                    orderEntity.NumberType = (int)OrderTypeEnum.Segmentation;
                    orderEntity.BeginTime = model.BeginTime;
                    orderEntity.EndTime = model.EndTime;
                    orderEntity.OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    switch (model.OrderDateTimeType)
                    {
                        case OrderTimeTypeEnum.Morning:
                            {
                                var orderTimetype = (int)OrderTimeTypeEnum.Morning;

                                //分时段
                                var segmentationOrder = db.IQueryable<SegmentationOrderEntity>(item => item.DoctorId == model.OrderDoctorId && item.OrderTimeType == orderTimetype).FirstOrDefault();

                                if (segmentationOrder != null)
                                {
                                    //查询已预约数量
                                    var orderedCount = db.IQueryable<OrderEntity>(item => item.OrderDoctorId == model.OrderDoctorId && item.OrderType == orderTimetype && item.OrderDate >= model.BeginTime && item.OrderDate <= model.EndTime).Sum(item => item.OrderId);
                                    remainOrderCount = segmentationOrder.OrderCount - orderedCount;
                                }
                            }
                            break;
                        case OrderTimeTypeEnum.Afternoon:
                            {
                                var orderTimetype = (int)OrderTimeTypeEnum.Afternoon;

                                //分时段
                                var segmentationOrder = db.IQueryable<SegmentationOrderEntity>(item => item.DoctorId == model.OrderDoctorId && item.OrderTimeType == orderTimetype).FirstOrDefault();

                                if (segmentationOrder != null)
                                {
                                    //查询已预约数量
                                    var orderedCount = db.IQueryable<OrderEntity>(item => item.OrderDoctorId == model.OrderDoctorId && item.OrderType == orderTimetype && item.OrderDate >= model.BeginTime && item.OrderDate <= model.EndTime).Sum(item => item.OrderId);
                                    remainOrderCount = segmentationOrder.OrderCount - orderedCount;
                                }
                            }
                            break;
                        case OrderTimeTypeEnum.Night:
                            {
                                var orderTimetype = (int)OrderTimeTypeEnum.Afternoon;

                                //分时段
                                var segmentationOrder = db.IQueryable<SegmentationOrderEntity>(item => item.DoctorId == model.OrderDoctorId && item.OrderTimeType == orderTimetype).FirstOrDefault();

                                if (segmentationOrder != null)
                                {
                                    //查询已预约数量
                                    var orderedCount = db.IQueryable<OrderEntity>(item => item.OrderDoctorId == model.OrderDoctorId && item.OrderType == orderTimetype && item.OrderDate >= model.BeginTime && item.OrderDate <= model.EndTime).Sum(item => item.OrderId);
                                    remainOrderCount = segmentationOrder.OrderCount - orderedCount;
                                }
                            }
                            break;
                    }
                }

                //如果有剩余，则进行添加
                if (remainOrderCount > 0)
                {

                    //添加预约信息
                    db.Insert(orderEntity);
                }
             
                addOrderResponse.FullName = model.FullName;
                addOrderResponse.OrderTime = model.OrderDateTime;
                addOrderResponse.NumberType = (OrderTypeEnum)orderEntity.NumberType;
                addOrderResponse.OrderTimeType = (OrderTimeTypeEnum)orderEntity.OrderType;
                //提交
                db.Commit();
            }

            return addOrderResponse;
        }
    }
}