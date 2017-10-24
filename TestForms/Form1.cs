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
          //  RestClient client = new RestClient(url);
            var testor = new APITestor(url);
            GetUserInfoParameter param = new GetUserInfoParameter();
            param.IdentificationType =(int) cbIdentificationType.SelectedValue;
            param.IdentificationNumber = txtIdentificationNumber.Text.Trim();
            var datas = testor.Query<List<GetUserInfoResult>, GetUserInfoParameter>("dyw/GetUserInfo", param);
            if (datas.Result)
            {
                txtResult.Text = "生日:" + datas.Data.First().Birthday.ToShortDateString() + "卡号：" + datas.Data.First().CardNumber + " 性别：" + datas.Data.First().Gender + " 证件号：" + datas.Data.First().IdentificationNumber + "证件类型： " + datas.Data.First().IdentificationType + "姓名： " + datas.Data.First().Name + " 电话：" + datas.Data.First().Tel;
            }
            
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


    #region 加密算法
    public class APITestor
    {
        private string ServerUri;
        public APITestor(string uri)
        {
            ServerUri = uri;
        }
        private bool E(object data, out string t, out string s)
        {
            //Console.WriteLine("执行验证函数=>");
            //Console.WriteLine("密匙:hbjk");

            var Encryption = MD5("hbjk");
            Console.WriteLine("Encryption = MD5(\"hbjk\")");
            //Console.WriteLine("Encryption = MD5(\"hbjk\")");
            Console.WriteLine("Encryption = " + Encryption);
            //Console.WriteLine("随机数 t:" + (t = System.Guid.NewGuid().ToString()));
            t = System.Guid.NewGuid().ToString();
            var datastr = S(data);
            //Console.WriteLine(string.Format(" s = MD5(Encryption+t+请求源对象)"));
            //Console.WriteLine(string.Format(" s = MD5({0}{1}{2})", Encryption, t, datastr));
            string.Format(" s = MD5({0}{1}{2})", Encryption, t, datastr);
            s = MD5(string.Format("{0}{1}{2}", Encryption, t, datastr));
            //Console.WriteLine("s = " + s);
            return true;
        }
        private string S(object data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        #region API
        public class ApiRequest<DT>
        {
            public string T { get; set; }
            public string S { get; set; }
            public DT Data { get; set; }

        }

        public class ApiResponse<T>
        {
            public ApiResponse()
            {
                Result = false;
                Error = null;
                Message = null;
                Debug = null;
                Data = default(T);
                Version = 0;
            }
            public bool Result { get; set; }
            public string Error { get; set; }
            public string Message { get; set; }
            public string Debug { get; set; }
            public int Version { get; set; }
            public T Data { get; set; }
        }


        public ApiResponse<T> Query<T, R>(string path, R data)
        {
            //Console.WriteLine();
            //Console.WriteLine("--------------------------");
            //Console.WriteLine("请求地址:" + ServerUri + path);
            Console.WriteLine("请求源对象:" + Newtonsoft.Json.JsonConvert.SerializeObject(data));
            System.Net.WebClient client = null;
            ApiResponse<T> result = null;
            try
            {
                client = new System.Net.WebClient();
                client.Encoding = Encoding.UTF8;
                if (path.Substring(0, 1) != "/")
                {
                    path = "/" + path;
                }
                string t;
                string s;
                if (E(data, out t, out s))
                {
                    var request = new ApiRequest<R>();
                    request.S = s;
                    request.T = t;
                    request.Data = data;

                    //Console.WriteLine("请求数据:" + S(request));
                    var paramData = System.Web.HttpUtility.UrlEncode(S(request));
                    //Console.WriteLine("请求数据UrlEncode编码:" + paramData);
                    var uri = ServerUri + path + "?Data=" + paramData;
                    var temp = client.UploadString(uri, "");
                    Console.WriteLine("请求结果:" + temp);
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse<T>>(temp);

                }
                else
                {
                    result = new ApiResponse<T>();
                    result.Error = "加密失败!";
                }

                // Console.WriteLine("请求结束\n");
                return result;
            }
            catch (Exception e)
            {
                result = new ApiResponse<T>();
                result.Error = e.Message;
                // Console.WriteLine("请求异常:" + e.Message);
            }
            finally
            {
                client.Dispose();
            }
            return result;
        }
        #endregion

        public string LastError { get { return m_error; } }
        private string m_error = "";

        #region MD5加密
        public static string MD5(string data)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var buff = System.Text.ASCIIEncoding.UTF8.GetBytes(data);
            var md5resultbytes = md5.ComputeHash(buff);
            var md5result = new StringBuilder();
            foreach (var b in md5resultbytes)
            {
                md5result.Append(b.ToString("X2"));
            }
            return md5result.ToString();
        }
        #endregion
    }
    #endregion

}
