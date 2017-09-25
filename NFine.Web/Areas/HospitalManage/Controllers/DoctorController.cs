
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFine.Domain.ViewModel;
using NFine.Application.SystemManage;
using NFine.Code;

namespace NFine.Web.Areas.HospitalManage.Controllers
{
    public class DoctorController : ControllerBase
    {
        private DoctorApp doctorApp = new DoctorApp();
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(DoctorViewModel model, string permissionIds, string keyValue)
        {
            doctorApp.SubmitForm(model);
            return Success("操作成功。");
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = doctorApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
    }
}
