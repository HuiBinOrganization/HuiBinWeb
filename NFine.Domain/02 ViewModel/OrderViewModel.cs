using NFine.Domain.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.ViewModel
{
    /// <summary>
    /// 预约
    /// </summary>
    public class OrderViewModel
    {
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CredentialInformation
        {
            get;
            set;
        }

        /// <summary>
        /// 证件号码
        /// </summary>
        public CredentialTypeEnum CredentialType
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
        /// 就诊卡号
        /// </summary>
        public string VisitingCardNumber
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
        /// 联系电话
        /// </summary>
        public string ContactNumber
        {
            get;
            set;
        }


        /// <summary>
        /// E-mail
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// 症状
        /// </summary>
        public string SymptomDescription
        {
            get;
            set;
        }

        /// <summary>
        /// 国籍
        /// </summary>
        public int Nationality
        {
            get;
            set;
        }


        /// <summary>
        /// 预约医生
        /// </summary>

        public int OrderDoctorId
        {
            get;
            set;
        }

        /// <summary>
        /// 预约时间
        /// </summary>

        public DateTime OrderDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 预约时间类型
        /// </summary>

        public OrderTimeTypeEnum OrderDateTimeType
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
        /// 分时间预约使用,依次预约为空
        /// 预约开始时间
        /// </summary>

        public DateTime? BeginTime
        {
            get;
            set;
        }

        /// <summary>
        /// 分时间预约使用,依次预约为空
        /// 预约结束时间
        /// </summary>

        public DateTime? EndTime
        {
            get;
            set;
        }

      
    }
}
