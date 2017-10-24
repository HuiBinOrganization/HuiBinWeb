using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NFine.Web.Areas.UIManage.Controllers;
using System.Configuration;

namespace NFine.Web.Controllers
{
    #region 医院
    /// <summary>
    /// 医院
    /// </summary>
    public class HospitalController : Controller
    {
        //1.医生列表展示
        //2.医生界面加载出诊安排
        //3.点击出诊安排进行预约
        //4.预约成功后查询预约信息

        //
        // GET: /Hospital/

        /// <summary>
        /// 医生列表展示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取医生列表信息
        /// </summary>
        /// <returns></returns>
        public string GetDoctorList()
        {
            var server = new DoctorController();

            return "";
        }

        /// <summary>
        /// 写死的科室简介
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Department()
        {
            return View();
        }

        /// <summary>
        /// 医生界面加载出诊安排
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Doctor()
        {
            return View();
        }

        /// <summary>
        /// 点击出诊安排进行预约
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FormSubscribe()
        {
            return View();
        }

    }
    #endregion
}
