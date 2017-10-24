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
            addOrderResponse.IsSuccess = true;

            MemberEntity memberEntity = new MemberEntity();
            using (var db = new RepositoryBase().BeginTrans())
            {
                //添加患者信息
              
                memberEntity.CredentialInformation = model.CredentialInformation;
                memberEntity.CredentialType = (int)model.CredentialType;
                memberEntity.FullName = model.FullName;
                memberEntity.VisitingCardNumber = model.VisitingCardNumber;
                memberEntity.Gender = (int)model.Gender;
                memberEntity.DateOfBirth = model.DateOfBirth;
                memberEntity.ContactNumber = model.ContactNumber;
                memberEntity.Email = model.Email;
                memberEntity.Nationality = model.Nationality;
                memberEntity.AddDate = DateTime.Now;

                //验证用户是否存在，如果存在不进行添加
                var isExistMember = db.IQueryable<MemberEntity>(item => item.CredentialInformation == memberEntity.CredentialInformation && item.CredentialType == memberEntity.CredentialType).Count()>0;
                if (!isExistMember)
                {
                    db.Insert(memberEntity);
                }
                else {

                    memberEntity=db.IQueryable<MemberEntity>(item => item.CredentialInformation == memberEntity.CredentialInformation && item.CredentialType == memberEntity.CredentialType).FirstOrDefault();
                }

              

                var orderDate = Convert.ToDateTime(model.OrderDateTime.ToString("yyyy-MM-dd"));
                //验证是否已经预约当前午别
                var isExist = db.IQueryable<OrderEntity>(item => item.OrderDate >= orderDate
                                                       && item.OrderDate <= orderDate && item.OrderType == (int)model.OrderDateTimeType && item.OrderDoctorId == model.OrderDoctorId&&item.MemberId==memberEntity.MemberId).Count() > 0;
                db.Commit();
                if (isExist)
                {
                    addOrderResponse.IsSuccess = false;
                    addOrderResponse.Reason = "you made an appointment";
                    return addOrderResponse;
                }
            }
            using (var db = new RepositoryBase().BeginTrans())
            {
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
                    orderEntity.BeginTime = DateTime.Now;
                    orderEntity.EndTime = DateTime.Now;
                    orderEntity.OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    orderEntity.OrderDate = model.OrderDateTime;
                    switch (model.OrderDateTimeType)
                    {
                        case OrderTimeTypeEnum.Morning:
                            {
                                var orderTimetype = (int)OrderTimeTypeEnum.Morning;
                                orderEntity.OrderType = orderTimetype;

                                var query = db.IQueryable<OrderEntity>(item => item.OrderDoctorId == model.OrderDoctorId && item.OrderType == orderTimetype && item.OrderDate == model.OrderDateTime);
                                var orderedCount = 0;
                                if (query != null && query.Any())
                                {
                                    //查询已预约数量
                                    orderedCount = query.Count();
                                }


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
                                orderEntity.OrderType = orderTimetype;
                                var query = db.IQueryable<OrderEntity>(item => item.OrderDoctorId == model.OrderDoctorId && item.OrderType == orderTimetype && item.OrderDate == model.OrderDateTime);
                                var orderedCount = 0;
                                if (query != null && query.Any())
                                {
                                    //查询已预约数量
                                    orderedCount = query.Count();
                                }


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
                                orderEntity.OrderType = orderTimetype;
                                var query = db.IQueryable<OrderEntity>(item => item.OrderDoctorId == model.OrderDoctorId && item.OrderType == orderTimetype && item.OrderDate == model.OrderDateTime);
                                var orderedCount = 0;
                                if (query != null && query.Any())
                                {
                                    //查询已预约数量
                                    orderedCount = query.Count();
                                }


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
                    var beginTime = Convert.ToDateTime(model.OrderDateTime.ToString("yyyy-MM-dd") + " " + model.BeginTime.Value.ToString("HH:mm:ss"));
                    var endTime = Convert.ToDateTime(model.OrderDateTime.ToString("yyyy-MM-dd") + " " + model.EndTime.Value.ToString("HH:mm:ss"));
                    orderEntity.OrderDate = model.OrderDateTime;
                    orderEntity.NumberType = (int)OrderTypeEnum.Segmentation;
                    orderEntity.BeginTime = beginTime;
                    orderEntity.EndTime = endTime;
                    orderEntity.OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    switch (model.OrderDateTimeType)
                    {
                        case OrderTimeTypeEnum.Morning:
                            {
                                var orderTimetype = (int)OrderTimeTypeEnum.Morning;
                                orderEntity.OrderType = orderTimetype;
                                //分时段
                                var segmentationOrder = db.IQueryable<SegmentationOrderEntity>(item => item.DoctorId == model.OrderDoctorId && item.OrderTimeType == orderTimetype).FirstOrDefault();

                                if (segmentationOrder != null)
                                {
                                    //查询已预约数量
                                    var query = db.IQueryable<OrderEntity>(item => item.OrderDoctorId == model.OrderDoctorId && item.OrderType == orderTimetype && item.OrderDate >= model.BeginTime && item.OrderDate <= model.EndTime);
                                    if (query != null)
                                    {
                                        var orderedCount = query.Count();
                                        remainOrderCount = segmentationOrder.OrderCount - orderedCount;
                                    }
                                }
                            }
                            break;
                        case OrderTimeTypeEnum.Afternoon:
                            {
                                var orderTimetype = (int)OrderTimeTypeEnum.Afternoon;
                                orderEntity.OrderType = orderTimetype;
                                //分时段
                                var segmentationOrder = db.IQueryable<SegmentationOrderEntity>(item => item.DoctorId == model.OrderDoctorId && item.OrderTimeType == orderTimetype).FirstOrDefault();

                                if (segmentationOrder != null)
                                {
                                    //查询已预约数量
                                    var query = db.IQueryable<OrderEntity>(item => item.OrderDoctorId == model.OrderDoctorId && item.OrderType == orderTimetype && item.OrderDate >= model.BeginTime && item.OrderDate <= model.EndTime);
                                    if (query != null)
                                    {
                                        var orderedCount = query.Count();
                                        remainOrderCount = segmentationOrder.OrderCount - orderedCount;
                                    }

                                }
                            }
                            break;
                        case OrderTimeTypeEnum.Night:
                            {
                                var orderTimetype = (int)OrderTimeTypeEnum.Night;
                                orderEntity.OrderType = orderTimetype;
                                //分时段
                                var segmentationOrder = db.IQueryable<SegmentationOrderEntity>(item => item.DoctorId == model.OrderDoctorId && item.OrderTimeType == orderTimetype).FirstOrDefault();

                                if (segmentationOrder != null)
                                {
                                    //查询已预约数量
                                    var query = db.IQueryable<OrderEntity>(item => item.OrderDoctorId == model.OrderDoctorId && item.OrderType == orderTimetype && item.OrderDate >= model.BeginTime && item.OrderDate <= model.EndTime);
                                    if (query != null)
                                    {
                                        var orderedCount = query.Count();
                                        remainOrderCount = segmentationOrder.OrderCount - orderedCount;
                                    }
                                }
                            }
                            break;
                    }
                }

                //如果有剩余，则进行添加
                if (remainOrderCount > 0)
                {
                    orderEntity.AddDate = DateTime.Now;
                    //添加预约信息
                    db.Insert(orderEntity);
                }
                //addOrderResponse.BeginTime = model.BeginTime.Value;

                addOrderResponse.BeginTime = orderEntity.BeginTime;
                addOrderResponse.EndTime = orderEntity.EndTime;
                addOrderResponse.FullName = model.FullName;
                addOrderResponse.OrderTime = model.OrderDateTime;
                addOrderResponse.NumberType = (OrderTypeEnum)orderEntity.NumberType;
                addOrderResponse.OrderTimeType = (OrderTimeTypeEnum)orderEntity.OrderType;
                addOrderResponse.OrderNumber = orderEntity.OrderNumber;
                //提交
                db.Commit();
            }

            return addOrderResponse;
        }
    }
}