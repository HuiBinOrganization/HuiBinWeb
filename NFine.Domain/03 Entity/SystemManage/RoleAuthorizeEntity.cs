﻿/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author:HuiBin
 * Description: 陕西惠宾电子科技有限公司-国际诊疗网开发平台
 * Website：http://www.hbdzoms.com
*********************************************************************************/
using System;

namespace NFine.Domain.Entity.SystemManage
{
    public class RoleAuthorizeEntity : IEntity<RoleAuthorizeEntity>, ICreationAudited
    {
        public string F_Id { get; set; }
        public int? F_ItemType { get; set; }
        public string F_ItemId { get; set; }
        public int? F_ObjectType { get; set; }
        public string F_ObjectId { get; set; }
        public int? F_SortCode { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_CreatorUserId { get; set; }
    }
}
