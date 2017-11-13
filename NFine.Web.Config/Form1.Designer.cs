namespace NFine.Web.Config
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtHisUrl = new System.Windows.Forms.TextBox();
            this.tbnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrderCycle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbIsTest = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbIsExistCard = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据库名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "用户名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "His接口地址";
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(96, 24);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(307, 21);
            this.txtDBServer.TabIndex = 5;
            this.txtDBServer.Text = ".";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(95, 51);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(307, 21);
            this.txtDBName.TabIndex = 6;
            this.txtDBName.Text = "HuiBin";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(96, 77);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(307, 21);
            this.txtUserName.TabIndex = 7;
            this.txtUserName.Text = "sa";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(95, 104);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(307, 21);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Text = "123";
            // 
            // txtHisUrl
            // 
            this.txtHisUrl.Location = new System.Drawing.Point(96, 131);
            this.txtHisUrl.Name = "txtHisUrl";
            this.txtHisUrl.Size = new System.Drawing.Size(307, 21);
            this.txtHisUrl.TabIndex = 9;
            this.txtHisUrl.Text = "http://localhost:1851/";
            // 
            // tbnSave
            // 
            this.tbnSave.Location = new System.Drawing.Point(96, 251);
            this.tbnSave.Name = "tbnSave";
            this.tbnSave.Size = new System.Drawing.Size(75, 23);
            this.tbnSave.TabIndex = 10;
            this.tbnSave.Text = "保存";
            this.tbnSave.UseVisualStyleBackColor = true;
            this.tbnSave.Click += new System.EventHandler(this.tbnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "预约周期[天]";
            // 
            // txtOrderCycle
            // 
            this.txtOrderCycle.Location = new System.Drawing.Point(95, 161);
            this.txtOrderCycle.Name = "txtOrderCycle";
            this.txtOrderCycle.Size = new System.Drawing.Size(307, 21);
            this.txtOrderCycle.TabIndex = 12;
            this.txtOrderCycle.Text = "8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "是否测试";
            // 
            // cbIsTest
            // 
            this.cbIsTest.FormattingEnabled = true;
            this.cbIsTest.Location = new System.Drawing.Point(96, 192);
            this.cbIsTest.Name = "cbIsTest";
            this.cbIsTest.Size = new System.Drawing.Size(306, 20);
            this.cbIsTest.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "是否有卡";
            // 
            // cbIsExistCard
            // 
            this.cbIsExistCard.FormattingEnabled = true;
            this.cbIsExistCard.Location = new System.Drawing.Point(95, 220);
            this.cbIsExistCard.Name = "cbIsExistCard";
            this.cbIsExistCard.Size = new System.Drawing.Size(306, 20);
            this.cbIsExistCard.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 308);
            this.Controls.Add(this.cbIsExistCard);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbIsTest);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtOrderCycle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbnSave);
            this.Controls.Add(this.txtHisUrl);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.txtDBServer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网站配置";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDBServer;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtHisUrl;
        private System.Windows.Forms.Button tbnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOrderCycle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbIsTest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbIsExistCard;
    }
}

