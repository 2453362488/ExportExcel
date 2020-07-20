namespace ExportExcel
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.url = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.sql = new System.Windows.Forms.TextBox();
            this.dbName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(559, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "导出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据库链接：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "用户名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "执行sql：";
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(282, 42);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(148, 21);
            this.url.TabIndex = 7;
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(282, 102);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(67, 21);
            this.port.TabIndex = 8;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(282, 222);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(46, 21);
            this.username.TabIndex = 9;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(282, 282);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(125, 21);
            this.password.TabIndex = 10;
            // 
            // sql
            // 
            this.sql.Location = new System.Drawing.Point(282, 342);
            this.sql.Multiline = true;
            this.sql.Name = "sql";
            this.sql.Size = new System.Drawing.Size(282, 102);
            this.sql.TabIndex = 11;
            // 
            // dbName
            // 
            this.dbName.Location = new System.Drawing.Point(282, 162);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(67, 21);
            this.dbName.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(211, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "数据库名：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 534);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dbName);
            this.Controls.Add(this.sql);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.port);
            this.Controls.Add(this.url);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "导出Excel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox sql;
        private System.Windows.Forms.TextBox dbName;
        private System.Windows.Forms.Label label7;
    }
}

