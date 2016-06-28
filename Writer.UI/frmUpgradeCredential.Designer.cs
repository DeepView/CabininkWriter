namespace Cabinink.Writer.UI
{
   partial class frmUpgradeCredential
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
         this.components = new System.ComponentModel.Container();
         this.picAccountAvater = new System.Windows.Forms.PictureBox();
         this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
         this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
         this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
         this.txtOldPassword = new MetroFramework.Controls.MetroTextBox();
         this.txtNewPassword = new MetroFramework.Controls.MetroTextBox();
         this.txtInputAgain = new MetroFramework.Controls.MetroTextBox();
         this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
         this.ttpTips = new System.Windows.Forms.ToolTip(this.components);
         this.ofdSelectAvater = new System.Windows.Forms.OpenFileDialog();
         ((System.ComponentModel.ISupportInitialize)(this.picAccountAvater)).BeginInit();
         this.SuspendLayout();
         // 
         // picAccountAvater
         // 
         this.picAccountAvater.Cursor = System.Windows.Forms.Cursors.Hand;
         this.picAccountAvater.Image = global::Cabinink.Properties.Resources.def_accountpicture;
         this.picAccountAvater.Location = new System.Drawing.Point(1, 40);
         this.picAccountAvater.Name = "picAccountAvater";
         this.picAccountAvater.Size = new System.Drawing.Size(200, 200);
         this.picAccountAvater.TabIndex = 0;
         this.picAccountAvater.TabStop = false;
         this.ttpTips.SetToolTip(this.picAccountAvater, "点击更换您的头像");
         this.picAccountAvater.Click += new System.EventHandler(this.picAccountAvater_Click);
         this.picAccountAvater.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picAccountAvater_MouseMove);
         // 
         // metroLabel1
         // 
         this.metroLabel1.AutoSize = true;
         this.metroLabel1.Location = new System.Drawing.Point(221, 63);
         this.metroLabel1.Name = "metroLabel1";
         this.metroLabel1.Size = new System.Drawing.Size(51, 20);
         this.metroLabel1.TabIndex = 1;
         this.metroLabel1.Text = "原密码";
         this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel1.UseCustomBackColor = true;
         // 
         // metroLabel2
         // 
         this.metroLabel2.AutoSize = true;
         this.metroLabel2.Location = new System.Drawing.Point(221, 99);
         this.metroLabel2.Name = "metroLabel2";
         this.metroLabel2.Size = new System.Drawing.Size(51, 20);
         this.metroLabel2.TabIndex = 1;
         this.metroLabel2.Text = "新密码";
         this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel2.UseCustomBackColor = true;
         // 
         // metroLabel3
         // 
         this.metroLabel3.AutoSize = true;
         this.metroLabel3.Location = new System.Drawing.Point(221, 135);
         this.metroLabel3.Name = "metroLabel3";
         this.metroLabel3.Size = new System.Drawing.Size(65, 20);
         this.metroLabel3.TabIndex = 1;
         this.metroLabel3.Text = "重复输入";
         this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel3.UseCustomBackColor = true;
         // 
         // txtOldPassword
         // 
         this.txtOldPassword.Lines = new string[0];
         this.txtOldPassword.Location = new System.Drawing.Point(292, 63);
         this.txtOldPassword.MaxLength = 32767;
         this.txtOldPassword.Name = "txtOldPassword";
         this.txtOldPassword.PasswordChar = '●';
         this.txtOldPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtOldPassword.SelectedText = "";
         this.txtOldPassword.Size = new System.Drawing.Size(277, 23);
         this.txtOldPassword.Style = MetroFramework.MetroColorStyle.Blue;
         this.txtOldPassword.TabIndex = 0;
         this.txtOldPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.ttpTips.SetToolTip(this.txtOldPassword, "输入以前的密码");
         this.txtOldPassword.UseSelectable = true;
         // 
         // txtNewPassword
         // 
         this.txtNewPassword.Lines = new string[0];
         this.txtNewPassword.Location = new System.Drawing.Point(292, 99);
         this.txtNewPassword.MaxLength = 32767;
         this.txtNewPassword.Name = "txtNewPassword";
         this.txtNewPassword.PasswordChar = '●';
         this.txtNewPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtNewPassword.SelectedText = "";
         this.txtNewPassword.Size = new System.Drawing.Size(277, 23);
         this.txtNewPassword.Style = MetroFramework.MetroColorStyle.Blue;
         this.txtNewPassword.TabIndex = 1;
         this.txtNewPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.ttpTips.SetToolTip(this.txtNewPassword, "输入新的密码");
         this.txtNewPassword.UseSelectable = true;
         // 
         // txtInputAgain
         // 
         this.txtInputAgain.Lines = new string[0];
         this.txtInputAgain.Location = new System.Drawing.Point(292, 135);
         this.txtInputAgain.MaxLength = 32767;
         this.txtInputAgain.Name = "txtInputAgain";
         this.txtInputAgain.PasswordChar = '●';
         this.txtInputAgain.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtInputAgain.SelectedText = "";
         this.txtInputAgain.Size = new System.Drawing.Size(277, 23);
         this.txtInputAgain.Style = MetroFramework.MetroColorStyle.Blue;
         this.txtInputAgain.TabIndex = 2;
         this.txtInputAgain.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.ttpTips.SetToolTip(this.txtInputAgain, "重新输入一次新密码");
         this.txtInputAgain.UseSelectable = true;
         // 
         // materialRaisedButton1
         // 
         this.materialRaisedButton1.Depth = 0;
         this.materialRaisedButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.materialRaisedButton1.Location = new System.Drawing.Point(475, 189);
         this.materialRaisedButton1.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.materialRaisedButton1.Name = "materialRaisedButton1";
         this.materialRaisedButton1.Primary = true;
         this.materialRaisedButton1.Size = new System.Drawing.Size(94, 30);
         this.materialRaisedButton1.TabIndex = 3;
         this.materialRaisedButton1.Text = "确认修改";
         this.ttpTips.SetToolTip(this.materialRaisedButton1, "修改密码并关闭窗口");
         this.materialRaisedButton1.UseVisualStyleBackColor = true;
         this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
         // 
         // ttpTips
         // 
         this.ttpTips.AutoPopDelay = 5000;
         this.ttpTips.InitialDelay = 100;
         this.ttpTips.ReshowDelay = 100;
         // 
         // ofdSelectAvater
         // 
         this.ofdSelectAvater.Filter = "JPEG|*.jpg";
         this.ofdSelectAvater.Title = "建议选择正方形尺寸的图像文件作为头像";
         // 
         // frmUpgradeCredential
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.ClientSize = new System.Drawing.Size(597, 241);
         this.Controls.Add(this.materialRaisedButton1);
         this.Controls.Add(this.txtInputAgain);
         this.Controls.Add(this.txtNewPassword);
         this.Controls.Add(this.txtOldPassword);
         this.Controls.Add(this.metroLabel3);
         this.Controls.Add(this.metroLabel2);
         this.Controls.Add(this.metroLabel1);
         this.Controls.Add(this.picAccountAvater);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmUpgradeCredential";
         this.Text = "更新用户凭据";
         this.Load += new System.EventHandler(this.frmUpgradeCredential_Load);
         this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmUpgradeCredential_MouseMove);
         ((System.ComponentModel.ISupportInitialize)(this.picAccountAvater)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox picAccountAvater;
      private MetroFramework.Controls.MetroLabel metroLabel1;
      private MetroFramework.Controls.MetroLabel metroLabel2;
      private MetroFramework.Controls.MetroLabel metroLabel3;
      private MetroFramework.Controls.MetroTextBox txtOldPassword;
      private MetroFramework.Controls.MetroTextBox txtNewPassword;
      private MetroFramework.Controls.MetroTextBox txtInputAgain;
      private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
      private System.Windows.Forms.ToolTip ttpTips;
      private System.Windows.Forms.OpenFileDialog ofdSelectAvater;
   }
}
