using System;
using BaiduApi;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Net.NetworkInformation;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 百度云在线备份
   /// </summary>
   public class BaiduCloudBackup
   {
      /// <summary>
      /// 百度账号，这个账号不能是绑定的邮箱或者手机号码
      /// </summary>
      private string username;
      /// <summary>
      /// 百度账号对应的密码
      /// </summary>
      private string password;
      /// <summary>
      /// 百度云核心类
      /// </summary>
      private Baidu baiducloud;
      /// <summary>
      /// 构造函数，初始化一个拥有指定百度账号和密码的备份实例
      /// </summary>
      /// <param name="_username">你的百度账号，这个账号不能是绑定的邮箱或者手机号码。</param>
      /// <param name="_password">这个账号对应的密码。</param>
      public BaiduCloudBackup(string _username, string _password)
      {
         username = _username;
         password = _password;
      }
      /// <summary>
      /// 获取或设置当前实例的百度账户名称
      /// </summary>
      public string Username
      {
         get { return username; }
         set { username = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的百度账户所对应的密码
      /// </summary>
      public string Password
      {
         get { return password; }
         set { password = value; }
      }
      /// <summary>
      /// 登录百度云
      /// </summary>
      public void Login()
      {
         if (NetworkIsConnected() == false) throw new NetworkNotConnectedOrExpediteException("网络不通畅或者未连接！");
         baiducloud = new Baidu(Username, Password);
      }
      /// <summary>
      /// 指示当前是否已经登录到百度云
      /// </summary>
      /// <returns>如果已经登录，则返回true，否则返回false。</returns>
      public bool IsLogin()
      {
         return TransformTest();
      }
      /// <summary>
      /// 向百度云上传文件
      /// </summary>
      /// <param name="_target">百度云网盘中的目标地址。</param>
      /// <param name="_source">本地文件的地址。</param>
      /// <returns>执行该操作之后，会返回一个表示当前操作状态的枚举实例。</returns>
      public ETransmissiveStatus Upload(string _target, string _source)
      {
         if (NetworkIsConnected() == false) throw new NetworkNotConnectedOrExpediteException("网络不通畅或者未连接！");
         ETransmissiveStatus status = ETransmissiveStatus.Succeed;
         FileOper foper = baiducloud.UpLoadFile(_target, _source);
         switch ((int)foper)
         {
            case 4:
               status = ETransmissiveStatus.FileNotExisits;
               break;
            case 5:
               status = ETransmissiveStatus.Fail;
               break;
            case 6:
               status = ETransmissiveStatus.Succeed;
               break;
         }
         return status;
      }
      /// <summary>
      /// 从百度云下载文件
      /// </summary>
      /// <param name="_source">被下载的文件的地址。</param>
      /// <param name="_local">需要存入本地磁盘的文件地址。</param>
      /// <returns>执行该操作之后，会返回一个表示当前操作状态的枚举实例。</returns>
      public ETransmissiveStatus Download(string _source, string _local)
      {
         if (NetworkIsConnected() == false) throw new NetworkNotConnectedOrExpediteException("网络不通畅或者未连接！");
         ETransmissiveStatus status = ETransmissiveStatus.Succeed;
         FileOper foper = baiducloud.DownFile(_source, _local);
         switch ((int)foper)
         {
            case 1:
               status = ETransmissiveStatus.FileNotExisits;
               break;
            case 2:
               status = ETransmissiveStatus.Fail;
               break;
            case 3:
               status = ETransmissiveStatus.Succeed;
               break;
         }
         return status;
      }
      /// <summary>
      /// 检查当前网络是否通畅
      /// </summary>
      /// <returns>如果当前网络畅通无阻，则返回true，否则返回false。</returns>
      public static bool NetworkIsConnected()
      {
         Ping pingSender = new Ping();
         PingOptions options = new PingOptions();
         options.DontFragment = true;
         string data = "00000000000000000000000000000000";
         byte[] buffer = Encoding.ASCII.GetBytes(data);
         int timeout = 120;
         PingReply reply = pingSender.Send("www.baidu.com", timeout, buffer, options);
         if (reply.Status == IPStatus.Success) return true; else return false;
      }
      /// <summary>
      /// 测试传输链接
      /// </summary>
      /// <returns>该操作用于测试传输链接以确保当前账户是否登录，如果测试通过则返回true，否则将返回false。</returns>
      internal bool TransformTest()
      {
         bool result = true;
         string provisional = Environment.CurrentDirectory + @"\transform_test.provisional-ci";
         if (FileOperation.FileExists(provisional) == false)
         {
            FileOperation.CreateFile(provisional, FileAccess.ReadWrite, FileShare.ReadWrite);
         }
         try
         {
            Upload("/", provisional);
            Download("/transform_test.provisional-ci", provisional);
         }
         catch (Exception ex)
         {
            if (ex != null) result = false;
         }
         return result;
      }
      /// <summary>
      /// 获取当前类的字符串表达形式
      /// </summary>
      /// <returns>该操作返回当前类的字符串表达形式，这个字符串是当前类的完整名称。</returns>
      public override string ToString()
      {
         return "Cabinink.Writer.Cores.BaiduCloudBackup";
      }
   }
   /// <summary>
   /// 传送文件的状态枚举
   /// </summary>
   public enum ETransmissiveStatus : int
   {
      /// <summary>
      /// 传输成功
      /// </summary>
      Succeed = 0x0000,
      /// <summary>
      /// 传输失败
      /// </summary>
      Fail = 0x0001,
      /// <summary>
      /// 文件不存在
      /// </summary>
      FileNotExisits = 0x0002
   }
   /// <summary>
   /// 当网络不通畅或者网络未连接的时候抛出的异常
   /// </summary>
   [Serializable]
   public class NetworkNotConnectedOrExpediteException : Exception
   {
      public NetworkNotConnectedOrExpediteException() { }
      public NetworkNotConnectedOrExpediteException(string message) : base(message) { }
      public NetworkNotConnectedOrExpediteException(string message, Exception inner) : base(message, inner) { }
      protected NetworkNotConnectedOrExpediteException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
