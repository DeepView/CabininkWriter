namespace Cabinink.Writer.UI
{
   partial class frmNtpClient
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
         this.cmbServer = new System.Windows.Forms.ComboBox();
         this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
         this.btnSync = new MetroFramework.Controls.MetroButton();
         this.btnClose = new MetroFramework.Controls.MetroButton();
         this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
         this.txtPort = new MetroFramework.Controls.MetroTextBox();
         this.ckbEnableChangedPort = new MetroFramework.Controls.MetroCheckBox();
         this.SuspendLayout();
         // 
         // cmbServer
         // 
         this.cmbServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.cmbServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.cmbServer.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.cmbServer.ForeColor = System.Drawing.Color.White;
         this.cmbServer.FormattingEnabled = true;
         this.cmbServer.Items.AddRange(new object[] {
            "192.43.244.18",
            "129.6.15.28",
            "129.6.15.29",
            "132.163.4.101",
            "132.163.4.102",
            "132.163.4.103",
            "128.138.140.44",
            "192.43.244.18",
            "210.72.145.44",
            "202.120.2.101"});
         this.cmbServer.Location = new System.Drawing.Point(105, 62);
         this.cmbServer.Name = "cmbServer";
         this.cmbServer.Size = new System.Drawing.Size(201, 25);
         this.cmbServer.TabIndex = 0;
         // 
         // metroLabel1
         // 
         this.metroLabel1.AutoSize = true;
         this.metroLabel1.Location = new System.Drawing.Point(20, 62);
         this.metroLabel1.Name = "metroLabel1";
         this.metroLabel1.Size = new System.Drawing.Size(79, 20);
         this.metroLabel1.TabIndex = 1;
         this.metroLabel1.Text = "NTP服务器";
         this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel1.UseCustomBackColor = true;
         // 
         // btnSync
         // 
         this.btnSync.Location = new System.Drawing.Point(217, 93);
         this.btnSync.Name = "btnSync";
         this.btnSync.Size = new System.Drawing.Size(89, 23);
         this.btnSync.TabIndex = 2;
         this.btnSync.Text = "同步时间(&S)";
         this.btnSync.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnSync.UseSelectable = true;
         this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
         // 
         // btnClose
         // 
         this.btnClose.Location = new System.Drawing.Point(217, 156);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(89, 32);
         this.btnClose.TabIndex = 2;
         this.btnClose.Text = "关闭(&C)";
         this.btnClose.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnClose.UseSelectable = true;
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // metroLabel2
         // 
         this.metroLabel2.AutoSize = true;
         this.metroLabel2.Location = new System.Drawing.Point(20, 93);
         this.metroLabel2.Name = "metroLabel2";
         this.metroLabel2.Size = new System.Drawing.Size(79, 20);
         this.metroLabel2.TabIndex = 1;
         this.metroLabel2.Text = "服务器端口";
         this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel2.UseCustomBackColor = true;
         // 
         // txtPort
         // 
         this.txtPort.Lines = new string[] {
        "123"};
         this.txtPort.Location = new System.Drawing.Point(105, 93);
         this.txtPort.MaxLength = 32767;
         this.txtPort.Name = "txtPort";
         this.txtPort.PasswordChar = '\0';
         this.txtPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtPort.SelectedText = "";
         this.txtPort.Size = new System.Drawing.Size(106, 23);
         this.txtPort.TabIndex = 3;
         this.txtPort.Text = "123";
         this.txtPort.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtPort.UseSelectable = true;
         // 
         // ckbEnableChangedPort
         // 
         this.ckbEnableChangedPort.AutoSize = true;
         this.ckbEnableChangedPort.Location = new System.Drawing.Point(20, 171);
         this.ckbEnableChangedPort.Name = "ckbEnableChangedPort";
         this.ckbEnableChangedPort.Size = new System.Drawing.Size(132, 17);
         this.ckbEnableChangedPort.TabIndex = 5;
         this.ckbEnableChangedPort.Text = "允许修改服务器端口";
         this.ckbEnableChangedPort.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.ckbEnableChangedPort.UseCustomBackColor = true;
         this.ckbEnableChangedPort.UseSelectable = true;
         this.ckbEnableChangedPort.CheckedChanged += new System.EventHandler(this.ckbEnableChangedPort_CheckedChanged);
         // 
         // frmNtpClient
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(329, 208);
         this.Controls.Add(this.ckbEnableChangedPort);
         this.Controls.Add(this.txtPort);
         this.Controls.Add(this.btnClose);
         this.Controls.Add(this.btnSync);
         this.Controls.Add(this.metroLabel2);
         this.Controls.Add(this.metroLabel1);
         this.Controls.Add(this.cmbServer);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmNtpClient";
         this.Text = "时间同步（测试功能）";
         this.Load += new System.EventHandler(this.frmNtpClient_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ComboBox cmbServer;
      private MetroFramework.Controls.MetroLabel metroLabel1;
      private MetroFramework.Controls.MetroButton btnSync;
      private MetroFramework.Controls.MetroButton btnClose;
      private MetroFramework.Controls.MetroLabel metroLabel2;
      private MetroFramework.Controls.MetroTextBox txtPort;
      private MetroFramework.Controls.MetroCheckBox ckbEnableChangedPort;
   }
}
