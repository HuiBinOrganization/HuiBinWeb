using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace NFine.IRepository.SystemManage
{
    /// <summary>
    /// 会员表
    /// </summary>
    public class MemberRepository : RepositoryBase<MemberEntity>, IMemberRepository
    {
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="keyValue">key</param>
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {

                db.Commit();
            }
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="entity">entity</param>
        /// <param name="keyValue">key</param>
        public void SubmitForm(MemberEntity entity, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Commit();
            }
        }

        /// <summary>
        /// 获取医生列表信息
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public List<MemberEntity> GetOrderList(GetOrderListRequest model)
        {
            List<MemberEntity> list = new List<MemberEntity>();
            using (var db = new RepositoryBase().BeginTrans())
            {
                list = db.IQueryable<MemberEntity>(item => item.MemberId == model.MemberId).ToList();
                db.Commit();
            }
            return list;
        }
    }
}