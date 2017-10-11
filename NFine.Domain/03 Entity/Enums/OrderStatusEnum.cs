using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.Entity.Enums
{
    /// <summary>
    /// 预约状态
    /// </summary>
    public enum OrderStatusEnum
    {
        /// <summary>
        /// 未就诊
        /// </summary>
        NoTreatment=0,
        /// <summary>
        /// 已就诊
        /// </summary>
        Treatmented = 1,
        /// <summary>
        /// 爽约
        /// </summary>
        Translate = 2,
        /// <summary>
        /// 停诊
        /// </summary>
        Stop = 2,
    }
}
