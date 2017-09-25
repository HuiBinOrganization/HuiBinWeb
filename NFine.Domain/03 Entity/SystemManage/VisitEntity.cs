using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.Entity.SystemManage
{
    /// <summary>
    /// 出诊信息
    /// </summary>
    public  class VisitEntity :IEntity<VisitEntity>
    {
        /// <summary>
        /// 出诊Id
        /// </summary>
        public int VisitId
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 星期
        /// </summary>
        public int Week
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 上午
        /// </summary>
        public bool Morning
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 下午
        /// </summary>
        public bool Afternoon
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 晚上
        /// </summary>
        public bool Night
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 停诊
        /// </summary>
        public bool Stop
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
    
        /// <summary>
        /// 上午预约数量
        /// </summary>
        public int MorningCount
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 下午预约数量
        /// </summary>
        public int AfternoonCount
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 晚上预约数量
        /// </summary>
        public int NightCount
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
    
    }
}