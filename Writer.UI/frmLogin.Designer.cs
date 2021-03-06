﻿namespace Cabinink.Writer.UI
{
   partial class frmLogin
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
         this.picAccountAvater = new System.Windows.Forms.PictureBox();
         this.txtPassword = new MetroFramework.Controls.MetroTextBox();
         this.btnLogin = new MaterialSkin.Controls.MaterialRaisedButton();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.lnkFoundPassword = new MetroFramework.Controls.MetroLink();
         ((System.ComponentModel.ISupportInitialize)(this.picAccountAvater)).BeginInit();
         this.SuspendLayout();
         // 
         // picAccountAvater
         // 
         this.picAccountAvater.Image = global::Cabinink.Properties.Resources.def_accountpicture;
         this.picAccountAvater.Location = new System.Drawing.Point(1, 1);
         this.picAccountAvater.Name = "picAccountAvater";
         this.picAccountAvater.Size = new System.Drawing.Size(200, 200);
         this.picAccountAvater.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.picAccountAvater.TabIndex = 0;
         this.picAccountAvater.TabStop = false;
         // 
         // txtPassword
         // 
         this.txtPassword.FontSize = MetroFramework.MetroTextBoxSize.Tall;
         this.txtPassword.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
         this.txtPassword.Lines = new string[0];
         this.txtPassword.Location = new System.Drawing.Point(242, 139);
         this.txtPassword.MaxLength = 32767;
         this.txtPassword.Name = "txtPassword";
         this.txtPassword.PasswordChar = '●';
         this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
         this.txtPassword.SelectedText = "";
         this.txtPassword.Size = new System.Drawing.Size(306, 32);
         this.txtPassword.Style = MetroFramework.MetroColorStyle.Blue;
         this.txtPassword.TabIndex = 1;
         this.txtPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.txtPassword.UseSelectable = true;
         // 
         // btnLogin
         // 
         this.btnLogin.Depth = 0;
         this.btnLogin.Location = new System.Drawing.Point(485, 140);
         this.btnLogin.MouseState = MaterialSkin.MouseStatus.HOVER;
         this.btnLogin.Name = "btnLogin";
         this.btnLogin.Primary = true;
         this.btnLogin.Size = new System.Drawing.Size(62, 30);
         this.btnLogin.TabIndex = 2;
         this.btnLogin.Text = "Login";
         this.btnLogin.UseVisualStyleBackColor = true;
         this.btnLogin.Click += new System.EventHandler(this.materialRaisedButton1_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.label1.ForeColor = System.Drawing.Color.White;
         this.label1.Location = new System.Drawing.Point(234, 22);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(191, 38);
         this.label1.TabIndex = 3;
         this.label1.Text = "登录你的帐户";
         // 
         // label2
         // 
         this.label2.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.label2.ForeColor = System.Drawing.Color.Gray;
         this.label2.Location = new System.Drawing.Point(238, 64);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(310, 34);
         this.label2.TabIndex = 3;
         this.label2.Text = "应用程序将使用当前Windows用户名称与您自定义的密码作为Cabinink Writer的登录凭据";
         // 
         // lnkFoundPassword
         // 
         this.lnkFoundPassword.FontWeight = MetroFramework.MetroLinkWeight.Light;
         this.lnkFoundPassword.Location = new System.Drawing.Point(237, 114);
         this.lnkFoundPassword.Name = "lnkFoundPassword";
         this.lnkFoundPassword.Size = new System.Drawing.Size(108, 23);
         this.lnkFoundPassword.Style = MetroFramework.MetroColorStyle.Blue;
         this.lnkFoundPassword.TabIndex = 4;
         this.lnkFoundPassword.Text = "忘记了您的密码？";
         this.lnkFoundPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lnkFoundPassword.UseCustomBackColor = true;
         this.lnkFoundPassword.UseSelectable = true;
         this.lnkFoundPassword.Click += new System.EventHandler(this.lnkFoundPassword_Click);
         // 
         // frmLogin
         // 
         this.AcceptButton = this.btnLogin;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.ClientSize = new System.Drawing.Size(589, 202);
         this.Controls.Add(this.lnkFoundPassword);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.btnLogin);
         this.Controls.Add(this.txtPassword);
         this.Controls.Add(this.picAccountAvater);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmLogin";
         this.ShowDrawIcon = false;
         this.Text = "";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
         this.Load += new System.EventHandler(this.frmLogin_Load);
         ((System.ComponentModel.ISupportInitialize)(this.picAccountAvater)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox picAccountAvater;
      private MetroFramework.Controls.MetroTextBox txtPassword;
      private MaterialSkin.Controls.MaterialRaisedButton btnLogin;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private MetroFramework.Controls.MetroLink lnkFoundPassword;
   }
}
