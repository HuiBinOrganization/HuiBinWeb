using NFine.Domain.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.ViewModel
{
    /// <summary>
    /// 获取预约列表信息，响应
    /// </summary>
    public class GetOrderListResponse
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
        /// 性别
        /// </summary>
        public GenderEnum Gender
        {
            get;
            set;
        }

        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        /// <summary>
        /// 证件
        /// </summary>
        public string IdentificationNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 症状
        /// </summary>
        public string Description
        {
            get;
            set;
        }


        /// <summary>
        /// 电话
        /// </summary>
        public string CellPhone
        {
            get;
            set;
        }

        /// <summary>
        /// 预约时间点
        /// </summary>
        public string Appointment
        {
            get;
            set;
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime Operating
        {
            get;
            set;
        }
    }
}
