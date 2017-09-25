using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.ViewModel
{
    /// <summary>
    /// 获取医生信息响应
    /// </summary>
    public class GetDoctorInfoResponse
    {
        /// <summary>
        /// 医生Id
        /// </summary>
        public int DoctorId
        {
            get;
            set;
        }

        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DoctorName
        {
            get;
            set;
        }

        /// <summary>
        /// 擅长
        /// </summary>
        public string GootAt
        {
            get;
            set;
        }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string Avatar
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
        /// 医生性别
        /// </summary>
        public int Gender
        {
            get;
            set;
        }

        /// <summary>
        /// 预约周期
        /// </summary>
        public int OrderCycle
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
        /// 预约星期详情
        /// </summary>
        public List<OrderCycle> OrderCycleList
        {
            get;
            set;
        }


    }

    /// <summary>
    /// 预约周期
    /// </summary>
    public class OrderCycle
    {
        /// <summary>
        /// 星期
        /// </summary>
        public int Week
        {
            get;
            set;
        }

        /// <summary>
        /// 上午预约状态
        /// 1:可预约
        /// 2:预约满
        /// 3:停诊
        /// </summary>
        public int MorningOrderType
        {
            get;
            set;
        }

        /// <summary>
        /// 上午预约数量
        /// </summary>
        public int MorningOrderCount
        {
            get;
            set;
        }

        /// <summary>
        /// 下午预约状态
        /// </summary>
        public int AfterNoonOrderType
        {
            get;
            set;
        }


        /// <summary>
        /// 下午预约数量
        /// </summary>
        public int AfterNoonOrderCount
        {
            get;
            set;
        }

        /// <summary>
        /// 晚上预约状态
        /// </summary>
        public int NightOrderType
        {
            get;
            set;
        }


        /// <summary>
        /// 晚上预约数量
        /// </summary>
        public int NightOrderCount
        {
            get;
            set;
        }

        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime OrderDateTime
        {
            set;
            get;
        }
    }

    /// <summary>
    /// 预约信息
    /// </summary>

    public class OrderDateTimeInfo
    {
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime OrderDateTime
        {
            set;
            get;
        }

        /// <summary>
        /// 预约时间类型
        /// 1:上午
        /// 2:下午
        /// 3:晚上
        /// </summary>
        public int OrderDateTimeType
        {
            set;
            get;
        }

        /// <summary>
        /// 预约数量
        /// </summary>
        public int OrderCount
        {
            get;
            set;
        }

        /// <summary>
        /// 预约星期
        /// </summary>
        public int Week
        {
            get;
            set;
        }
    }
}
