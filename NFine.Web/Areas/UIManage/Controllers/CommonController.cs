using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.UIManage.Controllers
{
    public class CommonController : Controller
    {
        ItemsDetailApp itemsDetailApp = new ItemsDetailApp();
        //
        // GET: /UIManage/Common/

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult GetNationality()
        {

            ResponseBase<List<GetNationalityResponse>> response = new ResponseBase<List<GetNationalityResponse>>();
            response.IsSuccess = false;
            response.Reason = "系统出错，请联系管理员";
            try
            {
                var itemsDetailList = itemsDetailApp.GetItemList("Language");

                List<GetNationalityResponse> list = new List<GetNationalityResponse>();
                if (itemsDetailList != null && itemsDetailList.Any())
                {
                    foreach (var info in itemsDetailList)
                    {
                        GetNationalityResponse getNationalityResponse = new GetNationalityResponse();
                        getNationalityResponse.Id = info.F_Id;
                        getNationalityResponse.Value = info.F_ItemName;
                        list.Add(getNationalityResponse);
                    }
                }
                response.Result = list;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {

            }
            return Content(response.ToJson());
        }
    }
}
