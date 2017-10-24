using NFine.Application.SystemManage;
using NFine.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFine.Code;
using NFine.Domain.Entity.Enums;
using NFine.Domain.Entity.SystemManage;

namespace NFine.Web.Areas.UIManage.Controllers
{
    #region 医生预约信息
    /// <summary>
    /// 医生预约信息
    /// </summary>
    public class DoctorController : Controller
    {
        #region 变量
        private DoctorApp doctorApp = new DoctorApp();
        private VisitApp visitApp = new VisitApp();
        private OrderApp orderApp = new OrderApp();
        private MemberApp memberApp = new MemberApp();
        private StopApp stopApp = new StopApp();
        private SegmentationOrderApp segmentationOrderApp = new SegmentationOrderApp();
        #endregion

        #region 获取医生列表
        /// <summary>
        /// 获取医生列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        // [ValidateAntiForgeryToken]
        public ActionResult GetDoctorList()
        {
            ResponseBase<List<GetDoctorListResponse>> response = new ResponseBase<List<GetDoctorListResponse>>();
            response.IsSuccess = false;
            response.Reason = "系统出错，请联系管理员";

            try
            {
                var doctorList = doctorApp.GetList(item => true).ToList();
                var visitList = visitApp.GetList(item => true).ToList();
                List<GetDoctorListResponse> responseDoctorList = new List<GetDoctorListResponse>();
                if (doctorList != null && doctorList.Any())
                {
                    foreach (var doctor in doctorList)
                    {
                        GetDoctorListResponse doctorResponse = new GetDoctorListResponse();
                        doctorResponse.DoctorId = doctor.DoctorId;
                        doctorResponse.DoctorName = doctor.DoctorName;
                        doctorResponse.Avatar = "/Content/img/pages/pic-doc.png";
                        doctorResponse.GootAt = doctor.GootAt;
                        doctorResponse.VisitList = new List<int>();
                        if (visitList != null && visitList.Any())
                        {
                            //获取每周出诊信息
                            List<int> weekVisit = visitList.Where(item => item.DoctorId == doctor.DoctorId && (item.Morning == true || item.Afternoon == true || item.Night == true)).Select(item => item.Week).ToList();
                            if (weekVisit != null && weekVisit.Any())
                            {
                                doctorResponse.VisitList.AddRange(weekVisit);
                            }
                        }

                        responseDoctorList.Add(doctorResponse);

                    }
                    response.Result = responseDoctorList;
                }
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {

            }
            return Content(response.ToJson());
        }
        #endregion

        #region 获取医生出诊信息
        /// <summary>
        /// 获取医生出诊信息
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        // [ValidateAntiForgeryToken]
        public ActionResult GetDoctorInfo(GetDoctorInfoRequest request)
        {
            ResponseBase<GetDoctorInfoResponse> response = new ResponseBase<GetDoctorInfoResponse>();
            response.IsSuccess = false;
            response.Reason = "系统出错，请联系管理员";

            #region 验证
            if (request == null)
            {
                response.IsSuccess = false;
                response.Reason = "参数不能为空";
                return Content(response.ToJson());
            }

            if (request.DoctorId < 1)
            {
                response.IsSuccess = false;
                response.Reason = "医生ID输入不正确";
                return Content(response.ToJson());
            }
            #endregion

            try
            {
                var doctor = doctorApp.GetList(item => item.DoctorId == request.DoctorId).FirstOrDefault();
                GetDoctorInfoResponse getDoctorInfoResponse = new GetDoctorInfoResponse();
                if (doctor != null)
                {
                    getDoctorInfoResponse.DoctorId = doctor.DoctorId;
                    getDoctorInfoResponse.DoctorName = doctor.DoctorName;
                    getDoctorInfoResponse.GootAt = doctor.GootAt;
                    getDoctorInfoResponse.Avatar = "/Content/img/pages/pic-doc.png";
                    getDoctorInfoResponse.Title = doctor.Title;
                    getDoctorInfoResponse.Introduction = doctor.Introduction;
                    getDoctorInfoResponse.Gender = doctor.Gender == true ? 1 : 2;
                    int orderCycle = 0;

                    ////配置文件读取
                    int.TryParse(Configs.GetValue("OrderCycle"), out orderCycle);
                    getDoctorInfoResponse.OrderCycle = orderCycle;


                    //获取预约周期信息
                    List<OrderCycle> orderCycleList = new List<OrderCycle>();

                    var visitList = visitApp.GetList(item => item.DoctorId == request.DoctorId).OrderBy(item => item.Week);

                    //预约周期内预约信息
                    List<OrderDateTimeInfo> orderDateTimeInfoList = new List<OrderDateTimeInfo>();
                    //预约时间列表
                    for (int i = 0; i < orderCycle; i++)
                    {
                        OrderDateTimeInfo orderDateTimeInfo = new OrderDateTimeInfo();
                        var orderDateTime = DateTime.Now.AddDays(i);
                        orderDateTimeInfo.OrderDateTime = orderDateTime;
                        //查询停诊表信息
                        int week = (int)orderDateTime.DayOfWeek;
                        if (week == 0)
                        {
                            week = 7;
                        }
                        orderDateTimeInfo.Week = week;

                        orderDateTimeInfoList.Add(orderDateTimeInfo);
                    }

                    //出诊列表
                    if (visitList != null && visitList.Any())
                    {
                        foreach (var visit in visitList)
                        {
                            //预约时间列表
                            var orderDateTimeList = orderDateTimeInfoList.Where(item => item.Week == visit.Week);

                            foreach (var info in orderDateTimeList)
                            {
                                OrderCycle orderCycleInfo = new OrderCycle();
                                orderCycleInfo.Week = visit.Week;
                                orderCycleInfo.OrderDateTime = info.OrderDateTime;
                                var beginTime = Convert.ToDateTime(orderCycleInfo.OrderDateTime.ToString("yyyy-MM-dd 00:00:00"));
                                var endTime = Convert.ToDateTime(orderCycleInfo.OrderDateTime.ToString("yyyy-MM-dd 23:59:59"));
                                var orderList = orderApp.GetList(item => item.OrderDoctorId == request.DoctorId && item.OrderDate == beginTime);

                                #region 下午出诊
                                //下午出诊
                                if (visit.Morning)
                                {
                                    //验证是否上午停诊
                                    var isStopOrder = stopApp.GetList(item => item.DoctorId == request.DoctorId
                                      && item.CloseDate >= beginTime
                                      && item.CloseDate <= beginTime
                                      && item.OrderTimeType == 1).Count() > 0;
                                    if (!isStopOrder)
                                    {
                                        #region 上午

                                        //预约时间是今天
                                        if (beginTime.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                                        {
                                            //现在时间大于上午
                                            if (DateTime.Now < Convert.ToDateTime(DateTime.Now.ToString("yyy-MM-dd 12:00:00")))
                                            {
                                                //查询预约人数,上午
                                                var orderUserCount = 0;
                                                orderList = orderList.Where(item => item.OrderType == 1);
                                                if (orderList != null && orderList.Any())
                                                {
                                                    orderUserCount = orderList.Count();
                                                }


                                                if (orderUserCount < visit.MorningCount)
                                                {
                                                    //预约状态，可预约
                                                    orderCycleInfo.MorningOrderType = 1;
                                                }

                                                if (visit.MorningCount == orderUserCount)
                                                {
                                                    //预约状态，预约已满
                                                    orderCycleInfo.MorningOrderType = 2;
                                                }
                                            }
                                        }
                                        else
                                        {

                                            //预约时间是今天
                                            if (beginTime.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                                            {
                                                //现在时间大于上午
                                                if (DateTime.Now < Convert.ToDateTime(DateTime.Now.ToString("yyy-MM-dd 18:00:00")))
                                                {
                                                    //查询预约人数,上午
                                                    var orderUserCount = 0;
                                                    orderList = orderList.Where(item => item.OrderType == 1);
                                                    if (orderList != null && orderList.Any())
                                                    {
                                                        orderUserCount = orderList.Count();
                                                    }


                                                    if (orderUserCount < visit.MorningCount)
                                                    {
                                                        //预约状态，可预约
                                                        orderCycleInfo.MorningOrderType = 1;
                                                    }

                                                    if (visit.MorningCount == orderUserCount)
                                                    {
                                                        //预约状态，预约已满
                                                        orderCycleInfo.MorningOrderType = 2;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //查询预约人数,上午
                                                var orderUserCount = 0;
                                                orderList = orderList.Where(item => item.OrderType == 1);
                                                if (orderList != null && orderList.Any())
                                                {
                                                    orderUserCount = orderList.Count();
                                                }


                                                if (orderUserCount < visit.MorningCount)
                                                {
                                                    //预约状态，可预约
                                                    orderCycleInfo.MorningOrderType = 1;
                                                }

                                                if (visit.MorningCount == orderUserCount)
                                                {
                                                    //预约状态，预约已满
                                                    orderCycleInfo.MorningOrderType = 2;
                                                }
                                            }

                                        }

                                        #endregion
                                    }
                                    else
                                    {
                                        //预约状态，停诊
                                        orderCycleInfo.MorningOrderType = 3;
                                    }
                                }
                                #endregion

                                #region 下午出诊
                                //下午出诊
                                if (visit.Afternoon)
                                {
                                    //验证是否下午停诊
                                    var isStopOrder = stopApp.GetList(item => item.DoctorId == request.DoctorId
                                      && item.CloseDate >= beginTime
                                      && item.CloseDate <= beginTime
                                      && item.OrderTimeType == 2).Count() > 0;
                                    if (!isStopOrder)
                                    {
                                        #region 下午

                                        //预约时间是今天
                                        if (beginTime.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                                        {
                                            //现在时间大于上午
                                            if (DateTime.Now < Convert.ToDateTime(DateTime.Now.ToString("yyy-MM-dd 22:00:00")))
                                            {
                                                //查询预约人数,下午
                                                var orderUserCount = 0;
                                                orderList = orderList.Where(item => item.OrderType == 2);
                                                if (orderList != null && orderList.Any())
                                                {
                                                    orderUserCount = orderList.Count();
                                                }

                                                if (orderUserCount < visit.AfternoonCount)
                                                {
                                                    //预约状态，可预约
                                                    orderCycleInfo.AfterNoonOrderType = 1;
                                                }

                                                if (visit.MorningCount == orderUserCount)
                                                {
                                                    //预约状态，预约已满
                                                    orderCycleInfo.AfterNoonOrderType = 2;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //查询预约人数,下午
                                            var orderUserCount = 0;
                                            orderList = orderList.Where(item => item.OrderType == 2);
                                            if (orderList != null && orderList.Any())
                                            {
                                                orderUserCount = orderList.Count();
                                            }

                                            if (orderUserCount < visit.AfternoonCount)
                                            {
                                                //预约状态，可预约
                                                orderCycleInfo.AfterNoonOrderType = 1;
                                            }

                                            if (visit.MorningCount == orderUserCount)
                                            {
                                                //预约状态，预约已满
                                                orderCycleInfo.AfterNoonOrderType = 2;
                                            }
                                        }

                                        #endregion
                                    }
                                    else
                                    {
                                        //预约状态，停诊
                                        orderCycleInfo.AfterNoonOrderType = 3;
                                    }
                                }
                                #endregion

                                #region 晚上出诊
                                //晚上出诊
                                if (visit.Night)
                                {
                                    //验证是否下午停诊
                                    var isStopOrder = stopApp.GetList(item => item.DoctorId == request.DoctorId
                                      && item.CloseDate >= beginTime
                                      && item.CloseDate <= beginTime
                                      && item.OrderTimeType == 3).Count() > 0;
                                    if (!isStopOrder)
                                    {
                                        #region 晚上
                                        //查询预约人数,晚上
                                        var orderUserCount = 0;
                                        orderList = orderList.Where(item => item.OrderType == 3);
                                        if (orderList != null && orderList.Any())
                                        {
                                            orderUserCount = orderList.Count();
                                        }

                                        if (orderUserCount < visit.NightCount)
                                        {
                                            //预约状态，可预约
                                            orderCycleInfo.NightOrderType = 1;
                                        }

                                        if (visit.MorningCount == orderUserCount)
                                        {
                                            //预约状态，预约已满
                                            orderCycleInfo.NightOrderType = 2;
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        //预约状态，停诊
                                        orderCycleInfo.NightOrderType = 3;
                                    }
                                }
                                #endregion

                                orderCycleList.Add(orderCycleInfo);
                            }
                        }
                    }
                    orderCycleList = orderCycleList.OrderBy(item => item.OrderDateTime).ToList();
                    //出诊周期列表
                    getDoctorInfoResponse.OrderCycleList = orderCycleList;

                    response.Result = getDoctorInfoResponse;
                    response.IsSuccess = true;
                    response.Reason = "";
                }
            }
            catch (Exception ex)
            {

            }
            return Content(response.ToJson());
        }
        #endregion

        #region 获取医生预约信息
        /// <summary>
        /// 获取医生预约信息
        /// </summary>
        /// <param name="request">参数</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult GetDoctorOrderInfo(GetDoctorOrderInfoRequest request)
        {
            ResponseBase<GetDoctorOrderInfoResponse> response = new ResponseBase<GetDoctorOrderInfoResponse>();
            response.IsSuccess = false;
            response.Reason = "系统出错，请联系管理员";

            #region 验证
            if (request == null)
            {
                response.IsSuccess = false;
                response.Reason = "参数不能为空";
                return Content(response.ToJson());
            }

            //验证医生
            if (request.DoctorId < 1)
            {
                response.IsSuccess = false;
                response.Reason = "医生ID输入不正确";
                return Content(response.ToJson());
            }

            //验证预约时间
            if (request.OrderDate == null || request.OrderDate == DateTime.MinValue)
            {
                response.IsSuccess = false;
                response.Reason = "预约时间不正确";
                return Content(response.ToJson());
            }

            //验证午别
            if ((int)request.OrderTimeType < 1 || (int)request.OrderTimeType > 3)
            {
                response.IsSuccess = false;
                response.Reason = "预约午别输入不正确";
                return Content(response.ToJson());
            }

            #endregion

            try
            {
                DoctorEntity doctor = doctorApp.GetList(item => item.DoctorId == request.DoctorId).FirstOrDefault();
                if (doctor == null)
                {
                    response.IsSuccess = false;
                    response.Reason = "未找到医生";
                    return Content(response.ToJson());
                }

                GetDoctorOrderInfoResponse getDoctorOrderInfoResponse = new GetDoctorOrderInfoResponse();

                getDoctorOrderInfoResponse.DoctorId = doctor.DoctorId;
                getDoctorOrderInfoResponse.DoctorName = doctor.DoctorName;
                getDoctorOrderInfoResponse.Title = doctor.Title;
                getDoctorOrderInfoResponse.DoctorOrderType = doctor.Category == true ? NumberTypeEnum.Ordinary : NumberTypeEnum.Expert;
                getDoctorOrderInfoResponse.OrderTimeType = request.OrderTimeType;
                getDoctorOrderInfoResponse.OrderPrice = doctor.Price;
                getDoctorOrderInfoResponse.OrderTime = request.OrderDate;
                getDoctorOrderInfoResponse.OrderType = doctor.OrderType == true ? OrderTypeEnum.Successively : OrderTypeEnum.Segmentation;
                getDoctorOrderInfoResponse.PeriodList = new List<Period>();
                //周几
                int week = (int)request.OrderDate.DayOfWeek;
                if (week == 0)
                {
                    week = 7;
                }

                //判断是否停诊,或者医生出诊是否存在
                var linq = visitApp.GetList(item => item.DoctorId == request.DoctorId && item.Week == week);
                switch (request.OrderTimeType)
                {
                    //上午
                    case OrderTimeTypeEnum.Morning:
                        {
                            linq = linq.Where(item => item.Morning == true);
                        }
                        break;
                    //下午
                    case OrderTimeTypeEnum.Afternoon:
                        {
                            linq = linq.Where(item => item.Afternoon == true);
                        }
                        break;
                    //晚上
                    case OrderTimeTypeEnum.Night:
                        {
                            linq = linq.Where(item => item.Night == true);
                        }
                        break;
                }
                var visit = linq.FirstOrDefault();
                if (visit == null)
                {
                    response.IsSuccess = false;
                    response.Reason = "未找到预约信息";
                    return Content(response.ToJson());
                }
                else
                {
                    if (visit.Stop)
                    {
                        response.IsSuccess = false;
                        response.Reason = "医生已经停诊";
                        return Content(response.ToJson());
                    }
                    else
                    {
                        //查询时间段和预约数量
                        var orderTimeType = (int)request.OrderTimeType;
                        var segmentationList = segmentationOrderApp.GetList(item => item.DoctorId == request.DoctorId && item.OrderTimeType == orderTimeType);

                        if (segmentationList != null && segmentationList.Any())
                        {
                            getDoctorOrderInfoResponse.PeriodList = segmentationList.ToList().Select(item =>
                            {
                                var orderBeginTime = Convert.ToDateTime(request.OrderDate.ToString("yyyy-MM-dd") + " " + item.BeginTime.ToString("HH:mm:ss"));
                                var orderEndTime = Convert.ToDateTime(request.OrderDate.ToString("yyyy-MM-dd") + " " + item.EndTime.ToString("HH:mm:ss"));
                                var orderTime = Convert.ToDateTime(request.OrderDate.ToString("yyyy-MM-dd"));
                                //已经预约数量
                                var list = orderApp.GetList(order =>
                                order.OrderDoctorId == request.DoctorId
                                && order.OrderDate >= orderTime
                                && order.OrderDate <= orderTime
                                && order.BeginTime == orderBeginTime
                                && order.EndTime == orderEndTime
                                && order.OrderType == (int)request.OrderTimeType);
                                var count = 0;
                                if (list != null && list.Any())
                                {
                                    count = list.Count();
                                }

                                return new Period
                                {
                                    BeginTime = item.BeginTime,
                                    EndTime = item.EndTime,
                                    OrderCount = item.OrderCount - count,//可预约数量
                                };
                            }).ToList();
                        }

                    }
                }

                response.Result = getDoctorOrderInfoResponse;
                response.IsSuccess = true;
                response.Reason = "";
            }
            catch (Exception ex)
            {

            }
            return Content(response.ToJson());
        }
        #endregion

        #region 用户预约
        /// <summary>
        /// 用户预约
        /// </summary>
        /// <param name="request">参数</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult UserOder(UserOderRequest request)
        {
            ResponseBase<AddOrderResponse> response = new ResponseBase<AddOrderResponse>();
            response.IsSuccess = false;
            response.Reason = "系统出错，请联系管理员";

            #region 验证
            if (request == null)
            {
                response.IsSuccess = false;
                response.Reason = "参数不能为空";
                return Content(response.ToJson());
            }

            //证件号码
            if (string.IsNullOrWhiteSpace(request.CredentialInformation))
            {
                response.IsSuccess = false;
                response.Reason = "证件号码输入不正确";
                return Content(response.ToJson());
            }

            //全名
            if (string.IsNullOrWhiteSpace(request.FullName))
            {
                response.IsSuccess = false;
                response.Reason = "全名输入不正确";
                return Content(response.ToJson());
            }

            //就诊卡号
            if (string.IsNullOrWhiteSpace(request.VisitingCardNumber))
            {
                response.IsSuccess = false;
                response.Reason = "就诊卡号输入不正确";
                return Content(response.ToJson());
            }

            //性别
            if ((int)request.Gender < 1 || (int)request.Gender > 2)
            {
                response.IsSuccess = false;
                response.Reason = "性别输入不正确";
                return Content(response.ToJson());
            }


            //出生年月
            if (request.DateOfBirth == null || request.DateOfBirth == DateTime.MinValue)
            {
                response.IsSuccess = false;
                response.Reason = "出生年月输入不正确";
                return Content(response.ToJson());
            }

            //联系电话
            if (string.IsNullOrWhiteSpace(request.ContactNumber))
            {
                response.IsSuccess = false;
                response.Reason = "联系电话输入不正确";
                return Content(response.ToJson());
            }

            //E-mail
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                response.IsSuccess = false;
                response.Reason = "E-mail输入不正确";
                return Content(response.ToJson());
            }

            //症状
            if (string.IsNullOrWhiteSpace(request.SymptomDescription))
            {
                response.IsSuccess = false;
                response.Reason = "症状输入不正确";
                return Content(response.ToJson());
            }

            //国籍
            if (string.IsNullOrWhiteSpace(request.Nationality))
            {
                response.IsSuccess = false;
                response.Reason = "国籍输入不正确";
                return Content(response.ToJson());
            }

            //预约医生Id
            if (request.OrderDoctorId < 1)
            {
                response.IsSuccess = false;
                response.Reason = "预约医生Id输入不正确";
                return Content(response.ToJson());
            }

            //预约时间
            if (request.OrderDateTime == null || request.OrderDateTime == DateTime.MinValue)
            {
                response.IsSuccess = false;
                response.Reason = "预约时间输入不正确";
                return Content(response.ToJson());
            }

            //预约时间类型
            if ((int)request.OrderDateTimeType < 1 || (int)request.OrderDateTimeType > 3)
            {
                response.IsSuccess = false;
                response.Reason = "预约时间类型不正确";
                return Content(response.ToJson());
            }

            //预约类型
            if ((int)request.OrderType < 1 || (int)request.OrderType > 2)
            {
                response.IsSuccess = false;
                response.Reason = "预约类型不正确";
                return Content(response.ToJson());
            }

            #endregion

            try
            {
                int orderCycle = 0;

                ////配置文件读取
                int.TryParse(Configs.GetValue("OrderCycle"), out orderCycle);

                var orderBeginDate = DateTime.Now;
                var orderEndDate = DateTime.Now.AddDays(orderCycle);


                //验证预约周期以外时间
                if (request.OrderDateTime < request.OrderDateTime || request.OrderDateTime > orderEndDate)
                {
                    response.IsSuccess = false;
                    response.Reason = "Order Fail";
                    return Content(response.ToJson());
                }

                OrderViewModel orderViewModel = new OrderViewModel();
                orderViewModel.CredentialInformation = request.CredentialInformation;
                orderViewModel.CredentialType = request.CredentialType;
                orderViewModel.FullName = request.FullName;
                orderViewModel.VisitingCardNumber = request.VisitingCardNumber;
                orderViewModel.Gender = request.Gender;
                orderViewModel.DateOfBirth = request.DateOfBirth;
                orderViewModel.ContactNumber = request.ContactNumber;
                orderViewModel.Email = request.Email;
                orderViewModel.Nationality = request.Nationality;
                orderViewModel.SymptomDescription = request.SymptomDescription;
                orderViewModel.OrderDateTime = request.OrderDateTime;
                orderViewModel.OrderDateTimeType = request.OrderDateTimeType;
                orderViewModel.OrderType = request.OrderType;
                orderViewModel.BeginTime = request.BeginTime;
                orderViewModel.EndTime = request.EndTime;
                orderViewModel.OrderDoctorId = request.OrderDoctorId;
                var orderResonse = orderApp.AddOrder(orderViewModel);

                //失败
                if (!orderResonse.IsSuccess)
                {
                    response.IsSuccess = false;
                    response.Reason = orderResonse.Reason;
                    return Content(response.ToJson());
                }
                response.IsSuccess = true;
                response.Result = orderResonse;
            }
            catch (Exception ex)
            {

            }
            return Content(response.ToJson());
        }
        #endregion

        #region 获取预约列表
        /// <summary>
        /// 获取预约列表
        /// </summary>
        /// <param name="request">参数</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult GetOrderList(GetOrderListRequest request)
        {
            ResponseBase<List<GetOrderListResponse>> response = new ResponseBase<List<GetOrderListResponse>>();
            response.IsSuccess = false;
            response.Reason = "系统出错，请联系管理员";
            List<GetOrderListResponse> list = new List<GetOrderListResponse>();
            response.Result = list;
            #region 验证
            if (request == null)
            {
                response.IsSuccess = false;
                response.Reason = "参数不能为空";
                return Content(response.ToJson());
            }

            //全名
            if (string.IsNullOrWhiteSpace(request.FullName))
            {
                response.IsSuccess = false;
                response.Reason = "全名不正确";
                return Content(response.ToJson());
            }

            //护照
            if (string.IsNullOrWhiteSpace(request.FullName))
            {
                response.IsSuccess = false;
                response.Reason = "护照不正确";
                return Content(response.ToJson());
            }

            #endregion

            try
            {
                // orderApp.AddOrder(orderViewModel);

                //获取用户信息
                var member = memberApp.GetList(item => item.FullName == request.FullName && item.CredentialType == (int)CredentialTypeEnum.Passport && item.CredentialInformation == request.PassportNo).FirstOrDefault();
                if (member != null)
                {
                    request.MemberId = member.MemberId;
                    var orderList = orderApp.GetOrderList(request);

                    //预约信息
                    if (orderList != null && orderList.Any())
                    {
                        foreach (var order in orderList)
                        {
                            GetOrderListResponse getOrderListResponse = new GetOrderListResponse();
                            getOrderListResponse.FullName = member.FullName.ToString();
                            getOrderListResponse.Gender = (GenderEnum)member.Gender;
                            getOrderListResponse.DateOfBirth = member.DateOfBirth;
                            getOrderListResponse.IdentificationNumber = member.CredentialInformation;
                            getOrderListResponse.CellPhone = member.ContactNumber;

                            getOrderListResponse.Description = order.SymptomDescription;
                            getOrderListResponse.Appointment = order.OrderDate.ToString();
                            getOrderListResponse.Operating = order.AddDate;

                            list.Add(getOrderListResponse);
                        }
                    }
                    response.IsSuccess = true;
                    response.Result = list;
                }
                else
                {
                    //没有找到信息
                    response.IsSuccess = true;
                }

            }
            catch (Exception ex)
            {

            }
            return Content(response.ToJson());
        }
        #endregion
    }
    #endregion
}
