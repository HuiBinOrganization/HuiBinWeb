using NFine.Code;
using NFine.Data;
using NFine.Domain.Entity.Enums;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.ViewModel;
using NFine.IRepository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.SystemManage
{
    /// <summary>
    /// 预约处理
    /// </summary>
    public class OrderApp
    {
        private IOrderRepository service = new OrderRepository();
        private IMemberRepository memberService = new MemberRepository();
        private IDoctorRepository doctorService = new DoctorRepository();

        public IQueryable<OrderEntity> GetList(Expression<Func<OrderEntity, bool>> predicate)
        {
            return service.IQueryable(predicate);
        }

        /// <summary>
        /// 预约
        /// </summary>
        /// <param name="model">参数</param>
        public AddOrderResponse AddOrder(OrderViewModel model)
        {
            return service.AddOrder(model);
        }

        /// <summary>
        /// 获取预约列表信息
        /// </summary>
        /// <param name="model">参数</param>
        public List<OrderEntity> GetOrderList(GetOrderListRequest model)
        {
            return service.IQueryable(item => item.MemberId == model.MemberId).ToList();
        }

        public List<OrderViewModel> GetList(Pagination pagination, string keyword)
        {

            //查询用户信息
            var memberList = memberService.IQueryable(item => item.FullName.Contains(keyword)
                                                     || item.VisitingCardNumber.Contains(keyword)
                                                     || item.ContactNumber.Contains(keyword)
                                                     || item.CredentialInformation.Contains(keyword));
            var expression = ExtLinq.True<OrderEntity>();
            if (memberList!=null&& memberList.Any())
            {
                List<int> memberIdList = memberList.Select(item => item.MemberId).ToList();
                expression = expression.And(t => memberIdList.Contains(t.MemberId));
            }

            List<OrderEntity> list = service.FindList(expression, pagination);
            List<OrderViewModel> viewModelList = new List<OrderViewModel>();

            foreach (var info in list)
            {
                OrderViewModel orderViewModel = new OrderViewModel();
                var member = memberService.IQueryable(item => item.MemberId == info.MemberId).FirstOrDefault();
                if (member != null)
                {
                    orderViewModel.FullName = member.FullName;
                    orderViewModel.SymptomDescription = info.SymptomDescription;
                    orderViewModel.Gender = (GenderEnum)member.Gender;
                    orderViewModel.DateOfBirth = member.DateOfBirth;
                    orderViewModel.VisitingCardNumber = member.VisitingCardNumber;
                    orderViewModel.ContactNumber = member.ContactNumber;
                    orderViewModel.CredentialType = (CredentialTypeEnum)member.CredentialType;
                    orderViewModel.CredentialInformation = member.CredentialInformation;
                }

                var doctor = doctorService.IQueryable(item => item.DoctorId == info.OrderDoctorId).FirstOrDefault();
                if (doctor != null)
                {
                    orderViewModel.OrderDoctorName = doctor.DoctorName;
                }
                orderViewModel.BeginTime = info.BeginTime;
                orderViewModel.EndTime = info.EndTime;
                orderViewModel.OrderDateTime = info.OrderDate;
                orderViewModel.OrderType = (OrderTypeEnum)info.NumberType;
                orderViewModel.OrderDateTimeType = (OrderTimeTypeEnum)info.OrderType;

                viewModelList.Add(orderViewModel);

            }
            return viewModelList;
        }
    }
}
