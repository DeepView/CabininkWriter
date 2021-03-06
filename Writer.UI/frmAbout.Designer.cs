﻿namespace Cabinink.Writer.UI
{
   partial class frmAbout
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.lblAssemblyName = new MetroFramework.Controls.MetroLabel();
         this.lblFileVersion = new MetroFramework.Controls.MetroLabel();
         this.lblAssemblyVersion = new MetroFramework.Controls.MetroLabel();
         this.lblCopyright = new MetroFramework.Controls.MetroLabel();
         this.lblIdeName = new MetroFramework.Controls.MetroLabel();
         this.lblClrVersion = new MetroFramework.Controls.MetroLabel();
         this.btnClose = new MetroFramework.Controls.MetroButton();
         this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
         this.lstComInfo = new System.Windows.Forms.ListBox();
         this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
         this.metroLink1 = new MetroFramework.Controls.MetroLink();
         this.metroLink2 = new MetroFramework.Controls.MetroLink();
         this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
         this.btnSysInfo = new MetroFramework.Controls.MetroButton();
         this.btnDxInfo = new MetroFramework.Controls.MetroButton();
         this.lblDescription = new MetroFramework.Controls.MetroLabel();
         this.lblAssemblyFullName = new MetroFramework.Controls.MetroLabel();
         this.SuspendLayout();
         // 
         // lblAssemblyName
         // 
         this.lblAssemblyName.AutoSize = true;
         this.lblAssemblyName.FontSize = MetroFramework.MetroLabelSize.Small;
         this.lblAssemblyName.ForeColor = System.Drawing.Color.White;
         this.lblAssemblyName.Location = new System.Drawing.Point(24, 58);
         this.lblAssemblyName.Name = "lblAssemblyName";
         this.lblAssemblyName.Size = new System.Drawing.Size(80, 17);
         this.lblAssemblyName.TabIndex = 0;
         this.lblAssemblyName.Text = "程序集名称：";
         this.lblAssemblyName.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblAssemblyName.UseCustomBackColor = true;
         // 
         // lblFileVersion
         // 
         this.lblFileVersion.AutoSize = true;
         this.lblFileVersion.FontSize = MetroFramework.MetroLabelSize.Small;
         this.lblFileVersion.ForeColor = System.Drawing.Color.White;
         this.lblFileVersion.Location = new System.Drawing.Point(24, 98);
         this.lblFileVersion.Name = "lblFileVersion";
         this.lblFileVersion.Size = new System.Drawing.Size(68, 17);
         this.lblFileVersion.TabIndex = 1;
         this.lblFileVersion.Text = "文件版本：";
         this.lblFileVersion.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblFileVersion.UseCustomBackColor = true;
         // 
         // lblAssemblyVersion
         // 
         this.lblAssemblyVersion.AutoSize = true;
         this.lblAssemblyVersion.FontSize = MetroFramework.MetroLabelSize.Small;
         this.lblAssemblyVersion.ForeColor = System.Drawing.Color.White;
         this.lblAssemblyVersion.Location = new System.Drawing.Point(24, 78);
         this.lblAssemblyVersion.Name = "lblAssemblyVersion";
         this.lblAssemblyVersion.Size = new System.Drawing.Size(80, 17);
         this.lblAssemblyVersion.TabIndex = 2;
         this.lblAssemblyVersion.Text = "程序集版本：";
         this.lblAssemblyVersion.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblAssemblyVersion.UseCustomBackColor = true;
         // 
         // lblCopyright
         // 
         this.lblCopyright.AutoSize = true;
         this.lblCopyright.FontSize = MetroFramework.MetroLabelSize.Small;
         this.lblCopyright.ForeColor = System.Drawing.Color.White;
         this.lblCopyright.Location = new System.Drawing.Point(24, 147);
         this.lblCopyright.Name = "lblCopyright";
         this.lblCopyright.Size = new System.Drawing.Size(65, 17);
         this.lblCopyright.TabIndex = 3;
         this.lblCopyright.Text = "Copyright";
         this.lblCopyright.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblCopyright.UseCustomBackColor = true;
         // 
         // lblIdeName
         // 
         this.lblIdeName.AutoSize = true;
         this.lblIdeName.FontSize = MetroFramework.MetroLabelSize.Small;
         this.lblIdeName.ForeColor = System.Drawing.Color.White;
         this.lblIdeName.Location = new System.Drawing.Point(24, 180);
         this.lblIdeName.Name = "lblIdeName";
         this.lblIdeName.Size = new System.Drawing.Size(92, 17);
         this.lblIdeName.TabIndex = 4;
         this.lblIdeName.Text = "集成开发环境：";
         this.lblIdeName.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblIdeName.UseCustomBackColor = true;
         // 
         // lblClrVersion
         // 
         this.lblClrVersion.AutoSize = true;
         this.lblClrVersion.FontSize = MetroFramework.MetroLabelSize.Small;
         this.lblClrVersion.ForeColor = System.Drawing.Color.White;
         this.lblClrVersion.Location = new System.Drawing.Point(24, 200);
         this.lblClrVersion.Name = "lblClrVersion";
         this.lblClrVersion.Size = new System.Drawing.Size(128, 17);
         this.lblClrVersion.TabIndex = 5;
         this.lblClrVersion.Text = "公共语言运行时版本：";
         this.lblClrVersion.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblClrVersion.UseCustomBackColor = true;
         // 
         // btnClose
         // 
         this.btnClose.Location = new System.Drawing.Point(523, 508);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(105, 29);
         this.btnClose.TabIndex = 6;
         this.btnClose.Text = "确定(&E)";
         this.btnClose.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnClose.UseSelectable = true;
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // metroLabel1
         // 
         this.metroLabel1.AutoSize = true;
         this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
         this.metroLabel1.Location = new System.Drawing.Point(24, 342);
         this.metroLabel1.Name = "metroLabel1";
         this.metroLabel1.Size = new System.Drawing.Size(236, 17);
         this.metroLabel1.TabIndex = 7;
         this.metroLabel1.Text = "当前应用程序使用到的技术和第三方组件：";
         this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel1.UseCustomBackColor = true;
         // 
         // lstComInfo
         // 
         this.lstComInfo.BackColor = System.Drawing.Color.Gray;
         this.lstComInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.lstComInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.lstComInfo.ForeColor = System.Drawing.Color.White;
         this.lstComInfo.FormattingEnabled = true;
         this.lstComInfo.IntegralHeight = false;
         this.lstComInfo.ItemHeight = 17;
         this.lstComInfo.Items.AddRange(new object[] {
            "CSkin - C#/.Net Winform界面库美化",
            "DMSkin - 专属你的Winform界面库",
            "MetroFramework - WinForms on steroids",
            "SQLite.NET - System.Data.SQLite is an ADO.NET provider for SQLite",
            "MaterialSkin - Theming .NET WinForms, C# or VB.Net, to Google\'s Material Design P" +
                "rinciples"});
         this.lstComInfo.Location = new System.Drawing.Point(24, 366);
         this.lstComInfo.Name = "lstComInfo";
         this.lstComInfo.Size = new System.Drawing.Size(604, 95);
         this.lstComInfo.TabIndex = 0;
         // 
         // metroLabel3
         // 
         this.metroLabel3.AutoSize = true;
         this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
         this.metroLabel3.Location = new System.Drawing.Point(24, 266);
         this.metroLabel3.Name = "metroLabel3";
         this.metroLabel3.Size = new System.Drawing.Size(128, 17);
         this.metroLabel3.TabIndex = 7;
         this.metroLabel3.Text = "主要的技术支持来源：";
         this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel3.UseCustomBackColor = true;
         // 
         // metroLink1
         // 
         this.metroLink1.Cursor = System.Windows.Forms.Cursors.Hand;
         this.metroLink1.FontWeight = MetroFramework.MetroLinkWeight.Light;
         this.metroLink1.ForeColor = System.Drawing.Color.DeepSkyBlue;
         this.metroLink1.Location = new System.Drawing.Point(24, 285);
         this.metroLink1.Name = "metroLink1";
         this.metroLink1.Size = new System.Drawing.Size(265, 23);
         this.metroLink1.TabIndex = 9;
         this.metroLink1.Text = "CSkin论坛（http://bbs.cskin.net/forum.php）";
         this.metroLink1.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLink1.UseCustomBackColor = true;
         this.metroLink1.UseCustomForeColor = true;
         this.metroLink1.UseSelectable = true;
         this.metroLink1.Click += new System.EventHandler(this.metroLink1_Click);
         // 
         // metroLink2
         // 
         this.metroLink2.Cursor = System.Windows.Forms.Cursors.Hand;
         this.metroLink2.FontWeight = MetroFramework.MetroLinkWeight.Light;
         this.metroLink2.ForeColor = System.Drawing.Color.DeepSkyBlue;
         this.metroLink2.Location = new System.Drawing.Point(23, 307);
         this.metroLink2.Name = "metroLink2";
         this.metroLink2.Size = new System.Drawing.Size(314, 23);
         this.metroLink2.TabIndex = 9;
         this.metroLink2.Text = "微软开发者网络（https://msdn.microsoft.com/zh-cn）";
         this.metroLink2.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLink2.UseCustomBackColor = true;
         this.metroLink2.UseCustomForeColor = true;
         this.metroLink2.UseSelectable = true;
         this.metroLink2.Click += new System.EventHandler(this.metroLink2_Click);
         // 
         // metroLabel4
         // 
         this.metroLabel4.AutoSize = true;
         this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Small;
         this.metroLabel4.Location = new System.Drawing.Point(24, 467);
         this.metroLabel4.Name = "metroLabel4";
         this.metroLabel4.Size = new System.Drawing.Size(428, 17);
         this.metroLabel4.TabIndex = 7;
         this.metroLabel4.Text = "附注：上面列表框之中列出的均为当前应用程序的第三方支持组件的相关信息。";
         this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.metroLabel4.UseCustomBackColor = true;
         // 
         // btnSysInfo
         // 
         this.btnSysInfo.FontWeight = MetroFramework.MetroButtonWeight.Light;
         this.btnSysInfo.Location = new System.Drawing.Point(22, 508);
         this.btnSysInfo.Name = "btnSysInfo";
         this.btnSysInfo.Size = new System.Drawing.Size(105, 29);
         this.btnSysInfo.TabIndex = 6;
         this.btnSysInfo.Text = "系统信息(&S)";
         this.btnSysInfo.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnSysInfo.UseSelectable = true;
         this.btnSysInfo.Click += new System.EventHandler(this.btnSysInfo_Click);
         // 
         // btnDxInfo
         // 
         this.btnDxInfo.FontWeight = MetroFramework.MetroButtonWeight.Light;
         this.btnDxInfo.Location = new System.Drawing.Point(133, 508);
         this.btnDxInfo.Name = "btnDxInfo";
         this.btnDxInfo.Size = new System.Drawing.Size(105, 29);
         this.btnDxInfo.TabIndex = 6;
         this.btnDxInfo.Text = "DirectX信息(&D)";
         this.btnDxInfo.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.btnDxInfo.UseSelectable = true;
         this.btnDxInfo.Click += new System.EventHandler(this.btnDxInfo_Click);
         // 
         // lblDescription
         // 
         this.lblDescription.AutoSize = true;
         this.lblDescription.FontSize = MetroFramework.MetroLabelSize.Small;
         this.lblDescription.Location = new System.Drawing.Point(24, 232);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(386, 17);
         this.lblDescription.TabIndex = 7;
         this.lblDescription.Text = "Cabinink Writer是一款可用于离线编辑小说等大中型文档的快捷工具！";
         this.lblDescription.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblDescription.UseCustomBackColor = true;
         // 
         // lblAssemblyFullName
         // 
         this.lblAssemblyFullName.AutoSize = true;
         this.lblAssemblyFullName.FontSize = MetroFramework.MetroLabelSize.Small;
         this.lblAssemblyFullName.ForeColor = System.Drawing.Color.White;
         this.lblAssemblyFullName.Location = new System.Drawing.Point(24, 117);
         this.lblAssemblyFullName.Name = "lblAssemblyFullName";
         this.lblAssemblyFullName.Size = new System.Drawing.Size(128, 17);
         this.lblAssemblyFullName.TabIndex = 1;
         this.lblAssemblyFullName.Text = "程序集完全限定名称：";
         this.lblAssemblyFullName.Theme = MetroFramework.MetroThemeStyle.Dark;
         this.lblAssemblyFullName.UseCustomBackColor = true;
         // 
         // frmAbout
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.ClientSize = new System.Drawing.Size(651, 556);
         this.Controls.Add(this.metroLink2);
         this.Controls.Add(this.metroLink1);
         this.Controls.Add(this.lstComInfo);
         this.Controls.Add(this.metroLabel4);
         this.Controls.Add(this.lblDescription);
         this.Controls.Add(this.metroLabel3);
         this.Controls.Add(this.metroLabel1);
         this.Controls.Add(this.btnDxInfo);
         this.Controls.Add(this.btnSysInfo);
         this.Controls.Add(this.btnClose);
         this.Controls.Add(this.lblClrVersion);
         this.Controls.Add(this.lblIdeName);
         this.Controls.Add(this.lblCopyright);
         this.Controls.Add(this.lblAssemblyVersion);
         this.Controls.Add(this.lblAssemblyFullName);
         this.Controls.Add(this.lblFileVersion);
         this.Controls.Add(this.lblAssemblyName);
         this.ForeColor = System.Drawing.Color.White;
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmAbout";
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.Text = "产品信息";
         this.Load += new System.EventHandler(this.frmAbout_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private MetroFramework.Controls.MetroLabel lblAssemblyName;
      private MetroFramework.Controls.MetroLabel lblFileVersion;
      private MetroFramework.Controls.MetroLabel lblAssemblyVersion;
      private MetroFramework.Controls.MetroLabel lblCopyright;
      private MetroFramework.Controls.MetroLabel lblIdeName;
      private MetroFramework.Controls.MetroLabel lblClrVersion;
      private MetroFramework.Controls.MetroButton btnClose;
      private MetroFramework.Controls.MetroLabel metroLabel1;
      private System.Windows.Forms.ListBox lstComInfo;
      private MetroFramework.Controls.MetroLabel metroLabel3;
      private MetroFramework.Controls.MetroLink metroLink1;
      private MetroFramework.Controls.MetroLink metroLink2;
      private MetroFramework.Controls.MetroLabel metroLabel4;
      private MetroFramework.Controls.MetroButton btnSysInfo;
      private MetroFramework.Controls.MetroButton btnDxInfo;
      private MetroFramework.Controls.MetroLabel lblDescription;
      private MetroFramework.Controls.MetroLabel lblAssemblyFullName;
   }
}