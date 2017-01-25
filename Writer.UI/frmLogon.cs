using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cabinink.Writer.Cores;

namespace Cabinink.Writer.UI
{
   public partial class frmLogon : Cabinink.Writer.UI.VsSkinFormBase
   {
      public UserCredential credential;
      public bool iscomplate = false;

      private string username = Environment.UserName;

      private frmMainInterface owner;
      private UserRegister register;
      public frmLogon()
      {
         InitializeComponent();
      }

      private void btnLogon_Click(object sender, EventArgs e)
      {
         if (txtPassword.Text != txtReptyPassword.Text)
         {
            VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("注册提示", "两次输入的密码不一致，请重新输入！", EMessageLevel.Error);
            msg.Display(this);
         }
         else
         {
            if (string.IsNullOrEmpty(txtMailAddress.Text))
            {
               VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("注册提示", "电子邮箱不能为空，这个邮箱是用来验证用户安全性，以及以后找回密码用的，还请您慎重考虑！", EMessageLevel.Error);
               msg.Display(this);
            }
            else
            {
               frmSendIdentifyingCode sendcode = new frmSendIdentifyingCode();
               DateTime maxdt = new DateTime(DateTime.MaxValue.Ticks);
               credential = new UserCredential(username, txtPassword.Text, txtMailAddress.Text, maxdt);
               sendcode.DisplayDialog(this);
               if (iscomplate)
               {
                  register = new UserRegister(credential);
                  if (register.Exists())
                  {
                     VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("注册失败", "用户名已存在，请尝试在登录窗口登录您的账户！", EMessageLevel.Error);
                     msg.Display(this);
                  }
                  else
                  {
                     bool iscomp = register.Register();
                     if (iscomp)
                     {
                        VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("注册完成", "注册完成，请牢记您的密码！", EMessageLevel.Information);
                        iscomplate = true;
                        msg.Display(this);
                        Close();
                     }
                     else
                     {
                        VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("注册失败", "用户数据库出现异常！", EMessageLevel.Error);
                        msg.Display(this);
                     }
                  }
               }
            }
         }
      }
      public DialogResult DisplayDialog(frmMainInterface _owner)
      {
         owner = _owner;
         return ShowDialog(_owner);
      }
      private void frmLogon_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (iscomplate == false)
         {
            owner.SecurityFlag = false;
         }
      }
   }
}
