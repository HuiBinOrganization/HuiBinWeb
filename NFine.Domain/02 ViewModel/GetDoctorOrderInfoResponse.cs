
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain.Entity.Enums;
using System;

namespace NFine.Domain.ViewModel
{
    /// <summary>
    /// 获取医生预约信息响应
    /// </summary>
    public class GetDoctorOrderInfoResponse
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
        /// 职称
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 医生号别
        /// </summary>
        public NumberTypeEnum DoctorOrderType
        {
            get;
            set;
        }

        /// <summary>
        /// 午别
        /// </summary>
        public OrderTimeTypeEnum OrderTimeType
        {
            get;
            set;
        }

        /// <summary>
        /// 挂号费
        /// </summary>
        public float OrderPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime OrderTime
        {
            get;
            set;
        }

        /// <summary>
        /// 预约类型
        /// </summary>
        public OrderTypeEnum OrderType
        {
            get;
            set;
        }

        /// <summary>
        /// 分段列表
        /// </summary>
        public List<Period> PeriodList
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 分段
    /// </summary>
    public class Period
    {
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
        /// 可预约数量
        /// </summary>
        public int OrderCount
        {
            get;
            set;
        }
    }
}
