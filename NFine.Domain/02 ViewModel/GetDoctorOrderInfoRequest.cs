using NFine.Domain.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.ViewModel
{
    /// <summary>
    /// 获取医生预约信息请求参数
    /// </summary>
    public class GetDoctorOrderInfoRequest
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
        /// 预约时间
        /// </summary>
        public DateTime OrderDate
        {
            get;
            set;
        }

        /// <summary>
        /// 预约时间
        /// </summary>
        public OrderTimeTypeEnum OrderTimeType
        {
            get;
            set;
        }
    }
}
