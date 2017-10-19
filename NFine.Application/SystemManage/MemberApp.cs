using NFine.Code;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.SystemManage
{
    /// <summary>
    /// 会员处理类
    /// </summary>
    public class MemberApp
    {
        private IMemberRepository service = new MemberRepository();
        private IItemsDetailRepository ItemsDetailService = new ItemsDetailRepository();

        public IQueryable<MemberEntity> GetList(Expression<Func<MemberEntity, bool>> predicate)
        {
            return service.IQueryable(predicate);
        }

        public List<MemberEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<MemberEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword)|| t.ContactNumber.Contains(keyword)|| t.VisitingCardNumber.Contains(keyword) || t.CredentialInformation.Contains(keyword));
            }
            List<MemberEntity> list= service.FindList(expression, pagination);

            foreach (var info in list)
            {
                info.Nationality = ItemsDetailService.IQueryable(item => item.F_Id == info.Nationality).FirstOrDefault().F_ItemName;
            }

            return list;
        }
    }
}
