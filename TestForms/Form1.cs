using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IList<IdentificationType> infoList = new List<IdentificationType>();
            IdentificationType identificationType = new IdentificationType();
            identificationType.Key = 1;
            identificationType.Value = "护照";
            infoList.Add(identificationType);
            identificationType = new IdentificationType();
            identificationType.Key = 2;
            identificationType.Value = "身体证";
            infoList.Add(identificationType);
            cbIdentificationType.DataSource = infoList;
            cbIdentificationType.ValueMember = "Key";
            cbIdentificationType.DisplayMember = "Value";
        }

        private void btnGetUser_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            RestClient client = new RestClient(url);

            string method = "GetUserInfo";
            GetUserInfoParameter param = new GetUserInfoParameter();
            param.IdentificationType =(int) cbIdentificationType.SelectedValue;
            param.IdentificationNumber = txtIdentificationNumber.Text.Trim();
            string json = JsonConvert.SerializeObject(param) ;
            string retPost = client.Post(json, method);
            txtResult.Text = retPost;
        }
    }

    public class IdentificationType
    {
        public int Key
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }


    /// <summary>
    /// 获取用户信息参数
    /// </summary>
    public class GetUserInfoParameter
    {
        /// <summary>
        /// 证件类型
        /// </summary>
        public int IdentificationType
        {
            get;
            set;
        }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string IdentificationNumber
        {
            get;
            set;
        }
    }

    public class Response<T>
    {

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccessfull
        {
            get;
            set;
        }

        /// <summary>
        /// 失败为原因
        /// </summary>
        public string Reason
        {
            get;
            set;
        }


        /// <summary>
        /// 数据列表
        /// </summary>
        public T Result
        {
            get;
            set;
        }


        /// <summary>
        /// 当前查询总条数
        /// </summary>
        public int TotalCount
        {
            get;
            set;
        }
    }

    public class GetUserInfoResult
    {
        /// <summary>
        /// 证件类型
        /// 1：护照
        /// 2：身体证
        /// </summary>
        public int IdentificationType
        {
            get;
            set;
        }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string IdentificationNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string Name
        {
            get;
            set;
        }


        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            get;
            set;
        }


        /// <summary>
        /// 性别
        /// 1:男
        /// 2:女
        /// </summary>
        public int Gender
        {
            get;
            set;
        }

        /// <summary>
        /// 出生年月(yyyy-MM-dd)
        /// </summary>
        public DateTime Birthday
        {
            get;
            set;
        }

        /// <summary>
        /// 就诊卡号
        /// </summary>
        public string CardNumber
        {
            get;
            set;
        }
    }
}
