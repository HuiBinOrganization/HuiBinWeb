using NFine.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace NFine.Mapping.SystemManage
{
    /// <summary>
    /// 医生表
    /// </summary>
    public class DoctorMap : EntityTypeConfiguration<DoctorEntity>
    {
        public DoctorMap()
        {
            this.ToTable("Doctor");
            this.HasKey(t => t.DoctorId);
        }
    }
}