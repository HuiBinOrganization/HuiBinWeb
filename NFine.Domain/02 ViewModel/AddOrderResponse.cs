using NFine.Domain.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.ViewModel
{
    /// <summary>
    /// 预约响应
    /// </summary>
    public class AddOrderResponse
    {
        /// <summary>
        /// 预约号
        /// </summary>
        public string OrderNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 全名
        /// </summary>
        public string FullName
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
        /// 预约开始时间
        /// </summary>
        public DateTime BeginTime
        {
            get;
            set;
        }

        /// <summary>
        /// 预约结束时间
        /// </summary>
        public DateTime EndTime
        {
            get;
            set;
        }

        /// <summary>
        /// 预约类型 
        /// 1:依次
        /// 2:分时段
        /// </summary>
        public OrderTypeEnum NumberType
        {
            get;
            set;
        }

        /// <summary>
        /// 预约时间类型
        /// 1:上午
        /// 2:下午
        /// 3:晚上
        /// </summary>
        public OrderTimeTypeEnum OrderTimeType
        {
            get;
            set;
        }
    }
}
