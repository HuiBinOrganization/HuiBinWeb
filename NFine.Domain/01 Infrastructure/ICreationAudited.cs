/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author:HuiBin
 * Description: 陕西惠宾电子科技有限公司-国际诊疗网开发平台
 * Website：http://www.hbdzoms.com
*********************************************************************************/
using System;

namespace NFine.Domain
{
    public interface ICreationAudited
    {
        string F_Id { get; set; }
        string F_CreatorUserId { get; set; }
        DateTime? F_CreatorTime { get; set; }
    }
}