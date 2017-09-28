using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Domain.ViewModel;

namespace NFine.IRepository.SystemManage
{
    /// <summary>
    /// 医生表
    /// </summary>
    public interface IDoctorRepository : IRepositoryBase<DoctorEntity>
    {

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="entity">entity</param>
        /// <param name="keyValue">key</param>
        void SubmitForm(DoctorViewModel entit, string keyValue);

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="doctorId">医生Id</param>
        void DeleteForm(int doctorId);
    }
}