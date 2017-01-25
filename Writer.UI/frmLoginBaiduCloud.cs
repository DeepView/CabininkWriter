using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cabinink.Writer.Cores;
using app = Cabinink.Program;
using System.Diagnostics;

namespace Cabinink.Writer.UI
{
   public partial class frmLoginBaiduCloud : Cabinink.Writer.UI.VsSkinFormBase
   {
      public frmLoginBaiduCloud()
      {
         InitializeComponent();
      }

      private void btnLogin_Click(object sender, EventArgs e)
      {
         app.CloudBackup = new BaiduCloudBackup(txtUserName.Text, txtPassword.Text);
         try
         {
            app.CloudBackup.Login();
         }
         catch
         {
            ShowLoginFialedDialog("无法登陆到百度云，请检查您的网络是否通畅！");
         }
         if (app.CloudBackup.IsLogin() == false) ShowLoginFialedDialog("无法登陆到百度云，请检查您的用户名称或者密码是否正确！");
         else Close();
      }
      private void ShowLoginFialedDialog(string _message)
      {
         VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("登录失败", _message, EMessageLevel.Warning);
         msg.Display(this);
      }

      private void metroLink1_Click(object sender, EventArgs e)
      {
         Process.Start("https://passport.baidu.com/v2/?reg&tt=1462996172833&gid=BBF0519-2B1C-4FC6-8CA8-5C61C0D194DA&tpl=mn&u=https%3A%2F%2Fwww.baidu.com%2F");
      }
   }
}
