using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.Entity.Enums
{
    /// <summary>
    /// 预约类型
    /// </summary>
    public enum OrderTypeEnum
    {
        /// <summary>
        /// 依次
        /// </summary>
        Successively=1,
        /// <summary>
        /// 分时段
        /// </summary>
        Segmentation=2,
    }
}
