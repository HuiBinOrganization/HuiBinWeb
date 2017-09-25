using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.ViewModel
{
    /// <summary>
    /// 医生
    /// </summary>
    public class DoctorViewModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender
        {
            get;
            set;
        }

        /// <summary>
        /// 号别
        /// </summary>
        public bool Category
        {
            get;
            set;
        }

        /// <summary>
        /// 职称
        /// </summary>
        public string Title
        {
            get;
            set;
        }


        /// <summary>
        /// 挂号费
        /// </summary>
        public float Price
        {
            get;
            set;
        }

        /// <summary>
        /// 专长
        /// </summary>
        public string Experties
        {
            get;
            set;
        }

        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction
        {
            get;
            set;
        }

        /// <summary>
        /// 星期一上午
        /// </summary>
        public bool MondayMorning
        {
            get;
            set;
        }

        /// <summary>
        /// 星期一下午
        /// </summary>
        public bool MondayAfternoon
        {
            get;
            set;
        }

        /// <summary>
        /// 星期一晚上
        /// </summary>
        public bool MondayNight
        {
            get;
            set;
        }

        /// <summary>
        /// 星期一停诊
        /// </summary>
        public bool MondayStop
        {
            get;
            set;
        }

        

        /// <summary>
        /// 星期二上午
        /// </summary>
        public bool TuesdayMorning
        {
            get;
            set;
        }

        /// <summary>
        /// 星期二下午
        /// </summary>
        public bool TuesdayAfternoon
        {
            get;
            set;
        }

        /// <summary>
        /// 星期二晚上
        /// </summary>
        public bool TuesdayNight
        {
            get;
            set;
        }

        /// <summary>
        /// 星期二停诊
        /// </summary>
        public bool TuesdayStop
        {
            get;
            set;
        }

        /// <summary>
        /// 星期三上午
        /// </summary>
        public bool WednesdayMorning
        {
            get;
            set;
        }

        /// <summary>
        /// 星期三下午
        /// </summary>
        public bool WednesdayAfternoon
        {
            get;
            set;
        }

        /// <summary>
        /// 星期三晚上
        /// </summary>
        public bool WednesdayNight
        {
            get;
            set;
        }

        /// <summary>
        /// 星期三停诊
        /// </summary>
        public bool WednesdayStop
        {
            get;
            set;
        }

        /// <summary>
        /// 星期四上午
        /// </summary>
        public bool ThursdayMorning
        {
            get;
            set;
        }

        /// <summary>
        /// 星期四下午
        /// </summary>
        public bool ThursdayAfternoon
        {
            get;
            set;
        }

        /// <summary>
        /// 星期四晚上
        /// </summary>
        public bool ThursdayNight
        {
            get;
            set;
        }

        /// <summary>
        /// 星期四停诊
        /// </summary>
        public bool ThursdayStop
        {
            get;
            set;
        }

        /// <summary>
        /// 星期五上午
        /// </summary>
        public bool FridayMorning
        {
            get;
            set;
        }

        /// <summary>
        /// 星期五下午
        /// </summary>
        public bool FridayAfternoon
        {
            get;
            set;
        }

        /// <summary>
        /// 星期五晚上
        /// </summary>
        public bool FridayNight
        {
            get;
            set;
        }

        /// <summary>
        /// 星期五停诊
        /// </summary>
        public bool FridayStop
        {
            get;
            set;
        }


        /// <summary>
        /// 星期六上午
        /// </summary>
        public bool SaturdayMorning
        {
            get;
            set;
        }

        /// <summary>
        /// 星期六下午
        /// </summary>
        public bool SaturdayAfternoon
        {
            get;
            set;
        }

        /// <summary>
        /// 星期六晚上
        /// </summary>
        public bool SaturdayNight
        {
            get;
            set;
        }

        /// <summary>
        /// 星期六停诊
        /// </summary>
        public bool SaturdayStop
        {
            get;
            set;
        }


        /// <summary>
        /// 星期日上午
        /// </summary>
        public bool SundayMorning
        {
            get;
            set;
        }

        /// <summary>
        /// 星期日下午
        /// </summary>
        public bool SundayAfternoon
        {
            get;
            set;
        }

        /// <summary>
        /// 星期日晚上
        /// </summary>
        public bool SundayNight
        {
            get;
            set;
        }

        /// <summary>
        /// 星期日停诊
        /// </summary>
        public bool SundayStop
        {
            get;
            set;
        }

        /// <summary>
        /// 上午分段数
        /// </summary>
        public int MorningSegmentationCount
        {
            get;
            set;
        }

        /// <summary>
        /// 上午预约数
        /// </summary>
        public int MorningOrderCount
        {
            get;
            set;
        }

        /// <summary>
        /// 下午分段数
        /// </summary>
        public int AfternoonSegmentationCount
        {
            get;
            set;
        }

        /// <summary>
        /// 下午预约数
        /// </summary>
        public int AfternoonOrderCount
        {
            get;
            set;
        }


        /// <summary>
        /// 晚上分段数
        /// </summary>
        public int NightSegmentationCount
        {
            get;
            set;
        }

        /// <summary>
        /// 晚上预约数
        /// </summary>
        public int NightOrderCount
        {
            get;
            set;
        }

        /// <summary>
        /// 上午分段
        /// </summary>

        public List<SegmentationOrder> MorningSegmentationOrderList
        {
            get;
            set;
        }

        /// <summary>
        /// 下午分段
        /// </summary>

        public List<SegmentationOrder> AfternoonSegmentationOrderList
        {
            get;
            set;
        }

        /// <summary>
        /// 晚上分段
        /// </summary>

        public List<SegmentationOrder> NightSegmentationOrderList
        {
            get;
            set;
        }

    }

    /// <summary>
    /// 分段预约
    /// </summary>
    public class SegmentationOrder
    {
        /// <summary>
        /// 预约时间类型
        /// 1:上午
        /// 2:下午
        /// 3:晚上
        /// </summary>
        public int OrderTimeType
        {
            get;
            set;
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime
        {
            get;
            set;
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get;
            set;
        }

        /// <summary>
        /// 预约数量
        /// </summary>
        public int OrderCount
        {
            get;
            set;
        }
    }
}
