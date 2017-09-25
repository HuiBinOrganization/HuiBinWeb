using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.ViewModel
{
    /// <summary>
    /// 获取预约列表信息
    /// </summary>
    public class GetOrderListRequest
    {
        /// <summary>
        /// 全名
        /// </summary>
        public string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// 护照
        /// </summary>
        public string PassportNo
        {
            get;
            set;
        }

        /// <summary>
        /// 会员信息
        /// </summary>
        public int MemberId
        {
            get;
            set;
        }
    }
}
