using NFine.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace NFine.Mapping.SystemManage
{
    /// <summary>
    /// 分时间预约
    /// </summary>
    public class SegmentationOrderMap : EntityTypeConfiguration<SegmentationOrderEntity>
    {
        public SegmentationOrderMap()
        {
            this.ToTable("SegmentationOrder");
            this.HasKey(t => t.SegmentationOrderId);
        }
    }
}