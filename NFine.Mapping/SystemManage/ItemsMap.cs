/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author:HuiBin
 * Description: 陕西惠宾电子科技有限公司-国际诊疗网开发平台
 * Website：http://www.hbdzoms.com
*********************************************************************************/
using NFine.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace NFine.Mapping.SystemManage
{
    public class ItemsMap : EntityTypeConfiguration<ItemsEntity>
    {
        public ItemsMap()
        {
            this.ToTable("Sys_Items");
            this.HasKey(t => t.F_Id);
        }
    }
}
