using NFine.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace NFine.Mapping.SystemManage
{
    /// <summary>
    /// 出诊信息
    /// </summary>
    public class VisitMap : EntityTypeConfiguration<VisitEntity>
    {
        public VisitMap()
        {
            this.ToTable("Visit");
            this.HasKey(t => t.VisitId);
        }
    }
}