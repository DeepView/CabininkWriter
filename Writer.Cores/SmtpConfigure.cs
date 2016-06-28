using System;
using System.IO;
using System.Web;
using System.Xml;
using System.Configuration;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// SMTP配置类
   /// </summary>
   [Obsolete("Abandoned class.")]
   public class SmtpConfigure
   {
      /// <summary>
      /// SmtpConfigure 静态实例
      /// </summary>
      private static SmtpConfigure _smtpConfig;
      /// <summary>
      /// 构造函数，不执行任何操作
      /// </summary>
      private SmtpConfigure() : base() { }
      /// <summary>
      /// 获取SMTP配置文件
      /// </summary>
      private string GetConfigFile
      {
         get
         {
            string configPath = ConfigurationManager.AppSettings["SmtpConfigPath"];
            if (string.IsNullOrEmpty(configPath) || configPath.Trim().Length == 0)
            {
               configPath = HttpContext.Current.Request.MapPath(@"/Config/SmtpSetting.config");/////
            }
            else
            {
               if (!Path.IsPathRooted(configPath))
                  configPath = HttpContext.Current.Request.MapPath(Path.Combine(configPath, "SmtpSetting.config"));
               else
                  configPath = Path.Combine(configPath, "SmtpSetting.config");
            }
            return configPath;
         }
      }
      /// <summary>
      /// 获取SMTP服务器信息
      /// </summary>
      public SmtpStructure SmtpInformation
      {
         get
         {
            XmlDocument doc = new XmlDocument();
            doc.Load(GetConfigFile);
            SmtpStructure smtpSetting = new SmtpStructure();
            smtpSetting.Server = doc.DocumentElement.SelectSingleNode("Server").InnerText;
            smtpSetting.Authentication = Convert.ToBoolean(doc.DocumentElement.SelectSingleNode("Authentication").InnerText);
            smtpSetting.User = doc.DocumentElement.SelectSingleNode("User").InnerText;
            smtpSetting.Password = doc.DocumentElement.SelectSingleNode("Password").InnerText;
            smtpSetting.Sender = doc.DocumentElement.SelectSingleNode("Sender").InnerText;
            return smtpSetting;
         }
      }
      /// <summary>
      /// 创建一个空的SMTP配置类实例
      /// </summary>
      /// <returns>该操作将会返回一个空SMTP配置类实例。</returns>
      public static SmtpConfigure Create()
      {
         if (_smtpConfig == null) _smtpConfig = new SmtpConfigure();
         return _smtpConfig;
      }
   }
}
