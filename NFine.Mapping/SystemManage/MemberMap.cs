using NFine.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace NFine.Mapping.SystemManage
{
    /// <summary>
    /// 会员表
    /// </summary>
    public class MemberMap : EntityTypeConfiguration<MemberEntity>
    {
        public MemberMap()
        {
            this.ToTable("Member");
            this.HasKey(t => t.MemberId);
        }
    }
}