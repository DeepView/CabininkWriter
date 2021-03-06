﻿using System;
using System.Text;
using System.Media;
using System.Threading;
using Cabinink.Writer.Cores;
using Cabinink.Writer.Middle;
namespace Cabinink.Writer.UI
{
   public partial class VsSkinExceptionForm : Cabinink.Writer.UI.VsSkinFormBase
   {
      public VsSkinExceptionForm()
      {
         InitializeComponent();
      }
      public VsSkinExceptionForm(string _stracktrackinfo)
      {
         InitializeComponent();
         rtbStackTrackInfo.Text = _stracktrackinfo;
      }
      private void VsSkinExceptionForm_Load(object sender, EventArgs e)
      {
         SoundPlayer player = new SoundPlayer(@"app_resources\exsound.wav");
         player.Play();
         Console.WriteLine("\n\n\t\tApplication Exception\n" + rtbStackTrackInfo.Text + "\n");
      }
      private void btnClose_Click(object sender, EventArgs e)
      {
         string exfile = @"exception_report\app_exception.exception-ci";
         if (FileOperation.DirectoryExists(@"exception_report") == false)
         {
            FileOperation.CreateDirectory(Environment.CurrentDirectory + @"\exception_report");
         }
         if (FileOperation.FileExists(exfile) == true)
         {
            FileOperation.DeleteFile(exfile);
         }
         string happened = "异常引发时间：" + DateTime.Now.ToString() + "\n\n";
         string osname = "操作系统名称：" + EnvironmentInformation.GetOperatingSystemName() + "\n";
         string osversion = "操作系统版本号：" + EnvironmentInformation.GetOperatingSystemVersion() + "\n";
         string osplatform = "操作系统平台：" + EnvironmentInformation.GetSystemPlatform() + "\n";
         string uiculture = "用户界面区域性描述：" + EnvironmentInformation.GetInterfaceCultureString() + "\n";
         string cpuid = "中央处理器序列：" + EnvironmentInformation.GetProcessorSerial() + "\n";
         string pctype = "计算机类型：" + EnvironmentInformation.GetComputerCategory() + "\n\n";
         string fcon = happened + osname + osversion + osplatform + uiculture + cpuid + pctype + rtbStackTrackInfo.Text;
         FileOperation.CreateFile(exfile, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
         FileOperation.WriteFile(exfile, fcon, false, false, Encoding.GetEncoding("GB2312"));
         string smtpsrv = "smtp.yeah.net";
         string from = "cabininkstudio@yeah.net";
         string fromusr = "cabininkstudio";
         string frompsw = "ci940321";
         string to = "lihuaxiang0321@msn.cn";
         string port = "25";
         string subject = "Cabinink Writer Exception";
         string body = "Cabinink Writer Exception - " + DateTime.Now.ToLongDateString();
         MailSender sendmail;
         try
         {
            sendmail = new MailSender(smtpsrv, to, from, subject, body, fromusr, frompsw, port, true, true);
            sendmail.AddAttachments(exfile);
            sendmail.Send();
         }
         catch
         {
            Thread.Sleep(500);
         }
         string tips = "异常日志邮件已成功送达至开发者，虽然我们不能直接作出回应，但是我们会重视用户发送的每一条异常日志和应用反馈，谢谢！";
         VsSkinMessageBoxOk msg = new VsSkinMessageBoxOk("发送成功", tips, EMessageLevel.Information);
         msg.Display(this);
         Close();
      }
   }
}
