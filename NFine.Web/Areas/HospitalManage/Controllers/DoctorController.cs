
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFine.Domain.ViewModel;
using NFine.Application.SystemManage;
using NFine.Code;

namespace NFine.Web.Areas.HospitalManage.Controllers
{
    public class DoctorController : ControllerBase
    {
        private DoctorApp doctorApp = new DoctorApp();
        private VisitApp visitApp = new VisitApp();
        private SegmentationOrderApp segmentationOrderApp = new SegmentationOrderApp();
        private StopApp stopApp = new StopApp();

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(DoctorViewModel model, string permissionIds, string keyValue)
        {
            doctorApp.SubmitForm(model, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitStopForm(StopDoctorViewModel model, string permissionIds, string keyValue)
        {
            var doctorId = 0;
            int.TryParse(keyValue, out doctorId);
            model.DoctorId = doctorId;
            stopApp.DoctorStop(model);
            return Success("操作成功。");
        }


        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            int doctorId = 0;
            int.TryParse(keyValue, out doctorId);
            var doctor = doctorApp.GetList(item => item.DoctorId == doctorId).FirstOrDefault();
            DoctorViewModel model = new DoctorViewModel();
            if (doctor != null)
            {
                model.DoctorId = doctor.DoctorId;
                model.Name = doctor.DoctorName;
                model.Gender = doctor.Gender;
                model.Category = doctor.Category;
                model.Title = doctor.Title;
                model.Price = doctor.Price;
                model.Experties = doctor.GootAt;
                model.Introduction = doctor.Introduction;
            }

            #region 获取出诊信息
            //获取出诊信息
            var visitList = visitApp.GetList(item => item.DoctorId == doctorId);
            if (visitList != null && visitList.Any())
            {
                foreach (var visit in visitList)
                {
                    switch (visit.Week)
                    {
                        //星期一
                        case 1:
                            {
                                model.MondayMorning = visit.Morning;
                                model.MondayAfternoon = visit.Afternoon;
                                model.MondayNight = visit.Night;
                            }
                            break;
                        //星期二
                        case 2:
                            {
                                model.TuesdayMorning = visit.Morning;
                                model.TuesdayAfternoon = visit.Afternoon;
                                model.TuesdayNight = visit.Night;
                            }
                            break;
                        //星期三
                        case 3:
                            {
                                model.WednesdayMorning = visit.Morning;
                                model.WednesdayAfternoon = visit.Afternoon;
                                model.WednesdayNight = visit.Night;
                            }
                            break;
                        //星期四
                        case 4:
                            {
                                model.ThursdayMorning = visit.Morning;
                                model.ThursdayAfternoon = visit.Afternoon;
                                model.ThursdayNight = visit.Night;
                            }
                            break;
                        //星期五
                        case 5:
                            {
                                model.FridayMorning = visit.Morning;
                                model.FridayAfternoon = visit.Afternoon;
                                model.FridayNight = visit.Night;
                            }
                            break;
                        //星期六
                        case 6:
                            {
                                model.SaturdayMorning = visit.Morning;
                                model.SaturdayAfternoon = visit.Afternoon;
                                model.SaturdayNight = visit.Night;
                            }
                            break;
                        //星期日
                        case 7:
                            {
                                model.SundayMorning = visit.Morning;
                                model.SundayAfternoon = visit.Afternoon;
                                model.SundayNight = visit.Night;
                            }
                            break;
                    }
                }

             
              
                
            }
            #endregion

            #region 分时段
            var segmetnationList = segmentationOrderApp.GetList(item => item.DoctorId == doctorId).OrderBy(item => item.OrderTimeType);
            if (segmetnationList != null && segmetnationList.Any())
            {

                #region 上午
                //上午
                var morningList = segmetnationList.Where(item => item.OrderTimeType == 1);
                if (morningList != null && morningList.Any())
                {
                    List<SegmentationOrder> list = new List<SegmentationOrder>();

                    //分段预约数量
                    string segmentationOrderCount = string.Empty;
                    foreach (var segmentation in morningList)
                    {

                        SegmentationOrder segmentationOrder = new SegmentationOrder();
                        segmentationOrder.OrderCount = segmentation.OrderCount;
                        segmentationOrder.OrderTimeType = segmentation.OrderTimeType;
                        segmentationOrder.BeginTime = segmentation.BeginTime;
                        segmentationOrder.EndTime = segmentation.EndTime;
                        list.Add(segmentationOrder);
                        segmentationOrderCount += segmentation.OrderCount + ",";
                    }

                    segmentationOrderCount = segmentationOrderCount.TrimEnd(',');
                    model.MorningSegmentationOrderList = list;

                    //上午预约数量
                    model.MorningOrderCount = list.Sum(item => item.OrderCount);
                    model.MorningSegmentationOrderCount = segmentationOrderCount;
                }
                #endregion

                #region 下午
                //下午
                var afternoonList = segmetnationList.Where(item => item.OrderTimeType == 2);
                if (afternoonList != null && afternoonList.Any())
                {
                    List<SegmentationOrder> list = new List<SegmentationOrder>();
                    //分段预约数量
                    string segmentationOrderCount = string.Empty;
                    foreach (var segmentation in afternoonList)
                    {

                        SegmentationOrder segmentationOrder = new SegmentationOrder();
                        segmentationOrder.OrderCount = segmentation.OrderCount;
                        segmentationOrder.OrderTimeType = segmentation.OrderTimeType;
                        segmentationOrder.BeginTime = segmentation.BeginTime;
                        segmentationOrder.EndTime = segmentation.EndTime;
                        list.Add(segmentationOrder);
                        segmentationOrderCount += segmentation.OrderCount + ",";
                    }
                    segmentationOrderCount = segmentationOrderCount.TrimEnd(',');
                    model.AfternoonSegmentationOrderList = list;

                    //下午预约数量
                    model.AfternoonOrderCount = list.Sum(item => item.OrderCount);
                    model.AfternoonSegmentationOrderCount = segmentationOrderCount;
                }
                #endregion

                #region 晚上
                var nightList = segmetnationList.Where(item => item.OrderTimeType == 3);
                if (nightList != null && nightList.Any())
                {
                    List<SegmentationOrder> list = new List<SegmentationOrder>();
                    //分段预约数量
                    string segmentationOrderCount = string.Empty;
                    foreach (var segmentation in nightList)
                    {

                        SegmentationOrder segmentationOrder = new SegmentationOrder();
                        segmentationOrder.OrderCount = segmentation.OrderCount;
                        segmentationOrder.OrderTimeType = segmentation.OrderTimeType;
                        segmentationOrder.BeginTime = segmentation.BeginTime;
                        segmentationOrder.EndTime = segmentation.EndTime;
                        list.Add(segmentationOrder);
                        segmentationOrderCount += segmentation.OrderCount + ",";
                    }
                    model.NightSegmentationOrderList = list;

                    //预约数量
                    model.NightOrderCount = list.Sum(item => item.OrderCount);
                    segmentationOrderCount = segmentationOrderCount.TrimEnd(',');
                    model.NightSegmentationOrderCount = segmentationOrderCount;
                }
                #endregion

                //分段数量
                //上午
                var segmentationCountList = segmetnationList.Where(item => item.OrderTimeType == 1);
                if (segmentationCountList != null && segmentationCountList.Any())
                {
                    model.MorningSegmentationCount = segmentationCountList.Count();
                }

                //下午
                segmentationCountList = segmetnationList.Where(item => item.OrderTimeType == 2);
                if (segmentationCountList != null && segmentationCountList.Any())
                {
                    model.AfternoonSegmentationCount = segmentationCountList.Count();
                }

                //晚上
                segmentationCountList = segmetnationList.Where(item => item.OrderTimeType == 3);
                if (segmentationCountList != null && segmentationCountList.Any())
                {
                    model.NightSegmentationCount = segmentationCountList.Count();
                }

            }
            else
            {
                if (visitList != null && visitList.Any())
                {
                    model.MorningOrderCount = visitList.Max(item => item.MorningCount);
                    model.AfternoonOrderCount = visitList.Max(item => item.AfternoonCount);
                    model.NightOrderCount = visitList.Max(item => item.NightCount);
                }
              
            }
            #endregion

            return Content(model.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetStopFormJson(string keyValue)
        {
          
            StopViewModel model = new StopViewModel();
            model.CloseDate = DateTime.Now.ToString("yyyy-MM-dd");
            return Content(model.ToJson());
        }


        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Stop()
        {
            return View();
        }

        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult StopList()
        {
            return View();
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = doctorApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDoctorStopListGrid(Pagination pagination, string keyValue)
        {
            var data = new
            {
                rows = stopApp.GetList(pagination, keyValue),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult DeleteForm(string keyValue)
        {
            var doctorId = 0;
            int.TryParse(keyValue, out doctorId);
            doctorApp.DeleteForm(doctorId);
            return Success("删除成功。");
        }
    }
}
