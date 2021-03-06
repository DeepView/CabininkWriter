﻿using System;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Net.NetworkInformation;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 用户凭据类
   /// </summary>
   public class UserCredential
   {
      /// <summary>
      /// 用户名称
      /// </summary>
      private string user;
      /// <summary>
      /// 对应的用户密码
      /// </summary>
      private string password;
      /// <summary>
      /// 预留的电子邮箱地址
      /// </summary>
      private MailAddress mailaddress;
      /// <summary>
      /// 密码失效的时间
      /// </summary>
      private DateTime ineffective;
      /// <summary>
      /// 构造函数，创建一个包含指定用户名和密码的用户凭据
      /// </summary>
      /// <param name="_username">指定的用户名称。</param>
      /// <param name="_passwd">指定的用户密码。</param>
      public UserCredential(string _username, string _passwd)
      {
         if (string.IsNullOrEmpty(_username)) throw new UserOrPasswordNotEmptyException("用户名不能为空！");
         if (string.IsNullOrEmpty(_passwd)) throw new UserOrPasswordNotEmptyException("密码不能为空！");
         DateTime dtt = new DateTime(DateTime.Now.Ticks);
         user = _username;
         password = _passwd;
         mailaddress = new MailAddress("someone@emailserver.com");
         ineffective = dtt.AddDays(60);
      }
      /// <summary>
      /// 构造函数，创建一个包含指定用户名、密码和预留邮箱地址的用户凭据
      /// </summary>
      /// <param name="_username">指定的用户名称。</param>
      /// <param name="_passwd">指定的用户密码。</param>
      /// <param name="_mailaddr">指定的预留邮箱地址。</param>
      public UserCredential(string _username, string _passwd, string _mailaddr)
      {
         if (string.IsNullOrEmpty(_username)) throw new UserOrPasswordNotEmptyException("用户名不能为空！");
         if (string.IsNullOrEmpty(_passwd)) throw new UserOrPasswordNotEmptyException("密码不能为空！");
         DateTime dtt = new DateTime(DateTime.Now.Ticks);
         user = _username;
         password = _passwd;
         mailaddress = new MailAddress(_mailaddr);
         ineffective = dtt.AddDays(60);
      }
      /// <summary>
      /// 构造函数，创建一个包含指定用户名、密码、预留邮箱地址和密码失效时间的用户凭据
      /// </summary>
      /// <param name="_username">指定的用户名称。</param>
      /// <param name="_passwd">指定的用户密码。</param>
      /// <param name="_mailaddr">指定的预留邮箱地址。</param>
      /// <param name="_ineffective">指定的密码失效时间。</param>
      public UserCredential(string _username, string _passwd, string _mailaddr, DateTime _ineffective)
      {
         if (string.IsNullOrEmpty(_username)) throw new UserOrPasswordNotEmptyException("用户名不能为空！");
         if (string.IsNullOrEmpty(_passwd)) throw new UserOrPasswordNotEmptyException("密码不能为空！");
         user = _username;
         password = _passwd;
         mailaddress = new MailAddress(_mailaddr);
         ineffective = _ineffective;
      }
      /// <summary>
      /// 获取或设置当前实例的用户名称（set代码对于其他程序集不可见）
      /// </summary>
      public string UserName
      {
         get { return user; }
         internal set
         {
            if (string.IsNullOrEmpty(value)) throw new UserOrPasswordNotEmptyException("用户名不能为空！");
            user = value;
         }
      }
      /// <summary>
      /// 获取或设置当前实例的密码（get代码对于其他程序集不可见）
      /// </summary>
      public string Password
      {
         internal get
         {
            if (IsIneffectived()) throw new PasswordIsIneffectivedException("密码已失效！");
            return password;
         }
         set
         {
            if (string.IsNullOrEmpty(value)) throw new UserOrPasswordNotEmptyException("密码不能为空！");
            password = value;
         }
      }
      /// <summary>
      /// 获取或设置当前实例的预留电子邮箱地址（set代码对于其他程序集不可见）
      /// </summary>
      public MailAddress EmailAddress
      {
         get { return mailaddress; }
         internal set { mailaddress = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的密码失效时间
      /// </summary>
      public DateTime IneffectiveTime
      {
         get { return ineffective; }
         set { ineffective = value; }
      }
      /// <summary>
      /// 检测当前凭据所包含的密码是否已经失效
      /// </summary>
      /// <returns>如果这个密码已经失效，则返回true，否则返回false。</returns>
      public bool IsIneffectived()
      {
         long ticks = IneffectiveTime.Ticks;
         return DateTime.Now.Ticks >= ticks ? true : false;
      }
      /// <summary>
      /// 更新当前用户凭据的密码
      /// </summary>
      /// <param name="_old">以前的密码。</param>
      /// <param name="_new">需要设置的新密码。</param>
      /// <returns>如果提供的旧密码和凭据里面密码不符合，则该操作无效，并返回false，否则返回true。</returns>
      public bool UpgradePassword(string _old, string _new)
      {
         if (_old != Password) return false;
         else
         {
            Password = _new;
            return true;
         }
      }
      /// <summary>
      /// 更新当前用户凭据的预留电子邮箱地址
      /// </summary>
      /// <param name="_passwd">防止信息被恶意篡改而设置的密码验证。</param>
      /// <param name="_new">需要设置的新的预留电子邮箱地址。</param>
      /// <returns>如果执行操作之前未通过密码验证，则该操作无效，并返回false，否则返回true。</returns>
      public bool UpgradeMailAddress(string _passwd, string _new)
      {
         if (_passwd != Password) return false;
         else
         {
            EmailAddress = new MailAddress(_new);
            return true;
         }
      }
      /// <summary>
      /// 忘记密码后向预留电子邮箱地址发送找回密码的邮件
      /// </summary>
      public void FoundPassword()
      {
         if (NetworkInterface.GetIsNetworkAvailable() == false)
         {
            throw new NetworkNotConnectedOrExpediteException("您未连接到互联网！");
         }
         string smtpsrv = "smtp.yeah.net";
         string from = "cabininkstudio@yeah.net";
         string fromusr = "cabininkstudio";
         string frompsw = "ci940321";
         string to = EmailAddress.Address;
         string port = "25";
         string subject = "Cabinink Writer 密码找回";
         string body = "用户" + UserName + "，您好：\n您在 Cabinink Writer 的密码是：\n" + Password + "\n不要再忘记了哦！";
         MailSender sender = new MailSender(smtpsrv, to, from, subject, body, fromusr, frompsw, port, true, true);
         sender.Send();
      }
      /// <summary>
      /// 给预留电子邮箱发送一条验证码邮件，这封邮件用来确认这个地址是有效或者是否是本人的邮箱
      /// </summary>
      /// <param name="_idcode">需要被发送的验证码。</param>
      /// <param name="_mins">验证码的有效分钟数。</param>
      public void SendValidatedMail(int _idcode, ref int _mins)
      {
         if (NetworkInterface.GetIsNetworkAvailable() == false)
         {
            throw new NetworkNotConnectedOrExpediteException("您未连接到互联网！");
         }
         string smtpsrv = "smtp.yeah.net";
         string from = "cabininkstudio@yeah.net";
         string fromusr = "cabininkstudio";
         string frompsw = "ci940321";
         string to = EmailAddress.Address;
         string port = "25";
         string subject = "Cabinink Writer 邮箱验证";
         string body = "用于验证邮箱真实性和用户信息安全性的验证码：" + _idcode + "，这个验证码在" + _mins + "分钟内有效！";
         MailSender sender = new MailSender(smtpsrv, to, from, subject, body, fromusr, frompsw, port, true, true);
         sender.Send();
      }
      /// <summary>
      /// 生成一个6位数的验证码
      /// </summary>
      /// <returns></returns>
      public int GenerateIdentifyingCode()
      {
         return new Random().Next(128732, 972805);
      }
   }
   /// <summary>
   /// 当用户名或者密码为空时而抛出的异常
   /// </summary>
   [Serializable]
   public class UserOrPasswordNotEmptyException : Exception
   {
      public UserOrPasswordNotEmptyException() { }
      public UserOrPasswordNotEmptyException(string message) : base(message) { }
      public UserOrPasswordNotEmptyException(string message, Exception inner) : base(message, inner) { }
      protected UserOrPasswordNotEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
   /// <summary>
   /// 当密码已经失效时而抛出的异常
   /// </summary>
   [Serializable]
   public class PasswordIsIneffectivedException : Exception
   {
      public PasswordIsIneffectivedException() { }
      public PasswordIsIneffectivedException(string message) : base(message) { }
      public PasswordIsIneffectivedException(string message, Exception inner) : base(message, inner) { }
      protected PasswordIsIneffectivedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
