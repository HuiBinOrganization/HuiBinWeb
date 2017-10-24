using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NFine.Web.Config
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 保存
        /// <summary>
        /// 保存 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnSave_Click(object sender, EventArgs e)
        {
            bool isReturn = false;

            var server = this.txtDBServer.Text.Trim();
            var dbName = this.txtDBName.Text.Trim();
            var dbUser = this.txtUserName.Text.Trim();
            var dbPassword = this.txtPassword.Text.Trim();
            var hisUrl = this.txtHisUrl.Text.Trim();
            var orderCycle = this.txtOrderCycle.Text.Trim();
            var isTest = this.cbIsTest.SelectedValue.ToString();
            if (string.IsNullOrEmpty(server))
            {
                isReturn = true;
            }
            if (string.IsNullOrEmpty(dbName))
            {
                isReturn = true;
            }
            if (string.IsNullOrEmpty(dbUser))
            {
                isReturn = true;
            }

            if (string.IsNullOrEmpty(dbPassword))
            {
                isReturn = true;
            }

            if (string.IsNullOrEmpty(hisUrl))
            {
                isReturn = true;
            }

            if (string.IsNullOrEmpty(orderCycle))
            {
                isReturn = true;
            }
            if (isReturn)
            {
                MessageBox.Show("输入不能为空");
                return;
            }
            //获取当前程序根目录
            var rootPath = System.Environment.CurrentDirectory;
            var appFile = rootPath + "/Configs/database.config";

            try
            {
                //如果找到Web.config
                if (File.Exists(appFile))
                {
                    XmlDocument configDoc = new XmlDocument();
                    configDoc.Load(appFile);

                    XmlNode appSettingsNode = configDoc.SelectSingleNode("connectionStrings");

                    //遍历所有子节点，找到ServiceIPAddress节点并返回
                    foreach (XmlNode node in appSettingsNode.ChildNodes)
                    {
                        if (node.NodeType != XmlNodeType.Element)
                        {
                            continue;
                        }

                        XmlElement xele = (XmlElement)node;
                        var keyToken = xele.GetAttribute("name");

                        var tempConn = string.Format("Server={0};Initial Catalog={1};User Id={2};Password={3};MultipleActiveResultSets=true;Max Pool Size=150", server, dbName, dbUser, dbPassword);
                        try
                        {

                            using (SqlConnection connection = new SqlConnection(tempConn))
                            {

                                connection.Open();

                                if (connection.State == ConnectionState.Open)
                                {

                                    MessageBox.Show("连接成功！");

                                }
                                else
                                {
                                    MessageBox.Show("连接失败！");
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }

                        switch (keyToken)
                        {
                            case "NFineDbContext":
                                xele.SetAttribute("connectionString", tempConn);
                                break;
                        }
                    }

                    configDoc.Save(appFile);

                    //修改其它配置
                    appFile = rootPath + "/Configs/system.config";
                    //如果找到Web.config
                    if (File.Exists(appFile))
                    {
                        configDoc = new XmlDocument();
                        configDoc.Load(appFile);

                        appSettingsNode = configDoc.SelectSingleNode("appSettings");

                        //遍历所有子节点，找到ServiceIPAddress节点并返回
                        foreach (XmlNode node in appSettingsNode.ChildNodes)
                        {
                            if (node.NodeType != XmlNodeType.Element)
                            {
                                continue;
                            }

                            XmlElement xele = (XmlElement)node;
                            var keyToken = xele.GetAttribute("key");

                            switch (keyToken)
                            {
                                case "OrderCycle":
                                    xele.SetAttribute("value", orderCycle);
                                    break;
                                case "HisUrl":
                                    xele.SetAttribute("value", hisUrl);
                                    break;
                                case "IsTest":
                                    xele.SetAttribute("value", isTest);
                                    break;
                            }
                        }

                        configDoc.Save(appFile);

                        //修改其它配置
                        MessageBox.Show("配置文件保存成功！");

                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("database.config 配置文件未找到！");
                    }

                    MessageBox.Show("配置文件保存成功！");

                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("database.config 配置文件未找到！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 加载界面
        /// <summary>
        /// 加载界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            IList<Select> infoList = new List<Select>();
            Select select = new Select();
            select.Key = 1;
            select.Value = "是";
            infoList.Add(select);
            select = new Select();
            select.Key = 0;
            select.Value = "否";
            infoList.Add(select);
            cbIsTest.DataSource = infoList;
            cbIsTest.ValueMember = "Key";
            cbIsTest.DisplayMember = "Value";
        }
        #endregion

    }

    #region 选择
    /// <summary>
    /// 选择
    /// </summary>
    public class Select
    {
        /// <summary>
        /// Key
        /// </summary>
        public int Key
        {
            set;
            get;
        }

        /// <summary>
        /// 值
        /// </summary>
        public string Value
        {
            get;
            set;
        }
    }
    #endregion

}
