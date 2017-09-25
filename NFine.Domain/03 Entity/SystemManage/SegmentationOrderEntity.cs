using System;
namespace NFine.Domain.Entity.SystemManage
{
    /// <summary>
    /// 分时间预约
    /// </summary>
    public partial class SegmentationOrderEntity : IEntity<RoleEntity>
    {
        /// <summary>
        /// 分时间预约Id
        /// </summary>
        public int SegmentationOrderId
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 预约时间类型 1:上午 2:下午 3:晚上
        /// </summary>
        public int OrderTimeType
        {
            get;
            set;
        }  
    
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
        /// 预约数量
        /// </summary>
        public int OrderCount
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
        /// 医生Id
        /// </summary>
        public int DoctorId
        {
            get;
            set;
        }

    }
}