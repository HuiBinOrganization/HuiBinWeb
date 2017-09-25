using System;
namespace NFine.Domain.Entity.SystemManage
{
    /// <summary>
    /// 医生表
    /// </summary>
    public  class DoctorEntity : IEntity<DoctorEntity>
    {
    
        /// <summary>
        /// 医生ID
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
        /// 专长
        /// </summary>
        public string GootAt
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 职称
        /// </summary>
        public string Title
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 预约周期
        /// </summary>
        public int OrderCycle
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 预约类型 1:依次 2:分时段预约
        /// </summary>
        public bool OrderType
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddDate
        {
            get;
            set;
        }  

        /// <summary>
        /// 挂号费
        /// </summary>
        public float Price
        {
            get;
            set;
        }

        /// <summary>
        /// 号别
        /// </summary>
        public bool Category
        {
            get;
            set;
        }


    }
}