
using System;

namespace NFine.Domain.Entity.SystemManage
{
    /// <summary>
    /// 会员表
    /// </summary>
    public partial class MemberEntity : IEntity<MemberEntity>
    {
    
       
        /// <summary>
        /// 会员Id
        /// </summary>
        public int MemberId
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CredentialInformation
        {
            get;
            set;
        }  
    
        /// <summary>
        /// 证件类型 1:护照 2:身份证
        /// </summary>
        public int CredentialType
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
        /// 性别 1:男 2:女
        /// </summary>
        public int Gender
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
        /// 国籍
        /// </summary>
        public int Nationality
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