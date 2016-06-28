using System;
using System.Diagnostics;
using System.Windows.Forms;
using Cabinink.Writer.Cores;
namespace Cabinink.Writer.Middle
{
   /// <summary>
   /// 应用程序帮助类
   /// </summary>
   public sealed class ApplicationHelp
   {
      /// <summary>
      /// 打开应用程序使用反馈
      /// </summary>
      public static void OpenFeedback()
      {
         Process.Start("https://www.wenjuan.com/s/B7rUri/");
      }
      /// <summary>
      /// 显示应用程序的产品信息窗体
      /// </summary>
      /// <param name="_prdinfofrm">指定的产品信息窗体。</param>
      public static void ShowProductionInformation(Form _prdinfofrm)
      {
         _prdinfofrm.ShowDialog();
      }
      /// <summary>
      /// 打开帮助文档
      /// </summary>
      /// <param name="_hlpdocurl">指定的帮助文档文件的地址。</param>
      public static void OpenHelpDocument(string _hlpdocurl)
      {
         if (new Uri(_hlpdocurl).IsFile)
         {
            if (FileOperation.FileExists(_hlpdocurl))
            {
               throw new NotFoundFileException("指定的帮助文档不存在！");
            }
         }
         Process.Start(_hlpdocurl);
      }
      /// <summary>
      /// 查看最终用户许可协议（EULA）
      /// </summary>
      /// <param name="_eulafrm">用于查看EULA的窗体。</param>
      public static void OpenEndUserLicenseAgreement(Form _eulafrm)
      {
         _eulafrm.ShowDialog();
      }
   }
}
