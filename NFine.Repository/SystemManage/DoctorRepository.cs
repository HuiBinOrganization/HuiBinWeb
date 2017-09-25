using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
namespace NFine.IRepository.SystemManage
{
    /// <summary>
    /// 医生表
    /// </summary>
    public class DoctorRepository : RepositoryBase<DoctorEntity>, IDoctorRepository
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
        public void SubmitForm(DoctorViewModel model)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                //添加医生信息
                DoctorEntity entity = new DoctorEntity();
                entity.DoctorName = model.Name;
                entity.GootAt = model.Experties;
                entity.Avatar = "";
                entity.Title = model.Title;
                entity.Introduction = model.Introduction;
                entity.Gender = model.Gender;
                entity.Category = model.Category;
                entity.Price = model.Price;
                // entity.OrderType = model.OrderType==tru;
                entity.AddDate = DateTime.Now;
                db.Insert(entity);

                List<VisitEntity> visitList = new List<VisitEntity>();
                VisitEntity visit = new VisitEntity();

                #region 星期一
                //坐诊信息
                visit.Week = 1;//星期一
                visit.Morning = model.MondayMorning;
                visit.Afternoon = model.MondayAfternoon;
                visit.Night = model.MondayNight;
                visit.Stop = model.MondayStop;
                visit.DoctorId = entity.DoctorId;
                visit.AddDate = DateTime.Now;
                SetVisit(visit, visit.Morning, visit.Afternoon, visit.Night, model);
                visitList.Add(visit);
                #endregion

                #region 星期二
                visit = new VisitEntity();
                //坐诊信息
                visit.Week = 2;//星期二
                visit.Morning = model.TuesdayMorning;
                visit.Afternoon = model.TuesdayAfternoon;
                visit.Night = model.TuesdayNight;
                visit.Stop = model.TuesdayStop;
                visit.DoctorId = entity.DoctorId;
                visit.AddDate = DateTime.Now;
                SetVisit(visit, visit.Morning, visit.Afternoon, visit.Night, model);
                visitList.Add(visit);
                #endregion

                #region 星期三
                visit = new VisitEntity();
                //坐诊信息
                visit.Week = 3;//星期三
                visit.Morning = model.WednesdayMorning;
                visit.Afternoon = model.WednesdayAfternoon;
                visit.Night = model.WednesdayNight;
                visit.Stop = model.WednesdayStop;
                visit.DoctorId = entity.DoctorId;
                visit.AddDate = DateTime.Now;
                SetVisit(visit, visit.Morning, visit.Afternoon, visit.Night, model);
                visitList.Add(visit);
                #endregion

                #region 星期四
                visit = new VisitEntity();
                //坐诊信息
                visit.Week = 4;//星期四
                visit.Morning = model.ThursdayMorning;
                visit.Afternoon = model.ThursdayAfternoon;
                visit.Night = model.ThursdayNight;
                visit.Stop = model.ThursdayStop;
                visit.DoctorId = entity.DoctorId;
                visit.AddDate = DateTime.Now;
                SetVisit(visit, visit.Morning, visit.Afternoon, visit.Night, model);
                visitList.Add(visit);
                #endregion

                #region 星期五
                visit = new VisitEntity();
                //坐诊信息
                visit.Week = 5;//星期五
                visit.Morning = model.FridayMorning;
                visit.Afternoon = model.FridayAfternoon;
                visit.Night = model.FridayNight;
                visit.Stop = model.FridayStop;
                visit.DoctorId = entity.DoctorId;
                visit.AddDate = DateTime.Now;
                SetVisit(visit, visit.Morning, visit.Afternoon, visit.Night, model);
                visitList.Add(visit);
                #endregion

                #region 星期六
                visit = new VisitEntity();
                //坐诊信息
                visit.Week = 6;//星期六
                visit.Morning = model.SaturdayMorning;
                visit.Afternoon = model.SaturdayAfternoon;
                visit.Night = model.SaturdayNight;
                visit.Stop = model.SaturdayStop;
                visit.DoctorId = entity.DoctorId;
                visit.AddDate = DateTime.Now;
                SetVisit(visit, visit.Morning, visit.Afternoon, visit.Night, model);
                visitList.Add(visit);
                #endregion

                #region 星期日
                visit = new VisitEntity();
                //坐诊信息
                visit.Week = 7;//星期日
                visit.Morning = model.SundayMorning;
                visit.Afternoon = model.SundayAfternoon;
                visit.Night = model.SundayNight;
                visit.Stop = model.SundayStop;
                visit.DoctorId = entity.DoctorId;
                visit.AddDate = DateTime.Now;
                SetVisit(visit, visit.Morning, visit.Afternoon, visit.Night, model);
                visitList.Add(visit);
                #endregion

                //添加坐诊
                db.Insert(visitList);

                //添加分时段
                List<SegmentationOrderEntity> segmentationOrderList = new List<SegmentationOrderEntity>();

                //上午分时段
                if (model.MorningSegmentationCount > 0)
                {
                    if (model.MorningSegmentationOrderList != null && model.MorningSegmentationOrderList.Any())
                    {
                        foreach (var segmentation in model.MorningSegmentationOrderList)
                        {
                            SegmentationOrderEntity segmentationOrder = new SegmentationOrderEntity();
                            segmentationOrder.OrderTimeType = 1;//上午
                            segmentationOrder.BeginTime = segmentation.BeginTime;
                            segmentationOrder.EndTime = segmentation.EndTime;
                            segmentationOrder.OrderCount = segmentation.OrderCount;
                            segmentationOrder.AddDate = DateTime.Now;
                            segmentationOrder.DoctorId = entity.DoctorId;
                            segmentationOrderList.Add(segmentationOrder);
                        }
                    }
                }

                //下午分时段
                if (model.AfternoonSegmentationCount > 0)
                {
                    if (model.AfternoonSegmentationOrderList != null && model.AfternoonSegmentationOrderList.Any())
                    {
                        foreach (var segmentation in model.AfternoonSegmentationOrderList)
                        {
                            SegmentationOrderEntity segmentationOrder = new SegmentationOrderEntity();
                            segmentationOrder.OrderTimeType = 2;//下午
                            segmentationOrder.BeginTime = segmentation.BeginTime;
                            segmentationOrder.EndTime = segmentation.EndTime;
                            segmentationOrder.OrderCount = segmentation.OrderCount;
                            segmentationOrder.AddDate = DateTime.Now;
                            segmentationOrder.DoctorId = entity.DoctorId;
                            segmentationOrderList.Add(segmentationOrder);
                        }


                    }
                }

                //晚上分时段
                if (model.NightSegmentationCount > 0)
                {
                    if (model.NightSegmentationOrderList != null && model.NightSegmentationOrderList.Any())
                    {
                        foreach (var segmentation in model.NightSegmentationOrderList)
                        {
                            SegmentationOrderEntity segmentationOrder = new SegmentationOrderEntity();
                            segmentationOrder.OrderTimeType = 3;//晚上
                            segmentationOrder.BeginTime = segmentation.BeginTime;
                            segmentationOrder.EndTime = segmentation.EndTime;
                            segmentationOrder.OrderCount = segmentation.OrderCount;
                            segmentationOrder.AddDate = DateTime.Now;
                            segmentationOrder.DoctorId = entity.DoctorId;
                            segmentationOrderList.Add(segmentationOrder);
                        }
                    }
                }

                if (segmentationOrderList.Any())
                {
                    //添加分时段
                    db.Insert(segmentationOrderList);
                }

                db.Commit();
            }
        }

        /// <summary>
        /// 设置预约
        /// </summary>
        /// <param name="visit">预约</param>
        /// <param name="morning">上午是否预约</param>
        /// <param name="afternoon">下午是否预约</param>
        /// <param name="night">晚上是否预约</param>
        /// <param name="model">医生信息</param>
        private void SetVisit(VisitEntity visit,
            bool morning,
            bool afternoon,
            bool night,
            DoctorViewModel model)
        {
            #region 星期一
            //计算上午预约数量
            //星期一上午预约
            if (morning)
            {
                //依次预约
                if (model.MorningSegmentationCount == 0)
                {
                    visit.MorningCount = model.MorningOrderCount;
                }
                else
                {
                    //存在分段数量
                    if (model.MorningSegmentationOrderList != null && model.MorningSegmentationOrderList.Any())
                    {
                        //分时间预约
                        visit.MorningCount = model.MorningSegmentationOrderList.Sum(item => item.OrderCount);
                    }
                }
            }

            //星期一上午预约
            if (afternoon)
            {
                //依次预约
                if (model.AfternoonSegmentationCount == 0)
                {
                    visit.AfternoonCount = model.AfternoonOrderCount;
                }
                else
                {
                    //存在分段数量
                    if (model.AfternoonSegmentationOrderList != null && model.AfternoonSegmentationOrderList.Any())
                    {
                        //分时间预约
                        visit.AfternoonCount = model.AfternoonSegmentationOrderList.Sum(item => item.OrderCount);
                    }
                }
            }

            //星期一晚上预约
            if (night)
            {
                //依次预约
                if (model.NightSegmentationCount == 0)
                {
                    visit.NightCount = model.NightOrderCount;
                }
                else
                {
                    //存在分段数量
                    if (model.NightSegmentationOrderList != null && model.NightSegmentationOrderList.Any())
                    {
                        //分时间预约
                        visit.NightCount = model.NightSegmentationOrderList.Sum(item => item.OrderCount);
                    }
                }
            }
            #endregion
        }
    }
}