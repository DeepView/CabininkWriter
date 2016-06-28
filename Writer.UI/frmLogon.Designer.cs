namespace Cabinink.Writer.UI
{
   partial class frmLogon
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
         this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
         this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
         this.txtPassword = new MetroFramework.Controls.MetroTextBox();
         this.txtReptyPassword = new MetroFramework.Controls.MetroTextBox();
         this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
         this.txtMailAddress = new MetroFramework.Controls.MetroTextBox();
         this.btnLogon = new MetroFramework.Controls.MetroButton();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.label1.ForeColor = System.Drawing.Color.White;
         this.label1.Location = new System.Drawing.Point(36, 39);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(133, 38);
         this.label1.TabIndex = 0;
         this.label1.Text = "用户注册";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.label2.ForeColor = System.Drawing.Color.Silver;
         this.label2.Location = new System.Drawing.Point(40, 87);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(475, 17);
         this.label2.TabIndex = 0;
         this.label2.Text = "使用当前Windows用户名称作为您在Cabinink Writer的用户名称，并定义您的登录密码";
         // 
         // metroLabel1
         // 
         this.metroLabel1.AutoSize = true;
         this.metroLabel1.Location = new System.Drawing.Point(43, 161);
         this.metroLabel1.Name = "metroLabel1";
         this.metroLabel1.Size = new System.Drawing.Size(37, 20);
         this.metroLabel1.TabIndex = 1;
         this.metroLabel1.Text = "密码";
         this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel1.UseCustomBackColor = true;
         // 
         // metroLabel2
         // 
         this.metroLabel2.AutoSize = true;
         this.metroLabel2.Location = new System.Drawing.Point(43, 203);
         this.metroLabel2.Name = "metroLabel2";
         this.metroLabel2.Size = new System.Drawing.Size(65, 20);
         this.metroLabel2.TabIndex = 1;
         this.metroLabel2.Text = "重复输入";
         this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel2.UseCustomBackColor = true;
         // 
         // txtPassword
         // 
         this.txtPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
         this.txtPassword.Lines = new string[0];
         this.txtPassword.Location = new System.Drawing.Point(142, 161);
         this.txtPassword.MaxLength = 32767;
         this.txtPassword.Name = "txtPassword";
         this.txtPassword.PasswordChar = '●';
         this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtPassword.SelectedText = "";
         this.txtPassword.Size = new System.Drawing.Size(306, 26);
         this.txtPassword.TabIndex = 0;
         this.txtPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtPassword.UseSelectable = true;
         // 
         // txtReptyPassword
         // 
         this.txtReptyPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
         this.txtReptyPassword.Lines = new string[0];
         this.txtReptyPassword.Location = new System.Drawing.Point(142, 203);
         this.txtReptyPassword.MaxLength = 32767;
         this.txtReptyPassword.Name = "txtReptyPassword";
         this.txtReptyPassword.PasswordChar = '●';
         this.txtReptyPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtReptyPassword.SelectedText = "";
         this.txtReptyPassword.Size = new System.Drawing.Size(306, 26);
         this.txtReptyPassword.TabIndex = 1;
         this.txtReptyPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtReptyPassword.UseSelectable = true;
         // 
         // metroLabel3
         // 
         this.metroLabel3.AutoSize = true;
         this.metroLabel3.Location = new System.Drawing.Point(43, 245);
         this.metroLabel3.Name = "metroLabel3";
         this.metroLabel3.Size = new System.Drawing.Size(65, 20);
         this.metroLabel3.TabIndex = 1;
         this.metroLabel3.Text = "电子邮箱";
         this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel3.UseCustomBackColor = true;
         // 
         // txtMailAddress
         // 
         this.txtMailAddress.FontSize = MetroFramework.MetroTextBoxSize.Medium;
         this.txtMailAddress.Lines = new string[0];
         this.txtMailAddress.Location = new System.Drawing.Point(142, 245);
         this.txtMailAddress.MaxLength = 32767;
         this.txtMailAddress.Name = "txtMailAddress";
         this.txtMailAddress.PasswordChar = '\0';
         this.txtMailAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtMailAddress.SelectedText = "";
         this.txtMailAddress.Size = new System.Drawing.Size(306, 26);
         this.txtMailAddress.TabIndex = 2;
         this.txtMailAddress.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtMailAddress.UseSelectable = true;
         // 
         // btnLogon
         // 
         this.btnLogon.Location = new System.Drawing.Point(415, 375);
         this.btnLogon.Name = "btnLogon";
         this.btnLogon.Size = new System.Drawing.Size(100, 31);
         this.btnLogon.TabIndex = 3;
         this.btnLogon.Text = "开始注册(&R)";
         this.btnLogon.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnLogon.UseSelectable = true;
         this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
         // 
         // frmLogon
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.ClientSize = new System.Drawing.Size(558, 439);
         this.Controls.Add(this.btnLogon);
         this.Controls.Add(this.txtMailAddress);
         this.Controls.Add(this.txtReptyPassword);
         this.Controls.Add(this.txtPassword);
         this.Controls.Add(this.metroLabel3);
         this.Controls.Add(this.metroLabel2);
         this.Controls.Add(this.metroLabel1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmLogon";
         this.ShowDrawIcon = false;
         this.Text = "";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogon_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private MetroFramework.Controls.MetroLabel metroLabel1;
      private MetroFramework.Controls.MetroLabel metroLabel2;
      private MetroFramework.Controls.MetroTextBox txtPassword;
      private MetroFramework.Controls.MetroTextBox txtReptyPassword;
      private MetroFramework.Controls.MetroLabel metroLabel3;
      private MetroFramework.Controls.MetroTextBox txtMailAddress;
      private MetroFramework.Controls.MetroButton btnLogon;
   }
}
