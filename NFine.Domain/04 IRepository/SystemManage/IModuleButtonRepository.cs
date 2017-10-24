﻿/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author:HuiBin
 * Description: 陕西惠宾电子科技有限公司-国际诊疗网开发平台
 * Website：http://www.hbdzoms.com
*********************************************************************************/
using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace NFine.Domain.IRepository.SystemManage
{
    public interface IModuleButtonRepository : IRepositoryBase<ModuleButtonEntity>
    {
        void SubmitCloneButton(List<ModuleButtonEntity> entitys);
    }
}
