using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.ViewModel
{
    /// <summary>
    /// 获取医生列表返回值
    /// </summary>
    public class GetDoctorListResponse
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
        /// 出诊时间
        /// </summary>
        public List<int> VisitList
        {
            get;
            set;
        }
    }
}
