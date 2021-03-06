﻿using System;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// SMTP结构描述类
   /// </summary>
   [Obsolete("Abandoned class.")]
   public class SmtpStructure
   {
      /// <summary>
      /// 服务器地址
      /// </summary>
      private string server;
      /// <summary>
      /// 认证标记
      /// </summary>
      private bool authentication;
      /// <summary>
      /// 用户名
      /// </summary>
      private string user;
      /// <summary>
      /// 邮件的发送者
      /// </summary>
      private string sender;
      /// <summary>
      /// 用户密码
      /// </summary>
      private string password;
      /// <summary>
      /// 获取或设置当前实例的服务器地址
      /// </summary>
      public string Server
      {
         get { return server; }
         set { server = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的认证标记
      /// </summary>
      public bool Authentication
      {
         get { return authentication; }
         set { authentication = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的用户名
      /// </summary>
      public string User
      {
         get { return user; }
         set { user = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的邮件发送者
      /// </summary>
      public string Sender
      {
         get { return sender; }
         set { sender = value; }
      }
      /// <summary>
      /// 获取或设置当前实例的用户密码
      /// </summary>
      public string Password
      {
         get { return password; }
         set { password = value; }
      }
   }
}
