using NFine.Domain.Entity.Enums;
using System;

namespace NFine.Domain.Entity.SystemManage
{
    /// <summary>
    /// 预约表
    /// </summary>
    public partial class OrderEntity : IEntity<OrderEntity>
    {
    
      
        /// <summary>
        /// 预约Id
        /// </summary>
        public int OrderId
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 预约医生Id
        /// </summary>
        public int OrderDoctorId
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
        /// 预约午别 1:上午 2:下午 3:晚上
        /// </summary>
        public int OrderType
        {
            get;
            set;
        }  
    
        /// <summary>
        /// <div style="border-style: none; position: relative; z-index: 1; left: 7px; width: 689px; ">医生号别 1:普通号 </div>2:专家号
        /// </summary>
        public int DorderType
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            get;
            set;
        }  

        /// <summary>
        /// 患者Id
        /// </summary>
        public int MemberId
        {
            get;
            set;
        }

        /// <summary>
        /// 午别
        /// </summary>
        public OrderTimeTypeEnum Category
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
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime
        {
            get;
            set;
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime
        {
            get;
            set;
        }

        /// <summary>
        /// 预约类型
        /// </summary>
        public int NumberType
        {
            get;
            set;
        }

        /// <summary>
        /// 预约号
        /// </summary>
        public string OrderNumber
        {
            get;
            set;
        }
    }
}